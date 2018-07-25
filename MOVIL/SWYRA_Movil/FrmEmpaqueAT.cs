using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWYRA_Movil
{
    public partial class FrmEmpaqueAT : Form
    {
        public DetallePedidoMerc ped;
        private List<DetallePedidoMerc> det = new List<DetallePedidoMerc>();
        private List<DetallePedidoMerc> mostrardet = new List<DetallePedidoMerc>();
        private List<DetallePedidoMerc> mostraremp = new List<DetallePedidoMerc>();
        private CodigosBarra cod = new CodigosBarra();
        private DetallePedidoMerc paq;

        public FrmEmpaqueAT()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
        }

        private void FrmEmpaqueAT_Load(object sender, EventArgs e)
        {
            lblPedido.Text = ped.cve_doc.Trim();
            lblPaquete.Text = "(" + ped.consec_empaque.ToString() + ") - " + ped.tipopaquete;
            det = CargaDetalleMerc();
            actualizaGrids();
        }

        private void actualizaGrids()
        {
            mostrardet = det.Where(o => o.consec_padre == 0).ToList();
            dgDetallePed.DataSource = Program.ToDataTable<DetallePedidoMerc>(mostrardet, "detallePedidoMerc");
            if (mostrardet.Count > 0) { dgDetallePed.Select(dgDetallePed.CurrentRowIndex); }
            mostraremp = det.Where(o => o.consec_padre == ped.consec).ToList();
            dgDetalleEmp.DataSource = Program.ToDataTable<DetallePedidoMerc>(mostraremp, "detallePedidoMerc");
            if (mostraremp.Count > 0) { dgDetalleEmp.Select(dgDetalleEmp.CurrentRowIndex); }
        }

        private List<DetallePedidoMerc> CargaDetalleMerc()
        {
            List<DetallePedidoMerc> tmp = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, dt.CVE_ART, CODIGO_BARRA, CASE WHEN CANT = 0 THEN TOTART ELSE CANT END TOTART, " +
                            "TIPOPAQUETE, ISNULL(CONSEC_PADRE,0) CONSEC_PADRE, isnull(i.DESCR, TIPOPAQUETE) DESCR, CONSEC_EMPAQUE " +
                            "FROM DETALLEPEDIDOMERC dt LEFT JOIN INVENTARIO i ON dt.CVE_ART = i.CVE_ART " +
                            "WHERE CVE_DOC = '" + ped.cve_doc + "' AND ISNULL(CANCELADO,0) = 0 " +
                            "AND ISNULL(TIPOPAQUETE,'') NOT IN ('', 'ATADOS', 'TARIMA') ORDER BY CONSEC";
                tmp = Program.GetDataTable(query, 1).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return tmp;
        }

        private void actualizaPed()
        {
            try
            {
                var query = "UPDATE DETALLEPEDIDOMERC SET CONSEC_PADRE = " + (paq.consec_padre == 0 ? "NULL" : paq.consec_padre.ToString()) +
                            " WHERE CVE_DOC = '" + paq.cve_doc + "' AND CONSEC = " + paq.consec;
                Program.GetExecute(query, 2) ;
                query = "UPDATE DETALLEPEDIDOMERC SET TOTART = " + mostraremp.Count.ToString() +
                        " WHERE CVE_DOC = '" + ped.cve_doc + "' AND CONSEC = " + ped.consec;
                Program.GetExecute(query, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgDetalleEmp_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetalleEmp.Select(dgDetalleEmp.CurrentRowIndex);
        }

        private void pbAgrega_Click(object sender, EventArgs e)
        {
            if (mostrardet.Count != 0)
            {
                paq = det.Find(o => o.consec_empaque == int.Parse(dgDetallePed[dgDetallePed.CurrentRowIndex, 0].ToString()));
                paq.consec_padre = ped.consec;
                actualizaGrids();
                actualizaPed();
            }
        }

        private void pbQuita_Click(object sender, EventArgs e)
        {
            if (mostraremp.Count != 0)
            {
                paq = det.Find(o => o.consec_empaque == int.Parse(dgDetalleEmp[dgDetalleEmp.CurrentRowIndex, 0].ToString()));
                paq.consec_padre = 0;
                actualizaGrids();
                actualizaPed();
            }
        }
    }
}