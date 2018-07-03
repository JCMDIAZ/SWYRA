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
        public Pedidos ped = new Pedidos();
        public List<DetallePedidos> det = new List<DetallePedidos>();
        public List<DetallePedidos> mostrardet = new List<DetallePedidos>();
        private CodigosBarra cod = new CodigosBarra();
        private DetallePedidos art = new DetallePedidos();
        private DetallePedidos artFirst = new DetallePedidos();
        private DetallePedidos artLast = new DetallePedidos();
        private string lastCB;
        private List<OrdenUbicacion> orbi = new List<OrdenUbicacion>();

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
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
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
            }
        }

        private void txtCant_LostFocus(object sender, EventArgs e)
        {
            actualizaDet();
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
                            if (cod.cant_piezas > art.cantdiferencia)
                            {
                                MessageBox.Show(@"Presentación del artículo excede a la cantidad devuelta.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                txtCant.ReadOnly = !(cod.cant_piezas == 1);
                                txtCant.Value = cod.cant_piezas;
                                actualizaDet();
                                if (cod.cant_piezas == 1) { txtCant.Focus(); }
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
            if (txtCant.ReadOnly)
            {
                art.cantdevuelto += (double)txtCant.Value;
                art.cantdiferencia = art.cant - art.cantdevuelto;
                art.devuelto = (art.cant == art.cantdevuelto);
                art.exist = (art.exist + (double)txtCant.Value);
                art.ubicacion = (art.cantdiferencia > art.mas) ? ((art.masters_ubi != "") ? art.masters_ubi : art.ctrl_alm) : art.ctrl_alm;
                var orb = orbi.First(o => o.cve_ubi == art.ubicacion);
                art.orden = orb.orden;
                var query = "UPDATE DETALLEPEDIDOMERC SET CANCELADO = CASE WHEN (CANT - " + txtCant.Value.ToString() + ") <= 0 THEN 1 ELSE 0 END, " +
                            "CANT = CANT - " + txtCant.Value.ToString() + " " +
                            "WHERE CVE_DOC = '" + art.cve_doc + "' AND CODIGO_BARRA = '" + lastCB + "'  AND ISNULL(CANCELADO,0) = 0) " + 
                            "UPDATE DETALLEPEDIDODEV SET CANTDEVUELTO = " + art.cantdevuelto + ", DEVUELTO = " + ((art.devuelto) ? "1" : "0") +
                            " WHERE CVE_DOC = '" + art.cve_doc + "' AND NUM_PAR = " + art.num_par.ToString() +
                            " UPDATE INVENTARIO SET EXIST = EXIST + " + txtCant.Value.ToString() + " WHERE CVE_ART = '" + art.cve_art + "' " +
                            "update PEDIDO set PORC_SURTIDO = r.porc from PEDIDO p join ( " +
                            "select CVE_DOC, (sum(CAST(ISNULL(SURTIDO,0) AS float)) / CAST(count(SURTIDO) as float)) * 100.0 porc from DETALLEPEDIDO " +
                            "where CVE_DOC = '" + art.cve_doc + "' group by CVE_DOC) as r ON p.CVE_DOC = r.CVE_DOC ";
                Program.GetExecute(query, 2);

                mostrardet = det.Where(o => o.devuelto == false).ToList();
                mostrardet = mostrardet.OrderBy(o => o.orden).ToList();
                art = mostrardet.FirstOrDefault();
                artFirst = art;
                artLast = mostrardet.LastOrDefault();
                lblPendientes.Text = mostrardet.Count.ToString();
                cargaDatos();
            }
        }

        private void pbSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCancelacion_Load(object sender, EventArgs e)
        {
            CargaUbicaciones();
            mostrardet = det.Where(o => o.devuelto == false).ToList();
            lblPedido.Text = ped.cve_doc.Trim();
            lblComentario.Text = "";
            art = mostrardet.FirstOrDefault();
            artFirst = art;
            artLast = mostrardet.LastOrDefault();
            lblPendientes.Text = mostrardet.Count.ToString();
            cargaDatos();
        }

        private void cargaDatos()
        {
            txtCant.Value = 1;
            txtUbica.Text = (art != null) ? art.ubicacion : "";
            txtClave.Text = (art != null) ? art.cve_art : "";
            txtDescr.Text = (art != null) ? art.descr : "";
            txtMinimo.Text = (art != null) ? art.min.ToString() : "";
            txtMaster.Text = (art != null) ? art.mas.ToString() : "";
            txtPorSurtir.Text = (art != null) ? art.cantdiferencia.ToString() : "";
            txtSurtido.Text = (art != null) ? art.cantsurtido.ToString() : "";
            txtExistencia.Text = (art != null) ? art.exist.ToString() : "";
            lblComentario.Text = (art != null) ? art.comentario : "";
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
    }
}