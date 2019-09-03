using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWYRA_Movil
{
    public partial class FrmCancelacion : Form
    {
        public bool Area = false;
        public Pedidos ped = new Pedidos();
        public List<DetallePedidos> det = new List<DetallePedidos>();
        public List<DetallePedidos> mostrardet = new List<DetallePedidos>();
        private CodigosBarra cod = new CodigosBarra();
        private DetallePedidos art = new DetallePedidos();
        private DetallePedidos artFirst = new DetallePedidos();
        private DetallePedidos artLast = new DetallePedidos();
        private string lastCB;
        private List<OrdenUbicacion> orbi = new List<OrdenUbicacion>();
        private List<DetallePedidoMerc> merc = new List<DetallePedidoMerc>();
        private List<DetallePedidoMerc> detmerc = new List<DetallePedidoMerc>();
        private DetallePedidoMerc mrc = new DetallePedidoMerc();
        private double maxvalue = 0.0;

        public FrmCancelacion()
        {
            InitializeComponent();
        }

        private void pbAnt_Click(object sender, EventArgs e)
        {
            if (art != null)
            {
                if (art.num_par == artFirst.num_par)
                {
                    art = artLast;
                }
                else
                {
                    art = Program.GetPrevious<DetallePedidos>(mostrardet, art);
                }
                cargaDatos();
            }
        }

        private void pbSig_Click(object sender, EventArgs e)
        {
            if (art != null)
            {
                if (art.num_par == artLast.num_par)
                {
                    art = artFirst;
                }
                else
                {
                    art = Program.GetNext<DetallePedidos>(mostrardet, art);
                }
                cargaDatos();
            }
        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                if (!txtCant.ReadOnly)
                {
                    if ((double)txtCant.Value > art.cantdiferencia)
                    {
                        txtCant.Value = (decimal)art.cantdiferencia;
                        MessageBox.Show(@"Artículo excede a la cantidad devuelta.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        txtCant.ReadOnly = true;
                        txtCodigo.Text = "";
                        txtCodigo.Focus();
                        e.Handled = true;
                    }
                }
            }*/
        }

        private void txtCant_LostFocus(object sender, EventArgs e)
        {
            //actualizaDet();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                txtMinimo.Focus();
                e.Handled = true;
            }
        }

        private void txtCodigo_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                return;
            }
            lastCB = txtCodigo.Text;
            txtCant.Value = 1; ;
            try
            {
                var str = txtCodigo.Text.Split('-');
                var query = "SELECT CVE_ART, CANT_PIEZAS, CODIGO_BARRA FROM vw_codigosBarras " +
                             "WHERE CODIGO_BARRA = '" + str[0] + "'";
                cod = Program.GetDataTable(query, 1).ToData<CodigosBarra>();
                if (str.Length == 2)
                {
                    txtCodigo.Text = str[0];
                    cod.cant_piezas = Convert.ToInt32(str[1]);
                }
                if (cod != null && str.Length <= 2)
                {
                    try
                    {
                        if (art.cve_art != cod.cve_art)
                        {
                            MessageBox.Show(@"Código NO coincide con el artículo a devolver", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            var tot = detmerc.Count(o => o.codigo_barra == txtCodigo.Text);
                            if (tot == 0)
                            {
                                MessageBox.Show(@"Artículo no registrado en la lista del surtido", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                txtCodigo.Focus();
                            }
                            else if (tot >= 1)
                            {
                                txtCant.Value = cod.cant_piezas;
                                mrc = detmerc.Find(o => o.codigo_barra == txtCodigo.Text && (o.cancelado == null || o.cancelado == false));
                                if (mrc.presentacion >= maxvalue)
                                {
                                    mrc.cant = mrc.cant - cod.cant_piezas;
                                    mrc.cancelado = (mrc.cant <= 0);
                                    actualizaDet();
                                }
                                else
                                {
                                    MessageBox.Show(@"Favor de quitar primero el de mayor presentación.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                    txtCodigo.Focus();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Artículo NO ASIGNADO al pedido.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show(@"Código de Barra INEXISTENTE, favor de validar.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            if (txtCant.ReadOnly)
            {
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
        }

        private void actualizaDet()
        {
            var query = "";
            try
            {
                if (ValidaCambios())
                {
                    MessageBox.Show("Existen cambios en el PEDIDO, por lo que el último movimiento no se registro, se regresara al menú anterior", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Close();
                    return;
                }
                if (txtCant.ReadOnly)
                {
                    query = "UPDATE DETALLEPEDIDOMERC SET Cancelado = " + (mrc.cancelado ? "1" : "0") + ", " +
                            "CANT = " + mrc.cant + " WHERE CVE_DOC  = '" + mrc.cve_doc + "' AND CONSEC = " + mrc.consec.ToString() + " and ISNULL(CANCELADO,0) = 0 " +
                            "DECLARE @CONSEC_PADRE INT " +
                            "SELECT @CONSEC_PADRE = ISNULL(CONSEC_PADRE,0) FROM DETALLEPEDIDOMERC WHERE CVE_DOC = '" + mrc.cve_doc + "' AND CONSEC = " + mrc.consec.ToString() +
                            " UPDATE DETALLEPEDIDOMERC SET TOTART = TOTART - 1 WHERE CVE_DOC = '" + mrc.cve_doc + "' AND CONSEC = @CONSEC_PADRE " +
                            "update DETALLEPEDIDOMERC set CANCELADO = CASE WHEN TotArt = 0 THEN 1 ELSE 0 END where (LTRIM(CVE_DOC) = '" + mrc.cve_doc + "') and CONSEC = @CONSEC_PADRE " +
                            " DECLARE @CONSEC_PADRE2 INT " +
                            "SELECT @CONSEC_PADRE2 = ISNULL(CONSEC_PADRE,0) FROM DETALLEPEDIDOMERC WHERE CVE_DOC = '" + mrc.cve_doc + "' AND CONSEC = @CONSEC_PADRE AND TOTART = 0 " +
                            "UPDATE DETALLEPEDIDOMERC SET TOTART = TOTART - 1 WHERE CVE_DOC = '" + art.cve_doc + "' AND CONSEC = @CONSEC_PADRE2 " +
                            "update DETALLEPEDIDOMERC set CANCELADO = CASE WHEN TotArt = 0 THEN 1 ELSE 0 END where (LTRIM(CVE_DOC) = '" + mrc.cve_doc + "') and CONSEC = @CONSEC_PADRE2 " +
                            "UPDATE DETALLEPEDIDO SET CANTSURTIDO = CANTSURTIDO - " + txtCant.Value.ToString() +
                            ", SURTIDO = 0 WHERE CVE_DOC = '" + mrc.cve_doc + "' AND NUM_PAR = " + mrc.num_par.ToString() +
                            " UPDATE INVENTARIO SET EXIST = EXIST + " + txtCant.Value.ToString() + " WHERE CVE_ART = '" + mrc.cve_art + "' " +
                            "update PEDIDO set PORC_SURTIDO = r.porc from PEDIDO p join ( " +
                            "select CVE_DOC, (sum(CAST(ISNULL(SURTIDO,0) AS float)) / CAST(count(ISNULL(SURTIDO,0)) as float)) * 100.0 porc from DETALLEPEDIDO " +
                            "where CVE_DOC = '" + mrc.cve_doc + "' group by CVE_DOC) as r ON p.CVE_DOC = r.CVE_DOC ";
                    Program.GetExecute(query, 2);

                    var cnt = (double)txtCant.Value;
                    art.cantdevuelto += (((art.cant - art.cantdevuelto) >= cnt) ? cnt : (art.cant - art.cantdevuelto));
                    art.con = (art.sel > 0) ? (int)((art.cant - (int)(art.cantdevuelto + art.cantpendiente) - 1) / art.sel) : 0;
                    art.cantdiferencia = art.cant - (art.sel * art.con) - (art.cantdevuelto + art.cantpendiente);
                    art.devuelto = (art.cant == (art.cantdevuelto + art.cantpendiente));
                    art.exist = (art.exist + cnt);
                    var ubiant = art.ubicacion;
                    art.ubicacion = (art.sel == 0 && art.con == 0) ? art.ctrl_alm : ((art.con > 0) ? art.ctrl_alm : ((art.masters_ubi == "") ? art.ctrl_alm : art.masters_ubi));
                    //art.ubicacion = (art.cantdiferencia > art.mas) ? ((art.masters_ubi != "") ? art.masters_ubi : art.ctrl_alm) : art.ctrl_alm;
                    var orb = orbi.First(o => o.cve_ubi == art.ubicacion);
                    art.orden = orb.orden;
                    var cvedoc = art.cve_doc.Trim();
                    query = "UPDATE DETALLEPEDIDODEV SET CANTDEVUELTO = " + art.cantdevuelto + ", DEVUELTO = " + ((art.devuelto) ? "1" : "0") +
                            " WHERE LTRIM(CVE_DOC) = '" + cvedoc + "' AND NUM_PAR = " + art.num_par.ToString();
                    Program.GetExecute(query, 2);

                    if (art.cantdiferencia == 0 || ubiant != art.ubicacion)
                    {
                        mostrardet = det.Where(o => o.devuelto == false).ToList();
                        mostrardet = mostrardet.OrderBy(o => o.orden).ToList();
                        art = mostrardet.FirstOrDefault();
                        artFirst = art;
                        artLast = mostrardet.LastOrDefault();
                        lblPendientes.Text = mostrardet.Count.ToString();
                    }
                    detmerc = CargaDetalleMerc();
                    cargaDatos();
                    txtCodigo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + query, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCancelacion_Load(object sender, EventArgs e)
        {
            CargaUbicaciones();
            CargaEmpaque();
            detmerc = CargaDetalleMerc();
            mostrardet = det.Where(o => o.devuelto == false).ToList();
            lblPedido.Text = ped.cve_doc.Trim();
            lblComentario.Text = "";
            art = mostrardet.FirstOrDefault();
            artFirst = art;
            artLast = mostrardet.LastOrDefault();
            lblPendientes.Text = mostrardet.Count.ToString();
            cargaDatos();
            txtCodigo.Focus();
        }

        private void cargaDatos()
        {
            string ln = "";
            try
            {
                ln = "1";  var muestra = 0.0;
                ln = "2";  if (art != null)
                {
                    ln = "3"; maxvalue = detmerc.Where(o => o.cve_art == art.cve_art).Max(o => o.presentacion);
                    ln = "4"; muestra = ((art.cantdiferencia > maxvalue) ? art.cantdiferencia : maxvalue);
                }
                ln = "5"; txtCant.Value = 1;
                ln = "6"; txtUbica.Text = (art != null) ? art.ubicacion : "";
                ln = "7"; txtClave.Text = (art != null) ? art.cve_art : "";
                ln = "8"; txtDescr.Text = (art != null) ? art.descr : "";
                ln = "9"; txtMinimo.Text = (art != null) ? art.min.ToString() : "";
                ln = "10"; txtMaster.Text = (art != null) ? art.mas.ToString() : "";
                ln = "11"; txtPorSurtir.Text = (art != null) ? muestra.ToString() : "";
                ln = "12"; txtSurtido.Text = (art != null) ? art.cantdevuelto.ToString() : "";
                ln = "13"; txtExistencia.Text = (art != null) ? art.exist.ToString() : "";
                ln = "14"; lblComentario.Text = (art != null) ? art.comentario : "";
                ln = "15"; txtMasterUbi.Text = (art != null) ? art.masters_ubi : "";
                ln = "16"; var cveart = (art != null) ? art.cve_art : "";
                ln = "17"; var mercF = merc.Find(o => o.cve_art == cveart);
                ln = "18"; lblEmp.Text = (mercF == null) ? "" : mercF.empaque;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ln + ": " + ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void CargaUbicaciones()
        {
            try
            {
                var query = "select * from orden_ruta order by ORDEN";
                orbi = Program.GetDataTable(query, 4).ToList<OrdenUbicacion>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void CargaEmpaque()
        {
            try
            {
                var query = 
                    "select distinct CVE_DOC, NUM_PAR, CVE_ART, STUFF((select ', ' + e.Empaque " +
                    "from DETALLEPEDIDOMERC d join( select h.CVE_DOC, h.CONSEC, h.TIPOPAQUETE + ' # ' + CAST(h.CONSEC_EMPAQUE AS VARCHAR(2)) + " +
                    "case when p.TIPOPAQUETE = 'ATADOS' then ' (A' + cast(p.CONSEC_EMPAQUE as varchar(2)) + ')' " +
                    "when p.TIPOPAQUETE = 'TARIMA' then ' (T' + cast(p.CONSEC_EMPAQUE as varchar(2)) + ')' ELSE '' END Empaque " +
                    "FROM DETALLEPEDIDOMERC h LEFT JOIN DETALLEPEDIDOMERC p ON p.CONSEC = h.CONSEC_PADRE and p.CVE_DOC = h.CVE_DOC " +
                    "WHERE (LTRIM(h.CVE_DOC) = '" + ped.cve_doc + "') AND(ISNULL(h.CANCELADO, 0) = 0) AND(ISNULL(h.TIPOPAQUETE, '') " +
                    "NOT IN('', 'GUIA'))) as e on d.CVE_DOC = e.CVE_DOC and d.CONSEC_PADRE = e.CONSEC WHERE(LTRIM(d.CVE_DOC) = '" + ped.cve_doc + "') " +
                    "AND(ISNULL(CANCELADO, 0) = 0) AND(ISNULL(TIPOPAQUETE, '') IN('')) AND a.CVE_DOC = d.CVE_DOC and a.CVE_ART = d.CVE_ART " +
                    "group by e.Empaque, d.NUM_PAR order by d.NUM_PAR FOR XML PATH('')), 1, 1, '') as Empaque from DETALLEPEDIDOMERC as a " +
                    "where (LTRIM(a.CVE_DOC) = '" + ped.cve_doc + "') AND(NUM_PAR > 0)";
                merc = Program.GetDataTable(query, 20).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private List<DetallePedidoMerc> CargaDetalleMerc()
        {
            List<DetallePedidoMerc> tmp = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, dt.CVE_ART, dt.CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, i.DESCR, CTRL_ALM, " +
                            "cast(cb.CANT_PIEZAS as float) PRESENTACION " +
                            "FROM DETALLEPEDIDOMERC dt JOIN INVENTARIO i ON dt.CVE_ART = i.CVE_ART " +
                            "LEFT JOIN ORDEN_RUTA o ON RTRIM(LTRIM(CTRL_ALM)) = o.CVE_UBI " +
                            "JOIN AREAS r ON ISNULL(o.AREA,'') " + (Area ? "" : "NOT") + " like '%' + r.NOMBRE + '%' " +
                            "LEFT JOIN vw_codigosBarras cb ON cb.CODIGO_BARRA = dt.CODIGO_BARRA " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc.Trim() + "' AND ISNULL(CANCELADO,0) = 0 " +
                            "ORDER BY CONSEC";
                tmp = Program.GetDataTable(query, 1).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return tmp;
        }

        private bool ValidaCambios()
        {
            bool b = false;
            try
            {
                var query = "select LTRIM(CVE_DOC) CVE_DOC, LTRIM(CVE_CLPV) CVE_CLPV, c.NOMBRE Cliente, LTRIM(p.CVE_VEND) CVE_VEND, " +
                            "TIPOSERVICIO, PRIORIDAD, ISNULL(SOLAREA,0) SOLAREA, ESTATUSPEDIDO, IMPORTE, OCURREDOMICILIO, NOMBRE_VENDEDOR, " +
                            "CAPTURO, u.Nombre CAPTURO_N from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE " +
                            "left join USUARIOS u on u.Usuario = p.CAPTURO WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
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
    }
}