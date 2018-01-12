namespace SWYRA
{
    partial class FrmRemision
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRemision));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.pedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcve_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltiposervicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colocurredomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha_cancela = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 27);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pedidosBindingSource
            // 
            this.pedidosBindingSource.DataSource = typeof(SWYRA.Pedidos);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.pedidosBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 42);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1040, 417);
            this.gridControl1.TabIndex = 43;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcve_doc,
            this.colcliente,
            this.coltiposervicio,
            this.colocurredomicilio,
            this.colfecha_doc,
            this.colfecha_cancela,
            this.gridColumn1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // colcve_doc
            // 
            this.colcve_doc.Caption = "Orden ID";
            this.colcve_doc.FieldName = "cve_doc";
            this.colcve_doc.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcve_doc.Name = "colcve_doc";
            this.colcve_doc.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colcve_doc.OptionsColumn.FixedWidth = true;
            this.colcve_doc.Visible = true;
            this.colcve_doc.VisibleIndex = 0;
            this.colcve_doc.Width = 90;
            // 
            // colcliente
            // 
            this.colcliente.Caption = "Cliente";
            this.colcliente.FieldName = "cliente";
            this.colcliente.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcliente.Name = "colcliente";
            this.colcliente.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.colcliente.OptionsColumn.FixedWidth = true;
            this.colcliente.Visible = true;
            this.colcliente.VisibleIndex = 1;
            this.colcliente.Width = 205;
            // 
            // coltiposervicio
            // 
            this.coltiposervicio.Caption = "Tipo Servicio";
            this.coltiposervicio.FieldName = "tiposervicio";
            this.coltiposervicio.Name = "coltiposervicio";
            this.coltiposervicio.Visible = true;
            this.coltiposervicio.VisibleIndex = 2;
            this.coltiposervicio.Width = 90;
            // 
            // colocurredomicilio
            // 
            this.colocurredomicilio.Caption = "Ocurre a Domicilio";
            this.colocurredomicilio.FieldName = "ocurredomicilio";
            this.colocurredomicilio.Name = "colocurredomicilio";
            this.colocurredomicilio.Visible = true;
            this.colocurredomicilio.VisibleIndex = 3;
            this.colocurredomicilio.Width = 90;
            // 
            // colfecha_doc
            // 
            this.colfecha_doc.Caption = "Fecha";
            this.colfecha_doc.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colfecha_doc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colfecha_doc.FieldName = "fecha_doc";
            this.colfecha_doc.Name = "colfecha_doc";
            this.colfecha_doc.Visible = true;
            this.colfecha_doc.VisibleIndex = 4;
            this.colfecha_doc.Width = 90;
            // 
            // colfecha_cancela
            // 
            this.colfecha_cancela.Caption = "Fecha Cancelado";
            this.colfecha_cancela.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colfecha_cancela.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colfecha_cancela.FieldName = "fecha_cancela";
            this.colfecha_cancela.Name = "colfecha_cancela";
            this.colfecha_cancela.Visible = true;
            this.colfecha_cancela.VisibleIndex = 5;
            this.colfecha_cancela.Width = 110;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // FrmRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1064, 471);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRemision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GENERACION DE REMISION";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.BindingSource pedidosBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_doc;
        private DevExpress.XtraGrid.Columns.GridColumn colcliente;
        private DevExpress.XtraGrid.Columns.GridColumn coltiposervicio;
        private DevExpress.XtraGrid.Columns.GridColumn colocurredomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha_doc;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha_cancela;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}