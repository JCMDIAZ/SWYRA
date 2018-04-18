namespace SWYRA_Movil
{
    partial class FrmAreaEmpaque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAreaEmpaque));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ubicacionEntregaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbAreaEmpaque = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAreaEmpaque = new System.Windows.Forms.TextBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionEntregaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.btnActivar);
            this.panel4.Controls.Add(this.btnCancelar);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 232);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 43);
            // 
            // btnActivar
            // 
            this.btnActivar.BackColor = System.Drawing.Color.Maroon;
            this.btnActivar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnActivar.ForeColor = System.Drawing.Color.White;
            this.btnActivar.Location = new System.Drawing.Point(3, 6);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(93, 31);
            this.btnActivar.TabIndex = 9;
            this.btnActivar.Text = "OK";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Maroon;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(142, 6);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(93, 31);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "CANCELAR";
            // 
            // ubicacionEntregaBindingSource
            // 
            this.ubicacionEntregaBindingSource.DataSource = typeof(SWYRA_Movil.UbicacionEntrega);
            // 
            // cbAreaEmpaque
            // 
            this.cbAreaEmpaque.DataSource = this.ubicacionEntregaBindingSource;
            this.cbAreaEmpaque.DisplayMember = "cve_ubicacion";
            this.cbAreaEmpaque.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbAreaEmpaque.Location = new System.Drawing.Point(4, 169);
            this.cbAreaEmpaque.Name = "cbAreaEmpaque";
            this.cbAreaEmpaque.Size = new System.Drawing.Size(228, 26);
            this.cbAreaEmpaque.TabIndex = 13;
            this.cbAreaEmpaque.ValueMember = "cve_ubicacion";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(16, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 76);
            this.label1.Text = "Área de EMPAQUE :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblPedido.Location = new System.Drawing.Point(15, 50);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(207, 40);
            this.lblPedido.Text = "999999";
            this.lblPedido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 40);
            this.label2.Text = "Pedido Número";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtAreaEmpaque
            // 
            this.txtAreaEmpaque.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtAreaEmpaque.Location = new System.Drawing.Point(5, 169);
            this.txtAreaEmpaque.Name = "txtAreaEmpaque";
            this.txtAreaEmpaque.ReadOnly = true;
            this.txtAreaEmpaque.Size = new System.Drawing.Size(228, 26);
            this.txtAreaEmpaque.TabIndex = 17;
            this.txtAreaEmpaque.Visible = false;
            // 
            // FrmAreaEmpaque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.txtAreaEmpaque);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.cbAreaEmpaque);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmAreaEmpaque";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmAreaEmpaque_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ubicacionEntregaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnActivar;
        public System.Windows.Forms.ComboBox cbAreaEmpaque;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource ubicacionEntregaBindingSource;
        public System.Windows.Forms.TextBox txtAreaEmpaque;
    }
}