namespace SWYRA_Movil
{
    partial class FrmEmpaqueAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpaqueAdd));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPaquete = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.detallePedidoMercBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgDetallePed = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.lblEstatusA = new System.Windows.Forms.Label();
            this.lblEstatusB = new System.Windows.Forms.Label();
            this.pbCambia = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pbCambia);
            this.panel2.Controls.Add(this.pbSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 40);
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(5, 3);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(35, 35);
            this.pbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click);
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(78, 4);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(150, 20);
            this.lblPedido.Text = "9999";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.Text = "Pedido :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPaquete
            // 
            this.lblPaquete.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPaquete.Location = new System.Drawing.Point(78, 24);
            this.lblPaquete.Name = "lblPaquete";
            this.lblPaquete.Size = new System.Drawing.Size(150, 17);
            this.lblPaquete.Text = "9999";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.Text = "Paquete :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCant.Location = new System.Drawing.Point(162, 65);
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
            this.txtCant.TabIndex = 32;
            this.txtCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            this.txtCant.LostFocus += new System.EventHandler(this.txtCant_LostFocus);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(133, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 19);
            this.label5.Text = "Cant.";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCodigo.Location = new System.Drawing.Point(53, 43);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(175, 19);
            this.txtCodigo.TabIndex = 30;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.LostFocus += new System.EventHandler(this.txtCodigo_LostFocus);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(10, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 19);
            this.label7.Text = "Código";
            // 
            // detallePedidoMercBindingSource
            // 
            this.detallePedidoMercBindingSource.AllowNew = false;
            this.detallePedidoMercBindingSource.DataSource = typeof(SWYRA_Movil.DetallePedidoMerc);
            // 
            // dgDetallePed
            // 
            this.dgDetallePed.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDetallePed.DataSource = this.detallePedidoMercBindingSource;
            this.dgDetallePed.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.dgDetallePed.Location = new System.Drawing.Point(9, 91);
            this.dgDetallePed.Name = "dgDetallePed";
            this.dgDetallePed.Size = new System.Drawing.Size(220, 138);
            this.dgDetallePed.TabIndex = 36;
            this.dgDetallePed.TableStyles.Add(this.dataGridTableStyle1);
            this.dgDetallePed.CurrentCellChanged += new System.EventHandler(this.dgDetallePed_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.MappingName = "detallePedidoMerc";
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
            this.dataGridTextBoxColumn2.HeaderText = "Código";
            this.dataGridTextBoxColumn2.MappingName = "codigo_barra";
            this.dataGridTextBoxColumn2.Width = 80;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Cantidad";
            this.dataGridTextBoxColumn3.MappingName = "cant";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Descripción";
            this.dataGridTextBoxColumn4.MappingName = "descr";
            this.dataGridTextBoxColumn4.Width = 150;
            // 
            // lblEstatusA
            // 
            this.lblEstatusA.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstatusA.ForeColor = System.Drawing.Color.Green;
            this.lblEstatusA.Location = new System.Drawing.Point(5, 68);
            this.lblEstatusA.Name = "lblEstatusA";
            this.lblEstatusA.Size = new System.Drawing.Size(122, 17);
            this.lblEstatusA.Text = "EMPAQUE";
            this.lblEstatusA.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblEstatusB
            // 
            this.lblEstatusB.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblEstatusB.ForeColor = System.Drawing.Color.Red;
            this.lblEstatusB.Location = new System.Drawing.Point(5, 68);
            this.lblEstatusB.Name = "lblEstatusB";
            this.lblEstatusB.Size = new System.Drawing.Size(122, 17);
            this.lblEstatusB.Text = "DESEMPAQUE";
            this.lblEstatusB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEstatusB.Visible = false;
            // 
            // pbCambia
            // 
            this.pbCambia.Image = ((System.Drawing.Image)(resources.GetObject("pbCambia.Image")));
            this.pbCambia.Location = new System.Drawing.Point(198, 3);
            this.pbCambia.Name = "pbCambia";
            this.pbCambia.Size = new System.Drawing.Size(35, 35);
            this.pbCambia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCambia.Click += new System.EventHandler(this.pbCambia_Click);
            // 
            // FrmEmpaqueAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.lblEstatusB);
            this.Controls.Add(this.lblEstatusA);
            this.Controls.Add(this.dgDetallePed);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPaquete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmEmpaqueAdd";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmEmpaqueAdd_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPaquete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtCant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGrid dgDetallePed;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Label lblEstatusA;
        private System.Windows.Forms.BindingSource detallePedidoMercBindingSource;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.Label lblEstatusB;
        private System.Windows.Forms.PictureBox pbCambia;
    }
}