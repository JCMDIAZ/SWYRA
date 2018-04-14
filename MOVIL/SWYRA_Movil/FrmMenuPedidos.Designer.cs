namespace SWYRA_Movil
{
    partial class FrmMenuPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPedidos));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlRetornar = new System.Windows.Forms.Panel();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.pnlPorSurtir = new System.Windows.Forms.Panel();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.txtPrioridad = new System.Windows.Forms.TextBox();
            this.txtServicio = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbImprimir = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSurtir = new System.Windows.Forms.Panel();
            this.pnlDevolver = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.pbDevolucion = new System.Windows.Forms.PictureBox();
            this.pnlDetener = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pbDetenido = new System.Windows.Forms.PictureBox();
            this.pnlIncompletos = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pbIncompletos = new System.Windows.Forms.PictureBox();
            this.pnlArea = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTransferir = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.pbTransferir = new System.Windows.Forms.PictureBox();
            this.pnlConcluir = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pbConcluir = new System.Windows.Forms.PictureBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlRetornar.SuspendLayout();
            this.pnlPorSurtir.SuspendLayout();
            this.pnlSurtir.SuspendLayout();
            this.pnlDevolver.SuspendLayout();
            this.pnlDetener.SuspendLayout();
            this.pnlIncompletos.SuspendLayout();
            this.pnlArea.SuspendLayout();
            this.pnlTransferir.SuspendLayout();
            this.pnlConcluir.SuspendLayout();
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
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click);
            // 
            // pnlPorSurtir
            // 
            this.pnlPorSurtir.BackColor = System.Drawing.SystemColors.Window;
            this.pnlPorSurtir.Controls.Add(this.txtMonto);
            this.pnlPorSurtir.Controls.Add(this.label13);
            this.pnlPorSurtir.Controls.Add(this.txtVendedor);
            this.pnlPorSurtir.Controls.Add(this.txtPrioridad);
            this.pnlPorSurtir.Controls.Add(this.txtServicio);
            this.pnlPorSurtir.Controls.Add(this.txtCliente);
            this.pnlPorSurtir.Controls.Add(this.txtPedido);
            this.pnlPorSurtir.Controls.Add(this.label10);
            this.pnlPorSurtir.Controls.Add(this.label8);
            this.pnlPorSurtir.Controls.Add(this.label9);
            this.pnlPorSurtir.Controls.Add(this.label6);
            this.pnlPorSurtir.Controls.Add(this.label2);
            this.pnlPorSurtir.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPorSurtir.Location = new System.Drawing.Point(0, 0);
            this.pnlPorSurtir.Name = "pnlPorSurtir";
            this.pnlPorSurtir.Size = new System.Drawing.Size(238, 130);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtVendedor.Location = new System.Drawing.Point(97, 89);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(134, 17);
            this.txtVendedor.TabIndex = 22;
            // 
            // txtPrioridad
            // 
            this.txtPrioridad.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtPrioridad.Location = new System.Drawing.Point(97, 71);
            this.txtPrioridad.Name = "txtPrioridad";
            this.txtPrioridad.ReadOnly = true;
            this.txtPrioridad.Size = new System.Drawing.Size(134, 17);
            this.txtPrioridad.TabIndex = 21;
            // 
            // txtServicio
            // 
            this.txtServicio.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtServicio.Location = new System.Drawing.Point(97, 53);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.ReadOnly = true;
            this.txtServicio.Size = new System.Drawing.Size(134, 17);
            this.txtServicio.TabIndex = 20;
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtCliente.Location = new System.Drawing.Point(97, 23);
            this.txtCliente.Multiline = true;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(134, 29);
            this.txtCliente.TabIndex = 19;
            // 
            // txtPedido
            // 
            this.txtPedido.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtPedido.Location = new System.Drawing.Point(97, 5);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.ReadOnly = true;
            this.txtPedido.Size = new System.Drawing.Size(134, 17);
            this.txtPedido.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(4, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.Text = "Vendedor";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(4, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.Text = "Prioridad";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(4, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.Text = "Servicio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.Text = "Cliente";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.Text = "Pedido No.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbImprimir
            // 
            this.pbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("pbImprimir.Image")));
            this.pbImprimir.Location = new System.Drawing.Point(16, 3);
            this.pbImprimir.Name = "pbImprimir";
            this.pbImprimir.Size = new System.Drawing.Size(18, 18);
            this.pbImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImprimir.Click += new System.EventHandler(this.pbImprimir_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(35, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.Text = "Surtir";
            // 
            // pnlSurtir
            // 
            this.pnlSurtir.BackColor = System.Drawing.SystemColors.Window;
            this.pnlSurtir.Controls.Add(this.label1);
            this.pnlSurtir.Controls.Add(this.pbImprimir);
            this.pnlSurtir.Location = new System.Drawing.Point(0, 132);
            this.pnlSurtir.Name = "pnlSurtir";
            this.pnlSurtir.Size = new System.Drawing.Size(115, 24);
            this.pnlSurtir.Click += new System.EventHandler(this.pbImprimir_Click);
            // 
            // pnlDevolver
            // 
            this.pnlDevolver.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDevolver.Controls.Add(this.label7);
            this.pnlDevolver.Controls.Add(this.pbDevolucion);
            this.pnlDevolver.Location = new System.Drawing.Point(0, 157);
            this.pnlDevolver.Name = "pnlDevolver";
            this.pnlDevolver.Size = new System.Drawing.Size(115, 24);
            this.pnlDevolver.Click += new System.EventHandler(this.pbDevolucion_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(35, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.Text = "Devolución";
            // 
            // pbDevolucion
            // 
            this.pbDevolucion.Image = ((System.Drawing.Image)(resources.GetObject("pbDevolucion.Image")));
            this.pbDevolucion.Location = new System.Drawing.Point(16, 3);
            this.pbDevolucion.Name = "pbDevolucion";
            this.pbDevolucion.Size = new System.Drawing.Size(18, 18);
            this.pbDevolucion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDevolucion.Click += new System.EventHandler(this.pbDevolucion_Click);
            // 
            // pnlDetener
            // 
            this.pnlDetener.BackColor = System.Drawing.SystemColors.Window;
            this.pnlDetener.Controls.Add(this.label3);
            this.pnlDetener.Controls.Add(this.pbDetenido);
            this.pnlDetener.Location = new System.Drawing.Point(120, 132);
            this.pnlDetener.Name = "pnlDetener";
            this.pnlDetener.Size = new System.Drawing.Size(115, 24);
            this.pnlDetener.Click += new System.EventHandler(this.pbDetenido_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(35, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.Text = "Detener";
            // 
            // pbDetenido
            // 
            this.pbDetenido.Image = ((System.Drawing.Image)(resources.GetObject("pbDetenido.Image")));
            this.pbDetenido.Location = new System.Drawing.Point(16, 3);
            this.pbDetenido.Name = "pbDetenido";
            this.pbDetenido.Size = new System.Drawing.Size(18, 18);
            this.pbDetenido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDetenido.Click += new System.EventHandler(this.pbDetenido_Click);
            // 
            // pnlIncompletos
            // 
            this.pnlIncompletos.BackColor = System.Drawing.SystemColors.Window;
            this.pnlIncompletos.Controls.Add(this.label4);
            this.pnlIncompletos.Controls.Add(this.pbIncompletos);
            this.pnlIncompletos.Location = new System.Drawing.Point(120, 157);
            this.pnlIncompletos.Name = "pnlIncompletos";
            this.pnlIncompletos.Size = new System.Drawing.Size(115, 24);
            this.pnlIncompletos.Click += new System.EventHandler(this.pbIncompletos_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(35, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.Text = "Incompletos";
            // 
            // pbIncompletos
            // 
            this.pbIncompletos.Image = ((System.Drawing.Image)(resources.GetObject("pbIncompletos.Image")));
            this.pbIncompletos.Location = new System.Drawing.Point(16, 3);
            this.pbIncompletos.Name = "pbIncompletos";
            this.pbIncompletos.Size = new System.Drawing.Size(18, 18);
            this.pbIncompletos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIncompletos.Click += new System.EventHandler(this.pbIncompletos_Click);
            // 
            // pnlArea
            // 
            this.pnlArea.BackColor = System.Drawing.SystemColors.Window;
            this.pnlArea.Controls.Add(this.label5);
            this.pnlArea.Controls.Add(this.pictureBox1);
            this.pnlArea.Location = new System.Drawing.Point(120, 182);
            this.pnlArea.Name = "pnlArea";
            this.pnlArea.Size = new System.Drawing.Size(115, 24);
            this.pnlArea.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(35, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.Text = "Sol. a áreas";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pnlTransferir
            // 
            this.pnlTransferir.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTransferir.Controls.Add(this.label11);
            this.pnlTransferir.Controls.Add(this.pbTransferir);
            this.pnlTransferir.Location = new System.Drawing.Point(0, 182);
            this.pnlTransferir.Name = "pnlTransferir";
            this.pnlTransferir.Size = new System.Drawing.Size(115, 24);
            this.pnlTransferir.Click += new System.EventHandler(this.pbTransferir_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(35, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 16);
            this.label11.Text = "Transferir";
            // 
            // pbTransferir
            // 
            this.pbTransferir.Image = ((System.Drawing.Image)(resources.GetObject("pbTransferir.Image")));
            this.pbTransferir.Location = new System.Drawing.Point(16, 3);
            this.pbTransferir.Name = "pbTransferir";
            this.pbTransferir.Size = new System.Drawing.Size(18, 18);
            this.pbTransferir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTransferir.Click += new System.EventHandler(this.pbTransferir_Click);
            // 
            // pnlConcluir
            // 
            this.pnlConcluir.BackColor = System.Drawing.SystemColors.Window;
            this.pnlConcluir.Controls.Add(this.label12);
            this.pnlConcluir.Controls.Add(this.pbConcluir);
            this.pnlConcluir.Location = new System.Drawing.Point(0, 207);
            this.pnlConcluir.Name = "pnlConcluir";
            this.pnlConcluir.Size = new System.Drawing.Size(115, 24);
            this.pnlConcluir.Click += new System.EventHandler(this.pbConcluir_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(35, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 16);
            this.label12.Text = "Concluir";
            // 
            // pbConcluir
            // 
            this.pbConcluir.Image = ((System.Drawing.Image)(resources.GetObject("pbConcluir.Image")));
            this.pbConcluir.Location = new System.Drawing.Point(16, 3);
            this.pbConcluir.Name = "pbConcluir";
            this.pbConcluir.Size = new System.Drawing.Size(18, 18);
            this.pbConcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbConcluir.Click += new System.EventHandler(this.pbConcluir_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtMonto.Location = new System.Drawing.Point(97, 107);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(134, 17);
            this.txtMonto.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(4, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 14);
            this.label13.Text = "Monto";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmMenuPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.pnlConcluir);
            this.Controls.Add(this.pnlArea);
            this.Controls.Add(this.pnlTransferir);
            this.Controls.Add(this.pnlIncompletos);
            this.Controls.Add(this.pnlDetener);
            this.Controls.Add(this.pnlDevolver);
            this.Controls.Add(this.pnlSurtir);
            this.Controls.Add(this.pnlRetornar);
            this.Controls.Add(this.pnlPorSurtir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmMenuPedidos";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmMenuPedidos_Load);
            this.pnlRetornar.ResumeLayout(false);
            this.pnlPorSurtir.ResumeLayout(false);
            this.pnlSurtir.ResumeLayout(false);
            this.pnlDevolver.ResumeLayout(false);
            this.pnlDetener.ResumeLayout(false);
            this.pnlIncompletos.ResumeLayout(false);
            this.pnlArea.ResumeLayout(false);
            this.pnlTransferir.ResumeLayout(false);
            this.pnlConcluir.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRetornar;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Panel pnlPorSurtir;
        private System.Windows.Forms.PictureBox pbImprimir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSurtir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.TextBox txtServicio;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.TextBox txtPrioridad;
        private System.Windows.Forms.Panel pnlDevolver;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbDevolucion;
        private System.Windows.Forms.Panel pnlDetener;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbDetenido;
        private System.Windows.Forms.Panel pnlIncompletos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbIncompletos;
        private System.Windows.Forms.Panel pnlArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlTransferir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbTransferir;
        private System.Windows.Forms.Panel pnlConcluir;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbConcluir;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label13;
    }
}