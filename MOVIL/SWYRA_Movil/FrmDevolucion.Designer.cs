namespace SWYRA_Movil
{
    partial class FrmDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucion));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlRetornar = new System.Windows.Forms.Panel();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgDetallePed = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlRetornar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRetornar
            // 
            this.pnlRetornar.BackColor = System.Drawing.SystemColors.Window;
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
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(148, 6);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(81, 11);
            this.lblPedido.Text = "Pedido:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(85, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.Text = "Pedido:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCodigo.Location = new System.Drawing.Point(54, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(175, 19);
            this.txtCodigo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.Text = "Código";
            // 
            // dgDetallePed
            // 
            this.dgDetallePed.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgDetallePed.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.dgDetallePed.Location = new System.Drawing.Point(9, 70);
            this.dgDetallePed.Name = "dgDetallePed";
            this.dgDetallePed.Size = new System.Drawing.Size(220, 159);
            this.dgDetallePed.TabIndex = 17;
            this.dgDetallePed.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.MappingName = "detallePedidos";
            // 
            // txtDescr
            // 
            this.txtDescr.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.txtDescr.Location = new System.Drawing.Point(54, 42);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.ReadOnly = true;
            this.txtDescr.Size = new System.Drawing.Size(175, 22);
            this.txtDescr.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(11, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 19);
            this.label4.Text = "Desc.";
            // 
            // FrmDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgDetallePed);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlRetornar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmDevolucion";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmDevolucion_Load);
            this.pnlRetornar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRetornar;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dgDetallePed;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label4;
    }
}