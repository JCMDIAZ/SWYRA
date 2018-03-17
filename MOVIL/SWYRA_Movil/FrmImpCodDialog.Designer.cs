namespace SWYRA_Movil
{
    partial class FrmImpCodDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpCodDialog));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.nmCantEti = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nmTotalPiezas = new System.Windows.Forms.NumericUpDown();
            this.lblTotalPiezas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.nmCantEti);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.nmTotalPiezas);
            this.panel3.Controls.Add(this.lblTotalPiezas);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 275);
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
            this.btnActivar.Text = "Aceptar";
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
            this.btnCancelar.Text = "Cancelar";
            // 
            // nmCantEti
            // 
            this.nmCantEti.Location = new System.Drawing.Point(156, 70);
            this.nmCantEti.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmCantEti.Name = "nmCantEti";
            this.nmCantEti.Size = new System.Drawing.Size(71, 24);
            this.nmCantEti.TabIndex = 5;
            this.nmCantEti.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 20);
            this.label7.Text = "Cantidad de Etiquetas ";
            // 
            // nmTotalPiezas
            // 
            this.nmTotalPiezas.Location = new System.Drawing.Point(156, 38);
            this.nmTotalPiezas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmTotalPiezas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmTotalPiezas.Name = "nmTotalPiezas";
            this.nmTotalPiezas.Size = new System.Drawing.Size(71, 24);
            this.nmTotalPiezas.TabIndex = 3;
            this.nmTotalPiezas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTotalPiezas
            // 
            this.lblTotalPiezas.Location = new System.Drawing.Point(10, 43);
            this.lblTotalPiezas.Name = "lblTotalPiezas";
            this.lblTotalPiezas.Size = new System.Drawing.Size(140, 20);
            this.lblTotalPiezas.Text = "Total de Piezas";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 20);
            this.label5.Text = "Impresión de Código de Barra";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmImpCodDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmImpCodDialog";
            this.Text = "SWRYA";
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown nmCantEti;
        public System.Windows.Forms.NumericUpDown nmTotalPiezas;
        public System.Windows.Forms.Label lblTotalPiezas;
    }
}