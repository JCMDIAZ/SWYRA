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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgCodigos_CurrentCellChanged(object sender, EventArgs e)
        {
            dgCodigos.Select(dgCodigos.CurrentRowIndex);
        }
    }
}