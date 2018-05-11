namespace SWYRA_Movil
{
    partial class FrmEmpaqueAT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpaqueAT));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbQuita = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.lblPaquete = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.detallePedidoMercBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgDetallePed = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dgDetalleEmp = new System.Windows.Forms.DataGrid();
            this.pbAgrega = new System.Windows.Forms.PictureBox();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pbAgrega);
            this.panel2.Controls.Add(this.pbQuita);
            this.panel2.Controls.Add(this.pbSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 40);
            // 
            // pbQuita
            // 
            this.pbQuita.Image = ((System.Drawing.Image)(resources.GetObject("pbQuita.Image")));
            this.pbQuita.Location = new System.Drawing.Point(198, 3);
            this.pbQuita.Name = "pbQuita";
            this.pbQuita.Size = new System.Drawing.Size(35, 35);
            this.pbQuita.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbQuita.Click += new System.EventHandler(this.pbQuita_Click);
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
            // lblPaquete
            // 
            this.lblPaquete.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPaquete.Location = new System.Drawing.Point(81, 24);
            this.lblPaquete.Name = "lblPaquete";
            this.lblPaquete.Size = new System.Drawing.Size(150, 17);
            this.lblPaquete.Text = "9999";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.Text = "Paquete :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(81, 4);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(150, 20);
            this.lblPedido.Text = "9999";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.Text = "Pedido :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.dgDetallePed.Location = new System.Drawing.Point(6, 3);
            this.dgDetallePed.Name = "dgDetallePed";
            this.dgDetallePed.Size = new System.Drawing.Size(225, 81);
            this.dgDetallePed.TabIndex = 37;
            this.dgDetallePed.TableStyles.Add(this.dataGridTableStyle1);
            this.dgDetallePed.CurrentCellChanged += new System.EventHandler(this.dgDetallePed_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.MappingName = "detallePedidoMerc";
            // 
            // dgDetalleEmp
            // 
            this.dgDetalleEmp.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDetalleEmp.DataSource = this.detallePedidoMercBindingSource;
            this.dgDetalleEmp.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.dgDetalleEmp.Location = new System.Drawing.Point(6, 44);
            this.dgDetalleEmp.Name = "dgDetalleEmp";
            this.dgDetalleEmp.Size = new System.Drawing.Size(225, 86);
            this.dgDetalleEmp.TabIndex = 38;
            this.dgDetalleEmp.TableStyles.Add(this.dataGridTableStyle3);
            this.dgDetalleEmp.CurrentCellChanged += new System.EventHandler(this.dgDetalleEmp_CurrentCellChanged);
            // 
            // pbAgrega
            // 
            this.pbAgrega.Image = ((System.Drawing.Image)(resources.GetObject("pbAgrega.Image")));
            this.pbAgrega.Location = new System.Drawing.Point(157, 3);
            this.pbAgrega.Name = "pbAgrega";
            this.pbAgrega.Size = new System.Drawing.Size(35, 35);
            this.pbAgrega.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAgrega.Click += new System.EventHandler(this.pbAgrega_Click);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.MappingName = "detallePedidoMerc";
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle3.MappingName = "detallePedidoMerc";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.dgDetalleEmp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblPedido);
            this.panel1.Controls.Add(this.lblPaquete);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 135);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Consec.";
            this.dataGridTextBoxColumn1.MappingName = "consec_empaque";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Empaque";
            this.dataGridTextBoxColumn2.MappingName = "tipopaquete";
            this.dataGridTextBoxColumn2.Width = 100;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Artículos";
            this.dataGridTextBoxColumn3.MappingName = "totart";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "Consec";
            this.dataGridTextBoxColumn4.MappingName = "consec_empaque";
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "Empaque";
            this.dataGridTextBoxColumn5.MappingName = "tipopaquete";
            this.dataGridTextBoxColumn5.Width = 100;
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Artículo";
            this.dataGridTextBoxColumn6.MappingName = "totart";
            // 
            // FrmEmpaqueAT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.dgDetallePed);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmEmpaqueAT";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmEmpaqueAT_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbQuita;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Label lblPaquete;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dgDetallePed;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGrid dgDetalleEmp;
        private System.Windows.Forms.PictureBox pbAgrega;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle3;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource detallePedidoMercBindingSource;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
    }
}