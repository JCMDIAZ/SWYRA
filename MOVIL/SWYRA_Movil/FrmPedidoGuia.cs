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
            var linea = "1";
            try
            {
                linea = "2";
                if (listPedidos.Count > 0)
                {
                    linea = "3";
                    var query = "SELECT CVE_DOC, ETIQUETADOR_ASIGNADO FROM PEDIDO WHERE LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString().Trim() + "'";
                    linea = "4";
                    var ls = Program.GetDataTable(query, 51).ToData<Pedidos>();
                    linea = "5";
                    if (ls.etiquetador_asignado == "" || ls.etiquetador_asignado == Program.usActivo.Usuario || ls.etiquetador_asignado == null)
                    {
                        linea = "6";
                        query = "UPDATE PEDIDO SET ETIQUETADOR_ASIGNADO = '" + Program.usActivo.Usuario + "' " +
                                    "WHERE LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString() + "'";
                        linea = "7";
                        var res = Program.GetExecute(query, 4);
                        linea = "8";
                        query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                                "where LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString() + "' " +
                                "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                                "@cvedoc, 'GUIA', getdate(), '" + Program.usActivo.Usuario + "')";
                        linea = "9";
                        res = Program.GetExecute(query, 5);
                        linea = "10";
                        FrmMenuGuia frmGuia = new FrmMenuGuia();
                        linea = "11";
                        frmGuia.cvedoc = dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString();
                        linea = "12";
                        frmGuia.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El pedido " + dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString().Trim() + " lo ha tomado otro ETIQUETADOR.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    linea = "14";
                    cargaPedidos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " linea " + linea, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
            var linea = "1b";
            try
            {
                linea = "2b";
                var query = "select top 1 CVE_DOC from PEDIDO where " +
                            "(ESTATUSPEDIDO = 'GUIA' and isnull(ETIQUETADOR_ASIGNADO,'') = '" + Program.usActivo.Usuario + "')";
                linea = "3b";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                linea = "4b";
                string surtAsig = (ped == null) ? "" : Program.usActivo.Usuario;
                linea = "5b";
                query = "select LTRIM(p.CVE_DOC) CVE_DOC, c.NOMBRE CLIENTE, p.FECHA_DOC, STUFF((select ',' + UbicacionEmpaque from PEDIDO_Ubicacion u " +
                        "where u.CVE_DOC = p.CVE_DOC FOR XML PATH('')), 1, 1, '') UbicacionEmpaque, ISNULL(flt,FLETE) FLETE " +
                        "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                        "where (p.ESTATUSPEDIDO = 'GUIA' and isnull(p.ETIQUETADOR_ASIGNADO,'') = '" + surtAsig + "') " +
                        "order by FLETE, PRIORIDAD, CVE_DOC ";
                linea = "6b";
                listPedidos = Program.GetDataTable(query, 2).ToList<Pedidos>();
                linea = "7b";
                dgPedidos.DataSource = Program.ToDataTable<Pedidos>(listPedidos, "Pedidos");
                linea = "8b";
                if (listPedidos.Count != 0)
                {
                    linea = "9b";
                    dgPedidos.Select(dgPedidos.CurrentRowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " linea " + linea , "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}