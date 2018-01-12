namespace SWYRA
{
    partial class MDIPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.almacenesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.áreasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatusPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorizaciónPedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stb = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.mínimosYMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.condicionesDeProdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remisiónDePedidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.stb.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.catalogosToolStripMenuItem,
            this.operaciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.configuraciónToolStripMenuItem.Text = "&Configuración";
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // catalogosToolStripMenuItem
            // 
            this.catalogosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.almacenesToolStripMenuItem,
            this.áreasToolStripMenuItem,
            this.mínimosYMasterToolStripMenuItem,
            this.condicionesDeProdToolStripMenuItem,
            this.usuariosToolStripMenuItem});
            this.catalogosToolStripMenuItem.Name = "catalogosToolStripMenuItem";
            this.catalogosToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.catalogosToolStripMenuItem.Text = "Catalogos";
            // 
            // almacenesToolStripMenuItem
            // 
            this.almacenesToolStripMenuItem.Name = "almacenesToolStripMenuItem";
            this.almacenesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.almacenesToolStripMenuItem.Text = "&Almacenes";
            this.almacenesToolStripMenuItem.Click += new System.EventHandler(this.almacenesToolStripMenuItem_Click);
            // 
            // áreasToolStripMenuItem
            // 
            this.áreasToolStripMenuItem.Name = "áreasToolStripMenuItem";
            this.áreasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.áreasToolStripMenuItem.Text = "Á&reas";
            this.áreasToolStripMenuItem.Click += new System.EventHandler(this.áreasToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.usuariosToolStripMenuItem.Text = "&Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // operaciónToolStripMenuItem
            // 
            this.operaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.estatusPedidoToolStripMenuItem,
            this.autorizaciónPedidoToolStripMenuItem,
            this.remisiónDePedidoToolStripMenuItem});
            this.operaciónToolStripMenuItem.Name = "operaciónToolStripMenuItem";
            this.operaciónToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.operaciónToolStripMenuItem.Text = "Operación";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Visible = false;
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // estatusPedidoToolStripMenuItem
            // 
            this.estatusPedidoToolStripMenuItem.Name = "estatusPedidoToolStripMenuItem";
            this.estatusPedidoToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.estatusPedidoToolStripMenuItem.Text = "Estatus Pedido";
            this.estatusPedidoToolStripMenuItem.Click += new System.EventHandler(this.estatusPedidoToolStripMenuItem_Click);
            // 
            // autorizaciónPedidoToolStripMenuItem
            // 
            this.autorizaciónPedidoToolStripMenuItem.Name = "autorizaciónPedidoToolStripMenuItem";
            this.autorizaciónPedidoToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.autorizaciónPedidoToolStripMenuItem.Text = "Autorización Pedido";
            this.autorizaciónPedidoToolStripMenuItem.Click += new System.EventHandler(this.autorizaciónPedidoToolStripMenuItem_Click);
            // 
            // stb
            // 
            this.stb.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.stb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.stb.Location = new System.Drawing.Point(0, 539);
            this.stb.Name = "stb";
            this.stb.Size = new System.Drawing.Size(1081, 25);
            this.stb.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(66, 20);
            this.toolStripStatusLabel1.Text = "Usuario: ";
            // 
            // mínimosYMasterToolStripMenuItem
            // 
            this.mínimosYMasterToolStripMenuItem.Name = "mínimosYMasterToolStripMenuItem";
            this.mínimosYMasterToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mínimosYMasterToolStripMenuItem.Text = "Mínimos y Master";
            // 
            // condicionesDeProdToolStripMenuItem
            // 
            this.condicionesDeProdToolStripMenuItem.Name = "condicionesDeProdToolStripMenuItem";
            this.condicionesDeProdToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.condicionesDeProdToolStripMenuItem.Text = "Condiciones de Prod.";
            // 
            // remisiónDePedidoToolStripMenuItem
            // 
            this.remisiónDePedidoToolStripMenuItem.Name = "remisiónDePedidoToolStripMenuItem";
            this.remisiónDePedidoToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.remisiónDePedidoToolStripMenuItem.Text = "Remisión de Pedido";
            // 
            // MDIPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SWYRA.Properties.Resources._2561;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1081, 564);
            this.Controls.Add(this.stb);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Almacen";
            this.TransparencyKey = System.Drawing.Color.White;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.stb.ResumeLayout(false);
            this.stb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip stb;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem operaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem catalogosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem almacenesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem áreasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatusPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorizaciónPedidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mínimosYMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem condicionesDeProdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remisiónDePedidoToolStripMenuItem;
    }
}

