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
    public partial class FrmGeneraGuias : Form
    {
        public string cve_doc = "";

        List<DetallePedidoMerc> listDetMerc = new List<DetallePedidoMerc>();
        List<Inventario> listInv = new List<Inventario>();

        class Variables
        {
            public int consec { get; set; }
        }

        public FrmGeneraGuias()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmGeneraGuias_Load(object sender, EventArgs e)
        {
            listInv = CargaPaquetes();
            lsPaqueteria.Properties.DataSource = listInv;
            gcIndicacion.DataSource = CargaPedidos();
            ActualizaGrids();
            limpiar();
        }

        private void ActualizaGrids()
        {
            CargaDetallePedidoMercs();
            var lsPaquetes = listDetMerc.Where(o => o.consec_padre_guia == 0 && o.tipopaquete != "GUIA").ToList();
            gcPaquetes.DataSource = lsPaquetes;
            var lsguias = listDetMerc.Where(o => o.tipopaquete == "GUIA").ToList();
            gcGuias.DataSource = lsguias;
            var lsAsignados = listDetMerc.Where(o => o.consec_padre_guia == int.Parse(txtConsec.Text) && o.tipopaquete != "GUIA").ToList();
            gcAsiganado.DataSource = lsAsignados;
        }

        private void ActualizaGridsSG()
        {
            CargaDetallePedidoMercs();
            var lsPaquetes = listDetMerc.Where(o => o.consec_padre_guia == 0 && o.tipopaquete != "GUIA").ToList();
            gcPaquetes.DataSource = lsPaquetes;
            var lsAsignados = listDetMerc.Where(o => o.consec_padre_guia == int.Parse(txtConsec.Text) && o.tipopaquete != "GUIA").ToList();
            gcAsiganado.DataSource = lsAsignados;
        }

        private void CargaDetallePedidoMercs()
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

        private List<Inventario> CargaPaquetes()
        {
            List<Inventario> ls = new List<Inventario>();
            try
            {
                var query = "select i.CVE_ART, i.DESCR, isnull(p.PRECIO, 0.0) PRECIO " +
                            "from INVENTARIO i left join INVENTARIOPRECIOS p on i.CVE_ART = p.CVE_ART and p.cve_precio = 1 " +
                            "where UNI_MED = 'flete' ";
                ls = GetDataTable("DB", query, 2).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ls;
        }

        private List<DetallePedidos> CargaPedidos()
        {
            List<DetallePedidos> ls = new List<DetallePedidos>();
            try
            {
                var query = "select dp.CVE_ART cve_art, ic.DESCR descr, ic.COMENTARIO comen from DETALLEPEDIDO dp " +
                            "join INVENTARIOCOND ic on dp.CVE_ART = ic.CVE_ART " + 
                            "where CVE_DOC = '" + cve_doc + "'";
                ls = GetDataTable("DB", query, 8).ToList<DetallePedidos>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ls;
        }

        private void lsPaqueteria_EditValueChanged(object sender, EventArgs e)
        {
            if (lsPaqueteria.EditValue != null)
            {
                var inv = listInv.First(o => o.cve_art == lsPaqueteria.EditValue.ToString());
                lblDescr.Text = inv.descr;
                txtPrecio.EditValue = inv.precio;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtConsec.Text = "0";
            lsPaqueteria.EditValue = null;
            txtPrecio.EditValue = 0;
            lblDescr.Text = "";
            gcAsiganado.DataSource = null;
            gcAsiganado.Refresh();
            valbtn();
        }

        private void CargaDatos(int consec)
        {
            var det = listDetMerc.First(o => o.consec == consec);
            txtConsec.Text = det.consec.ToString() ;
            lsPaqueteria.EditValue = det.cve_art_guia;
            txtPrecio.EditValue = det.precio_guia;
            lblDescr.Text = det.descr;
            var lsAsignados = listDetMerc.Where(o => o.consec_padre_guia == int.Parse(txtConsec.Text) && o.tipopaquete != "GUIA").ToList();
            gcAsiganado.DataSource = lsAsignados;
            valbtn();
        }

        private void valbtn()
        {
            btnAgregar.Enabled = (txtConsec.Text != "0");
            btnQuitar.Enabled = (txtConsec.Text != "0");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = @"";
                if (txtConsec.Text == "0")
                {
                    Variables var1 = GetDataTable("DB", @"select (max(CONSEC) + 1) consec " + 
                                                         "from DETALLEPEDIDOMERC where CVE_DOC = '" + cve_doc + "'", 3).ToData<Variables>();
                    txtConsec.Text = var1.consec.ToString();
                    query =
                        @"INSERT DETALLEPEDIDOMERC (CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, TotArt, CVE_ART_GUIA, PRECIO_GUIA) " +
                        "VALUES ('" + cve_doc + "', " + var1.consec.ToString() + ", 0, '', '" + cve_doc.Trim() + "-" + var1.consec.ToString() + "', 0, 'GUIA', 0, '" + 
                        lsPaqueteria.EditValue.ToString() + "', " + txtPrecio.EditValue.ToString() + ")";
                }
                else
                {
                    query =
                        @"UPDATE DETALLEPEDIDOMERC SET CVE_ART_GUIA = '" + lsPaqueteria.EditValue.ToString() + "', " + "PRECIO_GUIA = " + txtPrecio.EditValue.ToString() +
                        " WHERE CVE_DOC = '" + cve_doc + "' AND CONSEC = " + txtConsec.Text;
                }
                var res = GetExecute("DB", query, 4);
                MessageBox.Show(@"Guardado satisfactoriamente.");
                ActualizaGrids();
                valbtn();
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (gvGuias.RowCount > 0 && txtConsec.Text != "0")
            {
                var consec = gvGuias.GetRowCellValue(gvGuias.FocusedRowHandle, "consec");
                var det = listDetMerc.First(o => o.consec.ToString() == consec.ToString());
                if (det.totart == 0)
                {
                    try
                    {
                        var query = @"UPDATE DETALLEPEDIDOMERC SET CANCELADO = 1 WHERE CVE_DOC = '" + cve_doc + "' AND CONSEC = " + consec.ToString();
                        var res = GetExecute("DB", query, 5);
                        MessageBox.Show(@"Cancelado satisfactoriamente.");
                        ActualizaGrids();
                        limpiar();
                    }
                    catch (Exception ms)
                    {
                        MessageBox.Show(ms.Message);
                    }
                }
                else
                {
                    MessageBox.Show(@"Esta guía contiene paquetes asignados, favor de quitar para poder cancelarlo.");
                }
            }
        }

        private void gvGuias_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GetGridGuia();
        }

        private void GetGridGuia()
        {
            if (gvGuias.RowCount > 0)
            {
                var consec = gvGuias.GetRowCellValue(gvGuias.FocusedRowHandle, "consec");
                CargaDatos(int.Parse(consec.ToString()));
            }
            else
            {
                limpiar();
            }
        }

        private void gvGuias_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            GetGridGuia();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (gvPaquetes.RowCount > 0)
            {
                Int32[] srh = gvPaquetes.GetSelectedRows();
                foreach (Int32 i in srh)
                {
                    var consec = gvPaquetes.GetRowCellValue(i, "consec");
                    try
                    {
                        var query = @"UPDATE DETALLEPEDIDOMERC SET CONSEC_PADRE_GUIA = " + txtConsec.Text +
                                    " WHERE CVE_DOC = '" + cve_doc + "' AND CONSEC = " + consec.ToString() +
                                    " UPDATE DETALLEPEDIDOMERC SET TotArt = TotArt + 1 WHERE CVE_DOC = '" + cve_doc +
                                    "' AND CONSEC = " + txtConsec.Text;
                        var res = GetExecute("DB", query, 6);
                    }
                    catch (Exception ms)
                    {
                        MessageBox.Show(ms.Message);
                    }
                }
                ActualizaGridsSG();
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (gvAsignado.RowCount > 0)
            {
                Int32[] srh = gvAsignado.GetSelectedRows();
                foreach (Int32 i in srh)
                {
                    var consec = gvAsignado.GetRowCellValue(i, "consec");
                    try
                    {
                        var query = @"UPDATE DETALLEPEDIDOMERC SET CONSEC_PADRE_GUIA = NULL  WHERE CVE_DOC = '" +
                                    cve_doc + "' AND CONSEC = " + consec.ToString() +
                                    " UPDATE DETALLEPEDIDOMERC SET TotArt = TotArt - 1 WHERE CVE_DOC = '" + cve_doc +
                                    "' AND CONSEC = " + txtConsec.Text;
                        var res = GetExecute("DB", query, 7);
                    }
                    catch (Exception ms)
                    {
                        MessageBox.Show(ms.Message);
                    }
                }
                ActualizaGridsSG();
            }
        }
    }
}
