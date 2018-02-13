namespace SWYRA_Movil
{
    partial class FrmImpCodigoBarra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpCodigoBarra));
            System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
            System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbSalir = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.codigosBarraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgCodigos = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codigosBarraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 20);
            this.label1.Text = "Impresión de Código de Barra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pbSalir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 40);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(198, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
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
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(8, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 20);
            this.label2.Text = "Introduzca Clave o Codigo de Barra";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtBuscar.Location = new System.Drawing.Point(56, 37);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(174, 19);
            this.txtBuscar.TabIndex = 4;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.LostFocus += new System.EventHandler(this.txtBuscar_LostFocus);
            // 
            // codigosBarraBindingSource
            // 
            this.codigosBarraBindingSource.AllowNew = false;
            this.codigosBarraBindingSource.DataSource = typeof(SWYRA_Movil.CodigosBarra);
            // 
            // dgCodigos
            // 
            this.dgCodigos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgCodigos.DataSource = this.codigosBarraBindingSource;
            this.dgCodigos.Location = new System.Drawing.Point(8, 83);
            this.dgCodigos.Name = "dgCodigos";
            this.dgCodigos.Size = new System.Drawing.Size(223, 147);
            this.dgCodigos.TabIndex = 5;
            this.dgCodigos.TableStyles.Add(dataGridTableStyle1);
            this.dgCodigos.CurrentCellChanged += new System.EventHandler(this.dgCodigos_CurrentCellChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 21);
            this.label3.Text = "Desc.";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txtDesc.Location = new System.Drawing.Point(56, 58);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.Size = new System.Drawing.Size(174, 19);
            this.txtDesc.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(8, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.Text = "Buscar";
            // 
            // dataGridTableStyle1
            // 
            dataGridTableStyle1.GridColumnStyles.Add(dataGridTextBoxColumn1);
            dataGridTableStyle1.GridColumnStyles.Add(dataGridTextBoxColumn2);
            dataGridTableStyle1.GridColumnStyles.Add(dataGridTextBoxColumn3);
            dataGridTableStyle1.MappingName = "CodigosBarra";
            // 
            // dataGridTextBoxColumn1
            // 
            dataGridTextBoxColumn1.Format = "";
            dataGridTextBoxColumn1.FormatInfo = null;
            dataGridTextBoxColumn1.HeaderText = "Clave";
            dataGridTextBoxColumn1.MappingName = "cve_art";
            // 
            // dataGridTextBoxColumn2
            // 
            dataGridTextBoxColumn2.Format = "";
            dataGridTextBoxColumn2.FormatInfo = null;
            dataGridTextBoxColumn2.HeaderText = "Piezas";
            dataGridTextBoxColumn2.MappingName = "cant_piezas";
            // 
            // dataGridTextBoxColumn3
            // 
            dataGridTextBoxColumn3.Format = "";
            dataGridTextBoxColumn3.FormatInfo = null;
            dataGridTextBoxColumn3.HeaderText = "Código";
            dataGridTextBoxColumn3.MappingName = "codigo_barra";
            dataGridTextBoxColumn3.Width = 150;
            // 
            // FrmImpCodigoBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 275);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCodigos);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "FrmImpCodigoBarra";
            this.Text = "SWYRA";
            this.Load += new System.EventHandler(this.FrmImpCodigoBarra_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codigosBarraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pbSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGrid dgCodigos;
        private System.Windows.Forms.BindingSource codigosBarraBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
    }
}