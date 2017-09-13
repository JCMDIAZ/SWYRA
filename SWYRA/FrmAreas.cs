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
    public partial class FrmAreas : Form
    {
        public FrmAreas()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAreas_Load(object sender, EventArgs e)
        {
            dgAreas.DataSource = CargaAreas();
            cbAlmacen.Properties.DataSource = CargaAlmacen();
            GetGridAreas();
        }

        private List<Almacen> CargaAlmacen()
        {
            List<Almacen> listAlmacenes = new List<Almacen>();
            try
            {
                var query = "SELECT Clave, Nombre, Abreviatura, Zona, Area, Altura, offset, Activo FROM ALMACENES";
                listAlmacenes = GetDataTable("DB", query, 31).ToList<Almacen>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listAlmacenes;
        }

        private List<Areas> CargaAreas()
        {
            List<Areas> listAreas = new List<Areas>();
            try
            {
                var query = "SELECT AREAID, NOMBRE, DESCRIPCION, ALMACEN, UBICACION, AREAM2, ALTURA, ACTIVO FROM AREAS";
                listAreas = GetDataTable("DB", query, 32).ToList<Areas>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listAreas;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar(){
            txtCodigo.Text = "";
            cbAlmacen.EditValue = null;txtNombre.Text = "";
            txtUbicacion.Text = "";
            txtArea.Text = "";
            txtAltura.Text = "";
            txtDescripcion.Text = "";
            chkActivo.Checked = false;
        }

        private void GetGridAreas()
        {
            if (dgAreas.Rows.Count > 0)
            {
                var areaID = dgAreas.CurrentRow.Cells[0].Value;
                cargaDatos(areaID.ToString());
            }
            else
            {
                limpiar();
            }
        }

        private void cargaDatos(string areaID)
        {
            Areas area = CargaAreas().Where(o => o.areaid == areaID.ToString()).First();

            txtCodigo.Text = area.areaid;
            cbAlmacen.Text = area.almacen;
            txtNombre.Text = area.nombre;
            txtUbicacion.Text = area.ubicacion;
            txtArea.Text = area.aream2.ToString();
            txtAltura.Text = area.altura.ToString();
            txtDescripcion.Text = area.descripcion;
            chkActivo.Checked = area.activo;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            limpiar();
            List<Areas> listAreas = CargaAreas().Where(o => o.nombre.Contains(txtBuscar.Text) || o.areaid.Contains(txtBuscar.Text)).ToList();
            dgAreas.DataSource = listAreas;
            GetGridAreas();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text = txtNombre.Text.ToUpper();
        }

        private void txtUbicacion_TextChanged(object sender, EventArgs e)
        {
            txtUbicacion.Text = txtUbicacion.Text.ToUpper();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtUbicacion.Text = txtUbicacion.Text.ToUpper();
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
                                @"select cast((isnull(max(cast(AREAID as int)),0) + 1) as varchar(5)) Id from AREAS",
                                17).ToData<Variables>();
                        txtCodigo.Text = var1.Id;
                        query =
                            @"INSERT AREAS (AREAID, NOMBRE, DESCRIPCION, ALMACEN, UBICACION, AREAM2, ALTURA, ACTIVO) " +
                            "VALUES (RIGHT('0000" + var1.Id + "',4), '" + txtNombre.Text + "', '" + txtDescripcion.Text + "', '" + cbAlmacen.Text +
                            "', '" + txtUbicacion.Text + "', " + ((txtArea.Text == "0.00") ? "Null" : txtArea.Text) + ", " +
                            ((txtAltura.Text == "0.00") ? "Null" : txtAltura.Text) + ", " +
                            ((chkActivo.Checked) ? "1" : "0") + ")";
                    }
                    else
                    {
                        query =
                            @"UPDATE AREAS SET NOMBRE = '" + txtNombre.Text + "', DESCRIPCION = '" + txtDescripcion.Text + "', " +
                            "ALMACEN = '" + cbAlmacen.Text + "', UBICACION = '" + txtUbicacion + "', Area = " +
                            ((txtArea.Text == "0.00") ? "Null" : txtArea.Text) +
                            ", Altura = " + ((txtAltura.Text == "0.00") ? "Null" : txtAltura.Text) +
                            ", Activo = " + ((chkActivo.Checked) ? "1" : "0") +
                            " WHERE AREAID = " + txtCodigo.Text;
                    }
                    var res = GetExecute("DB", query, 33);
                    MessageBox.Show(@"Guardado satisfactoriamente.");
                    dgAreas.DataSource = CargaAlmacen();
                    GetGridAreas();
                }
                catch (Exception ms)
                {
                    MessageBox.Show(ms.Message);
                }
            }
        }

        private bool validaDatos(){
            bool b = true;
            if (cbAlmacen.Text == "")
            {
                MessageBox.Show(@"Favor de asignar el almacén.");
                cbAlmacen.Focus();
                b = false;
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show(@"Favor de asignar el nombre del área.");
                txtNombre.Focus();
                b = false;
            }
            return b;
        }
    }
}
