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
            var mostrardet = det;
            dgDetallePed.DataSource = Program.ToDataTable<DetallePedidos>(mostrardet, "detallePedidos");
            lblPedido.Text = ped.cve_doc.Trim();
            if (mostrardet.Count > 0)
            {
                dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
            }
        }

        private void pbRegresar_Click(object sender, EventArgs e)
        {
            var index = dgDetallePed.CurrentRowIndex;
            if (index >= 0)
            {
                art = det.First(o => o.num_par == int.Parse(dgDetallePed[index, 6].ToString()));
                art.surtido = false;
                var query = "UPDATE DETALLEPEDIDO SET SURTIDO = " + ((art.surtido) ? "1" : "0") +
                            " WHERE CVE_DOC = '" + art.cve_doc + "' AND NUM_PAR = " + art.num_par.ToString() + " " +
                            "update PEDIDO set PORC_SURTIDO = r.porc from PEDIDO p join ( " +
                            "select CVE_DOC, (sum(CAST(ISNULL(SURTIDO,0) AS float)) / CAST(count(SURTIDO) as float)) * 100.0 porc from DETALLEPEDIDO " +
                            "where CVE_DOC = '" + art.cve_doc + "' group by CVE_DOC) as r ON p.CVE_DOC = r.CVE_DOC ";
                Program.GetExecute(query, 3);
                var mostrardet = det.Where(o => o.surtido == true && o.cantdiferencia > 0).ToList();
                dgDetallePed.DataSource = Program.ToDataTable<DetallePedidos>(mostrardet, "detallePedidos");
            }
        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
        }
    }
}