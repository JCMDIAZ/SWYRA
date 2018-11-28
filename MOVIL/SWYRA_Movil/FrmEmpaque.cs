using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace SWYRA_Movil
{
    public partial class FrmEmpaque : Form
    {
        public string cvedoc;
        private Pedidos ped = new Pedidos();
        private List<DetallePedidoMerc> lstPaquetes = new List<DetallePedidoMerc>();
        private List<DetallePedidoMerc> lstMercancia = new List<DetallePedidoMerc>();
        private List<DetallePedidos> det = new List<DetallePedidos>();
        private List<DetallePedidos> dev = new List<DetallePedidos>();
        private List<DetallePedidos> detA = new List<DetallePedidos>();
        private List<DetallePedidos> devA = new List<DetallePedidos>();

        private int Rini = 530;
        private int Rlim = 981;
        private int Rsal = 30;
        private string Encabezado =
                "^FO10,20^GFA,870,870,15,,::I02,0066,00FF,00FF8,:00FFC,00FDC,01F9CI03FFC01FF80C7E03FF," +
                "03FFEI03IF07FFC1IF0IFC,03IFI03F3F8FCFE3IF0IFE,03FFB8003F0F8F83E3EI0F83E,03FFB8003F0F8F83E3EI0F03E," +
                "03IF8003F0F8F83E3EI0F83E,07FFD8003F0F8F83E3EI0F03E,07FCF8003F0F8F83E3E7F8F83E,07FF8I03F0F8F83E3E7F8F03E," +
                "0IF8I03F0F8F83E3E4F8F83E,0IF8I03F0F8F83E3E0F8F83E,0IFCI03F0F8F83E3E0F8F83E,1IFEI03F0F8F83E3E0F8F83E," +
                "1JFC003F0F8F83E3E1F8F87E,1KF003IF8IFE3IF8IFC,1KF003IF07FFC1FF787FFC,3KF8,1KFC,::0KFE03FFE0F8060F8003FF8," +
                "0KFE07IF1F8060FC007FFC,0KFE077E30F8060F800FDEC,0KFE003E00F8060F800F8,0F1IFE003E00F8060F800F8," +
                "0701FCF003E00F8060F800FC,0700FC7003E00F8060F800IFC,07007C3003E00F8060F800IFC,0700741003E00F8060F800IFC," +
                "0700741803E00F8060F800IFC,0701F01803E00F8060F8007FFC,0703F00C03E00F8060FCJ07C,0703F00C03E00F8060F8J07C," +
                "0701700603E00F80E0F8J07C,0700700703E00IFC0IF8IFD,0700700303E007FFC0IF07FF84,0F007W04,0F007,1F00F,0C00F8,J09,0804," +
                "08C6036CDBJ63923030361E188,19EOFCE7FE7IFEJFBC,1BEDFC9FEIFDE7FEJFEJF3C,1DC8649D08CA4E73466F679959B8,Y08,,^FS" +
                "^FO130,40^A0,45,37^FDHerramientas Importadas Monterrey SA CV^FS";

        public FrmEmpaque()
        {
            InitializeComponent();
        }

        private int valExistencias()
        {
            var n = 0;
            var v1 = validaExis(false);
            if (!v1)
            {
                n = 2;
                ped.solarea = false;
                var query = "UPDATE PEDIDO SET SOLAREA = 0, ESTATUSPEDIDO = 'MODIFICACION' " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                var r = Program.GetExecute(query, 9);
                MessageBox.Show(@"Existe Artículos por Agregar o Devolver se regresará al SURTIDOR : " + ped.surtidor_asignado_n + ".", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            var v2 = validaExis(true);
            if (!v2 && n != 2)
            {
                n = 1;
                var query = "UPDATE PEDIDO SET SOLAREA = 1, ESTATUSPEDIDO = 'MODIFICACION' " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "'";
                var r = Program.GetExecute(query, 9);
                MessageBox.Show(@"Existe Artículos por Agregar o Devolver se regresará al SURTIDOR DE BROCAS: " + ped.surtidor_area_n + ".", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return n;
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            valExistencias();
            this.Close();
        }

        private void dgPedidos_CurrentCellChanged(object sender, EventArgs e)
        {
            dgPedidos.Select(dgPedidos.CurrentRowIndex);
            cbTipoEmpaque.Text = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
        }

        private bool validaExis(bool Area)
        {
            bool res = false;
            try
            {
                if (Area)
                {
                    detA = Program.GetDataTable(createQR(Area, false), 2).ToList<DetallePedidos>();
                    devA = Program.GetDataTable(createQR(Area, true), 3).ToList<DetallePedidos>();
                    var cdetA = detA.Where(o => o.surtido == false).ToList().Count;
                    var cdevA = devA.Where(o => o.devuelto == false).ToList().Count;
                    res = (cdetA == 0 && cdevA == 0);
                }
                else
                {
                    det = Program.GetDataTable(createQR(Area, false), 4).ToList<DetallePedidos>();
                    dev = Program.GetDataTable(createQR(Area, true), 5).ToList<DetallePedidos>();
                    var cdet = det.Where(o => o.surtido == false).ToList().Count;
                    var cdev = dev.Where(o => o.devuelto == false).ToList().Count;
                    res = (cdet == 0 && cdev == 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return res;

        }

        private string createQR(bool Area, bool Devuelto)
        {
            var query = "select a.*, isnull(o.ORDEN,0) ORDEN FROM( select *, " +
                    "case when sel > 0 then cast(((CANT - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE) - 1) / sel) as int) else 0 end con, " +
                    "case when (case when sel > 0 then cast(((CANT - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE) - 1) / sel) as int) else 1 end) > 0 then CTRL_ALM " +
                    "else case when MASTERS_UBI = '' then CTRL_ALM else MASTERS_UBI end end ubicacion, " +
                    "(CANT - (sel * (case when sel > 0 then cast(((CANT - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE) - 1) / sel) as int) " +
                    "else 0 end)) - (ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) + CANTPENDIENTE)) CANTDIFERENCIA " +
                    "from ( SELECT  CVE_DOC, NUM_PAR, dp.CVE_ART, CANT, ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) " + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ", " +
                    "ISNULL(" + (Devuelto ? "DEVUELTO" : "SURTIDO") + ",0) " + (Devuelto ? "DEVUELTO" : "SURTIDO") + ", i.DESCR, i.EXIST, i.LIN_PROD, " +
                    "ISNULL(ic.COMENTARIO,'') COMENTARIO, ISNULL(ic.APLICAEXIST,0) APLICAEXIST, " +
                    "ISNULL(ic.EXISTENCIA,0) MINEXIST, ISNULL(IC.APLICALOTE,0) APLICALOTE, " +
                    "i.CTRL_ALM, i.MASTERS_UBI, i.UNI_EMP MIN, i.MASTERS MAS, " +
                    "cast(cast(case when i.MASTERS > 0 then (CANT / i.MASTERS) else 0 end as int) * i.MASTERS as int) sel, " +
                    (Devuelto ? "0" : "ISNULL(CANTPENDIENTE,0)") + " CANTPENDIENTE, cast(0 as bit) SW " +
                    "FROM " + (Devuelto ? "DETALLEPEDIDODEV" : "DETALLEPEDIDO") + " dp JOIN INVENTARIO i ON dp.CVE_ART = i.CVE_ART " +
                    "LEFT JOIN INVENTARIOCOND ic ON ic.CVE_ART = dp.CVE_ART AND ic.ACTIVO = 1 " +
                    "WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "') AND dp.NUM_PAR < 1000 ) as c) as a LEFT JOIN ORDEN_RUTA o ON RTRIM(LTRIM(a.ubicacion)) = o.CVE_UBI " +
                    "JOIN AREAS r ON ISNULL(o.AREA,'') " + (Area ? "" : "NOT") + " like '%' + r.NOMBRE + '%' ORDER BY o.ORDEN";
            return query;
        }

        private void FrmEmpaque_Load(object sender, EventArgs e)
        {
            try
            {
                cargaTipoEmpaque();
                var query = "select LTRIM(CVE_DOC) CVE_DOC, LTRIM(CVE_CLPV) CVE_CLPV, c.NOMBRE Cliente, LTRIM(p.CVE_VEND) CVE_VEND, EMPAQUETADOR_ASIGNADO, " +
                            "TIPOSERVICIO, PRIORIDAD, ISNULL(SOLAREA,0) SOLAREA, ESTATUSPEDIDO, IMPORTE, CONTADO, p.STATUS, INDICACIONES, " +
                            "CVE_PEDI, OCURREDOMICILIO, FECHA_ENT, STUFF((select ',' + UbicacionEmpaque from PEDIDO_Ubicacion u " +
                            "where u.CVE_DOC = p.CVE_DOC FOR XML PATH('')), 1, 1, '') UbicacionEmpaque, OBSERVACIONES, CONSIGNACION, " + 
                            "(CALLE + ' # ' + NUMEXT + ' COL. ' + COLONIA) direccion1, ('C.P. ' + CODIGO + '; ' + MUNICIPIO + ', ' + ESTADO) direccion2, " +
                            "FLETE, FLETE2, ENVIAR, FECHA_DOC, u.Nombre SURTIDOR_AREA_N, u2.Nombre SURTIDOR_ASIGNADO_N, u3.Nombre capturo_n " +
                            "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                            "left join USUARIOS u on u.Usuario = p.SURTIDOR_AREA " +
                            "left join USUARIOS u2 on u2.Usuario = p.SURTIDOR_ASIGNADO " +
                            "left join USUARIOS u3 on u3.Usuario = p.CAPTURO " +
                            "WHERE LTRIM(CVE_DOC) = '" + cvedoc + "'";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                if (ped.empaquetador_asignado == Program.usActivo.Usuario)
                {
                    lblPedido.Text = ped.cve_doc;
                    lblCliente.Text = ped.cliente;
                    lblfletes.Text = ped.flete + "; " + ped.flete2;

                    cargaPaquetes("CONSEC");
                    pbImprimir.Visible = validaExisMerc(1);
                    pbConcluir.Visible = validaExisMerc(1);
                    cargaDetalleMerc();
                    info();
                    if (valExistencias() > 0) { Close(); }
                }
                else
                {
                    MessageBox.Show("El pedido " + cvedoc + " ha sido asignado otro EMPAQUETADOR.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void cargaPaquetes(string order)
        {
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, cast(ULTIMO as varchar(5)) ULTIMO,  CANCELADO, TOTART, CONSEC_EMPAQUE " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') AND (CODIGO_BARRA <> '') " +
                            "AND (ISNULL(CANCELADO, 0) = 0) AND (TIPOPAQUETE IS NOT NULL) AND (CONSEC_PADRE IS NULL) ORDER BY " + order + " DESC";
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

        private void cargaDetalleMerc()
        {
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, d.CVE_ART, i.DESCR, CANT, cast(case when CONSEC_PADRE is null then 'NO' else 'SI' END as varchar(5)) ULTIMO " +
                            "FROM DETALLEPEDIDOMERC d JOIN INVENTARIO i ON i.CVE_ART = d.CVE_ART WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') " +
                            " AND (CODIGO_BARRA <> '') AND (ISNULL(CANCELADO, 0) = 0) AND (TIPOPAQUETE IS NULL) ORDER BY CONSEC DESC";
                lstMercancia = Program.GetDataTable(query, 4).ToList<DetallePedidoMerc>();
                var pend = lstMercancia.Where(o => o.ultimo == "NO").ToList().Sum(o => o.cant);
                lblPendientes.Text = "Pend " + pend;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private List<DetallePedidoMerc> cargaDetPaquetes(string cvedoc, int consec, bool ult, string tipopaq)
        {
            List<DetallePedidoMerc> ls = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CVE_DOC, MAX(CONSEC) CONSEC, NUM_PAR, CVE_ART, MIN(CODIGO_BARRA) CODIGO_BARRA, sum(CANT) CANT, TIPOPAQUETE, CONSEC_PADRE, NULL ULTIMO, isnull(CANCELADO,0) CANCELADO, TOTART, CONSEC_EMPAQUE " +
                    "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + cvedoc.Trim() + "') AND (CODIGO_BARRA <> '') AND (CONSEC_PADRE = " + consec + ") " + ((ult && tipopaq != "TARIMA") ? "AND CANT > 0" : "") +
                    "GROUP BY CVE_DOC, NUM_PAR, CVE_ART, TIPOPAQUETE, CONSEC_PADRE, isnull(CANCELADO,0), TOTART, CONSEC_EMPAQUE ORDER BY CONSEC";
                ls = Program.GetDataTable(query, 4).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return ls;
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

        private bool validaExisMerc(int opc)
        {
            bool b = false;
            try
            {
                var query = "";
                if (opc == 1)
                {
                    query = "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, CANCELADO " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') " +
                            "AND (CODIGO_BARRA <> '') AND (ISNULL(CANCELADO, 0) = 0) AND (TIPOPAQUETE IS NULL) AND (CONSEC_PADRE IS NULL) ORDER BY CONSEC";
                }
                else if (opc == 2)
                {
                    query = "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, CANCELADO " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') " +
                            "AND (CODIGO_BARRA <> '') AND (ISNULL(CANCELADO, 0) = 0) AND (ISNULL(TIPOPAQUETE,'') NOT IN ('', 'ATADOS', 'TARIMA')) AND (ISNULL(ULTIMO,0) = 0) ORDER BY CONSEC";
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
            if (valExistencias() > 0) { Close(); return; }
            try
            {
                var query2 = "UPDATE DETALLEPEDIDOMERC SET CANCELADO = 1 WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() +
                             "' AND ISNULL(TIPOPAQUETE,'') <> '' AND ISNULL(TotArt,0) = 0 AND ISNULL(CANCELADO,0) = 0";
                Program.GetExecute(query2, 51);

                ActualizaPedido();

                var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'REMISION' " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                var r = Program.GetExecute(query, 10);
                query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                        "where LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "' " +
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
            if (valExistencias() > 0) { Close(); return; }
            try
            {
                if (cbTipoEmpaque.Text != "")
                {
                    var query = "DECLARE @consec int, @consecEmpaque int, @cvedoc varchar(50) " +
                                "SELECT @cvedoc = CVE_DOC, @consec = (ISNULL(MAX(CONSEC),-1) + 1) FROM DETALLEPEDIDOMERC " +
                                "WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') GROUP BY CVE_DOC " +
                                "SELECT @consecEmpaque = (ISNULL(MAX(CONSEC_EMPAQUE), 0) + 1) FROM DETALLEPEDIDOMERC " +
                                "WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') " +
                                ((cbTipoEmpaque.Text == "ATADOS" || cbTipoEmpaque.Text == "TARIMA") ? " AND TIPOPAQUETE = '" + cbTipoEmpaque.Text + "' " : " AND TIPOPAQUETE NOT IN ('ATADOS', 'TARIMA') ") +
                                "IF @cvedoc IS NOT NULL " +
                                "INSERT DETALLEPEDIDOMERC (CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, TOTART, CONSEC_EMPAQUE) " +
                                "VALUES (@cvedoc, @consec, 0, '', '" + ped.cve_doc.Trim() + "-" +
                                ((cbTipoEmpaque.Text == "ATADOS") ? "A" : ((cbTipoEmpaque.Text == "TARIMA") ? "T" : "")) +
                                "' + CAST(@consecEmpaque AS VARCHAR(10)), 0, '" + cbTipoEmpaque.Text + "', 0, @consecEmpaque) ";
                    Program.GetExecute(query, 5);
                    ActualizaPedido();
                    cargaPaquetes("CONSEC");
                    cargaDetalleMerc();
                    pbConcluir.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbElimina_Click(object sender, EventArgs e)
        {
            if (valExistencias() > 0) { Close(); return; }
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
                        var tp = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                        var query = "UPDATE DETALLEPEDIDOMERC SET CANCELADO = 1 " +
                                    "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "' AND CONSEC_EMPAQUE = " + dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString() + " AND " +
                                    ((tp == "ATADOS" || tp == "TARIMA") ? "TIPOPAQUETE = '" + tp + "'" : "TIPOPAQUETE NOT IN ('ATADOS', 'TARIMA')");
                        Program.GetExecute(query, 6);
                        ActualizaPedido();
                        cargaPaquetes("CONSEC");
                        cargaDetalleMerc();
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
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') AND (CODIGO_BARRA <> '') AND (ISNULL(CANCELADO, 0) = 0) " +
                            "UPDATE PEDIDO SET totCajaCarton =  @totCajaCarton, totCajaMadera =  @totCajaMadera, " +
                            "totbultos = @totbultos, totRollos = @totRollos, totCubetas = @totCubetas, totAtados = @totAtados, " +
                            "totTarimas = @totTarimas, PORC_EMPAQUE = (@totEmp / @totArt) * 100.00 " +
                            "WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "')";
                Program.GetExecute(query, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbEmpacar_Click(object sender, EventArgs e)
        {
            if (valExistencias() > 0) { Close(); return; }
            if (lstPaquetes.Count > 0)
            {
                var emp = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                if (emp != "ATADOS" && emp != "TARIMA")
                {
                    FrmEmpaqueAdd frmEmpacar = new FrmEmpaqueAdd();
                    frmEmpacar.ped = lstPaquetes.Find(o => o.consec_empaque == int.Parse(dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString()) && o.tipopaquete != "ATADOS" && o.tipopaquete != "TARIMA");
                    frmEmpacar.ShowDialog();
                }
                else
                {
                    var tp = dgPedidos[dgPedidos.CurrentRowIndex, 1].ToString();
                    FrmEmpaqueAT frmEmpacar2 = new FrmEmpaqueAT();
                    frmEmpacar2.ped = lstPaquetes.Find(o => o.consec_empaque == int.Parse(dgPedidos[dgPedidos.CurrentRowIndex, 0].ToString()) && o.tipopaquete == tp);
                    frmEmpacar2.ShowDialog();
                }
                ActualizaPedido();
                cargaPaquetes("CONSEC");
                pbImprimir.Visible = validaExisMerc(1);
                pbConcluir.Visible = validaExisMerc(2);
                cargaDetalleMerc();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (valExistencias() > 0) { Close(); return; }
            try
            {
                FrmDetenerPed frmDetenerPed = new FrmDetenerPed();
                frmDetenerPed.lblPedido.Text = ped.cve_doc.Trim();
                var rs = frmDetenerPed.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    FrmDetenerPedCausa frmCausa = new FrmDetenerPedCausa();
                    frmCausa.lblPedido.Text = ped.cve_doc.Trim();
                    frmCausa.ShowDialog();
                    var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'DETENIDO EMP', " +
                                "CAUSADETENIDO = '" + frmCausa.txtCausa.Text + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                    var r = Program.GetExecute(query, 6);
                    query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                            "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                            "@cvedoc, 'DETENIDO EMP', getdate(), '" + Program.usActivo.Usuario + "')";
                    r = Program.GetExecute(query, 7);
                    MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    frmDetenerPed.Close();
                    Close();
                }
                else
                {
                    frmDetenerPed.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private bool validaEstatusPedido()
        {
            bool b = false;
            try
            {
                var query = "select CVE_DOC, ESTATUSPEDIDO from PEDIDO where CVE_DOC = '" + ped.cve_doc + "'";
                var valped = Program.GetDataTable(query, 100).ToData<Pedidos>();
                b = (valped.estatuspedido == "EMPAQUE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return b;
        }

        private void pbImprimir_Click(object sender, EventArgs e)
        {
            if (valExistencias() > 0) { Close(); return; }

            DialogResult dr = DialogResult.OK;
            if (validaExisMerc(2))
            {
                FrmSurtir4 frmConf = new FrmSurtir4();
                frmConf.lblCom.Text = "El Pedido ya tiene impreso las etiquetas.";
                frmConf.label1.Text = "¿DESEAS IMPRIMIRLO DE NUEVO?";
                dr = frmConf.ShowDialog();
                frmConf.Close();
            }

            if(dr == DialogResult.OK)
            {
                var query2 = "UPDATE DETALLEPEDIDOMERC SET CANCELADO = 1 WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() +
                             "' AND ISNULL(TIPOPAQUETE,'') <> '' AND ISNULL(TotArt,0) = 0 AND ISNULL(CANCELADO,0) = 0";
                Program.GetExecute(query2, 51);

                ActualizaPedido();
                cargaPaquetes("CONSEC_EMPAQUE");
                cargaDetalleMerc();

                // Printer IP Address and communication port
                string ipAddress = Program.ipImpEti();
                int port = 9100;

                // ZPL Command(s)
                string ZPLString = GeneraEtiqueta();

                try
                {
                    // Open connection
                    TcpClient client = new TcpClient();
                    client.Connect(ipAddress, port);

                    // Write ZPL String to connection
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    writer.Write(ZPLString);
                    writer.Flush();

                    // Close Connection
                    writer.Close();
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Impresora no disponible, favor de validar", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                try
                {
                    var query = "UPDATE DETALLEPEDIDOMERC SET ULTIMO = 1 WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "') AND (CODIGO_BARRA <> '') " +
                          "AND (ISNULL(CANCELADO, 0) = 0) AND (ISNULL(TIPOPAQUETE,'') NOT IN ('', 'ATADOS', 'TARIMA')) AND (ISNULL(ULTIMO,0) = 0) ";
                    Program.GetExecute(query, 8);
                    MessageBox.Show("Impresion Exitosa", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    pbConcluir.Visible = validaExisMerc(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                pbConcluir.Visible = validaExisMerc(2);
            }
        }

        private string GeneraEtiqueta()
        {
            string DatosPedido = "";
            string ZPLString = "";
            string contado = "";
            int cantidadPaquete = 0;
            int contadorPaquete = 0;
            string DatosPaquete = "";
            List<DetallePedidoMerc> lstAT = new List<DetallePedidoMerc>();
            try
            {
                var clt = "(" + ped.cve_clpv + ") " + ped.cliente;
                var aju = (clt.Length < 40) ? 30 : ((clt.Length < 50) ? 27 : ((clt.Length < 60) ? 24 : 21));
                var tam = ped.consignacion.Length;
                DatosPedido =
                    "^FO10,78^GB760,160,1,,2^FS" +
                    "^FO20,85^A0,30,25^FDNum.Pedido :^FS" +
                    "^FO160,85^A0,30,30^FD" + ped.cve_doc.Trim() + "^FS" +
                    "^FO405,85^A0,30,25^FDFecha :^FS" +
                    "^FO555,85^A0,30,30^FD" + ped.fecha_ent.ToString("dd / MM / yyyy") + "^FS" +
                    "^FO20,110^A0,30,25^FDCliente :^FS" +
                    "^FO160,110^A0,30," + aju + "^FD" + clt + "^FS" +
                    "^FO20,135^A0,30,25^FDDireccion :^FS" +
                    ((ped.enviar == "") ?
                    "^FO160,135^A0,30,20^FD" + ped.direccion1 + "^FS" +
                    "^FO160,160^A0,30,20^FD" + ped.direccion2 + "^FS" :
                    "^FO160,135^A0,30,20^FD" + ped.consignacion.Substring(0, (tam < 61 ? tam : 60)) + "^FS" +
                    (tam < 61 ? "" : "^FO160,160^A0,30,20^FD" + ped.consignacion.Substring(60) + "^FS")) +
                    "^FO20,185^A0,30,25^FDFlete :^FS" +
                    "^FO160,185^A0,30,30^FD" + ped.flete + "^FS" +
                    "^FO405,185^A0,30,25^FDFlete 2 :^FS" +
                    "^FO555,185^A0,30,30^FD" + ped.flete2 + "^FS" +
                    "^FO20,210^A0,30,25^FDOcrr / Dom :^FS" +
                    "^FO160,210^A0,30,30^FD" + ped.ocurredomicilio + "^FS" +
                    "^FO405,210^A0,30,25^FDOrden Comp. :^FS" +
                    "^FO555,210^A0,30,30^FD" + ped.cve_pedi + "^FS";

                contado = (ped.contado == "S") ? "CONTADO" : "";
                cantidadPaquete = lstPaquetes.Count;

                foreach (var paq in lstPaquetes)
                {
                    Rini = 530;
                    contadorPaquete++;
                    DatosPaquete =
                        "^FO10,245^GB560,60,2,,0^FS" +
                        "^FO569,245^GB200,60,2,,0^FS" +
                        "^FO10,304^GB760,130,2,,0^FS" +
                        "^FO10,433^GB760,60,2,,0^FS" +
                        "^FO10,265^A0,35,75^FB560,1,0,C,0^FR^FD" + paq.tipopaquete + "^FS" +
                        "^FO575,250^A0,20,20^FR^FDPAQ.^FS" +
                        "^FO570,265^A0,35,35^FB200,1,0,C,0^FR^FD" + contadorPaquete.ToString() + " de " + cantidadPaquete.ToString() + "^FS" +
                        "^BY4,2,80^FO50,310^BC^FD" + paq.codigo_barra + "^FS" +
                        "^FO10,450^A0,50,100^FB760,1,0,C,0^FR^FD" + contado + "^FS" +
                        "^FO10,500^A0,25,35^FR^FDContenido :^FS" +
                        "^FO10,520^GB760,480,1,,0^FS";

                    if (paq.tipopaquete == "TARIMA")
                    {
                        DatosPaquete += GeneraDetPaq(paq);

                        ZPLString +=
                            "^XA" +
                            Encabezado +
                            DatosPedido +
                            DatosPaquete +
                            "^XZ";

                        int cantidadPaqueteT = 0;
                        int contadorPaqueteT = 0;

                        lstAT = cargaDetPaquetes(paq.cve_doc, paq.consec, false, paq.tipopaquete);
                        cantidadPaqueteT = lstAT.Count;
                        foreach (var det in lstAT)
                        {
                            Rini = 530;
                            contadorPaqueteT++;
                            string DatosPaqueteT =
                                "^FO10,245^GB560,60,2,,0^FS" +
                                "^FO569,245^GB200,60,2,,0^FS" +
                                "^FO10,304^GB760,130,2,,0^FS" +
                                "^FO10,433^GB760,60,2,,0^FS" +
                                "^FO10,265^A0,35,75^FB560,1,0,C,0^FR^FD" + det.tipopaquete + " (T)^FS" +
                                "^FO575,250^A0,20,20^FR^FDPAQ.^FS" +
                                "^FO570,265^A0,35,35^FB200,1,0,C,0^FR^FD" + contadorPaqueteT.ToString() + " de " + cantidadPaqueteT.ToString() + "^FS" +
                                "^BY4,2,80^FO50,310^BC^FD" + det.codigo_barra + "^FS" +
                                "^FO10,450^A0,50,100^FB760,1,0,C,0^FR^FD" + contado + "^FS" +
                                "^FO10,500^A0,25,35^FR^FDContenido :^FS" +
                                "^FO10,520^GB760,480,1,,0^FS";

                            DatosPaqueteT += GeneraDetPaq(det);

                            ZPLString +=
                                "^XA" +
                                Encabezado +
                                DatosPedido +
                                DatosPaqueteT +
                                "^XZ";
                        }
                    }
                    else
                    {
                        if (paq.tipopaquete == "ATADOS")
                        {
                            lstAT = cargaDetPaquetes(paq.cve_doc, paq.consec, false, paq.tipopaquete);
                            foreach (var det in lstAT)
                            {
                                DatosPaquete += GeneraDetPaq(det);
                            }
                        }
                        else
                        {
                            DatosPaquete += GeneraDetPaq(paq);
                        }

                        ZPLString +=
                            "^XA" +
                            Encabezado +
                            DatosPedido +
                            DatosPaquete +
                            "^XZ";

                        if (paq.tipopaquete == "ATADOS")
                        {
                            for (var i = 1; i <= paq.totart; i++)
                            {
                                ZPLString +=
                                    "^XA" +
                                    Encabezado +
                                    DatosPedido +
                                    DatosPaquete +
                                    "^XZ";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return ZPLString;
        }

        private string valSaltoPag()
        {
            string res = "";
            if (Rini > Rlim)
            {
                res =
                    "^XZ" +
                    "^XA" +
                    Encabezado +
                    "^FO10,80^A0,25,35^FR^FDContenido :^FS" +
                    "^FO10,100^GB760,900,1,,0^FS";
                Rini = 110;
            }
            return res;
        }

        private string GeneraDetPaq(DetallePedidoMerc det)
        {
            string str = "";
            List<DetallePedidoMerc> ls = cargaDetPaquetes(det.cve_doc, det.consec, true, det.tipopaquete);
            str += valSaltoPag();
            str += "^FO20," + (Rini + 5) + "^A0,25,25^FR^FD" + det.tipopaquete + ' ' + det.codigo_barra + "^FS";
            Rini += Rsal;
            int ind = 1;
            string cb = "";
            foreach (var d in ls)
            {
                cb = d.codigo_barra.Substring(d.codigo_barra.Length - 7);
                str += valSaltoPag();
                switch (ind)
                {
                    case 1:
                        str +=
                            "^FO20," + Rini + "^A0,30,30^FD" + ((det.tipopaquete == "TARIMA") ? "1" : d.cant.ToString()) + "^FS" +
                            "^FO70," + Rini + "^A0,30,30^FD(" + ((det.tipopaquete == "TARIMA") ? cb : d.cve_art) + ")^FS" +
                            "^FO190," + Rini + "^GB1,30,1,,0^FS";
                        break;
                    case 2:
                        str +=
                            "^FO200," + Rini + "^A0,30,30^FD" + ((det.tipopaquete == "TARIMA") ? "1" : d.cant.ToString()) + "^FS" +
                            "^FO250," + Rini + "^A0,30,30^FD(" + ((det.tipopaquete == "TARIMA") ? cb : d.cve_art) + ")^FS" +
                            "^FO390," + Rini + "^GB1,30,1,,0^FS";
                        break;
                    case 3:
                        str +=
                            "^FO400," + Rini + "^A0,30,30^FD" + ((det.tipopaquete == "TARIMA") ? "1" : d.cant.ToString()) + "^FS" +
                            "^FO450," + Rini + "^A0,30,30^FD(" + ((det.tipopaquete == "TARIMA") ? cb : d.cve_art) + ")^FS" +
                            "^FO590," + Rini + "^GB1,30,1,,0^FS";
                        break;
                    case 4:
                        str +=
                            "^FO600," + Rini + "^A0,30,30^FD" + ((det.tipopaquete == "TARIMA") ? "1" : d.cant.ToString()) + "^FS" +
                            "^FO650," + Rini + "^A0,30,30^FD(" + ((det.tipopaquete == "TARIMA") ? cb : d.cve_art) + ")^FS";
                        Rini += Rsal;
                        ind = 0;
                        break;
                }
                ind++;
            }
            for (var i = ind; i <= 4; i++)
            {
                switch (i)
                {
                    case 1: i = 4; break;
                    case 2:
                        str += "^FO390," + Rini + "^GB1,30,1,,0^FS";
                        break;
                    case 3:
                        str += "^FO590," + Rini + "^GB1,30,1,,0^FS";
                        break;
                    case 4:
                        Rini += Rsal;
                        break;
                }
            }
            Rini += Rsal;
            return str;
        }

        private void pbListado_Click(object sender, EventArgs e)
        {
            FrmEmpaqueList frmEmpList = new FrmEmpaqueList();
            frmEmpList.ped = ped;
            frmEmpList.det = lstMercancia.Where(o => o.ultimo == "NO").ToList();
            frmEmpList.ShowDialog();
            if (valExistencias() > 0) { Close(); return; }
        }

        private void pbInfo_Click(object sender, EventArgs e)
        {
            info();
            if (valExistencias() > 0) { Close(); return; }
        }

        private void info()
        {
            FrmEmpaqueInfo inf = new FrmEmpaqueInfo();
            inf.ped = ped;
            inf.ShowDialog();
            inf.Close();
        }

        private void pbTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTransferir frmTransferir = new FrmTransferir();
                frmTransferir.lblPedido.Text = ped.cve_doc.Trim();
                frmTransferir.perfil = "EMPAQUE";
                var rs = frmTransferir.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    var query = "UPDATE PEDIDO SET EMPAQUETADOR_ASIGNADO = '" + frmTransferir.cbUsuarios.SelectedValue.ToString() + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                    var r = Program.GetExecute(query, 8);
                    MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    frmTransferir.Close();
                    Close();
                }
                else
                {
                    frmTransferir.Close();
                    valExistencias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}