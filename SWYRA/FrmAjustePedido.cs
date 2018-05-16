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

namespace SWYRA
{
    public partial class FrmAjustePedido : Form
    {
        public string cve_doc = "";
        private Pedidos ped = new Pedidos();
        private List<DetallePedidos> lsDetallePedidos = new List<DetallePedidos>();
        private List<DetallePedidoMerc> lsDetPedMerc = new List<DetallePedidoMerc>();
        public Usuarios userActivo = new Usuarios();

        public FrmAjustePedido()
        {
            InitializeComponent();
        }

        private void FrmAjustePedido_Load(object sender, EventArgs e)
        {
            AjusteSaldos();
            CargaPedido();
            Cargadatos();
        }

        private void CargaPedido()
        {
            try
            {
                var query = "SELECT CVE_DOC, CVE_CLPV, p.STATUS, FECHA_DOC, FECHA_CANCELA, CAN_TOT,  IMP_TOT4, DES_TOT, COM_TOT, CONDICION, " +
                            "NUM_MONED, FECHAELAB, CONTADO, FORMAENVIO, IMPORTE, TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO, INDICACIONES, " +
                            "LOTE, PRIORIDAD, UbicacionEmpaque, OCURREDOMICILIO, c.NOMBRE Cliente, TotCajaCarton, TotCajaMadera, TotBultos, TotRollos, " +
                            "TotCubetas, TotAtados, TotTarimas, TotCostoGuias " +
                            "FROM PEDIDO p JOIN CLIENTE c ON p.CVE_CLPV = c.CLAVE WHERE(CVE_DOC = '" + cve_doc + "')";
                ped = GetDataTable("DB", query, 5).ToData<Pedidos>();
                query =
                    "SELECT dp.CVE_DOC, dp.NUM_PAR, dp.CVE_ART, CANT, PXS, PREC, COST, IMPU1, IMPU2, IMPU3, IMPU4, IMP1APLA, IMP2APLA, IMP3APLA, " +
                    "IMP4APLA, TOTIMP1, TOTIMP2, TOTIMP3, TOTIMP4, DESC1, DESC2, DESC3, COMI, APAR, ACT_INV, NUM_ALM, POLIT_APLI, TIP_CAM, " +
                    "UNI_VENTA, TIPO_PROD, CVE_OBS, REG_SERIE, E_LTPD, TIPO_ELEM, NUM_MOV, TOT_PARTIDA, IMPRIMIR, CANTSURTIDO, SURTIDO, res.Empaque, " +
                    "TDESC, SUBTO, TCOMI, i.DESCR, (SUBTO + TOTIMP4) IMPORTE FROM DETALLEPEDIDO dp JOIN INVENTARIO i ON dp.CVE_ART = i.CVE_ART " +

                    "LEFT JOIN ( select distinct CVE_DOC, NUM_PAR, STUFF((select ', ' + ('(' + CAST(SUM(d.CANT) AS VARCHAR(5)) + ') ' + e.Empaque) " + 
                    "from DETALLEPEDIDOMERC d join(select CVE_DOC, CONSEC, TIPOPAQUETE + ' ' + CAST(CONSEC_EMPAQUE AS VARCHAR(2)) Empaque " +
                    "from DETALLEPEDIDOMERC WHERE (CVE_DOC = '" + cve_doc + "') AND(ISNULL(CANCELADO, 0) = 0) AND(ISNULL(TIPOPAQUETE, '') " +
                    "NOT IN('', 'GUIA'))) as e on d.CVE_DOC = e.CVE_DOC and d.CONSEC_PADRE = e.CONSEC WHERE(d.CVE_DOC = '" + cve_doc + "') " +
                    "AND(ISNULL(CANCELADO, 0) = 0) AND(ISNULL(TIPOPAQUETE, '') IN('')) AND a.CVE_DOC = d.CVE_DOC and a.CVE_ART = d.CVE_ART " +
                    "group by e.Empaque, d.NUM_PAR order by d.NUM_PAR FOR XML PATH('')), 1, 1, '') as Empaque from DETALLEPEDIDOMERC as a " +
                    "where (a.CVE_DOC = '" + cve_doc + "') AND(NUM_PAR > 0) ) as res on dp.NUM_PAR = res.NUM_PAR " + 

                    "WHERE (dp.CVE_DOC = '" + cve_doc + "') AND (CANTSURTIDO > 0)";
                lsDetallePedidos = GetDataTable("DB", query, 6).ToList<DetallePedidos>();
                query =
                    "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, CANCELADO, TotArt, " + 
                    "CONSEC_EMPAQUE, CONSEC_PADRE_GUIA, CVE_ART_GUIA, PRECIO_GUIA, ASIG_PEDIDO_GUIA, NUM_GUIA FROM DETALLEPEDIDOMERC " +
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
            txtPrioridad.Text = ped.prioridad;
            txtUbicacion.Text = ped.ubicacionempaque;
            txtCajaCarton.Text = ped.totcajacarton.ToString();
            txtCajaMadera.Text = ped.totcajamadera.ToString();
            txtBulto.Text = ped.totbultos.ToString();
            txtRollo.Text = ped.totrollos.ToString();
            txtCubeta.Text = ped.totcubetas.ToString();
            txtAtados.Text = ped.totatados.ToString();
            txtTarimas.Text = ped.tottarimas.ToString();

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
    }
}
