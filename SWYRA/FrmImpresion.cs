using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using static SWYRA.General;

namespace SWYRA
{
    public partial class FrmImpresion : Form
    {
        private List<Impresion> lstImpresiones = new List<Impresion>();
        public Usuarios userActivo = new Usuarios();

        public FrmImpresion()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmImpresion_Load(object sender, EventArgs e)
        {
            if (!tsTodos.IsOn)
            {
                timer1.Start();
            }
            FiltrarCarga();
        }

        private void FiltrarCarga()
        {
            btnImprimir.Visible = tsTodos.IsOn;
            lstImpresiones = null;
            lstImpresiones = CargaImpresiones(tsTodos.IsOn);
            gridControl1.DataSource = lstImpresiones;
        }

        private List<Impresion> CargaImpresiones(bool cond)
        {
            List<Impresion> list = new List<Impresion>();
            try
            {
                var query =
                    "SELECT ID, FECHA, CVE_DOC, CVE_IMP, IMPRESION, REALIZADO " +
                    "FROM IMPRESION WHERE ISNULL(REALIZADO,0) = " + (cond ? "1" : "0");
                list = GetDataTable("DB", query, 1).ToList<Impresion>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        private void tsTodos_Toggled(object sender, EventArgs e)
        {
            if (!tsTodos.IsOn)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
            FiltrarCarga();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            if (lstImpresiones.Count > 0)
            {
                var imp = lstImpresiones.FirstOrDefault();
                imprimir(imp);
            }
            FiltrarCarga();
            timer1.Start();
        }

        private void imprimir(Impresion imp)
        {
            List<Pedidos> ped = CargaPedido(imp.cve_doc);
            foreach (var pd in ped)
            {
                string[] rs = pd.condicion.Split(';');
                pd.condicion = rs[rs.Length -1];
            }
            List<DetallePedidoMerc> det = CargaDetalle(imp.cve_doc);
            XtraReport1 rpt1 = new XtraReport1();
            rpt1.DataSource = ped;
            XtraReport1_Detalle det1 = new XtraReport1_Detalle();
            det1.DataSource = det;
            rpt1.xrSubreport1.ReportSource = det1;
            rpt1.Print();
            ModificarImpresion(imp.id.ToString());
        }

        private List<Pedidos> CargaPedido(string cvedoc)
        {
            List<Pedidos> peds = new List<Pedidos>();
            try
            {
                var query =
                    "declare @porc float " + 
                    "select @porc = (SUM(CANTSURTIDO) / sum(CANT)) * 1 from DETALLEPEDIDO " +
                    "where CVE_DOC = '" + cvedoc + "' " +
                    "declare @fech datetime " +
                    "select TOP 1 @fech = FECHAMOV from PEDIDO_HIST " +
                    "where CVE_DOC = '" + cvedoc + "' and ESTATUSPEDIDO = 'SURTIENDO' order by FECHAMOV " +
                    "SELECT  CVE_DOC, CVE_CLPV, @fech FECHA_DOC, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, p.CVE_VEND, OBSERVACIONES, " +
                    "CONDICION, RFC, AUTORIZA, FOLIO, CONTADO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, TIPOSERVICIO, ESTATUSPEDIDO, COBRADOR_ASIGNADO, @porc porc_surtido, " +
                    "COBRADOR_AUTORIZO, uCobAsig.Nombre cobrador_asignado_n, uCobAut.Nombre cobrador_autorizo_n, uSurAsig.Nombre surtidor_asignado_n, cliente.NOMBRE CLIENTE, FECHAAUT, " +
                    "TotCajaCarton, TotCajaMadera, TotBultos, TotRollos, TotCubetas, TotAtados, TotTarimas, TotCostoGuias, OCURREDOMICILIO, p.NOMBRE_VENDEDOR, CONSIGNACION, " +
                    "STUFF((select ',' + UbicacionEmpaque from PEDIDO_Ubicacion u where u.CVE_DOC = p.CVE_DOC FOR XML PATH('')), 1, 1, '') UbicacionEmpaque, p.ENVIAR " +
                    "FROM PEDIDO p left join USUARIOS uCobAsig on uCobAsig.Usuario = p.COBRADOR_ASIGNADO " +
                    "left join USUARIOS uCobAut on uCobAut.Usuario = p.COBRADOR_AUTORIZO " +
                    "left join USUARIOS uSurAsig on uSurAsig.Usuario = p.SURTIDOR_ASIGNADO " +
                    "left join CLIENTE cliente on cliente.CLAVE = p.CVE_CLPV " +
                    "WHERE CVE_DOC = '" + cvedoc + "'";
                peds = GetDataTable("DB", query, 2).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return peds;
        }
        private List<DetallePedidoMerc> CargaDetalle(string cvedoc)
        {
            List<DetallePedidoMerc> dets = new List<DetallePedidoMerc>();
            try
            {
                var query =
                    "SELECT CVE_DOC, d.CVE_ART, CODIGO_BARRA, SUM(CANT) CANT, i.DESCR, SUM(ISNULL(PEND,0)) FALTAN " +
                    "FROM DETALLEPEDIDOMERC d LEFT JOIN INVENTARIO i ON d.CVE_ART = i.CVE_ART " +
                    "WHERE ISNULL(TIPOPAQUETE,'') = '' AND ISNULL(CANCELADO,0) = 0 AND CVE_DOC = '" + cvedoc + "' " +
                    "GROUP BY CVE_DOC, d.CVE_ART, CODIGO_BARRA, i.DESCR " +
                    "ORDER BY d.CVE_ART";
                dets = GetDataTable("DB", query, 3).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dets;
        }

        private void ModificarImpresion(string id)
        {
            try
            {
                var query =
                    "UPDATE IMPRESION SET REALIZADO = 1 " +
                    "WHERE ID = " + id;
                var res = GetDataTable("DB", query, 3).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (lstImpresiones.Count > 0)
            {
                var id = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id");
                var imp = lstImpresiones.Find(o => o.id == id);
                imprimir(imp);
            }
        }
    }
}
