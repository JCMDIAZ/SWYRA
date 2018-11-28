using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace SWYRA_Movil
{
    public partial class FrmMenuPedidosArea : Form
    {
        public string cvedoc;
        private Pedidos ped = new Pedidos();
        private List<DetallePedidos> det = new List<DetallePedidos>();
        private List<DetallePedidos> dev = new List<DetallePedidos>();
        private List<DetallePedidos> detA = new List<DetallePedidos>();
        private List<DetallePedidos> devA = new List<DetallePedidos>();

        public FrmMenuPedidosArea()
        {
            InitializeComponent();
        }

        private int valExistencias()
        {
            var n = 0;
            var c = ValidaCambios();
            var v1 = validaExis(false);
            if (!v1 && c)
            {
                n = 2;
                ped.solarea = false;
                var query = "UPDATE PEDIDO SET SOLAREA = 0 " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                var r = Program.GetExecute(query, 9);
                MessageBox.Show(@"Existe Artículos por Agregar o Devolver se regresará al SURTIDOR : " + ped.surtidor_asignado_n + ". Favor de dejar mercancía en " + ped.ubicacionempaque + ".", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            var v2 = validaExis(true);
            if (!v2 && n != 2 && c)
            {
                n = 1;
                MessageBox.Show(@"Existe Artículos por Agregar o Devolver del área de Brocas. Favor de validar.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            pbConcluir.Visible = v1 && v2;
            return n;
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            valExistencias();
            this.Close();
        }

        private void Ajuste()
        {
            try
            {
                var query = "update DETALLEPEDIDO set CANTSURTIDO = dm.cant_st, CANTPENDIENTE = dm.cant_pd, SURTIDO = case when dp.CANT = (dm.cant_st + dm.cant_pd) then 1 else 0 end " +
                            "from (SELECT CVE_DOC, CVE_ART, SUM(CANT) cant_st, SUM(ISNULL(PEND,0)) cant_pd FROM DETALLEPEDIDOMERC " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "' AND ISNULL(CVE_ART,'') <> '' AND ISNULL(CANCELADO,0) = 0 GROUP BY CVE_DOC, CVE_ART) dm " +
                            "join DETALLEPEDIDO dp ON dp.CVE_DOC = dm.CVE_DOC and dp.CVE_ART = dm.CVE_ART " +
                            "and ((cant_st + cant_pd) <> (isnull(dp.CANTSURTIDO,0) + isnull(dp.CANTPENDIENTE,0)))";
                Program.GetExecute(query, 7);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbConcluir_Click(object sender, EventArgs e)
        {
            Ajuste();
            var n = valExistencias();
            if(n == 2)
            {
                this.Close();
                return;
            }
            if(n == 1)
            {
                return;
            }
            try
            {
                FrmAreaEmpaque frmAreaEmp = new FrmAreaEmpaque();
                frmAreaEmp.lblPedido.Text = ped.cve_doc;
                frmAreaEmp.lblCliente.Text = ped.cliente.Trim();
                frmAreaEmp.lblCond.Text = ped.condicion.Trim();
                frmAreaEmp.listBox1.Visible = false;
                frmAreaEmp.pbSig.Visible = false;
                frmAreaEmp.pbAnt.Visible = false;
                DialogResult dr = new DialogResult();
                if (ped.estatuspedido != "DEVOLUCION")
                {
                    dr = frmAreaEmp.ShowDialog();
                }
                else
                {
                    dr = DialogResult.OK;
                }
                if (dr == DialogResult.OK)
                {
                    var estatus = (ped.estatuspedido == "DEVOLUCION") ? "CANCELACION" : "EMPAQUE";
                    var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = '" + estatus + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "' ";
                    var r = Program.GetExecute(query, 10);
                    query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                            "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                            "@cvedoc, '" + estatus + "', getdate(), '" + Program.usActivo.Usuario + "')";
                    r = Program.GetExecute(query, 11);
                    var query2 = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                                 "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                                 "DECLARE @num INT " +
                                 "SELECT @num = ISNULL(MAX(ID),0) + 1 FROM IMPRESION " +
                                 "INSERT IMPRESION (ID, FECHA, CVE_DOC, CVE_IMP, IMPRESION) " +
                                 "VALUES ( @num, GETDATE(), @cvedoc, 1, 'HOJA DE SURTIDO')";
                    var r2 = Program.GetExecute(query2, 13);
                    MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    MessageBox.Show(@"IMPRESIÓN DE LA HOJA DE SURTIDO EXITOSA. FAVOR DE TOMARLA.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbIncompletos_Click(object sender, EventArgs e)
        {
            FrmIncompleto frmIncompleto = new FrmIncompleto();
            frmIncompleto.ped = ped;
            frmIncompleto.det = detA.Where(o => o.cantpendiente > 0).ToList();
            frmIncompleto.pbRegresar.Visible = false;
            frmIncompleto.pbRegresarB.Visible = true;
            frmIncompleto.ShowDialog();
            if (valExistencias() == 2)
            {
                this.Close();
            }
        }

        private void pbDevolucion_Click(object sender, EventArgs e)
        {
            FrmDevolucion frmDevolucion = new FrmDevolucion();
            frmDevolucion.ped = ped;
            frmDevolucion.Area = true;
            frmDevolucion.ShowDialog();
            if (valExistencias() == 2)
            {
                this.Close();
            }
        }

        private bool validaDuplicidad()
        {
            bool m = false;
            try
            {
                var query = "select CVE_DOC, CVE_ART  from DETALLEPEDIDO WHERE LTRIM(CVE_DOC) = '" + cvedoc + "' " +
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

        private bool validaMinMultiplo()
        {
            bool m = false;
            try
            {
                var query = "select * from DETALLEPEDIDO dp left join INVENTARIO i on dp.CVE_ART = i.CVE_ART " +
                            "where cast(dp.CANT as int) % cast(i.UNI_EMP as int) <> 0 and ltrim(CVE_DOC) = '" + cvedoc + "' ";
                List<DetallePedidos> res = Program.GetDataTable(query, 52).ToList<DetallePedidos>();
                if (res.Count > 0)
                {
                    var dt = res.First();
                    MessageBox.Show(dt.cve_art + @" no cumple con el multiplo de venta, favor de solicitar a asistente su modificación.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    m = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return m;
        }

        private void pbImprimir_Click(object sender, EventArgs e)
        {
            if (validaDuplicidad()) { return; }
            if (validaMinMultiplo()) { return; }
            if (detA.Where(o => o.surtido == false).ToList().Count > 0)
            {
                FrmSurtit frmSurtir = new FrmSurtit();
                frmSurtir.ped = ped;
                frmSurtir.det = detA.Where(o => o.surtido == false).ToList();
                frmSurtir.pbIncompleto.Visible = false;
                frmSurtir.pbIncompletoB.Visible = true;
                frmSurtir.ShowDialog();
                if (valExistencias() == 2)
                {
                    this.Close();
                }
            }
        }

        private void FrmMenuPedidosArea_Load(object sender, EventArgs e)
        {
            var query = "";
            try
            {
                query = "select LTRIM(p.CVE_DOC) CVE_DOC, LTRIM(CVE_CLPV) CVE_CLPV, c.NOMBRE Cliente, LTRIM(p.CVE_VEND) CVE_VEND, SURTIDOR_AREA, " +
                            "TIPOSERVICIO, PRIORIDAD, ISNULL(SOLAREA,0) SOLAREA, ESTATUSPEDIDO, IMPORTE, NOMBRE_VENDEDOR, " +
                            "CAPTURO, u.Nombre CAPTURO_N, OCURREDOMICILIO, u2.Nombre SURTIDOR_ASIGNADO_N, ISNULL(STUFF((select ',' + UbicacionEmpaque from PEDIDO_Ubicacion u " +
                            "where u.CVE_DOC = p.CVE_DOC FOR XML PATH('')), 1, 1, ''),'') UbicacionEmpaque, CONDICION, OBSERVACIONES, INDICACIONES " +
                            "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                            "left join USUARIOS u on u.Usuario = p.CAPTURO " +
                            "left join USUARIOS u2 on u2.Usuario = p.SURTIDOR_ASIGNADO " +
                            "WHERE LTRIM(p.CVE_DOC) = '" + cvedoc.Trim() + "'";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                if (ped.surtidor_area == Program.usActivo.Usuario)
                {
                    Ajuste();
                    txtPedido.Text = ped.cve_doc;
                    txtCliente.Text = "(" + ped.cve_clpv + ") " + ped.cliente;
                    txtServicio.Text = ped.tiposervicio;
                    txtOcurrDom.Text = ped.ocurredomicilio;
                    txtVendedor.Text = ped.nombre_vendedor;
                    txtCapturo.Text = ped.capturo_n;
                    CultureInfo culture = new CultureInfo("es-MX");
                    info();
                    txtMonto.Text = ped.importe.ToString("C2", culture);
                    if (ped.estatuspedido == "DEVOLUCION") { lblInfo.Text = "POR CANCELAR"; }
                    lblUbica.Text = ((ped.ubicacionempaque != "") ? "Ubi: " + ped.ubicacionempaque : "");
                    if (valExistencias() == 2)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("El pedido " + cvedoc + " ha sido asignado otro SURTIDOR DE BROCAS.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
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
                    lblPendS.Text = cdetA.ToString();
                    lblPendM.Text = cdevA.ToString();
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

        private void pbDevolucion_Click_1(object sender, EventArgs e)
        {
            if (devA.Where(o => o.devuelto == false).ToList().Count > 0)
            {
                if (validaDuplicidad()) { return; }
                if (validaMinMultiplo()) { return; }
                FrmCancelacion frmCan = new FrmCancelacion();
                frmCan.Area = true;
                frmCan.ped = ped;
                frmCan.det = devA.Where(o => o.devuelto == false).ToList();
                frmCan.ShowDialog();
                if (valExistencias() == 2)
                {
                    this.Close();
                }
            }
        }

        private void pbDetener_Click(object sender, EventArgs e)
        {
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
                    var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'DETENIDO BROCAS', " +
                                "CAUSADETENIDO = '" + frmCausa.txtCausa.Text + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                    var r = Program.GetExecute(query, 6);
                    query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                            "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                            "@cvedoc, 'DETENIDO BROCAS', getdate(), '" + Program.usActivo.Usuario + "')";
                    r = Program.GetExecute(query, 7);
                    MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    frmDetenerPed.Close();
                    Close();
                }
                else
                {
                    frmDetenerPed.Close();
                    if (valExistencias() == 2)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private bool ValidaCambios()
        {
            var query = "";
            bool b = false;
            try
            {
                query = "select LTRIM(p.CVE_DOC) CVE_DOC, LTRIM(CVE_CLPV) CVE_CLPV, c.NOMBRE Cliente, LTRIM(p.CVE_VEND) CVE_VEND, " +
                            "TIPOSERVICIO, PRIORIDAD, ISNULL(SOLAREA,0) SOLAREA, ESTATUSPEDIDO, IMPORTE, OCURREDOMICILIO, NOMBRE_VENDEDOR, " +
                            "CAPTURO, u.Nombre CAPTURO_N, u2.Nombre SURTIDOR_ASIGNADO_N, r.UbicacionEmpaque " + 
                            "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                            "left join USUARIOS u on u.Usuario = p.CAPTURO " +
                            "left join USUARIOS u2 on u2.Usuario = p.SURTIDOR_ASIGNADO " +
                            "left join (select top 1 * from PEDIDO_Ubicacion where LTRIM(CVE_DOC) = '" + cvedoc.Trim() + "') as r on r.CVE_DOC = p.CVE_DOC " +
                            "WHERE LTRIM(p.CVE_DOC) = '" + cvedoc.Trim() + "'";
                var pedcam = Program.GetDataTable(query, 1).ToData<Pedidos>();
                if (ped.importe != pedcam.importe)
                {
                    ped = pedcam;
                    b = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return b;
        }

        private void pbTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTransferir frmTransferir = new FrmTransferir();
                frmTransferir.lblPedido.Text = ped.cve_doc.Trim();
                frmTransferir.perfil = "AREA";
                var rs = frmTransferir.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    var query = "UPDATE PEDIDO SET SURTIDOR_AREA = '" + frmTransferir.cbUsuarios.SelectedValue.ToString() + "' " +
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

        private void pbInfo_Click(object sender, EventArgs e)
        {
            info();
        }

        private void info()
        {
            FrmSurtirInfo inf = new FrmSurtirInfo();
            inf.ped = ped;
            inf.ShowDialog();
            inf.Close();
        }
    }
}