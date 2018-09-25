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
    public partial class FrmPedidosArea : Form
    {
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos ped = new Pedidos();

        public FrmPedidosArea()
        {
            InitializeComponent();
        }

        private void dgPedidos_CurrentCellChanged(object sender, EventArgs e)
        {
            var index = dgPedidos.CurrentRowIndex;
            var goindex = (dgPedidos[index, 0].ToString() == "SURTIR" || dgPedidos[index, 0].ToString() == "MODIFICACION") ? 0 : index;
            dgPedidos.Select(goindex);
            dgPedidos.CurrentRowIndex = goindex;
        }

        private bool validaDuplicidad()
        {
            bool m = false;
            var query = "";
            try
            {
                var cvedoc = dgPedidos[dgPedidos.CurrentRowIndex, 2].ToString().Trim();
                query = "select CVE_DOC, CVE_ART from DETALLEPEDIDO WHERE LTRIM(CVE_DOC) = '" + cvedoc + "' " +
                            "GROUP BY CVE_DOC, CVE_ART HAVING COUNT(CVE_ART) > 1";
                List<DetallePedidos> res = Program.GetDataTable(query, 52).ToList<DetallePedidos>();
                if (res.Count > 0)
                {
                    var dt = res.First();
                    MessageBox.Show(@"Existe duplicidad en el Pedido " + cvedoc + @" clave del artículo " + dt.cve_art, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    m = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return m;
        }

        private void pbAsignar_Click(object sender, EventArgs e)
        {
            if (validaDuplicidad()) { return; }
            try
            {
                if (listPedidos.Count > 0)
                {
                    var query = "SELECT CVE_DOC, SURTIDOR_AREA FROM PEDIDO WHERE LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 2].ToString().Trim() + "'";
                    var ls = Program.GetDataTable(query, 51).ToData<Pedidos>();
                    if (ls.surtidor_area == "" || ls.surtidor_area == Program.usActivo.Usuario || ls.surtidor_area == null)
                    {
                        query = "UPDATE PEDIDO SET SURTIDOR_AREA = '" + Program.usActivo.Usuario + "' " +
                                    "WHERE LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 2].ToString() + "'";
                        var res = Program.GetExecute(query, 3);
                        query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                                "where LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex, 2].ToString() + "' " +
                                "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                                "@cvedoc, 'SURTIENDO BROCAS', getdate(), '" + Program.usActivo.Usuario + "')";
                        res = Program.GetExecute(query, 4);
                        FrmMenuPedidosArea frmMenuPed = new FrmMenuPedidosArea();
                        frmMenuPed.cvedoc = dgPedidos[dgPedidos.CurrentRowIndex, 2].ToString();
                        frmMenuPed.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("El pedido " + dgPedidos[dgPedidos.CurrentRowIndex, 2].ToString().Trim() + " lo ha tomado otro SURTIDOR DE BROCAS.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
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

        public void cargaPedidos()
        {
            try
            {
                var query = "select top 1 CVE_DOC, ESTATUSPEDIDO from PEDIDO where " +
                            "isnull(SURTIDOR_AREA,'') = '" + Program.usActivo.Usuario + "' AND isnull(SOLAREA,0) = 1 " +
                            "and ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO', 'DEVOLUCION') ";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                string surtAsig = (ped == null) ? "" : ((ped.estatuspedido == "DETENIDO" ) ? "" : Program.usActivo.Usuario);
                query = "select LTRIM(p.CVE_DOC) CVE_DOC, c.NOMBRE CLIENTE, p.FECHA_DOC, p.ESTATUSPEDIDO, p.TIPOSERVICIO, p.PRIORIDAD, " +
                        "case " +
                        "    when p.ESTATUSPEDIDO = 'MODIFICACION' then " +
                        "        case " +
                        "            when p.TIPOSERVICIO = 'FORANEO URGENTE' THEN 1 " +
                        "            when p.TIPOSERVICIO = 'LOCAL URGENTE' THEN 2 " +
                        "            when p.TIPOSERVICIO = 'FORANEO' THEN 3 " +
                        "            when p.TIPOSERVICIO = 'LOCAL' THEN 4 " +
                        "        END " +
                        "    when p.ESTATUSPEDIDO = 'SURTIR' then " +
                        "        case " +
                        "            when p.TIPOSERVICIO = 'FORANEO URGENTE' THEN 5 " +
                        "            when p.TIPOSERVICIO = 'LOCAL URGENTE' THEN 6 " +
                        "            when p.TIPOSERVICIO = 'FORANEO' THEN 7 " +
                        "            when p.TIPOSERVICIO = 'LOCAL' THEN 8 " +
                        "        END " +
                        "    when p.ESTATUSPEDIDO = 'DETENIDO' then " +
                        "        case  " +
                        "            when p.TIPOSERVICIO = 'FORANEO URGENTE' THEN 9 " +
                        "            when p.TIPOSERVICIO = 'LOCAL URGENTE' THEN 10 " +
                        "            when p.TIPOSERVICIO = 'FORANEO' THEN 11 " +
                        "            when p.TIPOSERVICIO = 'LOCAL' THEN 12 " +
                        "        end " +
                        "end Numprioridad, UbicacionEmpaque, p.CVE_CLPV " +
                        "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                        "where ((isnull(p.SURTIDOR_AREA,'') = '" + Program.usActivo.Usuario + "' and p.ESTATUSPEDIDO in ('SURTIR','MODIFICACION', 'DETENIDO', 'DEVOLUCION')) " +
                        "or (isnull(p.SURTIDOR_AREA,'') = '" + surtAsig + "' and p.ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO'))) " +
                        "and isnull(p.SOLAREA,0) = 1 " +
                        "order by Numprioridad, PRIORIDAD, CVE_DOC ";
                listPedidos = Program.GetDataTable(query, 2).ToList<Pedidos>();
                dgPedidos.DataSource = Program.ToDataTable<Pedidos>(listPedidos, "Pedidos");
                dgPedidos.Refresh();
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

        private void FrmPedidosArea_Load(object sender, EventArgs e)
        {
            cargaPedidos();
        }
    }
}