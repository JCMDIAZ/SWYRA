using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using static SWYRA.General;

namespace SWYRA
{
    public partial class FrmRemision : Form
    {
        private bool sw = true;
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos pedido = new Pedidos();
        public Usuarios userActivo = new Usuarios();
        List<DetallePedidoMerc> listDetMerc = new List<DetallePedidoMerc>();

        public FrmRemision()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmRemision_Load(object sender, EventArgs e)
        {
            listPedidos = CargaPedidos();
            gridControl1.DataSource = listPedidos;
            gridView1.OptionsFind.AlwaysVisible = true;
            timer1.Start();
        }

        private List<Pedidos> CargaPedidos()
        {
            List<Pedidos> list = new List<Pedidos>();
            try
            {
                var query =
                    "SELECT  CVE_DOC, CVE_CLPV, FECHA_DOC, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, " +
                    "CONDICION, RFC, AUTORIZA, FOLIO, CONTADO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, TIPOSERVICIO, ESTATUSPEDIDO, COBRADOR_ASIGNADO, " +
                    "COBRADOR_AUTORIZO, uCobAsig.Nombre cobrador_asignado_n, uCobAut.Nombre cobrador_autorizo_n, cliente.NOMBRE CLIENTE, FECHAAUT, " +
                    "TotCajaCarton, TotCajaMadera, TotBultos, TotRollos, TotCubetas, TotAtados, TotTarimas, TotCostoGuias, OCURREDOMICILIO " +
                    "FROM PEDIDO p left join USUARIOS uCobAsig on uCobAsig.Usuario = p.COBRADOR_ASIGNADO " +
                    "left join USUARIOS uCobAut on uCobAut.Usuario = p.COBRADOR_AUTORIZO " +
                    "left join CLIENTE cliente on cliente.CLAVE = p.CVE_CLPV " +
                    "WHERE ESTATUSPEDIDO IN ('REMISION','FACTURACION') Order by CVE_DOC";
                list = GetDataTable("DB", query, 51).ToList<Pedidos>();}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && gridView1.RowCount > 0)
            {
                //popupMenu1.ShowPopup(MousePosition); --Deshabilitado temporalmente por el usuario
            }
        }

        private void bbPaqueteria_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            var fPaq = new FrmGeneraGuias();
            fPaq.cve_doc = cve_doc.ToString();
            fPaq.ShowDialog();
            fPaq.Close();
        }

        private void CargaDetallePedidoMercs(string cve_doc)
        {
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, d.CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, CANCELADO, TotArt, CONSEC_EMPAQUE, " +
                            "ISNULL(CONSEC_PADRE_GUIA,0) CONSEC_PADRE_GUIA, CVE_ART_GUIA, PRECIO_GUIA, ASIG_PEDIDO_GUIA, NUM_GUIA, i.DESCR " +
                            "FROM DETALLEPEDIDOMERC d LEFT JOIN INVENTARIO i ON i.CVE_ART = d.CVE_ART_GUIA " +
                            "WHERE CVE_DOC = '" + cve_doc + "' AND ISNULL(TIPOPAQUETE, '') <> '' " +
                            "AND ISNULL(CONSEC_PADRE, 0) = 0 AND ISNULL(CANCELADO, 0) = 0";
                listDetMerc = GetDataTable("DB", query, 1).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bbFacturacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            CargaDetallePedidoMercs(cve_doc.ToString());
            var lsPaquetes = listDetMerc.Where(o => o.consec_padre_guia == 0 && o.tipopaquete != "GUIA").ToList();
            if (lsPaquetes.Count == 0)
            {
                var fAjustePedido = new FrmAjustePedido();
                fAjustePedido.cve_doc = cve_doc.ToString();
                fAjustePedido.ShowDialog();
                fAjustePedido.Close();
                if (fAjustePedido.cve_doc == "")
                {
                    listPedidos = CargaPedidos();
                    gridControl1.DataSource = listPedidos;
                }
            }
            else
            {
                MessageBox.Show(@"Aún existen Paquetes sin asignar guías");
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            CargaDetallePedidoMercs(cve_doc.ToString());
            var lsPaquetes = listDetMerc.Where(o => o.consec_padre_guia == 0 && o.tipopaquete != "GUIA").ToList();
            //if (lsPaquetes.Count == 0) -- se quito temporalmente esta condición solicitado por el usuario.
            {
                var fAjustePedido = new FrmAjustePedido();
                fAjustePedido.cve_doc = cve_doc.ToString();
                fAjustePedido.userActivo = userActivo;
                fAjustePedido.ShowDialog();
                fAjustePedido.Close();
                if (fAjustePedido.cve_doc == "")
                {
                    listPedidos = CargaPedidos();
                    gridControl1.DataSource = listPedidos;
                }
            }
            /*else
            {
                MessageBox.Show(@"Aún existen Paquetes sin asignar guías");
            }*/
            timer1.Start();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            listPedidos = CargaPedidos();
            gridControl1.DataSource = listPedidos;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            listPedidos = CargaPedidos();
            gridControl1.DataSource = listPedidos;
            timer1.Start();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            try
            {
                var estatus = gridView1.GetRowCellValue(e.RowHandle, "estatuspedido");
                if (estatus != null)
                {
                    if (estatus.ToString() == "FACTURACION")
                    {
                        e.Appearance.BackColor = Color.Aqua;
                    }
                }
            }
            catch (Exception exception)
            {
                return;
            }
        }
    }
}