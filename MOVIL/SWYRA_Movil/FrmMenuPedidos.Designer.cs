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
            this.lblConcluir = new System.Windows.Forms.Label();
            this.pbConcluir = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.pnlPorSurtir = new System.Windows.Forms.Panel();
            this.txtOcurrDom = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
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
            this.pbSurtir = new System.Windows.Forms.PictureBox();
            this.pbRemover = new System.Windows.Forms.PictureBox();
            this.pbDetener = new System.Windows.Forms.PictureBox();
            this.pbIncompletos = new System.Windows.Forms.PictureBox();
            this.pbTransferir = new System.Windows.Forms.PictureBox();
            this.pbDevolucion = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDetenido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblPendS = new System.Windows.Forms.Label();
            this.lblPendM = new System.Windows.Forms.Label();
            this.pnlRetornar.SuspendLayout();
            this.pnlPorSurtir.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRetornar
            // 
            this.pnlRetornar.BackColor = System.Drawing.SystemColors.Window;
            this.pnlRetornar.Controls.Add(this.lblConcluir);
            this.pnlRetornar.Controls.Add(this.pbConcluir);
            this.pnlRetornar.Controls.Add(this.pbSalir);
            this.pnlRetornar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRetornar.Location = new System.Drawing.Point(0, 235);
            this.pnlRetornar.Name = "pnlRetornar";
            this.pnlRetornar.Size = new System.Drawing.Size(238, 40);
            // 
            // lblConcluir
            // 
            this.lblConcluir.Location = new System.Drawing.Point(180, 10);
            this.lblConcluir.Name = "lblConcluir";
            this.lblConcluir.Size = new System.Drawing.Size(18, 20);
            this.lblConcluir.Text = "F";
            this.lblConcluir.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbConcluir
            // 
            this.pbConcluir.Image = ((System.Drawing.Image)(resources.GetObject("pbConcluir.Image")));
            this.pbConcluir.Location = new System.Drawing.Point(200, 3);
            this.pbConcluir.Name = "pbConcluir";
            this.pbConcluir.Size = new System.Drawing.Size(35, 35);
            this.pbConcluir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbConcluir.Click += new System.EventHandler(this.pbConcluir_Click);
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
            this.pnlPorSurtir.Controls.Add(this.txtOcurrDom);
            this.pnlPorSurtir.Controls.Add(this.label12);
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
            this.pnlPorSurtir.Size = new System.Drawing.Size(238, 161);
            // 
            // txtOcurrDom
            // 
            this.txtOcurrDom.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtOcurrDom.Location = new System.Drawing.Point(97, 77);
            this.txtOcurrDom.Name = "txtOcurrDom";
            this.txtOcurrDom.ReadOnly = true;
            this.txtOcurrDom.Size = new System.Drawing.Size(134, 17);
            this.txtOcurrDom.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(4, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 20);
            this.label12.Text = "Ocurr. / Dom.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtMonto.Location = new System.Drawing.Point(97, 138);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.ReadOnly = true;
            this.txtMonto.Size = new System.Drawing.Size(134, 17);
            this.txtMonto.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(4, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 14);
            this.label13.Text = "Monto";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtVendedor
            // 
            this.txtVendedor.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtVendedor.Location = new System.Drawing.Point(97, 118);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(134, 17);
            this.txtVendedor.TabIndex = 22;
            // 
            // txtPrioridad
            // 
            this.txtPrioridad.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtPrioridad.Location = new System.Drawing.Point(97, 98);
            this.txtPrioridad.Name = "txtPrioridad";
            this.txtPrioridad.ReadOnly = true;
            this.txtPrioridad.Size = new System.Drawing.Size(134, 17);
            this.txtPrioridad.TabIndex = 21;
            // 
            // txtServicio
            // 
            this.txtServicio.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtServicio.Location = new System.Drawing.Point(97, 57);
            this.txtServicio.Name = "txtServicio";
            this.txtServicio.ReadOnly = true;
            this.txtServicio.Size = new System.Drawing.Size(134, 17);
            this.txtServicio.TabIndex = 20;
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular);
            this.txtCliente.Location = new System.Drawing.Point(97, 25);
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
            this.label10.Location = new System.Drawing.Point(4, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.Text = "Vendedor";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(4, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.Text = "Prioridad";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(4, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.Text = "Servicio";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 27);
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
            // pbSurtir
            // 
            this.pbSurtir.Image = ((System.Drawing.Image)(resources.GetObject("pbSurtir.Image")));
            this.pbSurtir.Location = new System.Drawing.Point(4, 180);
            this.pbSurtir.Name = "pbSurtir";
            this.pbSurtir.Size = new System.Drawing.Size(35, 35);
            this.pbSurtir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSurtir.Click += new System.EventHandler(this.pbImprimir_Click);
            // 
            // pbRemover
            // 
            this.pbRemover.Image = ((System.Drawing.Image)(resources.GetObject("pbRemover.Image")));
            this.pbRemover.Location = new System.Drawing.Point(43, 180);
            this.pbRemover.Name = "pbRemover";
            this.pbRemover.Size = new System.Drawing.Size(35, 35);
            this.pbRemover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbRemover.Click += new System.EventHandler(this.pbDevolucion_Click);
            // 
            // pbDetener
            // 
            this.pbDetener.Image = ((System.Drawing.Image)(resources.GetObject("pbDetener.Image")));
            this.pbDetener.Location = new System.Drawing.Point(82, 180);
            this.pbDetener.Name = "pbDetener";
            this.pbDetener.Size = new System.Drawing.Size(35, 35);
            this.pbDetener.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDetener.Click += new System.EventHandler(this.pbDetenido_Click);
            // 
            // pbIncompletos
            // 
            this.pbIncompletos.Image = ((System.Drawing.Image)(resources.GetObject("pbIncompletos.Image")));
            this.pbIncompletos.Location = new System.Drawing.Point(121, 180);
            this.pbIncompletos.Name = "pbIncompletos";
            this.pbIncompletos.Size = new System.Drawing.Size(35, 35);
            this.pbIncompletos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIncompletos.Click += new System.EventHandler(this.pbIncompletos_Click);
            // 
            // pbTransferir
            // 
            this.pbTransferir.Image = ((System.Drawing.Image)(resources.GetObject("pbTransferir.Image")));
            this.pbTransferir.Location = new System.Drawing.Point(160, 180);
            this.pbTransferir.Name = "pbTransferir";
            this.pbTransferir.Size = new System.Drawing.Size(35, 35);
            this.pbTransferir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbTransferir.Click += new System.EventHandler(this.pbTransferir_Click);
            // 
            // pbDevolucion
            // 
            this.pbDevolucion.Image = ((System.Drawing.Image)(resources.GetObject("pbDevolucion.Image")));
            this.pbDevolucion.Location = new System.Drawing.Point(199, 180);
            this.pbDevolucion.Name = "pbDevolucion";
            this.pbDevolucion.Size = new System.Drawing.Size(35, 35);
            this.pbDevolucion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDevolucion.Click += new System.EventHandler(this.pbDevolucion_Click_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.Text = "S";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(51, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 20);
            this.label3.Text = "Q";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDetenido
            // 
            this.lblDetenido.Location = new System.Drawing.Point(90, 164);
            this.lblDetenido.Name = "lblDetenido";
            this.lblDetenido.Size = new System.Drawing.Size(18, 20);
            this.lblDetenido.Text = "D";
            this.lblDetenido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(129, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 20);
            this.label4.Text = "I";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(168, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.Text = "T";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(207, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.Text = "M";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPendS
            // 
            this.lblPendS.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
            this.lblPendS.Location = new System.Drawing.Point(4, 218);
            this.lblPendS.Name = "lblPendS";
            this.lblPendS.Size = new System.Drawing.Size(35, 17);
            this.lblPendS.Text = "0";
            this.lblPendS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPendM
            // 
            this.lblPendM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Italic);
            this.lblPendM.Location = new System.Drawing.Point(199, 218);
            this.lblPendM.Name = "lblPendM";
            this.lblPendM.Size = new System.Drawing.Size(35, 17);
            this.lblPendM.Text = "0";
            this.lblPendM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FrmMenuPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.lblPendM);
            this.Controls.Add(this.lblPendS);
            this.Controls.Add(this.pbSurtir);
            this.Controls.Add(this.pbDevolucion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbTransferir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbIncompletos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbDetener);
            this.Controls.Add(this.lblDetenido);
            this.Controls.Add(this.pbRemover);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlRetornar);
            this.Controls.Add(this.pnlPorSurtir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmMenuPedidos";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmMenuPedidos_Load);
            this.pnlRetornar.ResumeLayout(false);
            this.pnlPorSurtir.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRetornar;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Panel pnlPorSurtir;
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
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pbSurtir;
        private System.Windows.Forms.PictureBox pbRemover;
        private System.Windows.Forms.PictureBox pbDetener;
        private System.Windows.Forms.PictureBox pbIncompletos;
        private System.Windows.Forms.PictureBox pbConcluir;
        private System.Windows.Forms.PictureBox pbTransferir;
        private System.Windows.Forms.PictureBox pbDevolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConcluir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDetenido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPendS;
        private System.Windows.Forms.Label lblPendM;
        private System.Windows.Forms.TextBox txtOcurrDom;
        private System.Windows.Forms.Label label12;
    }
}