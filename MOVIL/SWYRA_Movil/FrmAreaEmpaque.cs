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
        public List<UbicacionEntrega> lst = new List<UbicacionEntrega>();
        private bool sw = false;

        public FrmAreaEmpaque()
        {
            InitializeComponent();
        }

        private void FrmAreaEmpaque_Load(object sender, EventArgs e)
        {
            try
            {
                var query = "select *, cast(0 as bit) selecionado from UBICACION_ENTREGA where cve_zona = 'EMPAQUE' and " +
                            "cve_ubicacion not in ( select distinct UbicacionEmpaque from ( " +
                            "select isnull(p.UbicacionEmpaque, u.UbicacionEmpaque) UbicacionEmpaque from PEDIDO p " +
                            "left join PEDIDO_Ubicacion u on p.CVE_DOC = u.cve_doc " +
                            "where ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO', 'DEVOLUCION', 'EMPAQUE', 'DETENIDO BROCAS')) as a " +
                            "where UbicacionEmpaque is not null ) ";
                lst = Program.GetDataTable(query, 1).ToList<UbicacionEntrega>();

                sw = true;
                ActualizarListBox();
                sw = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void ActualizarListBox()
        {
            if (sw)
            {
                var lst1 = lst.Where(o => o.seleccionado != true).ToList();
                var lst2 = lst.Where(o => o.seleccionado == true).ToList();
                listBox1.DataSource = lst1;
                if (listBox1.Visible)
                {
                    listBox2.DataSource = lst2;
                }
                else
                {
                    var query = "select *, cast(0 as bit) selecionado from UBICACION_ENTREGA where cve_zona = 'EMPAQUE' and " +
                                "cve_ubicacion in ( select distinct UbicacionEmpaque from ( " +
                                "select isnull(p.UbicacionEmpaque, u.UbicacionEmpaque) UbicacionEmpaque from PEDIDO p " +
                                "left join PEDIDO_Ubicacion u on p.CVE_DOC = u.cve_doc " +
                                "where ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO', 'DEVOLUCION', 'EMPAQUE', 'DETENIDO BROCAS') " +
                                "and LTRIM(p.CVE_DOC) = '" + lblPedido.Text + "') as a " +
                                "where UbicacionEmpaque is not null ) ";
                    lst2 = Program.GetDataTable(query, 1).ToList<UbicacionEntrega>();
                    listBox2.DataSource = lst2;
                }
                btnActivar.Visible = (lst2.Count > 0);
            }
        }

        private void pbSig_Click(object sender, EventArgs e)
        {
            if (!sw)
            {
                var s = listBox1.SelectedValue.ToString();
                var dat = lst.Find(o => o.cve_ubicacion == s);

                if (validaAsignacion(dat))
                {
                    MessageBox.Show(@"La ubicación " + dat.cve_ubicacion + " acaba de ser asignado a otro pedido, intente con otra ubicación.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }

                if (dat != null) { dat.seleccionado = true; }
                sw = true;
                ActualizarListBox();
                sw = false;
            }
        }

        private bool validaAsignacion(UbicacionEntrega dat)
        {
            bool b = false;
            try
            {
                List<UbicacionEntrega> lstV = new List<UbicacionEntrega>();
                var query = "select *, cast(0 as bit) selecionado from UBICACION_ENTREGA where cve_zona = 'EMPAQUE' and " +
                            "cve_ubicacion not in ( select distinct UbicacionEmpaque from ( " +
                            "select isnull(p.UbicacionEmpaque, u.UbicacionEmpaque) UbicacionEmpaque from PEDIDO p " +
                            "left join PEDIDO_Ubicacion u on p.CVE_DOC = u.cve_doc " +
                            "where ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO', 'DEVOLUCION', 'EMPAQUE', 'DETENIDO BROCAS')) as a " +
                            "where UbicacionEmpaque is not null ) and cve_ubicacion = '" + dat.cve_ubicacion + "'";
                lstV = Program.GetDataTable(query, 1).ToList<UbicacionEntrega>();

                if (lstV.Count == 0)
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return b;
        }

        private void pbAnt_Click(object sender, EventArgs e)
        {
            if (!sw)
            {
                var s = listBox2.SelectedValue.ToString();
                var dat = lst.Find(o => o.cve_ubicacion == s);
                if (dat != null) { dat.seleccionado = false; }
                sw = true;
                ActualizarListBox();
                sw = false;
            }
        }
    }
}