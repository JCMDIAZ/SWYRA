using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SWYRA.General;

namespace SWYRA
{
    public partial class FrmCondiciones : Form
    {
        List<InventarioCondicion> listInventarioCondicion = new List<InventarioCondicion>();
        private bool sw = true;

        public FrmCondiciones()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            cbProducto.EditValue = null;
            cbProducto.Properties.ReadOnly = false;
            meCondicion.Text = "";
            chkEstablece.Checked = false;
            txtExistencia.EditValue = 0;
            chkActivo.Checked = true;
        }

        private void gcPresentaciones_Load(object sender, EventArgs e)
        {
            cbProducto.Properties.DataSource = CargaInventario();
            listInventarioCondicion = CargaInventarioCondicion();
            gcCondiciones.DataSource = listInventarioCondicion;
            GetGridCondicion();
        }

        private void GetGridCondicion()
        {
            if (gridView1.RowCount > 0)
            {
                var cveArt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_art");
                CargaDatos(cveArt.ToString());
            }
            else
            {
                Limpiar();
            }
        }

        private void CargaDatos(string cveArt)
        {
            var cnd = listInventarioCondicion.First(o => o.cve_art == cveArt);

            cbProducto.EditValue = cnd.cve_art;
            cbProducto.Properties.ReadOnly = true;
            chkActivo.Checked = cnd.activo;
            meCondicion.Text = cnd.comentario;
            chkEstablece.Checked = cnd.aplicaexist;
            txtExistencia.EditValue = cnd.existencia;
            chkActivo.Checked = cnd.activo;
            chkAplicaLote.Checked = cnd.aplicalote;
        }

        private List<Inventario> CargaInventario()
        {
            List<Inventario> listInventarios = new List<Inventario>();
            try
            {
                var query = "SELECT CVE_ART, DESCR, LIN_PROD, EXIST, STATUS FROM INVENTARIO " +
                            "WHERE STATUS = 'A' AND CVE_ART > '9808' ORDER BY CVE_ART";
                listInventarios = GetDataTable("DB", query, 1).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listInventarios;
        }

        private List<InventarioCondicion> CargaInventarioCondicion()
        {
            try
            {
                var query = "SELECT CVE_ART, DESCR, COMENTARIO, APLICAEXIST, EXISTENCIA, ACTIVO, APLICALOTE " +
                            "FROM INVENTARIOCOND WHERE CVE_ART IN(SELECT CVE_ART FROM INVENTARIO " +
                            "WHERE STATUS = 'A') ORDER BY CVE_ART";
                listInventarioCondicion = GetDataTable("DB", query, 2).ToList<InventarioCondicion>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listInventarioCondicion;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            sw = false;
            GetGridCondicion();
            sw = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                try
                {
                    var query =
                            @"IF NOT EXISTS (SELECT * FROM INVENTARIOCOND " +
                            " WHERE CVE_ART = '" + cbProducto.EditValue.ToString() + "') BEGIN " +
                            "INSERT INVENTARIOCOND (CVE_ART, DESCR, COMENTARIO, APLICAEXIST, EXISTENCIA, ACTIVO, APLICALOTE) " +
                            "VALUES ('" + cbProducto.EditValue.ToString() + "', '" + cbProducto.Text.Replace(",", "") + "', '" +
                            meCondicion.Text + "', " + ((chkEstablece.Checked) ? "1" : "0") + ", " + txtExistencia.EditValue + ", " +
                            ((chkActivo.Checked) ? "1" : "0") + ", " + ((chkAplicaLote.Checked) ? "1" : "0") + ") END ELSE BEGIN " +
                            @"UPDATE INVENTARIOCOND SET " +
                            "COMENTARIO = '" + meCondicion.Text + "', APLICAEXIST = " + ((chkEstablece.Checked) ? "1" : "0") + ", " +
                            "EXISTENCIA = " + txtExistencia.EditValue + ", Activo = " + ((chkActivo.Checked) ? "1" : "0") + ", " +
                            "APLICALOTE = " + ((chkActivo.Checked) ? "1" : "0") +
                            " WHERE CVE_ART = '" + cbProducto.EditValue.ToString() + "' END";
                    var res = GetExecute("DB", query, 3);
                    MessageBox.Show(@"Guardado satisfactoriamente.");
                    listInventarioCondicion = CargaInventarioCondicion();
                    gcCondiciones.DataSource = listInventarioCondicion;
                    GetGridCondicion();
                }
                catch (Exception ms)
                {
                    MessageBox.Show(ms.Message);
                }
            }
        }

        private bool ValidaDatos(){
            bool b = true;
            if (cbProducto.Text == "")
            {
                MessageBox.Show(@"Favor de asignar el producto.");
                cbProducto.Focus();
                b = false;
            } else if (meCondicion.Text == "")
            {
                MessageBox.Show(@"Favor de ingresar la condición.");
                meCondicion.Focus();
                b = false;
            }
            return b;
        }
    }
}
