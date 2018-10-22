using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars;
using static SWYRA.General;
using System.Net.Sockets;
using System.IO;
using DevExpress.XtraReports.UI;

namespace SWYRA
{
    public partial class FrmEstatusPedido : Form
    {
        private bool sw = true;
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos pedido = new Pedidos();
        public Usuarios userActivo = new Usuarios();

        private List<DetallePedidoMerc> lstPaquetes = new List<DetallePedidoMerc>();
        private List<DetallePedidoMerc> lstMercancia = new List<DetallePedidoMerc>();

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

        public FrmEstatusPedido()
        {
            InitializeComponent();
        }

        private void txtFechIni_TextChanged(object sender, EventArgs e)
        {
            if (sw)
            {
                sw = !sw;
                if (txtFechFin.Text == "")
                {
                    txtFechFin.DateTime = txtFechIni.DateTime.AddDays(1);
                }
                else if (txtFechFin.DateTime < txtFechIni.DateTime)
                {
                    txtFechFin.DateTime = txtFechIni.DateTime.AddDays(1);
                }
                FiltrarCarga();
                gridControl1.DataSource = listPedidos;
                sw = !sw;
            }
        }

        private void txtFechFin_TextChanged(object sender, EventArgs e)
        {
            if (sw)
            {
                sw = !sw;
                if (txtFechIni.Text == "")
                {
                    txtFechIni.DateTime = txtFechFin.DateTime.AddDays(-1);
                }
                else if (txtFechFin.DateTime < txtFechIni.DateTime)
                {
                    txtFechIni.DateTime = txtFechFin.DateTime.AddDays(-1);
                }
                FiltrarCarga();
                gridControl1.DataSource = listPedidos;
                sw = !sw;
            }
        }

        private void FrmEstatusPedido_Load(object sender, EventArgs e)
        {
            limpiarFiltro();
            validaFiltro();
            FiltrarCarga();
            gridControl1.DataSource = listPedidos;
            gridView1.OptionsFind.AlwaysVisible = true;
        }

        private void FiltrarCarga()
        {
            listPedidos = null;
            if (chkActual.Checked)
            {
                DateTime hoy = DateTime.Now;
                listPedidos = CargaPedidos(hoy.AddDays(-3), hoy.AddDays(1));
            }
            else
            {
                if (cbEstatusPed.Text != "" && txtFechIni.Text != "" && txtFechFin.Text != "")
                {
                    listPedidos = CargaPedidos(txtFechIni.DateTime, txtFechFin.DateTime);
                    if (cbEstatusPed.Text != @"TODOS")
                    {
                        listPedidos = listPedidos
                            .Where(o => o.estatuspedido == cbEstatusPed.Text)
                            .ToList();
                    }
                }
            }
        }

        private List<Pedidos> CargaPedidos(DateTime fini, DateTime ffin)
        {
            List<Pedidos> list = new List<Pedidos>();
            try
            {
                var query =
                    "declare @pedidos table (cve_doc varchar(20)) insert @pedidos (cve_doc) select CVE_DOC from PEDIDO " +
                    "WHERE FECHA_DOC between '" + fini.ToString("yyyyMMdd") + "' and '" + ffin.ToString("yyyyMMdd") + "' " +
                    "SELECT  TIP_DOC, p.CVE_DOC, CVE_CLPV, p.STATUS, DAT_MOSTR, p.CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, " +
                    "FECHA_VEN, FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, " +
                    "CONDICION, p.CVE_OBS, NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, " +
                    "FECHAELAB, PRIMERPAGO, RFC, CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, " +
                    "BLOQ, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, " +
                    "DOC_ANT, TIP_DOC_SIG, DOC_SIG, TIPOSERVICIO, ep.ESTATUSPEDIDO, OCURREDOMICILIO, COBRADOR_ASIGNADO, " +
                    "COBRADOR_AUTORIZO, SURTIDOR_ASIGNADO, EMPAQUETADOR_ASIGNADO, ETIQUETADOR_ASIGNADO, SURTIDOR_AREA, " +
                    "PORC_SURTIDO, PORC_EMPAQUE, INDICACIONES, LOTE, uCobAsig.Nombre cobrador_asignado_n, det.porc_surtidoReal, " +
                    "uCobAut.Nombre cobrador_autorizo_n, uSurAsig.Nombre surtidor_asignado_n, uEmpAsig.Nombre empaquetador_asignado_n, " +
                    "uEtiAsig.Nombre etiquetador_asignado_n, uSurArea.Nombre surtidor_area_n, cliente.NOMBRE CLIENTE, PRIORIDAD, NOMBRE_VENDEDOR, " +
                    "uCapturo.Nombre capturo_n, CONSIGNACION, ISNULL(FLT,FLETE) FLETE, FLETE2, ENVIAR, CAUSADETENIDO, " +
                    "(CALLE + ' # ' + NUMEXT + ' COL. ' + COLONIA) direccion1, ('C.P. ' + CODIGO + '; ' + MUNICIPIO + ', ' + ESTADO) direccion2, " +
                    "STUFF((select ',' + UbicacionEmpaque from PEDIDO_Ubicacion u where u.CVE_DOC = p.CVE_DOC FOR XML PATH('')), 1, 1, '') UbicacionEmpaque, " +
                    "FLETE, TotCajaCarton, TotCajaMadera, TotBultos, TotRollos, TotCubetas, TotAtados, TotTarimas, " +
                    "(TotCajaCarton + TotCajaMadera + TotBultos + TotRollos + TotCubetas + TotAtados + TotTarimas) Remitentes " +
                    "FROM PEDIDO p left join (select cve_doc, ((SUM(isnull(CANTSURTIDO, 0)) / sum(CANT)) * 100.0) porc_surtidoReal from DETALLEPEDIDO " +
                    "where CVE_DOC in (select CVE_DOC from @pedidos) group by cve_doc) as det on p.cve_doc = det.cve_doc " +
                    "left join vw_estatuspedido ep on ep.CVE_DOC = p.CVE_DOC " +
                    "left join USUARIOS uCobAsig on uCobAsig.Usuario = p.COBRADOR_ASIGNADO " +
                    "left join USUARIOS uCobAut on uCobAut.Usuario = p.COBRADOR_AUTORIZO " +
                    "left join USUARIOS uSurAsig on uSurAsig.Usuario = p.SURTIDOR_ASIGNADO " +
                    "left join USUARIOS uEmpAsig on uEmpAsig.Usuario = p.EMPAQUETADOR_ASIGNADO " +
                    "left join USUARIOS uEtiAsig on uEtiAsig.Usuario = p.ETIQUETADOR_ASIGNADO " +
                    "left join USUARIOS uSurArea on uSurArea.Usuario = p.SURTIDOR_AREA " +
                    "left join USUARIOS uCapturo on uCapturo.Usuario = p.CAPTURO " +
                    "left join CLIENTE cliente on cliente.CLAVE = p.CVE_CLPV " +
                    "WHERE FECHA_DOC between '" + fini.ToString("yyyyMMdd") + "' and '" + ffin.ToString("yyyyMMdd") + "' " +
                    "ORDER BY p.CVE_DOC DESC";
                list = GetDataTable("DB", query, 51).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        private void ActualizaPedido()
        {
            try
            {
                pedido.indicaciones = pedido.indicaciones ?? "";
                var query = "UPDATE PEDIDO SET TIPOSERVICIO = '" + pedido.tiposervicio + "', " +
                            "PRIORIDAD = '" + pedido.prioridad + "', " +
                            "OCURREDOMICILIO = '" + pedido.ocurredomicilio + "', " +
                            "INDICACIONES = '" + pedido.indicaciones.Replace("'", "") + "' " +
                            "WHERE CVE_DOC = '" + pedido.cve_doc + "'";
                var res = GetExecute("DB", query, 52);
                MessageBox.Show(@"Guardado satisfactoriamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void limpiarFiltro()
        {
            cbEstatusPed.SelectedIndex = -1;
            sw = !sw;
            txtFechIni.Text = "";
            txtFechFin.Text = "";
            sw = !sw;
        }

        private void validaFiltro()
        {
            cbEstatusPed.Enabled = !chkActual.Checked;
            txtFechIni.Enabled = !chkActual.Checked;
            txtFechFin.Enabled = !chkActual.Checked;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkActual_CheckedChanged(object sender, EventArgs e)
        {
            if (sw)
            {
                limpiarFiltro();
                validaFiltro();
                FiltrarCarga();
                gridControl1.DataSource = listPedidos;
            }
        }

        private void cbEstatusPed_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sw)
            {
                FiltrarCarga();
                gridControl1.DataSource = listPedidos;
            }
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && gridView1.RowCount > 0 && userActivo.Categoria.TrimEnd() == "MASTER")
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            pedido = listPedidos.Where(o => o.cve_doc == cve_doc).FirstOrDefault();
            Rectangle rect = Screen.GetWorkingArea(this);
            Point point = new Point(rect.Width / 2 - ppTipoServicio.Width / 2,
                rect.Height / 2 - ppTipoServicio.Height / 2);
            cbTipoServicio.EditValue = pedido.tiposervicio;
            ppTipoServicio.ShowPopup(point);
            popupMenu1.HidePopup();
        }

        private void BtnAceptarTS_Click(object sender, EventArgs e)
        {
            pedido.tiposervicio = cbTipoServicio.Text;
            gridControl1.RefreshDataSource();
            ppTipoServicio.HidePopup();
            ActualizaPedido();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            pedido = listPedidos.Where(o => o.cve_doc == cve_doc).FirstOrDefault();
            Rectangle rect = Screen.GetWorkingArea(this);
            Point point = new Point(rect.Width / 2 - ppTipoServicio.Width / 2,
                rect.Height / 2 - ppTipoServicio.Height / 2);
            cbPrioridad.EditValue = pedido.prioridad;
            ppPrioridad.ShowPopup(point);
            popupMenu1.HidePopup();
        }

        private void BtnAceptarPR_Click(object sender, EventArgs e)
        {
            pedido.prioridad = cbPrioridad.Text;
            gridControl1.RefreshDataSource();
            ppPrioridad.HidePopup();
            ActualizaPedido();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            pedido = listPedidos.Where(o => o.cve_doc == cve_doc).FirstOrDefault();
            Rectangle rect = Screen.GetWorkingArea(this);
            Point point = new Point(rect.Width / 2 - ppTipoServicio.Width / 2,
                rect.Height / 2 - ppTipoServicio.Height / 2);
            cbEntrega.EditValue = pedido.ocurredomicilio;
            ppEntrega.ShowPopup(point);
            popupMenu1.HidePopup();
        }

        private void BtnAceptarEN_Click(object sender, EventArgs e)
        {
            pedido.ocurredomicilio = cbEntrega.Text;
            gridControl1.RefreshDataSource();
            ppEntrega.HidePopup();
            ActualizaPedido();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            pedido = listPedidos.Where(o => o.cve_doc == cve_doc).FirstOrDefault();
            Rectangle rect = Screen.GetWorkingArea(this);
            Point point = new Point(rect.Width / 2 - ppIndicaciones.Width / 2,
                rect.Height / 2 - ppIndicaciones.Height / 2);
            txtIndicaciones.Text = pedido.indicaciones;
            ppIndicaciones.ShowPopup(point);
            popupMenu1.HidePopup();
        }

        private void BtnAceptarIN_Click(object sender, EventArgs e)
        {
            pedido.indicaciones = txtIndicaciones.Text;
            gridControl1.RefreshDataSource();
            ppIndicaciones.HidePopup();
            ActualizaPedido();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = @"xlsx Excel (*.xlsx)|*.xlsx";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gridControl1.ExportToXlsx(sfd.FileName);
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            var cveDoc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            if (cveDoc != null)
            {
                var fAjustePedido = new FrmAjustePedido();
                fAjustePedido.btnGuardar.Visible = false;
                fAjustePedido.cve_doc = cveDoc.ToString();
                fAjustePedido.userActivo = userActivo;
                fAjustePedido.ShowDialog();
                fAjustePedido.Close();
            }}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FiltrarCarga();
            gridControl1.DataSource = listPedidos;
        }

        private void cargaPaquetes(string cve_doc)
        {
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, cast(ULTIMO as varchar(5)) ULTIMO,  CANCELADO, TOTART, CONSEC_EMPAQUE " +
                            "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + cve_doc + "') AND (CODIGO_BARRA <> '') " +
                            "AND (ISNULL(CANCELADO, 0) = 0) AND (TIPOPAQUETE IS NOT NULL) AND (CONSEC_PADRE IS NULL) ORDER BY CONSEC DESC";
                lstPaquetes = GetDataTable("DB", query, 40).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cargaDetalleMerc(string cve_doc)
        {
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, d.CVE_ART, i.DESCR, CANT, cast(case when CONSEC_PADRE is null then 'NO' else 'SI' END as varchar(5)) ULTIMO " +
                            "FROM DETALLEPEDIDOMERC d JOIN INVENTARIO i ON i.CVE_ART = d.CVE_ART WHERE (LTRIM(CVE_DOC) = '" + cve_doc + "') " +
                            " AND (CODIGO_BARRA <> '') AND (ISNULL(CANCELADO, 0) = 0) AND (TIPOPAQUETE IS NULL) ORDER BY CONSEC DESC";
                lstMercancia = GetDataTable("DB", query, 41).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<DetallePedidoMerc> cargaDetPaquetes(string cvedoc, int consec, bool ult, string tipopaq)
        {
            List<DetallePedidoMerc> ls = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CVE_DOC, MAX(CONSEC) CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, sum(CANT) CANT, TIPOPAQUETE, CONSEC_PADRE, NULL ULTIMO, isnull(CANCELADO,0) CANCELADO, TOTART, CONSEC_EMPAQUE " +
                    "FROM DETALLEPEDIDOMERC WHERE (LTRIM(CVE_DOC) = '" + cvedoc.Trim() + "') AND (CODIGO_BARRA <> '') AND (CONSEC_PADRE = " + consec + ") " + ((ult && tipopaq != "TARIMA") ? "AND CANT > 0" : "") +
                    "GROUP BY CVE_DOC, NUM_PAR, CVE_ART, CODIGO_BARRA, TIPOPAQUETE, CONSEC_PADRE, isnull(CANCELADO,0), TOTART, CONSEC_EMPAQUE ORDER BY CONSEC";
                ls = GetDataTable("DB", query, 42).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ls;
        }

        private string GeneraEtiqueta(string cve_doc)
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
                var clt = "(" + pedido.cve_clpv + ") " + pedido.cliente;
                var aju = (clt.Length < 40) ? 30 : ((clt.Length < 50) ? 27 : ((clt.Length < 60) ? 24 : 21));
                var tam = pedido.consignacion.Length;
                DatosPedido =
                    "^FO10,78^GB760,160,1,,2^FS" +
                    "^FO20,85^A0,30,25^FDNum.Pedido :^FS" +
                    "^FO160,85^A0,30,30^FD" + pedido.cve_doc.Trim() + "^FS" +
                    "^FO405,85^A0,30,25^FDFecha :^FS" +
                    "^FO555,85^A0,30,30^FD" + pedido.fecha_ent.ToString("dd / MM / yyyy") + "^FS" +
                    "^FO20,110^A0,30,25^FDCliente :^FS" +
                    "^FO160,110^A0,30," + aju + "^FD" + clt + "^FS" +
                    "^FO20,135^A0,30,25^FDDireccion :^FS" +
                    ((pedido.enviar == "") ?
                    "^FO160,135^A0,30,20^FD" + pedido.direccion1 + "^FS" +
                    "^FO160,160^A0,30,20^FD" + pedido.direccion2 + "^FS" :
                    "^FO160,135^A0,30,20^FD" + pedido.consignacion.Substring(0, (tam < 61 ? tam : 60)) + "^FS" +
                    (tam < 61 ? "" : "^FO160,160^A0,30,20^FD" + pedido.consignacion.Substring(60) + "^FS")) +
                    "^FO20,185^A0,30,25^FDFlete :^FS" +
                    "^FO160,185^A0,30,30^FD" + pedido.flete + "^FS" +
                    "^FO405,185^A0,30,25^FDFlete 2 :^FS" +
                    "^FO555,185^A0,30,30^FD" + pedido.flete2 + "^FS" +
                    "^FO20,210^A0,30,25^FDOcrr / Dom :^FS" +
                    "^FO160,210^A0,30,30^FD" + pedido.ocurredomicilio + "^FS" +
                    "^FO405,210^A0,30,25^FDOrden Comp. :^FS" +
                    "^FO555,210^A0,30,30^FD" + pedido.cve_pedi + "^FS";

                contado = (pedido.contado == "S") ? "CONTADO" : "";
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
                MessageBox.Show(ex.Message);
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

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc").ToString();
            pedido = listPedidos.Where(o => o.cve_doc == cve_doc).FirstOrDefault();

            if (pedido.estatuspedido == "REMISION" || pedido.estatuspedido == "LEVANTAMIENTO" || pedido.estatuspedido == "GUIA" || pedido.estatuspedido == "DETENIDO GUIA" ||
                pedido.estatuspedido == "INGRESEAR GUIA" || pedido.estatuspedido == "TERMINADO")
            {
                cargaPaquetes(cve_doc.Trim());
                cargaDetalleMerc(cve_doc.Trim());

                // Printer IP Address and communication port
                string ipAddress = ipImpEti;
                int port = 9100;

                // ZPL Command(s)
                string ZPLString = GeneraEtiqueta(cve_doc);

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
                    MessageBox.Show(@"Impresión exitosa, favor de validar");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"Impresora no disponible, favor de validar");
                    return;
                }
            }
            else
            {
                MessageBox.Show(@"Solo puede imprimirse en estos estatus REMISION, LEVANTAMIENTO, INGRESAR GUIA");
            }
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc").ToString();
            try
            {
                var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'TERMINADO' " +
                            "WHERE CVE_DOC = '" + cve_doc + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                            cve_doc + "', 'TERMINADO', getdate(), '" + userActivo.Usuario.ToString()  + "')";
                var res = GetExecute("DB", query, 52);
                MessageBox.Show(@"Cambiado satisfactoriamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc").ToString();
            var ped = listPedidos.Where(o => o.cve_doc == cve_doc).ToList();
            List<PedidoHist> hist = cargaPedidoHist(cve_doc.Trim());
            ReporteHistorial rh = new ReporteHistorial();
            rh.bindingSource1.DataSource = hist;
            rh.bindingSource2.DataSource = ped;
            rh.ShowPreview();
        }

        private List<PedidoHist> cargaPedidoHist(string cvedoc)
        {
            List<PedidoHist> ls = new List<PedidoHist>();
            try
            {
                var query = "select p.*, u.Nombre from PEDIDO_HIST p " +
                            "left join USUARIOS u on p.USUARIO = u.Usuario " +
                             "where LTRIM(CVE_DOC) = '" + cvedoc + "' " +
                             "order by FECHAMOV desc";
                ls = GetDataTable("DB", query, 52).ToList<PedidoHist>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ls;
        }
    }
}
