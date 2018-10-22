using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using MobilePrinter.TSCWinCE;
using MobilePrinter.Connectivity;
using MobilePrinter.BarcodePrinter;
using MobilePrinter;

namespace SWYRA_Movil
{
    public partial class FrmImpCodigoBarra : Form
    {
        private InventarioPresentacion inv = new InventarioPresentacion();
        private List<CodigosBarra> listCB = new List<CodigosBarra>();

        public FrmImpCodigoBarra()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmImpCodigoBarra_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                txtDesc.Focus();
                e.Handled = true;
            }
        }

        private void txtBuscar_LostFocus(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                Buscar();
            }
        }

        private void Buscar()
        {
            try
            {
                if (txtBuscar.Text != "")
                {
                    var query = "SELECT CVE_ART, DESCR, CANT_PIEZAS_1, CODIGO_BARRA_1, CANT_PIEZAS_2, CODIGO_BARRA_2, " +
                                "CANT_PIEZAS_3, CODIGO_BARRA_3, CANT_PIEZAS_4, CODIGO_BARRA_4, CANT_PIEZAS_5, CODIGO_BARRA_5, " +
                                "CANT_PIEZAS_6, CODIGO_BARRA_6, CANT_PIEZAS_7, CODIGO_BARRA_7, CANT_PIEZAS_8, CODIGO_BARRA_8, " +
                                "CANT_PIEZAS_9, CODIGO_BARRA_9, ACTIVO FROM INVENTARIOPRESENT " +
                                "WHERE CVE_ART = '" + txtBuscar.Text + "' OR CVE_ART IN (SELECT CVE_ART FROM vw_codigosBarras " + 
                                "WHERE CODIGO_BARRA = '" + txtBuscar.Text + "')";
                    inv = Program.GetDataTable(query, 1).ToData<InventarioPresentacion>();
                    if (inv == null)
                    {
                        MessageBox.Show(@"No existe producto o no tiene presentación, favor de validar", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        txtBuscar.Text = "";
                        txtDesc.Text = "";
                        txtBuscar.Focus();
                    }
                    else
                    {
                        txtDesc.Text = inv.descr;
                        var query2 = "SELECT CVE_ART, CANT_PIEZAS, CODIGO_BARRA FROM vw_codigosBarras " +
                                     "WHERE CVE_ART = '" + inv.cve_art + "'";
                        listCB = Program.GetDataTable(query2, 2).ToList<CodigosBarra>();
                        dgCodigos.DataSource = Program.ToDataTable<CodigosBarra>(listCB, "CodigosBarra");
                        txtBuscar.Text = "";
                        txtBuscar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void dgCodigos_CurrentCellChanged(object sender, EventArgs e)
        {
            dgCodigos.Select(dgCodigos.CurrentRowIndex);
        }

        private void pbImprimir_Click(object sender, EventArgs e)
        {
            FrmImpCodDialog frm2 = new FrmImpCodDialog();
            var index = dgCodigos.CurrentRowIndex;
            if (index >= 0)
            {
                var cdb = dgCodigos[index, 1].ToString();
                var clv = dgCodigos[index, 0].ToString();
                frm2.nmTotalPiezas.Value = decimal.Parse(cdb);
                frm2.lblTotalPiezas.Enabled = (cdb == "1");
                frm2.nmTotalPiezas.Enabled = (cdb == "1");
                DialogResult dr = frm2.ShowDialog();
                if (dr == DialogResult.Cancel)
                {
                    frm2.Close();
                }
                else if (dr == DialogResult.OK)
                {
                    try
                    {
                        TSCBluetooth bt = new TSCBluetooth();
                        bt.openport(Program.ptoImp());
                        string strcdb = dgCodigos[index, 2].ToString() + ((frm2.nmTotalPiezas.Value > 1 && frm2.nmTotalPiezas.Enabled) ? "-" + frm2.nmTotalPiezas.Value : "");
                        string str = "SIZE 2,1\n" +
                                     "GAP 0.12,0\n" +
                                     "DIRECTION 0\n" +
                                     "TEXT 340,20,\"3\",0,1,1,3,\"(" + clv + ")\"\n" +
                                     "TEXT 340,45,\"0\",0,8,8,3,\"" + frm2.nmTotalPiezas.Value.ToString() + " Piezas\"\n" +
                                     //"TEXT 125,40,\"3\",0,1,1,\"Monterrey SA CV\"\n" +
                                     "PUTPCX 10,5,\"dogotuls2.pcx\"\n" +
                                     "TEXT 10,70,\"0\",0,6,8,\"" + txtDesc.Text.Replace("\\", "").Replace("\"", "") + "\"\n" +
                                     "BARCODE 30,95,\"128\",70,1,0,2,2,\"" + strcdb + "\"\n";

                        var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                        bt.clearbuffer();
                        bt.downloadfile(directoryName + @"\dogotuls2.pcx", "dogotuls2.pcx");
                        bt.sendcommand(str);
                        bt.printlabel(1, (int)frm2.nmCantEti.Value);

                        MessageBox.Show(@"Se mando la impresión, satisfactoriamente", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                        frm2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Impresora no disponible.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                MessageBox.Show(@"No ha seleccionado una presentación.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                frm2.Close();
            }
        }
    }
}