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
    public partial class FrmPedidoEmpaque : Form
    {
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos ped = new Pedidos();

        public FrmPedidoEmpaque()
        {
            InitializeComponent();
        }

        private void pbAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listPedidos.Count > 0)
                {
                    var query = "UPDATE PEDIDO SET EMPAQUETADOR_ASIGNADO = '" + Program.usActivo.Usuario + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString() + "'";
                    var res = Program.GetExecute(query, 4);
                    query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                            "where LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString() + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                            "@cvedoc, 'EMPACANDO', getdate(), '" + Program.usActivo.Usuario + "')";
                    res = Program.GetExecute(query, 5);
                    FrmEmpaque frmEmpaque = new FrmEmpaque();
                    frmEmpaque.cvedoc = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                    frmEmpaque.ShowDialog();
                    cargaPedidos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPedidos_CurrentCellChanged(object sender, EventArgs e)
        {
            var index = dgPedidos.CurrentRowIndex;
            dgPedidos.Select(index);
            dgPedidos.CurrentRowIndex = index;
        }

        private void pnlSurtido_Click(object sender, EventArgs e)
        {
            FrmPedidosArea frmPedA = new FrmPedidosArea();
            frmPedA.Show();
            this.Close();
        }

        private void FrmPedidoEmpaque_Load(object sender, EventArgs e)
        {
            CuentaPedidos();
            cargaPedidos();
        }

        public void cargaPedidos()
        {
            try
            {
                var query = "select top 1 CVE_DOC from PEDIDO where " +
                            "(ESTATUSPEDIDO = 'EMPAQUE' and isnull(EMPAQUETADOR_ASIGNADO,'') = '" + Program.usActivo.Usuario + "')";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                string surtAsig = (ped == null) ? "" : Program.usActivo.Usuario;
                query = "select LTRIM(p.CVE_DOC) CVE_DOC, c.NOMBRE CLIENTE, p.FECHA_DOC, p.UbicacionEmpaque " +
                        "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                        "where (p.ESTATUSPEDIDO = 'EMPAQUE' and isnull(p.EMPAQUETADOR_ASIGNADO,'') = '" + surtAsig + "') " +
                        "order by PRIORIDAD, CVE_DOC ";
                listPedidos = Program.GetDataTable(query, 2).ToList<Pedidos>();
                dgPedidos.DataSource = Program.ToDataTable<Pedidos>(listPedidos, "Pedidos");
                if (listPedidos.Count != 0)
                {
                    dgPedidos.Select(dgPedidos.CurrentRowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void CuentaPedidos()
        {
            try
            {
                var query = "select ESTATUSPEDIDO, ISNULL(SOLAREA,0) SOLAREA from PEDIDO where ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO', 'DEVOLUCION', 'EMPAQUE')";
                listPedidos = Program.GetDataTable(query, 3).ToList<Pedidos>();
                string[] opc = { "SURTIR", "MODIFICACION", "DETENIDO", "DEVOLUCION" };
                var are = listPedidos.Where(o => o.estatuspedido.In(opc) && o.solarea == true).ToList().Count.ToString();
                lblCantArea.Text = are;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}