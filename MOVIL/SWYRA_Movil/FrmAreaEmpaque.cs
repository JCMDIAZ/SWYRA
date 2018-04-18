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
    public partial class FrmAreaEmpaque : Form
    {
        public FrmAreaEmpaque()
        {
            InitializeComponent();
        }

        private void FrmAreaEmpaque_Load(object sender, EventArgs e)
        {
            try
            {
                var query = "select * from UBICACION_ENTREGA where cve_zona = 'EMPAQUE' and " +
                            "cve_ubicacion not in (select UbicacionEmpaque from PEDIDO " +
                            "where ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO', 'DEVOLUCION', 'EMPAQUE') " +
                            "and UbicacionEmpaque is not null) ";
                var lst = Program.GetDataTable(query, 1);
                cbAreaEmpaque.DataSource = lst.ToList<UbicacionEntrega>();
                cbAreaEmpaque.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}