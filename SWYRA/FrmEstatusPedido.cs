using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraBars;
using static SWYRA.General;

namespace SWYRA
{
    public partial class FrmEstatusPedido : Form
    {
        private bool sw = true;
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos pedido = new Pedidos();
        public Usuarios userActivo = new Usuarios();

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
                    "SELECT  TIP_DOC, CVE_DOC, CVE_CLPV, p.STATUS, DAT_MOSTR, p.CVE_VEND, CVE_PEDI, FECHA_DOC, FECHA_ENT, " +
                    "FECHA_VEN, FECHA_CANCELA, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, " +
                    "CONDICION, p.CVE_OBS, NUM_ALMA, ACT_CXC, ACT_COI, ENLAZADO, TIP_DOC_E, NUM_MONED, TIPCAMB, NUM_PAGOS, " +
                    "FECHAELAB, PRIMERPAGO, RFC, CTLPOL, ESCFD, AUTORIZA, SERIE, FOLIO, AUTOANIO, DAT_ENVIO, CONTADO, CVE_BITA, " +
                    "BLOQ, FORMAENVIO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, COM_TOT_PORC, METODODEPAGO, NUMCTAPAGO, TIP_DOC_ANT, " +
                    "DOC_ANT, TIP_DOC_SIG, DOC_SIG, TIPOSERVICIO, ESTATUSPEDIDO, OCURREDOMICILIO, COBRADOR_ASIGNADO, " +
                    "COBRADOR_AUTORIZO, SURTIDOR_ASIGNADO, EMPAQUETADOR_ASIGNADO, ETIQUETADOR_ASIGNADO, SURTIDOR_AREA, " +
                    "PORC_SURTIDO, PORC_EMPAQUE, INDICACIONES, LOTE, uCobAsig.Nombre cobrador_asignado_n, " +
                    "uCobAut.Nombre cobrador_autorizo_n, uSurAsig.Nombre surtidor_asignado_n, uEmpAsig.Nombre empaquetador_asignado_n, " +
                    "uEtiAsig.Nombre etiquetador_asignado_n, uSurArea.Nombre surtidor_area_n, cliente.NOMBRE CLIENTE, PRIORIDAD " +
                    "FROM PEDIDO p left join USUARIOS uCobAsig on uCobAsig.Usuario = p.COBRADOR_ASIGNADO " +
                    "left join USUARIOS uCobAut on uCobAut.Usuario = p.COBRADOR_AUTORIZO " +
                    "left join USUARIOS uSurAsig on uSurAsig.Usuario = p.SURTIDOR_ASIGNADO " +
                    "left join USUARIOS uEmpAsig on uEmpAsig.Usuario = p.EMPAQUETADOR_ASIGNADO " +
                    "left join USUARIOS uEtiAsig on uEtiAsig.Usuario = p.ETIQUETADOR_ASIGNADO " +
                    "left join USUARIOS uSurArea on uSurArea.Usuario = p.SURTIDOR_AREA " +
                    "left join CLIENTE cliente on cliente.CLAVE = p.CVE_CLPV " +
                    "WHERE p.FECHA_ENT between '" + fini.ToString("yyyyMMdd") + "' and '" + ffin.ToString("yyyyMMdd") +
                    "'";
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
            ppPrioridad.HidePopup();
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
    }
}
