namespace SWYRA_Movil
{
    partial class FrmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.pbImprimir = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlImpCod = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlPedidos = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSurtido = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlEmpaque = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlGuías = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlImpCod.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlPedidos.SuspendLayout();
            this.pnlSurtido.SuspendLayout();
            this.pnlEmpaque.SuspendLayout();
            this.pnlGuías.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(20, 3);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(35, 35);
            this.pbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSalir.Click += new System.EventHandler(this.panel2_Click);
            // 
            // pbImprimir
            // 
            this.pbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("pbImprimir.Image")));
            this.pbImprimir.Location = new System.Drawing.Point(20, 3);
            this.pbImprimir.Name = "pbImprimir";
            this.pbImprimir.Size = new System.Drawing.Size(35, 35);
            this.pbImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImprimir.Click += new System.EventHandler(this.pnlImpCod_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(61, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 34);
            this.label1.Text = "Impresión de Código de Barra";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(61, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.Text = "Salir del Sistema";
            // 
            // pnlImpCod
            // 
            this.pnlImpCod.BackColor = System.Drawing.SystemColors.Window;
            this.pnlImpCod.Controls.Add(this.pbImprimir);
            this.pnlImpCod.Controls.Add(this.label1);
            this.pnlImpCod.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImpCod.Location = new System.Drawing.Point(0, 0);
            this.pnlImpCod.Name = "pnlImpCod";
            this.pnlImpCod.Size = new System.Drawing.Size(238, 45);
            this.pnlImpCod.Click += new System.EventHandler(this.pnlImpCod_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pbSalir);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 40);
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // pnlPedidos
            // 
            this.pnlPedidos.BackColor = System.Drawing.SystemColors.Window;
            this.pnlPedidos.Controls.Add(this.pictureBox1);
            this.pnlPedidos.Controls.Add(this.label3);
            this.pnlPedidos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPedidos.Location = new System.Drawing.Point(0, 45);
            this.pnlPedidos.Name = "pnlPedidos";
            this.pnlPedidos.Size = new System.Drawing.Size(238, 45);
            this.pnlPedidos.Click += new System.EventHandler(this.pnlPedidos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.Click += new System.EventHandler(this.pnlPedidos_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(61, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.Text = "Pedidos";
            // 
            // pnlSurtido
            // 
            this.pnlSurtido.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSurtido.Controls.Add(this.pictureBox2);
            this.pnlSurtido.Controls.Add(this.label4);
            this.pnlSurtido.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSurtido.Location = new System.Drawing.Point(0, 90);
            this.pnlSurtido.Name = "pnlSurtido";
            this.pnlSurtido.Size = new System.Drawing.Size(238, 45);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(20, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(61, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 15);
            this.label4.Text = "Área de Surtido";
            // 
            // pnlEmpaque
            // 
            this.pnlEmpaque.BackColor = System.Drawing.SystemColors.Window;
            this.pnlEmpaque.Controls.Add(this.pictureBox3);
            this.pnlEmpaque.Controls.Add(this.label5);
            this.pnlEmpaque.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEmpaque.Location = new System.Drawing.Point(0, 135);
            this.pnlEmpaque.Name = "pnlEmpaque";
            this.pnlEmpaque.Size = new System.Drawing.Size(238, 45);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(20, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(61, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 15);
            this.label5.Text = "Epaquetado";
            // 
            // pnlGuías
            // 
            this.pnlGuías.BackColor = System.Drawing.SystemColors.Window;
            this.pnlGuías.Controls.Add(this.pictureBox4);
            this.pnlGuías.Controls.Add(this.label6);
            this.pnlGuías.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGuías.Location = new System.Drawing.Point(0, 180);
            this.pnlGuías.Name = "pnlGuías";
            this.pnlGuías.Size = new System.Drawing.Size(238, 45);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(20, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(35, 35);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(61, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 35);
            this.label6.Text = "Levantamiento de Guías ";
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.pnlGuías);
            this.Controls.Add(this.pnlEmpaque);
            this.Controls.Add(this.pnlSurtido);
            this.Controls.Add(this.pnlPedidos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlImpCod);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmMenuPrincipal";
            this.Text = "SWYRA";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.pnlImpCod.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlPedidos.ResumeLayout(false);
            this.pnlSurtido.ResumeLayout(false);
            this.pnlEmpaque.ResumeLayout(false);
            this.pnlGuías.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.PictureBox pbImprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlImpCod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlPedidos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSurtido;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlEmpaque;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlGuías;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label6;
    }
}