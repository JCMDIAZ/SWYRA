namespace SWYRA_Movil
{
    partial class FrmSurtit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSurtit));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.pnlRetornar = new System.Windows.Forms.Panel();
            this.pbFinal = new System.Windows.Forms.PictureBox();
            this.pbIncompletoB = new System.Windows.Forms.PictureBox();
            this.pbIncompleto = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPedido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblComentario = new System.Windows.Forms.Label();
            this.txtDescr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMinimo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMasterUbi = new System.Windows.Forms.TextBox();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbAnt = new System.Windows.Forms.PictureBox();
            this.pbSig = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSurtido = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPorSurtir = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaster = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUbica = new System.Windows.Forms.TextBox();
            this.detallePedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlRetornar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRetornar
            // 
            this.pnlRetornar.BackColor = System.Drawing.SystemColors.Window;
            this.pnlRetornar.Controls.Add(this.pbFinal);
            this.pnlRetornar.Controls.Add(this.pbIncompletoB);
            this.pnlRetornar.Controls.Add(this.pbIncompleto);
            this.pnlRetornar.Controls.Add(this.pbSalir);
            this.pnlRetornar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlRetornar.Location = new System.Drawing.Point(0, 235);
            this.pnlRetornar.Name = "pnlRetornar";
            this.pnlRetornar.Size = new System.Drawing.Size(238, 40);
            // 
            // pbFinal
            // 
            this.pbFinal.Image = ((System.Drawing.Image)(resources.GetObject("pbFinal.Image")));
            this.pbFinal.Location = new System.Drawing.Point(157, 3);
            this.pbFinal.Name = "pbFinal";
            this.pbFinal.Size = new System.Drawing.Size(35, 35);
            this.pbFinal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbFinal.Click += new System.EventHandler(this.pbFinal_Click);
            // 
            // pbIncompletoB
            // 
            this.pbIncompletoB.Image = ((System.Drawing.Image)(resources.GetObject("pbIncompletoB.Image")));
            this.pbIncompletoB.Location = new System.Drawing.Point(198, 3);
            this.pbIncompletoB.Name = "pbIncompletoB";
            this.pbIncompletoB.Size = new System.Drawing.Size(35, 35);
            this.pbIncompletoB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIncompletoB.Visible = false;
            this.pbIncompletoB.Click += new System.EventHandler(this.pbIncompleto_Click);
            // 
            // pbIncompleto
            // 
            this.pbIncompleto.Image = ((System.Drawing.Image)(resources.GetObject("pbIncompleto.Image")));
            this.pbIncompleto.Location = new System.Drawing.Point(198, 3);
            this.pbIncompleto.Name = "pbIncompleto";
            this.pbIncompleto.Size = new System.Drawing.Size(35, 35);
            this.pbIncompleto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbIncompleto.Click += new System.EventHandler(this.pbIncompleto_Click);
            // 
            // pbSalir
            // 
            this.pbSalir.Image = ((System.Drawing.Image)(resources.GetObject("pbSalir.Image")));
            this.pbSalir.Location = new System.Drawing.Point(4, 3);
            this.pbSalir.Name = "pbSalir";
            this.pbSalir.Size = new System.Drawing.Size(35, 35);
            this.pbSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSalir.Click += new System.EventHandler(this.pbSalir_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblPedido);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCant);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 64);
            // 
            // lblPedido
            // 
            this.lblPedido.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblPedido.Location = new System.Drawing.Point(146, 5);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(81, 11);
            this.lblPedido.Text = "Pedido:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(83, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 11);
            this.label5.Text = "Pedido:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtCant
            // 
            this.txtCant.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCant.Location = new System.Drawing.Point(161, 39);
            this.txtCant.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtCant.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCant.Name = "txtCant";
            this.txtCant.ReadOnly = true;
            this.txtCant.Size = new System.Drawing.Size(66, 20);
            this.txtCant.TabIndex = 4;
            this.txtCant.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            this.txtCant.LostFocus += new System.EventHandler(this.txtCant_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(132, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.Text = "Cant.";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtCodigo.Location = new System.Drawing.Point(52, 18);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(175, 19);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.LostFocus += new System.EventHandler(this.txtCodigo_LostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.Text = "Código";
            // 
            // lblComentario
            // 
            this.lblComentario.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.lblComentario.ForeColor = System.Drawing.Color.Red;
            this.lblComentario.Location = new System.Drawing.Point(11, 112);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(218, 27);
            this.lblComentario.Text = "Comentario";
            this.lblComentario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDescr
            // 
            this.txtDescr.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.txtDescr.Location = new System.Drawing.Point(65, 24);
            this.txtDescr.Multiline = true;
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.ReadOnly = true;
            this.txtDescr.Size = new System.Drawing.Size(164, 22);
            this.txtDescr.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(11, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.Text = "Desc.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMinimo
            // 
            this.txtMinimo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMinimo.Location = new System.Drawing.Point(65, 48);
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.ReadOnly = true;
            this.txtMinimo.Size = new System.Drawing.Size(54, 19);
            this.txtMinimo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(22, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.Text = "Mínimo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtMasterUbi);
            this.panel2.Controls.Add(this.lblPendientes);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.lblComentario);
            this.panel2.Controls.Add(this.pbAnt);
            this.panel2.Controls.Add(this.pbSig);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtExistencia);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtSurtido);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtPorSurtir);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtMaster);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtClave);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtUbica);
            this.panel2.Controls.Add(this.txtDescr);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMinimo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 167);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label13.Location = new System.Drawing.Point(119, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 19);
            this.label13.Text = "Mast. Ubi.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMasterUbi
            // 
            this.txtMasterUbi.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMasterUbi.Location = new System.Drawing.Point(175, 90);
            this.txtMasterUbi.Name = "txtMasterUbi";
            this.txtMasterUbi.ReadOnly = true;
            this.txtMasterUbi.Size = new System.Drawing.Size(54, 19);
            this.txtMasterUbi.TabIndex = 39;
            // 
            // lblPendientes
            // 
            this.lblPendientes.Font = new System.Drawing.Font("Tahoma", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblPendientes.Location = new System.Drawing.Point(124, 147);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(66, 15);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(52, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 15);
            this.label12.Text = "Pendientes";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbAnt
            // 
            this.pbAnt.BackColor = System.Drawing.Color.Transparent;
            this.pbAnt.Image = ((System.Drawing.Image)(resources.GetObject("pbAnt.Image")));
            this.pbAnt.Location = new System.Drawing.Point(4, 142);
            this.pbAnt.Name = "pbAnt";
            this.pbAnt.Size = new System.Drawing.Size(20, 20);
            this.pbAnt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbAnt.Click += new System.EventHandler(this.pbAnt_Click);
            // 
            // pbSig
            // 
            this.pbSig.BackColor = System.Drawing.Color.Transparent;
            this.pbSig.Image = ((System.Drawing.Image)(resources.GetObject("pbSig.Image")));
            this.pbSig.Location = new System.Drawing.Point(213, 142);
            this.pbSig.Name = "pbSig";
            this.pbSig.Size = new System.Drawing.Size(20, 20);
            this.pbSig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSig.Click += new System.EventHandler(this.pbSig_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(11, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 19);
            this.label11.Text = "Existencia";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtExistencia
            // 
            this.txtExistencia.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtExistencia.Location = new System.Drawing.Point(65, 90);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.ReadOnly = true;
            this.txtExistencia.Size = new System.Drawing.Size(54, 19);
            this.txtExistencia.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(134, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 19);
            this.label10.Text = "Surtido";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtSurtido
            // 
            this.txtSurtido.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtSurtido.Location = new System.Drawing.Point(175, 69);
            this.txtSurtido.Name = "txtSurtido";
            this.txtSurtido.ReadOnly = true;
            this.txtSurtido.Size = new System.Drawing.Size(54, 19);
            this.txtSurtido.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(11, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 19);
            this.label9.Text = "Por Surtir";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPorSurtir
            // 
            this.txtPorSurtir.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtPorSurtir.Location = new System.Drawing.Point(65, 69);
            this.txtPorSurtir.Name = "txtPorSurtir";
            this.txtPorSurtir.ReadOnly = true;
            this.txtPorSurtir.Size = new System.Drawing.Size(54, 19);
            this.txtPorSurtir.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(134, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 19);
            this.label8.Text = "Master";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtMaster
            // 
            this.txtMaster.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtMaster.Location = new System.Drawing.Point(175, 48);
            this.txtMaster.Name = "txtMaster";
            this.txtMaster.ReadOnly = true;
            this.txtMaster.Size = new System.Drawing.Size(54, 19);
            this.txtMaster.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(134, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.Text = "Clave";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtClave
            // 
            this.txtClave.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtClave.Location = new System.Drawing.Point(175, 3);
            this.txtClave.Name = "txtClave";
            this.txtClave.ReadOnly = true;
            this.txtClave.Size = new System.Drawing.Size(54, 19);
            this.txtClave.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(11, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.Text = "Ubicación";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtUbica
            // 
            this.txtUbica.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtUbica.Location = new System.Drawing.Point(65, 3);
            this.txtUbica.Name = "txtUbica";
            this.txtUbica.ReadOnly = true;
            this.txtUbica.Size = new System.Drawing.Size(54, 19);
            this.txtUbica.TabIndex = 15;
            // 
            // detallePedidosBindingSource
            // 
            this.detallePedidosBindingSource.DataSource = typeof(SWYRA_Movil.DetallePedidos);
            // 
            // FrmSurtit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlRetornar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmSurtit";
            this.Text = "SWRYA";
            this.Load += new System.EventHandler(this.FrmSurtit_Load);
            this.pnlRetornar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRetornar;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtCant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMinimo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource detallePedidosBindingSource;
        private System.Windows.Forms.Label lblComentario;
        private System.Windows.Forms.Label lblPedido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUbica;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaster;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSurtido;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPorSurtir;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.PictureBox pbSig;
        private System.Windows.Forms.PictureBox pbAnt;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.PictureBox pbIncompletoB;
        public System.Windows.Forms.PictureBox pbIncompleto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMasterUbi;
        public System.Windows.Forms.PictureBox pbFinal;
    }
}