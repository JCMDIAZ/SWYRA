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
    public partial class FrmUbicacion : Form
    {
        private List<OrdenUbicacion> listOrdenUbicacion = new List<OrdenUbicacion>();

        public FrmUbicacion()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUbicacion_Load(object sender, EventArgs e)
        {
            gcAlmacen.DataSource = CargaOrdenUbicacion();
            cbArea.Properties.DataSource = CargaAreas();
            GetGridOrdenUbicacion();
        }

        private List<OrdenUbicacion> CargaOrdenUbicacion()
        {
            try
            {
                var query = "SELECT CVE_UBI, ORDEN, AREA FROM ORDEN_RUTA";
                listOrdenUbicacion = GetDataTable("DB", query, 21).ToList<OrdenUbicacion>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listOrdenUbicacion;
        }

        private List<Areas> CargaAreas()
        {
            List<Areas> listAreas = new List<Areas>();
            try
            {
                var query = "SELECT AREAID, NOMBRE, DESCRIPCION, ALMACEN, UBICACION, AREAM2, ALTURA, ACTIVO FROM AREAS";
                listAreas = GetDataTable("DB", query, 31).ToList<Areas>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listAreas;
        }


        private void GetGridOrdenUbicacion()
        {
            if (gridView1.RowCount > 0)
            {
                var cveubi = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_ubi");
                cargaDatos(cveubi.ToString());
            }
            else
            {
                limpiar();
            }
        }


        private void cargaDatos(string cveubiId)
        {
            OrdenUbicacion ordubi = CargaOrdenUbicacion().Where(o => o.cve_ubi == cveubiId.ToString()).First();
            txtCveUbi.Text = ordubi.cve_ubi;
            txtOrden.Text = ordubi.orden.ToString();
            cbArea.EditValue = ordubi.area;
        }

        private void limpiar()
        {
            txtCveUbi.Text = "";
            txtOrden.Text = "";
            cbArea.EditValue = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetGridOrdenUbicacion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCveUbi.Text == "")
                {
                    MessageBox.Show(@"Favor de asignar la clave de ubicación.");
                }
                else if (txtOrden.Text == "")
                {
                    MessageBox.Show(@"Favor de ingresar el número de oden.");
                }
                else
                {
                    var query = "SELECT CVE_UBI, ORDEN, AREA FROM ORDEN_RUTA WHERE CVE_UBI <> '" + txtCveUbi.Text + "' and ORDEN = " + txtOrden.Text;
                    var ls = GetDataTable("DB", query, 41).ToList<OrdenUbicacion>();
                    if (ls.Count > 0)
                    {
                        MessageBox.Show(@"El número de orden ya fue asignado, favor de validar.");
                    }
                    else
                    {
                        query = "if exists(select * from ORDEN_RUTA where CVE_UBI = '" + txtCveUbi.Text + "') " +
                                "update ORDEN_RUTA set ORDEN = " + txtOrden.Text + ", AREA = " +
                                (cbArea.Text == "" ? "NULL" : "'" + cbArea.Text + "'") +
                                " WHERE CVE_UBI = '" + txtCveUbi.Text + "' else " +
                                "insert ORDEN_RUTA (CVE_UBI, ORDEN, AREA) values('" + txtCveUbi.Text + "', " +
                                txtOrden.Text + ", " + (cbArea.Text == "" ? "NULL" : "'" + cbArea.Text + "'") + ")";
                        GetExecute("DB", query, 51);
                        MessageBox.Show(@"Guardado satisfactoriamente.");
                        gcAlmacen.DataSource = CargaOrdenUbicacion();
                        GetGridOrdenUbicacion();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(@"¿Esta seguro de eliminar la Ubicación?", "SWRYA", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var query = "delete ORDEN_RUTA where CVE_UBI = '" + txtCveUbi.Text + "'";
                    GetExecute("DB", query, 61);
                    MessageBox.Show(@"Guardado satisfactoriamente.");
                    gcAlmacen.DataSource = CargaOrdenUbicacion();
                    GetGridOrdenUbicacion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
