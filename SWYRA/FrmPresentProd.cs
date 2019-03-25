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
    public partial class FrmPresentProd : Form
    {
        List<InventarioPresentacion> listInventarioPresentacion = new List<InventarioPresentacion>();
        private bool sw = true;

        public FrmPresentProd()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPresentProd_Load(object sender, EventArgs e)
        {
            cbProducto.Properties.DataSource = CargaInventario();
            listInventarioPresentacion = CargaInventarioPresentacion();
            gcPresentaciones.DataSource = listInventarioPresentacion;
            gridView1.OptionsFind.AlwaysVisible = true;
            gridView1.Layout += (s, em) =>
            {
                sw = false;
                GetGridPresentacion();
                sw = true;
            };
            //GetGridPresentacion();
        }
   
        private List<Inventario> CargaInventario()
        {
            List<Inventario> listInventarios = new List<Inventario>();
            try
            {
                var query = "SELECT CVE_ART, DESCR, LIN_PROD, EXIST, STATUS FROM INVENTARIO " +
                            "WHERE STATUS = 'A' AND EXIST >= 0 AND (CVE_ART > '9808' OR CVE_ART IN ('9600')) ORDER BY CVE_ART";
                listInventarios = GetDataTable("DB", query, 1).ToList<Inventario>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listInventarios;
        }

        private List<InventarioPresentacion> CargaInventarioPresentacion()
        {
            try
            {
                var query = "SELECT CVE_ART, DESCR, CANT_PIEZAS_1, CODIGO_BARRA_1, CANT_PIEZAS_2, CODIGO_BARRA_2, " +
                            "CANT_PIEZAS_3, CODIGO_BARRA_3, CANT_PIEZAS_4, CODIGO_BARRA_4, " +
                            "CANT_PIEZAS_5, CODIGO_BARRA_5, CANT_PIEZAS_6, CODIGO_BARRA_6, " +"CANT_PIEZAS_7, CODIGO_BARRA_7, CANT_PIEZAS_8, CODIGO_BARRA_8, " +
                            "CANT_PIEZAS_9, CODIGO_BARRA_9, ACTIVO " +
                            "FROM INVENTARIOPRESENT WHERE CVE_ART IN(SELECT CVE_ART FROM INVENTARIO " +
                            "WHERE STATUS = 'A' AND EXIST > 0) ORDER BY CVE_ART";
                listInventarioPresentacion = GetDataTable("DB", query, 2).ToList<InventarioPresentacion>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listInventarioPresentacion;
        }

        private int FindCodigosBarra(string cv, string cd)
        {
            int cant = 0;
            try
            {
                var query = "SELECT CVE_ART, CANT_PIEZAS, CODIGO_BARRA FROM vw_codigosBarras " +
                            "WHERE CVE_ART <> '" + cv + "' AND CODIGO_BARRA = '" + cd + "'";
                cant = GetDataTable("DB", query, 5).ToList<CodigosBarra>().Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return cant;
        }

        private void GetGridPresentacion()
        {
            if (gridView1.RowCount > 0)
            {
                var cveArt = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "cve_art");
                CargaDatos(cveArt.ToString());
            }
            else
            {
                Limpiar();
            }
        }

        private void CargaDatos(string cveArt)
        {
            var inv = listInventarioPresentacion.First(o => o.cve_art == cveArt);

            cbProducto.EditValue = inv.cve_art;
            cbProducto.Properties.ReadOnly = true;
            txtNumPiezas1.EditValue = inv.cant_piezas_1;
            txtCodigoBarra1.EditValue = inv.codigo_barra_1;
            txtNumPiezas2.EditValue = inv.cant_piezas_2;
            txtCodigoBarra2.EditValue = inv.codigo_barra_2;
            txtNumPiezas3.EditValue = inv.cant_piezas_3;
            txtCodigoBarra3.EditValue = inv.codigo_barra_3;
            txtNumPiezas4.EditValue = inv.cant_piezas_4;
            txtCodigoBarra4.EditValue = inv.codigo_barra_4;
            txtNumPiezas5.EditValue = inv.cant_piezas_5;
            txtCodigoBarra5.EditValue = inv.codigo_barra_5;
            txtNumPiezas6.EditValue = inv.cant_piezas_6;
            txtCodigoBarra6.EditValue = inv.codigo_barra_6;
            txtNumPiezas7.EditValue = inv.cant_piezas_7;
            txtCodigoBarra7.EditValue = inv.codigo_barra_7;
            txtNumPiezas8.EditValue = inv.cant_piezas_8;
            txtCodigoBarra8.EditValue = inv.codigo_barra_8;
            txtNumPiezas9.EditValue = inv.cant_piezas_9;
            txtCodigoBarra9.EditValue = inv.codigo_barra_9;
            chkActivo.Checked = inv.activo;
        }

        private void Limpiar()
        {
            cbProducto.EditValue = null;
            cbProducto.Properties.ReadOnly = false;
            txtNumPiezas1.EditValue = 0;
            txtCodigoBarra1.EditValue = "";
            txtNumPiezas2.EditValue = 0;
            txtCodigoBarra2.EditValue = "";
            txtNumPiezas3.EditValue = 0;
            txtCodigoBarra3.EditValue = "";
            txtNumPiezas4.EditValue = 0;
            txtCodigoBarra4.EditValue = "";
            txtNumPiezas5.EditValue = 0;
            txtCodigoBarra5.EditValue = "";
            txtNumPiezas6.EditValue = 0;
            txtCodigoBarra6.EditValue = "";
            txtNumPiezas7.EditValue = 0;
            txtCodigoBarra7.EditValue = "";
            txtNumPiezas8.EditValue = 0;
            txtCodigoBarra8.EditValue = "";
            txtNumPiezas9.EditValue = 0;
            txtCodigoBarra9.EditValue = "";
            chkActivo.Checked = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            sw = false;
            GetGridPresentacion();
            sw = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
            {
                try
                {
                    var query =
                            @"IF NOT EXISTS (SELECT * FROM INVENTARIOPRESENT " +
                            " WHERE CVE_ART = '" + cbProducto.EditValue.ToString() + "') BEGIN " +
                            "INSERT INVENTARIOPRESENT (CVE_ART, DESCR, CANT_PIEZAS_1, CODIGO_BARRA_1, " +
                            "CANT_PIEZAS_2, CODIGO_BARRA_2, CANT_PIEZAS_3, CODIGO_BARRA_3, " +
                            "CANT_PIEZAS_4, CODIGO_BARRA_4, CANT_PIEZAS_5, CODIGO_BARRA_5, " +
                            "CANT_PIEZAS_6, CODIGO_BARRA_6, CANT_PIEZAS_7, CODIGO_BARRA_7, " +
                            "CANT_PIEZAS_8, CODIGO_BARRA_8, CANT_PIEZAS_9, CODIGO_BARRA_9, ACTIVO) " +
                            "VALUES ('" + cbProducto.EditValue.ToString() + "', '" + cbProducto.Text.Replace(",","") + "', " + 
                            txtNumPiezas1.EditValue + ", '" + txtCodigoBarra1.Text + "', " +
                            txtNumPiezas2.EditValue + ", '" + txtCodigoBarra2.Text + "', " +
                            txtNumPiezas3.EditValue + ", '" + txtCodigoBarra3.Text + "', " +
                            txtNumPiezas4.EditValue + ", '" + txtCodigoBarra4.Text + "', " +
                            txtNumPiezas5.EditValue + ", '" + txtCodigoBarra5.Text + "', " +
                            txtNumPiezas6.EditValue + ", '" + txtCodigoBarra6.Text + "', " +
                            txtNumPiezas7.EditValue + ", '" + txtCodigoBarra7.Text + "', " +
                            txtNumPiezas8.EditValue + ", '" + txtCodigoBarra8.Text + "', " +
                            txtNumPiezas9.EditValue + ", '" + txtCodigoBarra9.Text + "', " +
                            ((chkActivo.Checked) ? "1" : "0") + ") END ELSE BEGIN " +
                            @"UPDATE INVENTARIOPRESENT SET " +
                            "CANT_PIEZAS_1 = " + txtNumPiezas1.EditValue + ", CODIGO_BARRA_1 = '" + txtCodigoBarra1.Text + "', " +
                            "CANT_PIEZAS_2 = " + txtNumPiezas2.EditValue + ", CODIGO_BARRA_2 = '" + txtCodigoBarra2.Text + "', " +
                            "CANT_PIEZAS_3 = " + txtNumPiezas3.EditValue + ", CODIGO_BARRA_3 = '" + txtCodigoBarra3.Text + "', " +
                            "CANT_PIEZAS_4 = " + txtNumPiezas4.EditValue + ", CODIGO_BARRA_4 = '" + txtCodigoBarra4.Text + "', " +
                            "CANT_PIEZAS_5 = " + txtNumPiezas5.EditValue + ", CODIGO_BARRA_5 = '" + txtCodigoBarra5.Text + "', " +
                            "CANT_PIEZAS_6 = " + txtNumPiezas6.EditValue + ", CODIGO_BARRA_6 = '" + txtCodigoBarra6.Text + "', " +
                            "CANT_PIEZAS_7 = " + txtNumPiezas7.EditValue + ", CODIGO_BARRA_7 = '" + txtCodigoBarra7.Text + "', " +
                            "CANT_PIEZAS_8 = " + txtNumPiezas8.EditValue + ", CODIGO_BARRA_8 = '" + txtCodigoBarra8.Text + "', " +
                            "CANT_PIEZAS_9 = " + txtNumPiezas9.EditValue + ", CODIGO_BARRA_9 = '" + txtCodigoBarra9.Text + "', " +
                            "Activo = " + ((chkActivo.Checked) ? "1" : "0") +
                            " WHERE CVE_ART = '" + cbProducto.EditValue.ToString() + "' END";
                    var res = GetExecute("DB", query, 3);
                    MessageBox.Show(@"Guardado satisfactoriamente.");
                    listInventarioPresentacion = CargaInventarioPresentacion();
                    gcPresentaciones.DataSource = listInventarioPresentacion;
                    GetGridPresentacion();
                }
                catch (Exception ms)
                {
                    MessageBox.Show(ms.Message);
                }
            }
        }

        private bool ValidaDatos()
        {
            bool b = true;
            double tot = double.Parse(txtNumPiezas1.EditValue.ToString()) + double.Parse(txtNumPiezas2.EditValue.ToString()) + 
                         double.Parse(txtNumPiezas3.EditValue.ToString()) + double.Parse(txtNumPiezas4.EditValue.ToString()) + 
                         double.Parse(txtNumPiezas5.EditValue.ToString()) + double.Parse(txtNumPiezas6.EditValue.ToString()) +
                         double.Parse(txtNumPiezas7.EditValue.ToString()) + double.Parse(txtNumPiezas8.EditValue.ToString()) + 
                         double.Parse(txtNumPiezas9.EditValue.ToString());
            string cod = txtCodigoBarra1.Text + txtCodigoBarra2.Text + txtCodigoBarra3.Text +
                         txtCodigoBarra4.Text + txtCodigoBarra5.Text + txtCodigoBarra6.Text +
                         txtCodigoBarra7.Text + txtCodigoBarra8.Text + txtCodigoBarra9.Text;
            if (cbProducto.Text == "")
            {
                MessageBox.Show(@"Favor de asignar el producto.");
                cbProducto.Focus();
                b = false;
            } else if (tot == 0 && cod == "")
            {
                MessageBox.Show(@"Al menos debe de haber una presentación.");
                txtNumPiezas1.Focus();
                b = false;
            } else if ( val1(txtNumPiezas1, txtCodigoBarra1, 1) ) { b = false; }
            else if (val1(txtNumPiezas2, txtCodigoBarra2, 2)) { b = false; }
            else if (val1(txtNumPiezas3, txtCodigoBarra3, 3)) { b = false; }
            else if (val1(txtNumPiezas4, txtCodigoBarra4, 4)) { b = false; }
            else if (val1(txtNumPiezas5, txtCodigoBarra5, 5)) { b = false; }
            else if (val1(txtNumPiezas6, txtCodigoBarra6, 6)) { b = false; }
            else if (val1(txtNumPiezas7, txtCodigoBarra7, 7)) { b = false; }
            else if (val1(txtNumPiezas8, txtCodigoBarra8, 8)) { b = false; }
            else if (val1(txtNumPiezas9, txtCodigoBarra9, 9)) { b = false; }
            return b;
        }


        private bool val1(DevExpress.XtraEditors.TextEdit pz, DevExpress.XtraEditors.TextEdit cd, int pr)
        {
            bool b = true;
            if (cd.Text != "")
            {
                if (FindCodigosBarra(cbProducto.EditValue.ToString(), cd.Text) != 0)
                {
                    MessageBox.Show(@"El código de barra de la presentacion " + pr.ToString() + @" esta siendo utilizada en otro producto.");
                    cd.Focus();
                    b = false;
                }
            }
            if (double.Parse(pz.EditValue.ToString()) == 0 && cd.Text != "")
            {
                MessageBox.Show(@"La presentacion " + pr.ToString() + @" debe ser mayor a cero el numero de piezas.");
                pz.Focus();
                b = false;
            }
            if (double.Parse(pz.EditValue.ToString()) > 0 && cd.Text == "")
            {
                MessageBox.Show(@"La presentacion " + pr.ToString() + @" debe contener un codigo o la cantidad de piezas en 0.");
                pz.Focus();
                b = false;
            }

            return !b;
        }

        private void cbProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (sw)
            {
                var cveArt = cbProducto.EditValue ?? "";
                cbProducto.Properties.ReadOnly = false;
            }
        }

        private void txtCodigoBarra_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = @"xlsx Excel (*.xlsx)|*.xlsx";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gcPresentaciones.ExportToXlsx(sfd.FileName);
            }
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string ruta = string.Empty;
            string query = "";
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = @"Base de Presentaciones Excel";
            fDialog.Filter = @"Excel |*.xlsx|Excel Ant|*.xls";
            fDialog.InitialDirectory = @"C:\";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                ruta = fDialog.FileName.ToString();
                var listCargaInvPresent = GetExcelDataTable(ruta, "Sheet", 4).ToList<InventarioPresentacion>();
                pcProgresBar.Location = new Point(
                    this.ClientSize.Width / 2 - pcProgresBar.Size.Width / 2,
                    this.ClientSize.Height / 2 - pcProgresBar.Size.Height / 2);
                pcProgresBar.Anchor = AnchorStyles.None;
                pcProgresBar.Show();
                var lim = MessageBox.Show(@"¿Deseas limpiar la tabla de Presentaciones?",@"Confirmación",MessageBoxButtons.YesNoCancel);
                if(lim == DialogResult.Cancel) { pcProgresBar.Hide(); return; }
                if (lim == DialogResult.Yes)
                {
                    try
                    {
                        query =
                                @"DELETE INVENTARIOPRESENT";
                        var res = GetExecute("DB", query, 7);
                    }
                    catch (Exception ms)
                    {
                        MessageBox.Show(ms.Message);
                    }
                }
                progressBarControl1.Properties.Maximum = listCargaInvPresent.Count;
                progressBarControl1.Position = 0;
                memoRep.MaskBox.Clear();
                int c = 0;
                foreach (var pres in listCargaInvPresent)
                {
                    c++;
                    progressBarControl1.Position = c;
                    progressBarControl1.Refresh();
                    if (ValidaDatosCarga(pres, c))
                    {
                        try
                        {
                            query =
                                    @"IF NOT EXISTS (SELECT * FROM INVENTARIOPRESENT " +
                                    " WHERE UPPER(CVE_ART) = UPPER('" + pres.cve_art + "')) BEGIN " +
                                    "INSERT INVENTARIOPRESENT (CVE_ART, DESCR, CANT_PIEZAS_1, CODIGO_BARRA_1, " +
                                    "CANT_PIEZAS_2, CODIGO_BARRA_2, CANT_PIEZAS_3, CODIGO_BARRA_3, " +
                                    "CANT_PIEZAS_4, CODIGO_BARRA_4, CANT_PIEZAS_5, CODIGO_BARRA_5, " +
                                    "CANT_PIEZAS_6, CODIGO_BARRA_6, CANT_PIEZAS_7, CODIGO_BARRA_7, " +
                                    "CANT_PIEZAS_8, CODIGO_BARRA_8, CANT_PIEZAS_9, CODIGO_BARRA_9, ACTIVO) " +
                                    "VALUES (UPPER('" + pres.cve_art + "'), CAST('" + pres.descr.Replace("'","") + "' AS VARCHAR(40)), " +
                                    pres.cant_piezas_1 + ", '" + pres.codigo_barra_1 + "', " +
                                    pres.cant_piezas_2 + ", '" + pres.codigo_barra_2 + "', " +
                                    pres.cant_piezas_3 + ", '" + pres.codigo_barra_3 + "', " +
                                    pres.cant_piezas_4 + ", '" + pres.codigo_barra_4 + "', " +
                                    pres.cant_piezas_5 + ", '" + pres.codigo_barra_5 + "', " +
                                    pres.cant_piezas_6 + ", '" + pres.codigo_barra_6 + "', " +
                                    pres.cant_piezas_7 + ", '" + pres.codigo_barra_7 + "', " +
                                    pres.cant_piezas_8 + ", '" + pres.codigo_barra_8 + "', " +
                                    pres.cant_piezas_9 + ", '" + pres.codigo_barra_9 + "', " +
                                    ((pres.activo) ? "1" : "0") + ") END ELSE BEGIN " +
                                    @"UPDATE INVENTARIOPRESENT SET " +
                                    "CANT_PIEZAS_1 = " + pres.cant_piezas_1 + ", CODIGO_BARRA_1 = '" + pres.codigo_barra_1 + "', " +
                                    "CANT_PIEZAS_2 = " + pres.cant_piezas_2 + ", CODIGO_BARRA_2 = '" + pres.codigo_barra_2 + "', " +
                                    "CANT_PIEZAS_3 = " + pres.cant_piezas_3 + ", CODIGO_BARRA_3 = '" + pres.codigo_barra_3 + "', " +
                                    "CANT_PIEZAS_4 = " + pres.cant_piezas_4 + ", CODIGO_BARRA_4 = '" + pres.codigo_barra_4 + "', " +
                                    "CANT_PIEZAS_5 = " + pres.cant_piezas_5 + ", CODIGO_BARRA_5 = '" + pres.codigo_barra_5 + "', " +
                                    "CANT_PIEZAS_6 = " + pres.cant_piezas_6 + ", CODIGO_BARRA_6 = '" + pres.codigo_barra_6 + "', " +
                                    "CANT_PIEZAS_7 = " + pres.cant_piezas_7 + ", CODIGO_BARRA_7 = '" + pres.codigo_barra_7 + "', " +
                                    "CANT_PIEZAS_8 = " + pres.cant_piezas_8 + ", CODIGO_BARRA_8 = '" + pres.codigo_barra_8 + "', " +
                                    "CANT_PIEZAS_9 = " + pres.cant_piezas_9 + ", CODIGO_BARRA_9 = '" + pres.codigo_barra_9 + "', " +
                                    "Activo = " + ((pres.activo) ? "1" : "0") +
                                    " WHERE UPPER(CVE_ART) = UPPER('" + pres.cve_art + "') END";
                            var res = GetExecute("DB", query, 6);
                        }
                        catch (Exception ms)
                        {
                            MessageBox.Show(ms.Message);
                        }
                    }
                }
                pcProgresBar.Hide();
                pcReporte.Location = new Point(
                    this.ClientSize.Width / 2 - pcReporte.Size.Width / 2,
                    (this.ClientSize.Height - gcPresentaciones.Size.Height) / 2 - pcReporte.Size.Height / 2);
                pcReporte.Anchor = AnchorStyles.None;
                pcReporte.Show();
            }
        }

        private bool ValidaDatosCarga(InventarioPresentacion pres, int reg)
        {
            double tot = pres.cant_piezas_1 + pres.cant_piezas_2 + pres.cant_piezas_3 +
                      pres.cant_piezas_4 + pres.cant_piezas_5 + pres.cant_piezas_6 +
                      pres.cant_piezas_7 + pres.cant_piezas_8 + pres.cant_piezas_9;
            string cod = (pres.codigo_barra_1 ?? "") + (pres.codigo_barra_2 ?? "") + (pres.codigo_barra_3 ?? "") +
                         (pres.codigo_barra_4 ?? "") + (pres.codigo_barra_5 ?? "") + (pres.codigo_barra_6 ?? "") +
                         (pres.codigo_barra_7 ?? "") + (pres.codigo_barra_8 ?? "") + (pres.codigo_barra_9 ?? "");
            if (pres.cve_art == null)
            {
                memoRep.MaskBox.AppendText("Reg. " + reg.ToString() + " : No tiene registrado clave del artículo." + Environment.NewLine);
                return false;
            }
            if (tot == 0 && cod == "")
            {
                memoRep.MaskBox.AppendText("Reg. " + reg.ToString() + " : Al menos debe de haber una presentación." + Environment.NewLine);
                return false;
            }
            if (val4(pres.cant_piezas_1, pres.codigo_barra_1, 1, reg)) { return false; }
            if (val4(pres.cant_piezas_2, pres.codigo_barra_2, 2, reg)) { return false; }
            if (val4(pres.cant_piezas_3, pres.codigo_barra_3, 3, reg)) { return false; }
            if (val4(pres.cant_piezas_4, pres.codigo_barra_4, 4, reg)) { return false; }
            if (val4(pres.cant_piezas_5, pres.codigo_barra_5, 5, reg)) { return false; }
            if (val4(pres.cant_piezas_6, pres.codigo_barra_6, 6, reg)) { return false; }
            if (val4(pres.cant_piezas_7, pres.codigo_barra_7, 7, reg)) { return false; }
            if (val4(pres.cant_piezas_8, pres.codigo_barra_8, 8, reg)) { return false; }
            if (val4(pres.cant_piezas_9, pres.codigo_barra_9, 9, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_1, 1, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_2, 2, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_3, 3, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_4, 4, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_5, 5, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_6, 6, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_7, 7, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_8, 8, reg)) { return false; }
            if (val5(pres, pres.cant_piezas_9, 9, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_1, 1, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_2, 2, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_3, 3, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_4, 4, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_5, 5, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_6, 6, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_7, 7, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_8, 8, reg)) { return false; }
            if (val6(pres, pres.codigo_barra_9, 9, reg)) { return false; }

            return true;
        }

        private bool val4(double pz, string cd, int pr, int reg)
        {
            if (pz == 0 && (cd ?? "") != "")
            {
                memoRep.MaskBox.AppendText("Reg. " + reg.ToString() +
                                           " : La presentacion " + pr.ToString() +
                                           " debe ser mayor a cero el numero de piezas." + Environment.NewLine);
                return true;
            }
            if (pz > 0 && (cd ?? "") == "")
            {
                memoRep.MaskBox.AppendText("Reg. " + reg.ToString() +
                                           " : La presentacion " + pr.ToString() +
                                           " debe contener un codigo o la cantidad de piezas en 0." + Environment.NewLine);
                return true;
            }
            return false;
        }

        private bool val5(InventarioPresentacion pres, double vl, int pr, int reg)
        {
            bool b = true;
            if (vl == 0) { return false; }
            b = !(pr != 1 && pres.cant_piezas_1 == vl) &&
                !(pr != 2 && pres.cant_piezas_2 == vl) &&
                !(pr != 3 && pres.cant_piezas_3 == vl) &&
                !(pr != 4 && pres.cant_piezas_4 == vl) &&
                !(pr != 5 && pres.cant_piezas_5 == vl) &&
                !(pr != 6 && pres.cant_piezas_6 == vl) &&
                !(pr != 7 && pres.cant_piezas_7 == vl) &&
                !(pr != 8 && pres.cant_piezas_8 == vl) &&
                !(pr != 9 && pres.cant_piezas_9 == vl);
            if (!b)
            {
                memoRep.MaskBox.AppendText("Reg. " + reg.ToString() +
                                           " : La cantidad de piezas de la presentacion " + pr + " esta duplicada." + Environment.NewLine);
            }
            return !b;
        }

        private bool val6(InventarioPresentacion pres, string cd, int pr, int reg)
        {
            bool b = true;
            if ((cd ?? "") == "") { return false; }
            b = !(pr != 1 && pres.codigo_barra_1 == cd) &&
                !(pr != 2 && pres.codigo_barra_2 == cd) &&
                !(pr != 3 && pres.codigo_barra_3 == cd) &&
                !(pr != 4 && pres.codigo_barra_4 == cd) &&
                !(pr != 5 && pres.codigo_barra_5 == cd) &&
                !(pr != 6 && pres.codigo_barra_6 == cd) &&
                !(pr != 7 && pres.codigo_barra_7 == cd) &&
                !(pr != 8 && pres.codigo_barra_8 == cd) &&
                !(pr != 9 && pres.codigo_barra_9 == cd);
            if (!b)
            {
                memoRep.MaskBox.AppendText("Reg. " + reg.ToString() +
                                           " : El codigo de la presentacion " + pr + " esta duplicado." + Environment.NewLine);
                return true;
            }
            if (FindCodigosBarra(pres.cve_art, cd) != 0)
            {
                memoRep.MaskBox.AppendText("Reg. " + reg.ToString() +
                                           " : El código de barra de la presentacion " + pr + @" esta siendo utilizada en otro producto." + Environment.NewLine);
                return true;
            }

            return false;
        }

        private void val2(DevExpress.XtraEditors.TextEdit pz)
        {
            bool b = true;
            if (double.Parse(pz.EditValue.ToString()) == 0) { return; }
            b = !(txtNumPiezas1.Name != pz.Name && (double.Parse(txtNumPiezas1.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas2.Name != pz.Name && (double.Parse(txtNumPiezas2.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas3.Name != pz.Name && (double.Parse(txtNumPiezas3.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas4.Name != pz.Name && (double.Parse(txtNumPiezas4.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas5.Name != pz.Name && (double.Parse(txtNumPiezas5.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas6.Name != pz.Name && (double.Parse(txtNumPiezas6.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas7.Name != pz.Name && (double.Parse(txtNumPiezas7.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas8.Name != pz.Name && (double.Parse(txtNumPiezas8.EditValue.ToString()) == double.Parse(pz.EditValue.ToString()))) &&
                !(txtNumPiezas9.Name != pz.Name && (double.Parse(txtNumPiezas9.EditValue.ToString()) == double.Parse(pz.EditValue.ToString())));
            if (!b)
            {
                MessageBox.Show(@"La cantidad de piezas ya existe en otra presentacion.");
                pz.Focus();
            }}

        private void txtNumPiezas1_Leave(object sender, EventArgs e)
        {
            var obj = (DevExpress.XtraEditors.TextEdit) sender;
            if (obj.IsModified) { val2(obj); }
        }

        private void txtCodigoBarra1_Leave(object sender, EventArgs e)
        {
            var obj = (DevExpress.XtraEditors.TextEdit)sender;
            if (obj.IsModified) { val3(obj); }
        }

        private void val3(DevExpress.XtraEditors.TextEdit cd)
        {
            bool b = true;
            if (cd.EditValue.ToString() == "") { return; }
            b = !(txtCodigoBarra1.Name != cd.Name && txtCodigoBarra1.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra2.Name != cd.Name && txtCodigoBarra2.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra3.Name != cd.Name && txtCodigoBarra3.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra4.Name != cd.Name && txtCodigoBarra4.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra5.Name != cd.Name && txtCodigoBarra5.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra6.Name != cd.Name && txtCodigoBarra6.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra7.Name != cd.Name && txtCodigoBarra7.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra8.Name != cd.Name && txtCodigoBarra8.Text == cd.EditValue.ToString()) &&
                !(txtCodigoBarra9.Name != cd.Name && txtCodigoBarra9.Text == cd.EditValue.ToString());
            if (!b)
            {
                MessageBox.Show(@"El código de barra ya existe en otra presentacion.");
                cd.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pcReporte.Hide();
            listInventarioPresentacion = CargaInventarioPresentacion();
            gcPresentaciones.DataSource = listInventarioPresentacion;
            GetGridPresentacion();
        }
    }
}