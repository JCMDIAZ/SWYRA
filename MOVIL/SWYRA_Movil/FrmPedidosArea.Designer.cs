namespace SWYRA_Movil
{
    partial class FrmPedidosArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidosArea));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgPedidos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dgtEstatus = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtPrioridad = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtServicio = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtPedido = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtCliente = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dgtFecha = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbAsignar = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.dgtCve_clpv = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgPedidos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 235);
            // 
            // pedidosBindingSource
            // 
            this.pedidosBindingSource.AllowNew = false;
            this.pedidosBindingSource.DataSource = typeof(SWYRA_Movil.Pedidos);
            // 
            // dgPedidos
            // 
            this.dgPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgPedidos.DataSource = this.pedidosBindingSource;
            this.dgPedidos.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.dgPedidos.Location = new System.Drawing.Point(8, 23);
            this.dgPedidos.Name = "dgPedidos";
            this.dgPedidos.Size = new System.Drawing.Size(223, 206);
            this.dgPedidos.TabIndex = 15;
            this.dgPedidos.TableStyles.Add(this.dataGridTableStyle1);
            this.dgPedidos.CurrentCellChanged += new System.EventHandler(this.dgPedidos_CurrentCellChanged);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dgtCve_clpv);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dgtCliente);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dgtPedido);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dgtFecha);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dgtEstatus);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dgtServicio);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dgtPrioridad);
            this.dataGridTableStyle1.MappingName = "Pedidos";
            // 
            // dgtEstatus
            // 
            this.dgtEstatus.Format = "";
            this.dgtEstatus.FormatInfo = null;
            this.dgtEstatus.HeaderText = "Estatus";
            this.dgtEstatus.MappingName = "estatuspedido";
            // 
            // dgtPrioridad
            // 
            this.dgtPrioridad.Format = "";
            this.dgtPrioridad.FormatInfo = null;
            this.dgtPrioridad.HeaderText = "Prioridad";
            this.dgtPrioridad.MappingName = "prioridad";
            // 
            // dgtServicio
            // 
            this.dgtServicio.Format = "";
            this.dgtServicio.FormatInfo = null;
            this.dgtServicio.HeaderText = "Servicio";
            this.dgtServicio.MappingName = "tiposervicio";
            // 
            // dgtPedido
            // 
            this.dgtPedido.Format = "";
            this.dgtPedido.FormatInfo = null;
            this.dgtPedido.HeaderText = "Pedido";
            this.dgtPedido.MappingName = "cve_doc";
            this.dgtPedido.Width = 60;
            // 
            // dgtCliente
            // 
            this.dgtCliente.Format = "";
            this.dgtCliente.FormatInfo = null;
            this.dgtCliente.HeaderText = "Cliente";
            this.dgtCliente.MappingName = "cliente";
            this.dgtCliente.Width = 150;
            // 
            // dgtFecha
            // 
            this.dgtFecha.Format = "dd-MMM-yyyy";
            this.dgtFecha.FormatInfo = null;
            this.dgtFecha.MappingName = "fecha_doc";
            this.dgtFecha.Width = 60;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 20);
            this.label1.Text = "Selecciona Pedido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pbAsignar);
            this.panel2.Controls.Add(this.pbSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 40);
            // 
            // pbAsignar
            // 
            this.pbAsignar.Image = ((System.Drawing.Image)(resources.GetObject("pbAsignar.Image")));
            this.pbAsignar.Location = new System.Drawing.Point(198, 3);
            this.pbAsignar.Name = "pbAsignar";
            this.pbAsignar.Size = new System.Drawing.Size(35, 35);
            this.pbAsignar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAsignar.Click += new System.EventHandler(this.pbAsignar_Click);
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
            // dgtCve_clpv
            // 
            this.dgtCve_clpv.Format = "";
            this.dgtCve_clpv.FormatInfo = null;
            this.dgtCve_clpv.HeaderText = "# Clte.";
            this.dgtCve_clpv.MappingName = "cve_clpv";
            // 
            // FrmPedidosArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmPedidosArea";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmPedidosArea_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGrid dgPedidos;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbAsignar;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.BindingSource pedidosBindingSource;
        private System.Windows.Forms.DataGridTextBoxColumn dgtEstatus;
        private System.Windows.Forms.DataGridTextBoxColumn dgtPrioridad;
        private System.Windows.Forms.DataGridTextBoxColumn dgtServicio;
        private System.Windows.Forms.DataGridTextBoxColumn dgtPedido;
        private System.Windows.Forms.DataGridTextBoxColumn dgtCliente;
        private System.Windows.Forms.DataGridTextBoxColumn dgtFecha;
        private System.Windows.Forms.DataGridTextBoxColumn dgtCve_clpv;
    }
}