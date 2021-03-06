﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static SWYRA.General;
using System.Drawing;
using DevExpress.XtraPrinting.Native.Lines;

namespace SWYRA
{
    public partial class FrmAutorizaCobro : Form
    {
        private bool sw = true;
        private List<Pedidos> listPedidos = new List<Pedidos>();
        private Pedidos pedido = new Pedidos();
        public Usuarios userActivo = new Usuarios();

        public FrmAutorizaCobro()
        {
            InitializeComponent();
        }

        private void FrmAutorizaCobro_Load(object sender, EventArgs e)
        {
            FiltrarCarga();
            gridControl1.DataSource = listPedidos;
            gridView1.OptionsFind.AlwaysVisible = true;
        }

        private void FiltrarCarga()
        {
            listPedidos = null;
            listPedidos = CargaPedidos(tsTodos.IsOn);
        }

        private List<Pedidos> CargaPedidos(bool cond)
        {
            List<Pedidos> list = new List<Pedidos>();
            try
            {
                var query =
                    "SELECT  CVE_DOC, CVE_CLPV, FECHA_ENT, CAN_TOT, IMP_TOT1, IMP_TOT2, IMP_TOT3, IMP_TOT4, DES_TOT, DES_FIN, COM_TOT, FECHA_DOC, " +
                    "CONDICION, RFC, AUTORIZA, FOLIO, CONTADO, DES_FIN_PORC, DES_TOT_PORC, IMPORTE, TIPOSERVICIO, ESTATUSPEDIDO, COBRADOR_ASIGNADO, OBSERVACIONES, " +
                    "COBRADOR_AUTORIZO, uCobAsig.Nombre cobrador_asignado_n, uCobAut.Nombre cobrador_autorizo_n, cliente.NOMBRE CLIENTE, FECHAAUT, des_tot_porc " +
                    "FROM PEDIDO p left join USUARIOS uCobAsig on uCobAsig.Usuario = p.COBRADOR_ASIGNADO " +
                    "left join USUARIOS uCobAut on uCobAut.Usuario = p.COBRADOR_AUTORIZO " +
                    "left join CLIENTE cliente on cliente.CLAVE = p.CVE_CLPV " +
                    "WHERE COBRADOR_ASIGNADO " + (!cond ? "=" : "<>") + " '" + userActivo.Usuario + "' " +
                    "AND ESTATUSPEDIDO = 'AUTORIZACION'";
                list = GetDataTable("DB", query, 51).ToList<Pedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return list;
        }

        private void tsTodos_Toggled(object sender, EventArgs e)
        {
            FiltrarCarga();
            gridControl1.DataSource = listPedidos;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridControl1_MouseDown(object sender, MouseEventArgs e)
        {
            string[] param = {"MASTER", "COBRADOR"};
            if (e.Button == MouseButtons.Right && gridView1.RowCount > 0 && userActivo.Categoria.TrimEnd().In(param))
            {
                popupMenu1.ShowPopup(MousePosition);
            }
        }

        private void ActualizaPedido()
        {
            try
            {
                var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = '" + pedido.estatuspedido + "', " +
                            "FECHA_CANCELA = " + ((pedido.estatuspedido == "PORCANCELAR") ? "GETDATE()" : "Null") + ", " +
                            "FECHAAUT = " + ((pedido.estatuspedido == "SURTIR") ? "GETDATE()" : "Null") + ", " +
                            (pedido.indicaciones == null ? "" : "INDICACIONES = '" + pedido.indicaciones.Replace("'", "") + "', ") + 
                            "CONTADO = '" + pedido.contado + "', " +
                            "COBRADOR_AUTORIZO = '" + pedido.cobrador_autorizo + "' " +
                            "WHERE CVE_DOC = '" + pedido.cve_doc + "'";
                var res = GetExecute("DB", query, 52);
                query = "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values ('" +
                        pedido.cve_doc + "', '" + pedido.estatuspedido + "', getdate(), '" + userActivo.Usuario + "')";
                res = GetExecute("DB", query, 53);
                MessageBox.Show(@"Guardado satisfactoriamente.");
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool validaDuplicidad()
        {
            bool m = false;
            try
            {
                var query = "select CVE_DOC, CVE_ART  from DETALLEPEDIDO WHERE LTRIM(CVE_DOC) = '" + pedido.cve_doc.Trim() + "' " +
                            "GROUP BY CVE_DOC, CVE_ART HAVING COUNT(CVE_ART) > 1";
                List<DetallePedidos> res = GetDataTable("DB", query, 52).ToList<DetallePedidos>();
                if (res.Count > 0)
                {
                    var dt = res.First();
                    MessageBox.Show(@"Existe duplicidad en el Pedido " + pedido.cve_doc.Trim() + @" clave del artículo " + dt.cve_art);
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
                            "where cast(dp.CANT as int) % cast(i.UNI_EMP as int) <> 0 and ltrim(CVE_DOC) = '" + pedido.cve_doc.Trim() + "' ";
                List<DetallePedidos> res = GetDataTable("DB", query, 52).ToList<DetallePedidos>();
                if (res.Count > 0)
                {
                    var dt = res.First();
                    MessageBox.Show(dt.cve_art + @" no cumple con el multiplo de venta, favor de solicitar a asistente su modificación.");
                    m = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return m;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupMenu1.HidePopup();
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            pedido = listPedidos.FirstOrDefault(o => o.cve_doc == cve_doc);
            if (validaDuplicidad()) { return; }
            if (validaMinMultiplo()) { return; }
            DialogResult dialogResult = MessageBox.Show(@"¿Esta seguro de AUTORIZAR el pedido " + pedido.cve_doc.Trim() + @"?",
                @"AUTORIZAR", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pedido.estatuspedido = "SURTIR";
                pedido.fechaaut = DateTime.Now;
                pedido.cobrador_autorizo = userActivo.Usuario;
                pedido.cobrador_autorizo_n = userActivo.Nombre;
                ActualizaPedido();
                FiltrarCarga();
                gridControl1.DataSource = listPedidos;
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupMenu1.HidePopup();
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            pedido = listPedidos.FirstOrDefault(o => o.cve_doc == cve_doc);
            if (validaDuplicidad()) { return; }
            if (validaMinMultiplo()) { return; }
            DialogResult dialogResult = MessageBox.Show(@"¿Esta seguro de AUTORIZAR DE CONTADO el pedido " + pedido.cve_doc.Trim() + @"?",
                @"AUTORIZAR CONTADO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pedido.estatuspedido = "SURTIR";
                pedido.fechaaut = DateTime.Now;
                pedido.cobrador_autorizo = userActivo.Usuario;
                pedido.cobrador_autorizo_n = userActivo.Nombre;
                pedido.contado = "S";
                ActualizaPedido();
                FiltrarCarga();
                gridControl1.DataSource = listPedidos;
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var cve_doc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            pedido = listPedidos.Where(o => o.cve_doc == cve_doc).FirstOrDefault();
            Rectangle rect = Screen.GetWorkingArea(this);
            Point point = new Point(rect.Width / 2 - ppIndicaciones.Width / 2, rect.Height / 2 - ppIndicaciones.Height / 2);
            txtIndicaciones.Text = pedido.indicaciones;
            ppIndicaciones.ShowPopup(point);
            popupMenu1.HidePopup();
        }

        private void BtnAceptarIN_Click(object sender, EventArgs e)
        {
            ppIndicaciones.HidePopup();
            DialogResult dialogResult = MessageBox.Show(@"¿Esta seguro de cancelar el pedido " + pedido.cve_doc.Trim() + @"?",
                @"CANCELAR", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pedido.estatuspedido = "PORCANCELAR";
                pedido.fecha_cancela = DateTime.Now;
                pedido.cobrador_autorizo = userActivo.Usuario;
                pedido.cobrador_autorizo_n = userActivo.Nombre;
                ActualizaPedido();
                FiltrarCarga();
                gridControl1.DataSource = listPedidos;
            }
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            var cveDoc = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_doc");
            var fAjustePedido = new FrmAjustePedido();
            fAjustePedido.btnGuardar.Visible = false;
            fAjustePedido.cve_doc = cveDoc.ToString();
            fAjustePedido.userActivo = userActivo;
            fAjustePedido.ShowDialog();
            fAjustePedido.Close();
        }
    }
}
