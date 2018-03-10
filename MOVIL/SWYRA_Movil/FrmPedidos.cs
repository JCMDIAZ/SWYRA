using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace SWYRA_Movil
{
    public partial class FrmPedidos : Form
    {
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos ped = new Pedidos();

        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            cargaPedidos();
        }

        public void cargaPedidos()
        {
            try
            {
                var query = "select top 1 CVE_DOC from PEDIDO where " +
                            "(ESTATUSPEDIDO = 'SURTIR' and isnull(SURTIDOR_ASIGNADO,'') = '" + Program.usActivo.Usuario + "')";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                string surtAsig = (ped == null) ? "" : Program.usActivo.Usuario;
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
                        "            when p.TIPOSERVICIO = 'LOCAL URGENTE' THEN 5 " +
                        "            when p.TIPOSERVICIO = 'FORANEO' THEN 6 " +
                        "            when p.TIPOSERVICIO = 'LOCAL' THEN 5 " +
                        "        END " +
                        "    when p.ESTATUSPEDIDO = 'DETENIDO' then " +
                        "        case  " +
                        "            when p.TIPOSERVICIO = 'FORANEO URGENTE' THEN 7 " +
                        "            when p.TIPOSERVICIO = 'LOCAL URGENTE' THEN 8 " +
                        "            when p.TIPOSERVICIO = 'FORANEO' THEN 9 " +
                        "            when p.TIPOSERVICIO = 'LOCAL' THEN 10 " +
                        "        end " +
                        "end Numprioridad " +
                        "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                        "where (p.ESTATUSPEDIDO = 'SURTIR' and isnull(p.SURTIDOR_ASIGNADO,'') = '" + surtAsig + "') " +
                        "or (isnull(p.SURTIDOR_ASIGNADO,'') = '" + Program.usActivo.Usuario + "' and p.ESTATUSPEDIDO in ('MODIFICACION', 'DETENIDO', 'DEVOLUCION')) " +
                        "order by Numprioridad, PRIORIDAD, CVE_DOC ";
                listPedidos = Program.GetDataTable(query, 2).ToList<Pedidos>();
                dgPedidos.DataSource = Program.ToDataTable<Pedidos>(listPedidos, "Pedidos");
                dgPedidos.Select(dgPedidos.CurrentRowIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgPedidos_CurrentCellChanged(object sender, EventArgs e)
        {
            var index = dgPedidos.CurrentRowIndex;
            var goindex = (dgPedidos[index, 0].ToString() == "SURTIR" || dgPedidos[index, 0].ToString() == "MODIFICACION") ? 0 : index;
            dgPedidos.Select(goindex);
            dgPedidos.CurrentRowIndex = goindex;
        }

        private void pbAsignar_Click(object sender, EventArgs e)
        {
            try 
            {
                var query = "UPDATE PEDIDO SET SURTIDOR_ASIGNADO = '" + Program.usActivo.Usuario + "' " +
                            "WHERE LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex,3].ToString() + "'";
                var res = Program.GetExecute(query, 3);
                query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " + 
                        "where LTRIM(CVE_DOC) = '" + dgPedidos[dgPedidos.CurrentRowIndex,3].ToString() + "' " +
                        "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                        "@cvedoc, 'SURTIENDO', getdate(), '" + Program.usActivo.Usuario + "')";
                res = Program.GetExecute(query, 4);
                FrmMenuPedidos frmMenuPed = new FrmMenuPedidos();
                frmMenuPed.cvedoc = dgPedidos[dgPedidos.CurrentRowIndex, 3].ToString();
                frmMenuPed.ShowDialog();
                cargaPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}