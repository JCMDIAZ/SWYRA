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
    public partial class FrmDeptos : Form
    {
        public FrmDeptos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDeptos_Load(object sender, EventArgs e)
        {
            dgAlmacen.DataSource = CargaAlmacen();
            GetGridAlmacen();
        }

        private List<Almacen> CargaAlmacen()
        {
            List<Almacen> listAlmacenes = new List<Almacen>();
            try
            {
                var query = "SELECT Clave, Nombre, Abreviatura, Zona, Area, Altura, offset, Activo FROM ALMACENES";
                listAlmacenes = GetDataTable("DB", query, 21).ToList<Almacen>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listAlmacenes;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            limpiar();
            List<Almacen> listAlmacenes = CargaAlmacen().Where(o => o.Nombre.Contains(txtBuscar.Text) || o.Clave.Contains(txtBuscar.Text)).ToList();
            dgAlmacen.DataSource = listAlmacenes;
            GetGridAlmacen();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void GetGridAlmacen()
        {
            if (dgAlmacen.Rows.Count > 0)
            {
                var almacenID = dgAlmacen.CurrentRow.Cells[0].Value;
                cargaDatos(almacenID.ToString());
            }
            else
            {
                limpiar();
            }
        }

        private void cargaDatos(string almacenID)
        {
            Almacen almacen = CargaAlmacen().Where(o => o.Clave == almacenID.ToString()).First();

            txtCodigo.Text = almacen.Clave;
            txtDescripcion.Text = almacen.Nombre;
            txtAbreviaura.Text = almacen.Abreviatura;
            txtZona.Text = almacen.Zona;
            txtArea.Text = almacen.Area.ToString();
            txtAltura.Text = almacen.Altura.ToString();
            txtOffset.Text = almacen.offset.ToString();
            chkActivo.Checked = almacen.Activo;
        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtAbreviaura.Text = "";
            txtZona.Text = "";
            txtArea.Text = "";
            txtAltura.Text = "";
            txtOffset.Text = "";
            chkActivo.Checked = false;
        }

        private void dgAlmacen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var almacenID = dgAlmacen.Rows[e.RowIndex].Cells[0].Value;
                cargaDatos(almacenID.ToString());
            }
        }

        class Variables
        {
            public string Id { get; set; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validaDatos())
            {
                try
                {
                    var query = @"";
                    if (txtCodigo.Text == "")
                    {
                        Variables var1 =
                            GetDataTable("DB",
                                @"select cast((isnull(max(cast(Clave as int)),0) + 1) as varchar(5)) Id from ALMACENES",
                                17).ToData<Variables>();
                        txtCodigo.Text = var1.Id;
                        query =
                            @"INSERT ALMACENES (Clave, Nombre, Abreviatura, Zona, Area, Altura, offset, Activo) " +
                            "VALUES (RIGHT('0000" + var1.Id + "',4), '" + txtDescripcion.Text + "', '" +txtAbreviaura.Text + "', '" + txtZona.Text +
                            "', " + ((txtArea.Text == "0.00") ? "Null" : txtArea.Text) + ", " +
                            ((txtAltura.Text == "0.00") ? "Null" : txtAltura.Text) +
                            ", " + ((txtOffset.Text == "0.00") ? "Null" : txtOffset.Text) + ", " +
                            ((chkActivo.Checked) ? "1" : "0") + ")";
                    }
                    else
                    {
                        query =
                            @"UPDATE ALMACENES SET Nombre = '" + txtDescripcion.Text + "', Abreviatura = '" + txtAbreviaura.Text + "', " +
                            "Zona = '" + txtZona.Text + "', Area = " +
                            ((txtArea.Text == "0.00") ? "Null" : txtArea.Text) +
                            ", Altura = " + ((txtAltura.Text == "0.00") ? "Null" : txtAltura.Text) +", offset = " + ((txtOffset.Text == "0.00") ? "Null" : txtOffset.Text) +
                            ", Activo = " + ((chkActivo.Checked) ? "1" : "0") +
                            " WHERE Clave = " + txtCodigo.Text;
                    }
                    var res = GetExecute("DB", query, 23);
                    MessageBox.Show(@"Guardado satisfactoriamente.");
                    dgAlmacen.DataSource = CargaAlmacen();
                    GetGridAlmacen();
                }
                catch (Exception ms)
                {
                    MessageBox.Show(ms.Message);
                }
            }
        }
        private bool validaDatos()
        {
            bool b = true;
            if (txtDescripcion.Text == "")
            {
                MessageBox.Show(@"Favor de agregar el nombre del almacén.");
                txtDescripcion.Focus();
                b = false;
            }
            else if (txtAbreviaura.Text == "")
            {
                MessageBox.Show(@"Favor de asignar la abreviatura del almacén.");
                txtAbreviaura.Focus();
                b = false;
            }
            return b;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.Text = txtDescripcion.Text.ToUpper();
        }

        private void txtAbreviaura_TextChanged(object sender, EventArgs e)
        {
            txtAbreviaura.Text = txtAbreviaura.Text.ToUpper();
        }

        private void txtZona_TextChanged(object sender, EventArgs e)
        {
            txtZona.Text = txtZona.Text.ToUpper();}
    }
}
