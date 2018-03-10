namespace SWYRA_Movil
{
    partial class FrmIncompleto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIncompleto));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlRetornar = new System.Windows.Forms.Panel();
            this.pbSalir = new System.Windows.Forms.PictureBox();
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
            this.lblPedido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pbRegresar = new System.Windows.Forms.PictureBox();
            this.pnlRetornar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRetornar
            // 
            this.pnlRetornar.BackColor = System.Drawing.SystemColors.Window;
            this.pnlRetornar.Controls.Add(this.pbRegresar);
            this.pnlRetornar.Controls.Add(this.pbSalir);
            this.pnlRetornar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRetornar.Location = new System.Drawing.Point(0, 235);
            this.pnlRetornar.Name = "pnlRetornar";
            this.pnlRetornar.Size = new System.Drawing.Size(238, 40);
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(4, 3);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(35, 35);
            this.pbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click);
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
            this.dgDetallePed.Location = new System.Drawing.Point(9, 27);
            this.dgDetallePed.Name = "dgDetallePed";
            this.dgDetallePed.Size = new System.Drawing.Size(220, 198);
            this.dgDetallePed.TabIndex = 17;
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
            this.dataGridTextBoxColumn3.HeaderText = "Pendiente";
            this.dataGridTextBoxColumn3.MappingName = "cantdiferencia";
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
            this.dataGridTextBoxColumn5.HeaderText = "Decripción";
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
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(145, 8);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(81, 11);
            this.lblPedido.Text = "Pedido:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(82, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.Text = "Pedido:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbRegresar
            // 
            this.pbRegresar.Image = ((System.Drawing.Image)(resources.GetObject("pbRegresar.Image")));
            this.pbRegresar.Location = new System.Drawing.Point(198, 2);
            this.pbRegresar.Name = "pbRegresar";
            this.pbRegresar.Size = new System.Drawing.Size(35, 35);
            this.pbRegresar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRegresar.Click += new System.EventHandler(this.pbRegresar_Click);
            // 
            // FrmIncompleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgDetallePed);
            this.Controls.Add(this.pnlRetornar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmIncompleto";
            this.Text = "SWYRA";
            this.Load += new System.EventHandler(this.FrmIncompleto_Load);
            this.pnlRetornar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRetornar;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.DataGrid dgDetallePed;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.BindingSource detallePedidosBindingSource;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.PictureBox pbRegresar;
    }
}