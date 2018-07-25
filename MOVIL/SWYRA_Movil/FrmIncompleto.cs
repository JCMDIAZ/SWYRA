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
    public partial class FrmIncompleto : Form
    {
        public Pedidos ped = new Pedidos();
        public List<DetallePedidos> det = new List<DetallePedidos>();
        private DetallePedidos art = new DetallePedidos();
        private List<OrdenUbicacion> orbi = new List<OrdenUbicacion>();

        public FrmIncompleto()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmIncompleto_Load(object sender, EventArgs e)
        {
            CargaUbicaciones();
            var mostrardet = det;
            dgDetallePed.DataSource = Program.ToDataTable<DetallePedidos>(mostrardet, "detallePedidos");
            lblPedido.Text = ped.cve_doc.Trim();
            if (mostrardet.Count > 0)
            {
                dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
            }
        }

        private void CargaUbicaciones()
        {
            try
            {
                var query = "select * from orden_ruta order by ORDEN";
                orbi = Program.GetDataTable(query, 4).ToList<OrdenUbicacion>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbRegresar_Click(object sender, EventArgs e)
        {
            var index = dgDetallePed.CurrentRowIndex;
            if (index >= 0)
            {
                art = det.First(o => o.num_par == int.Parse(dgDetallePed[index, 6].ToString()));

                var query = "UPDATE DETALLEPEDIDOMERC SET PEND = 0, CANCELADO = CASE WHEN CODIGO_BARRA = '' THEN 1 END " +
                            "WHERE CVE_DOC = '" + art.cve_doc + "' AND CVE_ART = '" + art.cve_art + "' ";
                Program.GetExecute(query, 100);

                art.cantpendiente = 0;
                art.con = (art.sel > 0) ? (int)((art.cant - (int)(art.cantsurtido + art.cantpendiente) - 1) / art.sel) : 0;
                art.cantdiferencia = art.cant - (art.sel * art.con) - (art.cantsurtido + art.cantpendiente);
                art.surtido = (art.cant == (art.cantsurtido + art.cantpendiente));
                art.ubicacion = (art.sel == 0 && art.con == 0) ? art.ctrl_alm : ((art.con > 0) ? art.ctrl_alm : ((art.masters_ubi == "") ? art.ctrl_alm : art.masters_ubi));
                var orb = orbi.First(o => o.cve_ubi == art.ubicacion);
                art.orden = orb.orden;

                query =
                            "UPDATE DETALLEPEDIDO SET SURTIDO = " + ((art.surtido) ? "1" : "0") + ", CANTPENDIENTE = " + art.cantpendiente +
                            " WHERE CVE_DOC = '" + art.cve_doc + "' AND NUM_PAR = " + art.num_par.ToString() + " " +
                            "update PEDIDO set PORC_SURTIDO = r.porc from PEDIDO p join ( " +
                            "select CVE_DOC, (sum(CAST(ISNULL(SURTIDO,0) AS float)) / CAST(count(SURTIDO) as float)) * 100.0 porc from DETALLEPEDIDO " +
                            "where CVE_DOC = '" + art.cve_doc + "' group by CVE_DOC) as r ON p.CVE_DOC = r.CVE_DOC ";
                Program.GetExecute(query, 3);

                var mostrardet = det.Where(o => o.cantpendiente > 0).ToList();
                dgDetallePed.DataSource = Program.ToDataTable<DetallePedidos>(mostrardet, "detallePedidos");
            }
        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
        }
    }
}