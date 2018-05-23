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
    public partial class FrmEmpaque : Form
    {
        public string cvedoc;
        private Pedidos ped = new Pedidos();
        private List<DetallePedidoMerc> lstPaquetes = new List<DetallePedidoMerc>();

        public FrmEmpaque()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgPedidos_CurrentCellChanged(object sender, EventArgs e)
        {
            dgPedidos.Select(dgPedidos.CurrentRowIndex);
            cbTipoEmpaque.Text = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
        }

        private void FrmEmpaque_Load(object sender, EventArgs e)
        {
            try
            {
                cargaTipoEmpaque();
                var query = "select LTRIM(CVE_DOC) CVE_DOC, LTRIM(CVE_CLPV) CVE_CLPV, c.NOMBRE Cliente, LTRIM(p.CVE_VEND) CVE_VEND, " +
                            "TIPOSERVICIO, PRIORIDAD, ISNULL(SOLAREA,0) SOLAREA, ESTATUSPEDIDO, IMPORTE " +
                            "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE WHERE LTRIM(CVE_DOC) = '" + cvedoc + "'";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                lblPedido.Text = ped.cve_doc;
                lblCliente.Text = ped.cliente;

                cargaPaquetes();
                pbImprimir.Visible = validaExis(1);
                pbConcluir.Visible = validaExis(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void cargaPaquetes()
        {
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, CANCELADO, TOTART, CONSEC_EMPAQUE " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "') " +
                            "AND (ISNULL(CANCELADO, 0) = 0) AND (TIPOPAQUETE IS NOT NULL) AND (CONSEC_PADRE IS NULL) ORDER BY CONSEC DESC";
                lstPaquetes = Program.GetDataTable(query, 4).ToList<DetallePedidoMerc>();
                dgPedidos.DataSource = Program.ToDataTable(lstPaquetes, "detallePedidoMerc");
                if (lstPaquetes.Count > 0) { 
                    dgPedidos.Select(dgPedidos.CurrentRowIndex);
                    cbTipoEmpaque.Text = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void cargaTipoEmpaque()
        {
            try
            {
                var query = "SELECT Id, Catalogo, Valor, ValorTexto FROM CATALOGOS WHERE (Catalogo = 'Tipo Empaque')";
                cbTipoEmpaque.DataSource = Program.GetDataTable(query, 2).ToList<Catalogos>();
                cbTipoEmpaque.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private bool validaExis(int opc)
        {
            bool b = false;
            try
            {
                var query = "";
                if (opc == 1)
                {
                    query = "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, CANCELADO " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "') " +
                            "AND (ISNULL(CANCELADO, 0) = 0) AND (TIPOPAQUETE IS NULL) AND (CONSEC_PADRE IS NULL) ORDER BY CONSEC";
                }
                else if (opc == 2)
                {
                    query = "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, CANCELADO " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "') " +
                            "AND (ISNULL(CANCELADO, 0) = 0) AND (ISNULL(TIPOPAQUETE,'') NOT IN ('', 'ATADOS', 'TARIMA')) AND (ISNULL(ULTIMO,0) = 0) ORDER BY CONSEC";
                }
                var lsArt = Program.GetDataTable(query, 3).ToList<DetallePedidoMerc>();
                b = (lsArt.Count == 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return b;
        }

        private void pbConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'REMISION' " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                var r = Program.GetExecute(query, 10);
                query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                        "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                        "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                        "@cvedoc, 'REMISION', getdate(), '" + Program.usActivo.Usuario + "')";
                r = Program.GetExecute(query, 11);
                MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "DECLARE @consec int, @consecEmpaque int, @cvedoc varchar(50) " +
                            "SELECT @cvedoc = CVE_DOC, @consec = (ISNULL(MAX(CONSEC),-1) + 1), " +
                            "@consecEmpaque = (ISNULL(MAX(CONSEC_EMPAQUE), 0) + 1) FROM DETALLEPEDIDOMERC " +
                            "WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "') GROUP BY CVE_DOC " +
                            "IF @cvedoc IS NOT NULL " +
                            "INSERT DETALLEPEDIDOMERC (CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, TOTART, CONSEC_EMPAQUE) " +
                            "VALUES (@cvedoc, @consec, 0, '', '" + ped.cve_doc + "-' + CAST(@consecEmpaque AS VARCHAR(10)), 0, '" + cbTipoEmpaque.Text + "', 0, @consecEmpaque) ";
                Program.GetExecute(query, 5);
                ActualizaPedido();
                cargaPaquetes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbElimina_Click(object sender, EventArgs e)
        {
            if (lstPaquetes.Count > 0)
            {
                try
                {
                    if (int.Parse(dgPedidos[dgPedidos.CurrentRowIndex, 2].ToString()) != 0)
                    {
                        MessageBox.Show(@"Debe desempacar los arítculos primero.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        var query = "UPDATE DETALLEPEDIDOMERC SET CANCELADO = 1 " +
                                    "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "' AND CONSEC_EMPAQUE = " + dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString();
                        Program.GetExecute(query, 6);
                        ActualizaPedido();
                        cargaPaquetes();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void ActualizaPedido()
        {
            try
            {
                var query = "DECLARE @totCajaCarton int, @totCajaMadera int, @totbultos int, @totRollos int, @totCubetas int, " + 
                            "@totAtados int, @totTarimas int, @totArt int, @totEmp int " +
                            "SELECT	@totCajaCarton = sum(case when TIPOPAQUETE = 'CAJA CARTON' AND ISNULL(CONSEC_PADRE,'') = '' then 1 else 0 end), " +
                            "@totCajaMadera = sum(case when TIPOPAQUETE = 'CAJA MADERA' AND ISNULL(CONSEC_PADRE,'') = '' then 1 else 0 end), " +
                            "@totbultos = sum(case when TIPOPAQUETE = 'BULTO' AND ISNULL(CONSEC_PADRE,'') = '' then 1 else 0 end), " +
                            "@totRollos = sum(case when TIPOPAQUETE = 'ROLLO' AND ISNULL(CONSEC_PADRE,'') = '' then 1 else 0 end), " +
                            "@totCubetas = sum(case when TIPOPAQUETE = 'CUBETA' AND ISNULL(CONSEC_PADRE,'') = '' then 1 else 0 end), " +
                            "@totAtados = sum(case when TIPOPAQUETE = 'ATADOS' then 1 else 0 end), " +
                            "@totTarimas = sum(case when TIPOPAQUETE = 'TARIMA' then 1 else 0 end), " +
                            "@totArt = sum(case when isnull(TIPOPAQUETE, '') = '' then 1 else 0 end), " +
                            "@totEmp = sum(case when isnull(TIPOPAQUETE, '') = '' and isnull(CONSEC_PADRE,'') <> '' then 1 else 0 end) " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "') AND (ISNULL(CANCELADO, 0) = 0) " +
                            "UPDATE PEDIDO SET totCajaCarton =  @totCajaCarton, totCajaMadera =  @totCajaMadera, " +
                            "totbultos = @totbultos, totRollos = @totRollos, totCubetas = @totCubetas, totAtados = @totAtados, " +
                            "totTarimas = @totTarimas, PORC_EMPAQUE = (@totEmp / @totArt) * 100.00 " +
                            "WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "')";
                Program.GetExecute(query, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbEmpacar_Click(object sender, EventArgs e)
        {
            if (lstPaquetes.Count > 0)
            {
                var emp = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                if (emp != "ATADOS" && emp != "TARIMA")
                {
                    FrmEmpaqueAdd frmEmpacar = new FrmEmpaqueAdd();
                    frmEmpacar.ped = lstPaquetes.Find(o => o.consec_empaque == int.Parse(dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString()));
                    frmEmpacar.ShowDialog();
                }
                else
                {
                    FrmEmpaqueAT frmEmpacar = new FrmEmpaqueAT();
                    frmEmpacar.ped = lstPaquetes.Find(o => o.consec_empaque == int.Parse(dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString()));
                    frmEmpacar.ShowDialog();
                }
                ActualizaPedido();
                cargaPaquetes();
                pbImprimir.Visible = validaExis(1);
                pbConcluir.Visible = validaExis(2);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (lstPaquetes.Count > 0)
            {
                var emp = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                if (emp != "ATADOS" && emp != "TARIMA")
                {
                    FrmEmpaqueAdd frmEmpacar = new FrmEmpaqueAdd();
                    frmEmpacar.proceso = "DES";
                    frmEmpacar.ped = lstPaquetes.Find(o => o.consec_empaque == int.Parse(dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString()));
                    frmEmpacar.ShowDialog();
                }
                else
                {
                    FrmEmpaqueAT frmEmpacar = new FrmEmpaqueAT();
                    frmEmpacar.ped = lstPaquetes.Find(o => o.consec_empaque == int.Parse(dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString()));
                    frmEmpacar.ShowDialog();
                }
                ActualizaPedido();
                cargaPaquetes();
                pbImprimir.Visible = validaExis(1);
                pbConcluir.Visible = validaExis(2);
            }
        }

        private void pbImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "UPDATE DETALLEPEDIDOMERC SET ULTIMO = 1 WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "') " +
                      "AND (ISNULL(CANCELADO, 0) = 0) AND (ISNULL(TIPOPAQUETE,'') NOT IN ('', 'ATADOS', 'TARIMA')) AND (ISNULL(ULTIMO,0) = 0) ";
                Program.GetExecute(query, 8);
                MessageBox.Show("Impresion Exitosa", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                pbConcluir.Visible = validaExis(2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}