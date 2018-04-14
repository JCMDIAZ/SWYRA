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
            List<OrdenUbicacion> listOrdenUbicacion = new List<OrdenUbicacion>();
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
    }
}
