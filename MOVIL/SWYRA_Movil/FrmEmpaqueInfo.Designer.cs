namespace SWYRA_Movil
{
    partial class FrmEmpaqueInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpaqueInfo));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTipoServicio = new System.Windows.Forms.TextBox();
            this.txtEstatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOcuDom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtConsigna = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
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
            // lblCliente
            // 
            this.lblCliente.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblCliente.Location = new System.Drawing.Point(79, 26);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(157, 25);
            this.lblCliente.Text = "cliente";
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(79, 9);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(69, 17);
            this.lblPedido.Text = "9999";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.Text = "Cliente :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.Text = "Pedido :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.Text = "Servicio :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTipoServicio
            // 
            this.txtTipoServicio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtTipoServicio.Location = new System.Drawing.Point(78, 74);
            this.txtTipoServicio.Name = "txtTipoServicio";
            this.txtTipoServicio.Size = new System.Drawing.Size(149, 19);
            this.txtTipoServicio.TabIndex = 11;
            // 
            // txtEstatus
            // 
            this.txtEstatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtEstatus.Location = new System.Drawing.Point(78, 95);
            this.txtEstatus.Name = "txtEstatus";
            this.txtEstatus.Size = new System.Drawing.Size(149, 19);
            this.txtEstatus.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.Text = "Estatus :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtOcuDom
            // 
            this.txtOcuDom.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtOcuDom.Location = new System.Drawing.Point(78, 116);
            this.txtOcuDom.Name = "txtOcuDom";
            this.txtOcuDom.Size = new System.Drawing.Size(149, 19);
            this.txtOcuDom.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.Text = "Ocu/Dom :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtUbicacion.Location = new System.Drawing.Point(78, 137);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(149, 19);
            this.txtUbicacion.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(3, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.Text = "Ubicación :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtConsigna
            // 
            this.txtConsigna.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtConsigna.Location = new System.Drawing.Point(78, 158);
            this.txtConsigna.Multiline = true;
            this.txtConsigna.Name = "txtConsigna";
            this.txtConsigna.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsigna.Size = new System.Drawing.Size(149, 36);
            this.txtConsigna.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(3, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.Text = "Dirección :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtObservaciones.Location = new System.Drawing.Point(78, 196);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservaciones.Size = new System.Drawing.Size(149, 36);
            this.txtObservaciones.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 32);
            this.label8.Text = "Observa-ciones :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtFecha
            // 
            this.txtFecha.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtFecha.Location = new System.Drawing.Point(78, 53);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(149, 19);
            this.txtFecha.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(3, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.Text = "Fecha :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmEmpaqueInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtConsigna);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOcuDom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEstatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTipoServicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmEmpaqueInfo";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmEmpaqueInfo_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTipoServicio;
        private System.Windows.Forms.TextBox txtEstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOcuDom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtConsigna;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label label9;
    }
}