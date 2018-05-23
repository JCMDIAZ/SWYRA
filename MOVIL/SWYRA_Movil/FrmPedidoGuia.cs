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
    public partial class FrmPedidoGuia : Form
    {
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos ped = new Pedidos();

        public FrmPedidoGuia()
        {
            InitializeComponent();
        }

        private void dgPedidos_CurrentCellChanged(object sender, EventArgs e)
        {
            var index = dgPedidos.CurrentRowIndex;
            dgPedidos.Select(index);
            dgPedidos.CurrentRowIndex = index;
        }

        private void pbAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listPedidos.Count > 0)
                {
                    var query = "UPDATE PEDIDO SET ETIQUETADOR_ASIGNADO = '" + Program.usActivo.Usuario + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString() + "'";
                    var res = Program.GetExecute(query, 4);
                    query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                            "where LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString() + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                            "@cvedoc, 'GUIA', getdate(), '" + Program.usActivo.Usuario + "')";
                    res = Program.GetExecute(query, 5);
                    FrmMenuGuia frmGuia = new FrmMenuGuia();
                    frmGuia.cvedoc = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                    frmGuia.ShowDialog();
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

        private void FrmPedidoGuia_Load(object sender, EventArgs e)
        {
            cargaPedidos();
        }

        private void cargaPedidos()
        {
            try
            {
                var query = "select top 1 CVE_DOC from PEDIDO where " +
                            "(ESTATUSPEDIDO = 'GUIA' and isnull(ETIQUETADOR_ASIGNADO,'') = '" + Program.usActivo.Usuario + "')";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                string surtAsig = (ped == null) ? "" : Program.usActivo.Usuario;
                query = "select LTRIM(p.CVE_DOC) CVE_DOC, c.NOMBRE CLIENTE, p.FECHA_DOC, STUFF((select ',' + UbicacionEmpaque from PEDIDO_Ubicacion u " +
                        "where u.CVE_DOC = p.CVE_DOC FOR XML PATH('')), 1, 1, '') UbicacionEmpaque " +
                        "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                        "where (p.ESTATUSPEDIDO = 'GUIA' and isnull(p.ETIQUETADOR_ASIGNADO,'') = '" + surtAsig + "') " +
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
    }
}