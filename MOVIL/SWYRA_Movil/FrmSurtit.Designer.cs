namespace SWYRA_Movil
{
    partial class FrmSurtit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSurtit));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlRetornar = new System.Windows.Forms.Panel();
            this.pbIncompleto = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLinea = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detallePedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgDetallePed = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pnlRetornar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRetornar
            // 
            this.pnlRetornar.BackColor = System.Drawing.SystemColors.Window;
            this.pnlRetornar.Controls.Add(this.pbIncompleto);
            this.pnlRetornar.Controls.Add(this.pbSalir);
            this.pnlRetornar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRetornar.Location = new System.Drawing.Point(0, 235);
            this.pnlRetornar.Name = "pnlRetornar";
            this.pnlRetornar.Size = new System.Drawing.Size(238, 40);
            // 
            // pbIncompleto
            // 
            this.pbIncompleto.Image = ((System.Drawing.Image)(resources.GetObject("pbIncompleto.Image")));
            this.pbIncompleto.Location = new System.Drawing.Point(198, 3);
            this.pbIncompleto.Name = "pbIncompleto";
            this.pbIncompleto.Size = new System.Drawing.Size(35, 35);
            this.pbIncompleto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIncompleto.Click += new System.EventHandler(this.pbIncompleto_Click);
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(4, 3);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(35, 35);
            this.pbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblComentario);
            this.panel1.Controls.Add(this.txtDescr);
            this.panel1.Controls.Add(this.lblPedido);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtLinea);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCant);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 110);
            // 
            // lblComentario
            // 
            this.lblComentario.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblComentario.ForeColor = System.Drawing.Color.Red;
            this.lblComentario.Location = new System.Drawing.Point(9, 82);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(218, 20);
            this.lblComentario.Text = "Comentario";
            this.lblComentario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDescr
            // 
            this.txtDescr.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.txtDescr.Location = new System.Drawing.Point(52, 60);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.ReadOnly = true;
            this.txtDescr.Size = new System.Drawing.Size(175, 22);
            this.txtDescr.TabIndex = 9;
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(146, 5);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(81, 11);
            this.lblPedido.Text = "Pedido:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(9, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 19);
            this.label4.Text = "Desc.";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(83, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.Text = "Pedido:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtLinea
            // 
            this.txtLinea.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtLinea.Location = new System.Drawing.Point(52, 39);
            this.txtLinea.Name = "txtLinea";
            this.txtLinea.ReadOnly = true;
            this.txtLinea.Size = new System.Drawing.Size(75, 19);
            this.txtLinea.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(9, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.Text = "Línea";
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCant.Location = new System.Drawing.Point(161, 39);
            this.txtCant.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCant.Name = "txtCant";
            this.txtCant.ReadOnly = true;
            this.txtCant.Size = new System.Drawing.Size(66, 20);
            this.txtCant.TabIndex = 4;
            this.txtCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            this.txtCant.LostFocus += new System.EventHandler(this.txtCant_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(132, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.Text = "Cant.";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCodigo.Location = new System.Drawing.Point(52, 18);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(175, 19);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.LostFocus += new System.EventHandler(this.txtCodigo_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.Text = "Código";
            // 
            // detallePedidosBindingSource
            // 
            this.detallePedidosBindingSource.DataSource = typeof(SWYRA_Movil.DetallePedidos);
            // 
            // dgDetallePed
            // 
            this.dgDetallePed.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDetallePed.DataSource = this.detallePedidosBindingSource;
            this.dgDetallePed.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.dgDetallePed.Location = new System.Drawing.Point(7, 113);
            this.dgDetallePed.Name = "dgDetallePed";
            this.dgDetallePed.Size = new System.Drawing.Size(220, 115);
            this.dgDetallePed.TabIndex = 16;
            this.dgDetallePed.TableStyles.Add(this.dataGridTableStyle1);
            this.dgDetallePed.CurrentCellChanged += new System.EventHandler(this.dgDetallePed_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle1.MappingName = "detallePedidos";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Artículo";
            this.dataGridTextBoxColumn1.MappingName = "cve_art";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Ubicación";
            this.dataGridTextBoxColumn2.MappingName = "ubicacion";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Por Surtir";
            this.dataGridTextBoxColumn3.MappingName = "cantdiferencia";
            this.dataGridTextBoxColumn3.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "Surtido";
            this.dataGridTextBoxColumn7.MappingName = "cantsurtido";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Existencia";
            this.dataGridTextBoxColumn4.MappingName = "exist";
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Descripción";
            this.dataGridTextBoxColumn5.MappingName = "descr";
            this.dataGridTextBoxColumn5.Width = 150;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Num";
            this.dataGridTextBoxColumn6.MappingName = "num_par";
            this.dataGridTextBoxColumn6.Width = 30;
            // 
            // FrmSurtit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.dgDetallePed);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlRetornar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmSurtit";
            this.Text = "SWYRA";
            this.Load += new System.EventHandler(this.FrmSurtit_Load);
            this.pnlRetornar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRetornar;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtCant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLinea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGrid dgDetallePed;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.BindingSource detallePedidosBindingSource;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbIncompleto;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
    }
}