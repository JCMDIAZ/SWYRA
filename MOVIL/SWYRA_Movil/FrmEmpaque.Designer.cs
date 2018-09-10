namespace SWYRA_Movil
{
    partial class FrmEmpaque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpaque));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.catalogosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbTipoEmpaque = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbTransfer = new System.Windows.Forms.PictureBox();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.pbConcluir = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.pbAgregar = new System.Windows.Forms.PictureBox();
            this.pbEmpacar = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pbElimina = new System.Windows.Forms.PictureBox();
            this.pbImprimir = new System.Windows.Forms.PictureBox();
            this.detallePedidoMercBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgPedidos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.pbListado = new System.Windows.Forms.PictureBox();
            this.lblfletes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.catalogosBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.Text = "Pedido :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.Text = "Cliente :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(78, 3);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(69, 17);
            this.lblPedido.Text = "9999";
            // 
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCliente.Location = new System.Drawing.Point(78, 20);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(157, 25);
            this.lblCliente.Text = "cliente";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(7, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 18);
            this.label5.Text = "Tipo Empaque :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // catalogosBindingSource
            // 
            this.catalogosBindingSource.AllowNew = false;
            this.catalogosBindingSource.DataSource = typeof(SWYRA_Movil.Catalogos);
            // 
            // cbTipoEmpaque
            // 
            this.cbTipoEmpaque.DataSource = this.catalogosBindingSource;
            this.cbTipoEmpaque.DisplayMember = "valor";
            this.cbTipoEmpaque.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.cbTipoEmpaque.Location = new System.Drawing.Point(104, 50);
            this.cbTipoEmpaque.Name = "cbTipoEmpaque";
            this.cbTipoEmpaque.Size = new System.Drawing.Size(129, 19);
            this.cbTipoEmpaque.TabIndex = 2;
            this.cbTipoEmpaque.ValueMember = "valor";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pbTransfer);
            this.panel2.Controls.Add(this.pbInfo);
            this.panel2.Controls.Add(this.lblPendientes);
            this.panel2.Controls.Add(this.pbConcluir);
            this.panel2.Controls.Add(this.pbSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 40);
            // 
            // pbTransfer
            // 
            this.pbTransfer.Image = ((System.Drawing.Image)(resources.GetObject("pbTransfer.Image")));
            this.pbTransfer.Location = new System.Drawing.Point(122, 3);
            this.pbTransfer.Name = "pbTransfer";
            this.pbTransfer.Size = new System.Drawing.Size(35, 35);
            this.pbTransfer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTransfer.Click += new System.EventHandler(this.pbTransfer_Click);
            // 
            // pbInfo
            // 
            this.pbInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbInfo.Image")));
            this.pbInfo.Location = new System.Drawing.Point(160, 3);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(35, 35);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbInfo.Click += new System.EventHandler(this.pbInfo_Click);
            // 
            // lblPendientes
            // 
            this.lblPendientes.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Italic);
            this.lblPendientes.Location = new System.Drawing.Point(44, 11);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(69, 18);
            this.lblPendientes.Text = "Pend. 0";
            // 
            // pbConcluir
            // 
            this.pbConcluir.Image = ((System.Drawing.Image)(resources.GetObject("pbConcluir.Image")));
            this.pbConcluir.Location = new System.Drawing.Point(198, 3);
            this.pbConcluir.Name = "pbConcluir";
            this.pbConcluir.Size = new System.Drawing.Size(35, 35);
            this.pbConcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbConcluir.Visible = false;
            this.pbConcluir.Click += new System.EventHandler(this.pbConcluir_Click);
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
            // pbAgregar
            // 
            this.pbAgregar.Image = ((System.Drawing.Image)(resources.GetObject("pbAgregar.Image")));
            this.pbAgregar.Location = new System.Drawing.Point(8, 72);
            this.pbAgregar.Name = "pbAgregar";
            this.pbAgregar.Size = new System.Drawing.Size(35, 35);
            this.pbAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAgregar.Click += new System.EventHandler(this.pbAgregar_Click);
            // 
            // pbEmpacar
            // 
            this.pbEmpacar.Image = ((System.Drawing.Image)(resources.GetObject("pbEmpacar.Image")));
            this.pbEmpacar.Location = new System.Drawing.Point(46, 72);
            this.pbEmpacar.Name = "pbEmpacar";
            this.pbEmpacar.Size = new System.Drawing.Size(35, 35);
            this.pbEmpacar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbEmpacar.Click += new System.EventHandler(this.pbEmpacar_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(122, 72);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pbElimina
            // 
            this.pbElimina.Image = ((System.Drawing.Image)(resources.GetObject("pbElimina.Image")));
            this.pbElimina.Location = new System.Drawing.Point(84, 73);
            this.pbElimina.Name = "pbElimina";
            this.pbElimina.Size = new System.Drawing.Size(35, 35);
            this.pbElimina.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbElimina.Click += new System.EventHandler(this.pbElimina_Click);
            // 
            // pbImprimir
            // 
            this.pbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("pbImprimir.Image")));
            this.pbImprimir.Location = new System.Drawing.Point(198, 72);
            this.pbImprimir.Name = "pbImprimir";
            this.pbImprimir.Size = new System.Drawing.Size(35, 35);
            this.pbImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImprimir.Click += new System.EventHandler(this.pbImprimir_Click);
            // 
            // detallePedidoMercBindingSource
            // 
            this.detallePedidoMercBindingSource.AllowNew = false;
            this.detallePedidoMercBindingSource.DataSource = typeof(SWYRA_Movil.DetallePedidoMerc);
            // 
            // dgPedidos
            // 
            this.dgPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgPedidos.DataSource = this.detallePedidoMercBindingSource;
            this.dgPedidos.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.dgPedidos.Location = new System.Drawing.Point(8, 111);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.Size = new System.Drawing.Size(223, 104);
            this.dgPedidos.TabIndex = 20;
            this.dgPedidos.TableStyles.Add(this.dataGridTableStyle1);
            this.dgPedidos.CurrentCellChanged += new System.EventHandler(this.dgPedidos_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.MappingName = "detallePedidoMerc";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Consec.";
            this.dataGridTextBoxColumn1.MappingName = "consec_empaque";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 45;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "Empaque";
            this.dataGridTextBoxColumn2.MappingName = "tipopaquete";
            this.dataGridTextBoxColumn2.Width = 80;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "Artículos";
            this.dataGridTextBoxColumn3.MappingName = "totart";
            this.dataGridTextBoxColumn3.Width = 80;
            // 
            // pbListado
            // 
            this.pbListado.Image = ((System.Drawing.Image)(resources.GetObject("pbListado.Image")));
            this.pbListado.Location = new System.Drawing.Point(160, 72);
            this.pbListado.Name = "pbListado";
            this.pbListado.Size = new System.Drawing.Size(35, 35);
            this.pbListado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbListado.Click += new System.EventHandler(this.pbListado_Click);
            // 
            // lblfletes
            // 
            this.lblfletes.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.lblfletes.ForeColor = System.Drawing.Color.Maroon;
            this.lblfletes.Location = new System.Drawing.Point(3, 214);
            this.lblfletes.Name = "lblfletes";
            this.lblfletes.Size = new System.Drawing.Size(232, 21);
            this.lblfletes.Text = "fletes : ";
            this.lblfletes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmEmpaque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.lblfletes);
            this.Controls.Add(this.pbListado);
            this.Controls.Add(this.dgPedidos);
            this.Controls.Add(this.pbImprimir);
            this.Controls.Add(this.pbElimina);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pbEmpacar);
            this.Controls.Add(this.pbAgregar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbTipoEmpaque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmEmpaque";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmEmpaque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.catalogosBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbTipoEmpaque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbConcluir;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.PictureBox pbAgregar;
        private System.Windows.Forms.PictureBox pbEmpacar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pbElimina;
        private System.Windows.Forms.PictureBox pbImprimir;
        private System.Windows.Forms.DataGrid dgPedidos;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.BindingSource catalogosBindingSource;
        private System.Windows.Forms.BindingSource detallePedidoMercBindingSource;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.PictureBox pbListado;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Label lblfletes;
        private System.Windows.Forms.PictureBox pbTransfer;
    }
}