namespace SWYRA
{
    partial class FrmImpresion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpresion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.impresionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_imp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colimpresion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrealizado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gpoFiltro = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tsTodos = new DevExpress.XtraEditors.ToggleSwitch();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.gpoFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsTodos.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl1);
            this.panel1.Controls.Add(this.gpoFiltro);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 261);
            this.panel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.impresionBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 80);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(285, 181);
            this.gridControl1.TabIndex = 46;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // impresionBindingSource
            // 
            this.impresionBindingSource.DataSource = typeof(SWYRA.Impresion);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colfecha,
            this.colcve_doc,
            this.colcve_imp,
            this.colimpresion,
            this.colrealizado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            // 
            // colfecha
            // 
            this.colfecha.Caption = "Fecha";
            this.colfecha.FieldName = "fecha";
            this.colfecha.Name = "colfecha";
            this.colfecha.Visible = true;
            this.colfecha.VisibleIndex = 0;
            this.colfecha.Width = 80;
            // 
            // colcve_doc
            // 
            this.colcve_doc.Caption = "Pedido";
            this.colcve_doc.FieldName = "cve_doc";
            this.colcve_doc.Name = "colcve_doc";
            this.colcve_doc.Visible = true;
            this.colcve_doc.VisibleIndex = 1;
            this.colcve_doc.Width = 90;
            // 
            // colcve_imp
            // 
            this.colcve_imp.FieldName = "cve_imp";
            this.colcve_imp.Name = "colcve_imp";
            // 
            // colimpresion
            // 
            this.colimpresion.Caption = "Impresión de";
            this.colimpresion.FieldName = "impresion";
            this.colimpresion.Name = "colimpresion";
            this.colimpresion.Visible = true;
            this.colimpresion.VisibleIndex = 2;
            this.colimpresion.Width = 150;
            // 
            // colrealizado
            // 
            this.colrealizado.FieldName = "realizado";
            this.colrealizado.Name = "colrealizado";
            // 
            // gpoFiltro
            // 
            this.gpoFiltro.Controls.Add(this.Label1);
            this.gpoFiltro.Controls.Add(this.tsTodos);
            this.gpoFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpoFiltro.Location = new System.Drawing.Point(0, 27);
            this.gpoFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.gpoFiltro.Name = "gpoFiltro";
            this.gpoFiltro.Padding = new System.Windows.Forms.Padding(2);
            this.gpoFiltro.Size = new System.Drawing.Size(285, 53);
            this.gpoFiltro.TabIndex = 45;
            this.gpoFiltro.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(34, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(81, 15);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "IMPRESIÓN :";
            // 
            // tsTodos
            // 
            this.tsTodos.Location = new System.Drawing.Point(120, 21);
            this.tsTodos.Margin = new System.Windows.Forms.Padding(2);
            this.tsTodos.Name = "tsTodos";
            this.tsTodos.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsTodos.Properties.Appearance.Options.UseFont = true;
            this.tsTodos.Properties.OffText = "ACTUAL";
            this.tsTodos.Properties.OnText = "ANTERIORES";
            this.tsTodos.Size = new System.Drawing.Size(161, 24);
            this.tsTodos.TabIndex = 0;
            this.tsTodos.Toggled += new System.EventHandler(this.tsTodos_Toggled);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir,
            this.btnImprimir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(285, 27);
            this.toolStrip1.TabIndex = 44;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(51, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = global::SWYRA.Properties.Resources._1366681786_print;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(66, 24);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImpresion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MÓDULO DE IMPRESIÓN";
            this.Load += new System.EventHandler(this.FrmImpresion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.impresionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.gpoFiltro.ResumeLayout(false);
            this.gpoFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsTodos.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox gpoFiltro;
        internal System.Windows.Forms.Label Label1;
        private DevExpress.XtraEditors.ToggleSwitch tsTodos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.BindingSource impresionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_doc;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_imp;
        private DevExpress.XtraGrid.Columns.GridColumn colimpresion;
        private DevExpress.XtraGrid.Columns.GridColumn colrealizado;
        private System.Windows.Forms.Timer timer1;
    }
}