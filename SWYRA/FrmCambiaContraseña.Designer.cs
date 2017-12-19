namespace SWYRA
{
    partial class FrmCambiaContraseña
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCambiaContraseña));
            this.GpoEmpleados = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.Txtcpass = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Txtnpass = new System.Windows.Forms.TextBox();
            this.Txtapass = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.GpoEmpleados.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GpoEmpleados
            // 
            this.GpoEmpleados.Controls.Add(this.Label4);
            this.GpoEmpleados.Controls.Add(this.TxtUsuario);
            this.GpoEmpleados.Controls.Add(this.Txtcpass);
            this.GpoEmpleados.Controls.Add(this.Label1);
            this.GpoEmpleados.Controls.Add(this.Label5);
            this.GpoEmpleados.Controls.Add(this.Label2);
            this.GpoEmpleados.Controls.Add(this.Txtnpass);
            this.GpoEmpleados.Controls.Add(this.Txtapass);
            this.GpoEmpleados.Location = new System.Drawing.Point(13, 31);
            this.GpoEmpleados.Margin = new System.Windows.Forms.Padding(4);
            this.GpoEmpleados.Name = "GpoEmpleados";
            this.GpoEmpleados.Padding = new System.Windows.Forms.Padding(4);
            this.GpoEmpleados.Size = new System.Drawing.Size(365, 157);
            this.GpoEmpleados.TabIndex = 43;
            this.GpoEmpleados.TabStop = false;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(11, 119);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 18);
            this.Label4.TabIndex = 32;
            this.Label4.Text = "Conf. Contraseña";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtUsuario.Enabled = false;
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(157, 23);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.ReadOnly = true;
            this.TxtUsuario.Size = new System.Drawing.Size(200, 24);
            this.TxtUsuario.TabIndex = 4;
            // 
            // Txtcpass
            // 
            this.Txtcpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcpass.Location = new System.Drawing.Point(157, 116);
            this.Txtcpass.Margin = new System.Windows.Forms.Padding(4);
            this.Txtcpass.MaxLength = 4;
            this.Txtcpass.Name = "Txtcpass";
            this.Txtcpass.PasswordChar = '*';
            this.Txtcpass.Size = new System.Drawing.Size(200, 24);
            this.Txtcpass.TabIndex = 7;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(76, 26);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(60, 18);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Usuario";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(17, 88);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(119, 18);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "Nva. Contraseña";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(22, 57);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(114, 18);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Contraseña Ant.";
            // 
            // Txtnpass
            // 
            this.Txtnpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtnpass.Location = new System.Drawing.Point(157, 85);
            this.Txtnpass.Margin = new System.Windows.Forms.Padding(4);
            this.Txtnpass.MaxLength = 4;
            this.Txtnpass.Name = "Txtnpass";
            this.Txtnpass.PasswordChar = '*';
            this.Txtnpass.Size = new System.Drawing.Size(200, 24);
            this.Txtnpass.TabIndex = 6;
            // 
            // Txtapass
            // 
            this.Txtapass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Txtapass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtapass.Location = new System.Drawing.Point(157, 54);
            this.Txtapass.Margin = new System.Windows.Forms.Padding(4);
            this.Txtapass.MaxLength = 4;
            this.Txtapass.Name = "Txtapass";
            this.Txtapass.PasswordChar = '*';
            this.Txtapass.Size = new System.Drawing.Size(200, 24);
            this.Txtapass.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnLimpiar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(391, 27);
            this.toolStrip1.TabIndex = 44;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::SWYRA.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(93, 24);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::SWYRA.Properties.Resources._1366681822_edit_clear;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(87, 24);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(61, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmCambiaContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(391, 198);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.GpoEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCambiaContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CAMBIA CONTRASEÑA";
            this.Load += new System.EventHandler(this.FrmCambiaContraseña_Load);
            this.GpoEmpleados.ResumeLayout(false);
            this.GpoEmpleados.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox GpoEmpleados;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox TxtUsuario;
        internal System.Windows.Forms.TextBox Txtcpass;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox Txtnpass;
        internal System.Windows.Forms.TextBox Txtapass;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
    }
}