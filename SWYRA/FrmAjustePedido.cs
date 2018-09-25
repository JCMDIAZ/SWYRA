using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SWYRA.General;
using DevExpress.XtraReports.UI;

namespace SWYRA
{
    public partial class FrmAjustePedido : Form
    {
        public string cve_doc = "";
        private Pedidos ped = new Pedidos();
        private List<Pedidos> lsPedidos = new List<Pedidos>();
        private List<DetallePedidos> lsDetallePedidos = new List<DetallePedidos>();
        private List<DetallePedidoMerc> lsDetPedMerc = new List<DetallePedidoMerc>();
        public Usuarios userActivo = new Usuarios();
        public bool ajustar = false;

        public FrmAjustePedido()
        {
            InitializeComponent();
        }

        private void FrmAjustePedido_Load(object sender, EventArgs e)
        {
            if (ajustar) { AjusteSaldos(); }
            CargaPedido();
            lblContado.Text = (ped.contado == "S") ? "AUTORIZADO CONTADO" : ((ped.estatuspedido != "AUTORIZACION") ? "AUTORIZADO" : "");
            Cargadatos();
        }

        private void CargaPedido()
        {
            try
            {
                var query = "SELECT  TIP_DOC, CVE_DOC, CVE_CLPV, p.STATUS, DAT_MOSTR, p.CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, " +
                            "FECHA_VEN, FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, " +
                            "CONDICION, p.CVE_OBS, NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, " +
                            "FECHAELAB, PRIMERPAGO, RFC, CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, " +
                            "BLOQ, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, " +
                            "DOC_ANT, TIP_DOC_SIG, DOC_SIG, TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO, COBRADOR_ASIGNADO, " +
                            "COBRADOR_AUTORIZO, SURTIDOR_ASIGNADO, EMPAQUETADOR_ASIGNADO, ETIQUETADOR_ASIGNADO, SURTIDOR_AREA, " +
                            "PORC_SURTIDO, PORC_EMPAQUE, INDICACIONES, LOTE, uCobAsig.Nombre cobrador_asignado_n, " +
                            "uCobAut.Nombre cobrador_autorizo_n, uSurAsig.Nombre surtidor_asignado_n, uEmpAsig.Nombre empaquetador_asignado_n, " +
                            "uEtiAsig.Nombre etiquetador_asignado_n, uSurArea.Nombre surtidor_area_n, cliente.NOMBRE CLIENTE, PRIORIDAD, " +
                            "TotCajaCarton, TotCajaMadera, TotBultos, TotRollos, TotCubetas, TotAtados, TotTarimas, TotCostoGuias, p.ENVIAR, " +
                            "ISNULL(FLT,cliente.FLETE) FLETE, cliente.FLETE2, p.OBSERVACIONES, p.CONSIGNACION, p.NOMBRE_VENDEDOR, uCapturo.Nombre capturo_n, " +
                            "(CALLE + ' # ' + NUMEXT + ' COL. ' + COLONIA) direccion1, ('C.P. ' + CODIGO + '; ' + MUNICIPIO + ', ' + ESTADO) direccion2 " +
                            "FROM PEDIDO p left join USUARIOS uCobAsig on uCobAsig.Usuario = p.COBRADOR_ASIGNADO " +
                            "left join USUARIOS uCobAut on uCobAut.Usuario = p.COBRADOR_AUTORIZO " +
                            "left join USUARIOS uSurAsig on uSurAsig.Usuario = p.SURTIDOR_ASIGNADO " +
                            "left join USUARIOS uEmpAsig on uEmpAsig.Usuario = p.EMPAQUETADOR_ASIGNADO " +
                            "left join USUARIOS uEtiAsig on uEtiAsig.Usuario = p.ETIQUETADOR_ASIGNADO " +
                            "left join USUARIOS uSurArea on uSurArea.Usuario = p.SURTIDOR_AREA " +
                            "left join USUARIOS uCapturo on uCapturo.Usuario = p.CAPTURO " +
                            "left join CLIENTE cliente on cliente.CLAVE = p.CVE_CLPV " +
                            "WHERE(CVE_DOC = '" + cve_doc + "')";
                lsPedidos = GetDataTable("DB", query, 5).ToList<Pedidos>();
                ped = lsPedidos.FirstOrDefault();
                var num = ped.condicion.Split(';').Length;
                ped.condicion = (num > 2) ? ped.condicion.Split(';')[2] : "";
                string[] est = {"REMISION", "GUIA", "TERMINADO"};
                query =
                    "SELECT dp.CVE_DOC, dp.NUM_PAR, dp.CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, " +
                    "IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, " +
                    "(isnull(replace(ic.COMENTARIO,'Lote:',''),'') + case when ic.APLICALOTE = 1 then ' Lote : ' + isnull(res.lote,'') else '' end) comen, " +
                    "UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, CASE WHEN ISNULL(CANTSURTIDO, 0) = 0 THEN CANT ELSE ISNULL(CANTSURTIDO, 0) END CANTSURTIDO, SURTIDO, res.Empaque, " +
                    "TDESC, SUBTO, TCOMI, i.DESCR, (SUBTO + TOTIMP4) IMPORTE, (CANT * PESO) PESO, (CANT * VOLUMEN) VOLUMEN " + 
                    "FROM DETALLEPEDIDO dp JOIN INVENTARIO i ON dp.CVE_ART = i.CVE_ART " +
                    "LEFT join INVENTARIOCOND ic on dp.CVE_ART = ic.CVE_ART " +
                    "LEFT JOIN ( select distinct CVE_DOC, NUM_PAR, STUFF((select ', ' + ('(' + CAST(SUM(d.CANT) AS VARCHAR(5)) + ') ' + e.Empaque) " + 
                    "from DETALLEPEDIDOMERC d join(select h.CVE_DOC, h.CONSEC, h.TIPOPAQUETE + ' # ' + CAST(h.CONSEC_EMPAQUE AS VARCHAR(2)) + " +
                    "case when p.TIPOPAQUETE = 'ATADOS' then ' (A' + cast(p.CONSEC_EMPAQUE as varchar(2)) + ')' " +
                    "when p.TIPOPAQUETE = 'TARIMA' then ' (T' + cast(p.CONSEC_EMPAQUE as varchar(2)) + ')' ELSE '' END Empaque " +
                    "FROM DETALLEPEDIDOMERC h LEFT JOIN DETALLEPEDIDOMERC p ON p.CONSEC = h.CONSEC_PADRE and p.CVE_DOC = h.CVE_DOC " +
                    "WHERE (h.CVE_DOC = '" + cve_doc + "') AND(ISNULL(h.CANCELADO, 0) = 0) AND(ISNULL(h.TIPOPAQUETE, '') " +
                    "NOT IN('', 'GUIA'))) as e on d.CVE_DOC = e.CVE_DOC and d.CONSEC_PADRE = e.CONSEC WHERE(d.CVE_DOC = '" + cve_doc + "') " +
                    "AND(ISNULL(CANCELADO, 0) = 0) AND(ISNULL(TIPOPAQUETE, '') IN('')) AND a.CVE_DOC = d.CVE_DOC and a.CVE_ART = d.CVE_ART " +
                    "group by e.Empaque, d.NUM_PAR order by d.NUM_PAR FOR XML PATH('')), 1, 1, '') as Empaque, isnull(a.lote,'') lote from DETALLEPEDIDOMERC as a " +
                    "where (a.CVE_DOC = '" + cve_doc + "') AND(NUM_PAR > 0) ) as res on dp.NUM_PAR = res.NUM_PAR " +
                    "WHERE (dp.CVE_DOC = '" + cve_doc + "') AND ((ISNULL(CANTSURTIDO," + (ped.estatuspedido.In(est) ? "0" : "CANT") + ") > 0) " +
                    "OR (ISNULL(CANTSURTIDO,0) = 0 AND ISNULL(CANTPENDIENTE,0) = 0))";
                lsDetallePedidos = GetDataTable("DB", query, 6).ToList<DetallePedidos>();
                query =
                    "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, CANCELADO, TotArt, " + 
                    "CONSEC_EMPAQUE, CONSEC_PADRE_GUIA, CVE_ART_GUIA, PRECIO_GUIA, ASIG_PEDIDO_GUIA, NUM_GUIA, " +
                    "(CASE WHEN TIPOPAQUETE = 'ATADOS' THEN 'A' ELSE 'T' END + CAST(CONSEC_EMPAQUE AS VARCHAR(5))) STR_CONSEC_EMPAQUE FROM DETALLEPEDIDOMERC " +
                    "WHERE (CVE_DOC = '" + cve_doc + "') AND (TIPOPAQUETE IN ('ATADOS', 'TARIMA')) AND (ISNULL(CANCELADO, 0) = 0)";
                lsDetPedMerc = GetDataTable("DB", query, 8).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cargadatos()
        {
            txtPedido.Text = ped.cve_doc;
            deFecha.EditValue = ped.fechaelab;
            txtCliente.Text = ped.cliente;
            txtTipoServicio.Text = ped.tiposervicio;
            txtOcurredom.Text = ped.ocurredomicilio;
            txtEnviar.Text = ped.enviar;
            txtCajaCarton.Text = ped.totcajacarton.ToString();
            txtCajaMadera.Text = ped.totcajamadera.ToString();
            txtBulto.Text = ped.totbultos.ToString();txtRollo.Text = ped.totrollos.ToString();
            txtCubeta.Text = ped.totcubetas.ToString();
            txtAtados.Text = ped.totatados.ToString();
            txtTarimas.Text = ped.tottarimas.ToString();
            txtNumCli.Text = ped.cve_clpv;
            txtNumVendedor.Text = @"(" + ped.cve_vend.Trim() + @") - " + ped.nombre_vendedor;
            txtCondiciones.Text = ped.condicion;
            txtObservaciones.Text = ped.observaciones + @" / " + ped.indicaciones;
            txtFlete.Text = ped.flete;
            txtFlete2.Text = ped.flete2;
            txtCapturo.Text = ped.capturo_n;
            txtAutorizo.Text = ped.cobrador_autorizo_n;
            txtSurtio.Text = ped.surtidor_asignado_n;
            txtBrocas.Text = ped.surtidor_area_n;
            txtEmpaco.Text = ped.empaquetador_asignado_n;
            txtOrdenCompra.Text = ped.cve_pedi;
            txtConsigna.Text = ped.consignacion;

            gcDetPedido.DataSource = lsDetallePedidos;
            gcPaquetes.DataSource = lsDetPedMerc;
        }

        private void AjusteSaldos()
        {
            try
            {
                List<DetallePedidoMerc> lsDet = new List<DetallePedidoMerc>();
                var query = @"DELETE DETALLEPEDIDO WHERE (CVE_DOC = '" + cve_doc + "') AND ISNULL(SERVI,0) = 1";
                var res = GetExecute("DB", query, 1);

                query = "SELECT CVE_DOC, CVE_ART_GUIA, PRECIO_GUIA " +
                        "FROM DETALLEPEDIDOMERC WHERE(CVE_DOC = '" + cve_doc + "') AND(ISNULL(TIPOPAQUETE, '') = 'GUIA') " +
                        "AND(ISNULL(CANCELADO, 0) = 0)";
                lsDet = GetDataTable("DB", query, 2).ToList<DetallePedidoMerc>();
                foreach (var det in lsDet)
                {
                    query = "declare @numpar int select @numpar = MAX(NUM_PAR) + 1 from DETALLEPEDIDO WHERE (CVE_DOC = '" + cve_doc + "') " +
                            "INSERT DETALLEPEDIDO (CVE_DOC, NUM_PAR, CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, " +
                            "IMP3APLA, IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, " +
                            "TIP_CAM, UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, CANTSURTIDO, SURTIDO, SERVI) " +
                            "VALUES('" + cve_doc + "', @numpar, '" + det.cve_art_guia + "', 1, 0, " + det.precio_guia + ", 0, 0, 0, 0, 16, 0, 0, 0, 0, 0, 0, 0, 0, " +
                            "0, 0, 0, 0, 0, 'N', 1, '', 1, 'pz', 'P', 0, 0, 0, 'N', 0, 0, 'S', 1, 1, 1)";
                    res = GetExecute("DB", query, 3);
                }

                query = @"declare @cve_doc varchar(20) set @cve_doc = '" + cve_doc + "' " +
                        "UPDATE DETALLEPEDIDO SET TOT_PARTIDA = CANTSURTIDO * PREC WHERE (CVE_DOC = @cve_doc) " +
                        "UPDATE DETALLEPEDIDO SET TDESC = TOT_PARTIDA * (DESC1 / 100.0) WHERE (CVE_DOC = @cve_doc) " +
                        "UPDATE DETALLEPEDIDO SET SUBTO = TOT_PARTIDA - TDESC WHERE (CVE_DOC = @cve_doc) " +
                        "UPDATE DETALLEPEDIDO SET TOTIMP4 = SUBTO * (IMPU4 / 100) WHERE (CVE_DOC = @cve_doc) " +
                        "UPDATE DETALLEPEDIDO SET TCOMI = SUBTO * (COMI / 100) WHERE (CVE_DOC = @cve_doc) " +
                        "UPDATE PEDIDO SET CAN_TOT = D.CANT_TOT, IMP_TOT4 = D.IMP_TOT4, DES_TOT = D.DES_TOT, " +
                        "COM_TOT = D.COM_TOT, IMPORTE = D.CANT_TOT - D.DES_TOT + D.IMP_TOT4 " +
                        "FROM PEDIDO P JOIN ( SELECT CVE_DOC, SUM(TOT_PARTIDA) CANT_TOT, SUM(TOTIMP4) IMP_TOT4, " +
                        "SUM(TDESC) DES_TOT, SUM(TCOMI) COM_TOT FROM DETALLEPEDIDO WHERE (CVE_DOC = @cve_doc) " +
                        "GROUP BY CVE_DOC) AS D ON P.CVE_DOC = D.CVE_DOC";
                res = GetExecute("DB", query, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'FACTURACION' " +
                            "WHERE (CVE_DOC = '" + cve_doc + "')";
                var res = GetExecute("DB", query, 7);
                var query3 = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                             cve_doc + "', 'FACTURACION', getdate(), '" + userActivo.Usuario + "')";
                var res2 = GetExecute("DB", query, 12);
                cve_doc = "";
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ResumenPedido resumenPedido = new ResumenPedido();
            resumenPedido.DataSource = lsPedidos;
            ResumenPedidoAT resumenPedidoAt = new ResumenPedidoAT();
            resumenPedidoAt.DataSource = lsDetPedMerc;
            ResumenPedidoDT resumenPedidoDt = new ResumenPedidoDT();
            resumenPedidoDt.DataSource = lsDetallePedidos;

            resumenPedido.xrSubreport1.ReportSource = resumenPedidoAt;
            resumenPedido.xrSubreport2.ReportSource = resumenPedidoDt;
            resumenPedido.ShowPreview();
        }
    }
}
