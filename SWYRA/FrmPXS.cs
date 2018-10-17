using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using static SWYRA.General;

namespace SWYRA
{
    public partial class FrmPXS : Form
    {
        public FrmPXS()
        {
            InitializeComponent();
        }

        private void FrmPXS_Load(object sender, EventArgs e)
        {
            txtFechFin.DateTime = DateTime.Now;
            txtFechIni.DateTime = DateTime.Now;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<PXS> pxs = CargaPXS();
            Backorder backorder = new Backorder();
            backorder.DataSource = pxs;
            backorder.Parameters[0].Value = txtFechIni.DateTime;
            backorder.Parameters[1].Value = txtFechFin.DateTime;
            backorder.ShowPreview();
        }

        private List<PXS> CargaPXS()
        {
            List<PXS> dets = new List<PXS>();
            try
            {
                var query =
                    "select p.CVE_DOC, p.CVE_CLPV cve_clpv, c.NOMBRE CLIENTE, p.CVE_VEND, p.NOMBRE_VENDEDOR, " +
                    "p.CVE_PEDI, p.FECHA_DOC, d.CVE_ART, i.DESCR, d.CANT, isnull(d.CANTSURTIDO, 0) CANTSURTIDO, d.CANTPENDIENTE cantpend " +
                    "from PEDIDO p left join DETALLEPEDIDO d on p.CVE_DOC = d.CVE_DOC " +
                    "left join CLIENTE c on c.CLAVE = p.CVE_CLPV left join INVENTARIO i on i.CVE_ART = d.CVE_ART " +
                    "where p.FECHA_DOC between '" + txtFechIni.DateTime.ToString("yyyyMMdd") + "' AND '" + txtFechFin.DateTime.ToString("yyyyMMdd") + "' " +
                    "and d.CANTPENDIENTE > 0 and p.ESTATUSPEDIDO IN ('TERMINADO', 'GUIA', 'REMISION')";
                    dets = GetDataTable("DB", query, 3).ToList<PXS>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dets;
        }
    }
}
