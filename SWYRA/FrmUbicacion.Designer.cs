namespace SWYRA
{
    partial class FrmUbicacion
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUbicacion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbArea = new DevExpress.XtraEditors.LookUpEdit();
            this.areasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrden = new DevExpress.XtraEditors.TextEdit();
            this.txtCveUbi = new DevExpress.XtraEditors.TextEdit();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.gcAlmacen = new DevExpress.XtraGrid.GridControl();
            this.ordenUbicacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcve_ubi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colorden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colarea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveUbi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenUbicacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbArea);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtOrden);
            this.panel1.Controls.Add(this.txtCveUbi);
            this.panel1.Controls.Add(this.Label16);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.gcAlmacen);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(-6, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 288);
            this.panel1.TabIndex = 3;
            // 
            // cbArea
            // 
            this.cbArea.Location = new System.Drawing.Point(81, 86);
            this.cbArea.Margin = new System.Windows.Forms.Padding(2);
            this.cbArea.Name = "cbArea";
            this.cbArea.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbArea.Properties.Appearance.Options.UseFont = true;
            this.cbArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbArea.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Clave", "Clave", 58, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cbArea.Properties.DataSource = this.areasBindingSource;
            this.cbArea.Properties.DisplayMember = "Nombre";
            this.cbArea.Properties.NullText = "";
            this.cbArea.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cbArea.Properties.ValueMember = "Nombre";
            this.cbArea.Size = new System.Drawing.Size(128, 22);
            this.cbArea.TabIndex = 54;
            // 
            // areasBindingSource
            // 
            this.areasBindingSource.DataSource = typeof(SWYRA.Areas);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(23, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 53;
            this.label1.Text = "Area";
            // 
            // txtOrden
            // 
            this.txtOrden.Location = new System.Drawing.Point(81, 60);
            this.txtOrden.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrden.Name = "txtOrden";
            this.txtOrden.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrden.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOrden.Properties.Appearance.Options.UseFont = true;
            this.txtOrden.Properties.Appearance.Options.UseForeColor = true;
            this.txtOrden.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOrden.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtOrden.Properties.Mask.EditMask = "##0.00";
            this.txtOrden.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOrden.Size = new System.Drawing.Size(64, 22);
            this.txtOrden.TabIndex = 52;
            // 
            // txtCveUbi
            // 
            this.txtCveUbi.Location = new System.Drawing.Point(81, 34);
            this.txtCveUbi.Margin = new System.Windows.Forms.Padding(2);
            this.txtCveUbi.Name = "txtCveUbi";
            this.txtCveUbi.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCveUbi.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCveUbi.Properties.Appearance.Options.UseFont = true;
            this.txtCveUbi.Properties.Appearance.Options.UseForeColor = true;
            this.txtCveUbi.Properties.MaxLength = 50;
            this.txtCveUbi.Size = new System.Drawing.Size(128, 22);
            this.txtCveUbi.TabIndex = 50;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(31, 63);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(41, 15);
            this.Label16.TabIndex = 49;
            this.Label16.Text = "Orden";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(35, 36);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(37, 15);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "Clave";
            // 
            // gcAlmacen
            // 
            this.gcAlmacen.DataSource = this.ordenUbicacionBindingSource;
            this.gcAlmacen.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            gridLevelNode1.RelationName = "Level1";
            this.gcAlmacen.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcAlmacen.Location = new System.Drawing.Point(14, 118);
            this.gcAlmacen.MainView = this.gridView1;
            this.gcAlmacen.Margin = new System.Windows.Forms.Padding(2);
            this.gcAlmacen.Name = "gcAlmacen";
            this.gcAlmacen.Size = new System.Drawing.Size(266, 161);
            this.gcAlmacen.TabIndex = 46;
            this.gcAlmacen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ordenUbicacionBindingSource
            // 
            this.ordenUbicacionBindingSource.DataSource = typeof(SWYRA.OrdenUbicacion);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcve_ubi,
            this.colorden,
            this.colarea});
            this.gridView1.GridControl = this.gcAlmacen;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colcve_ubi
            // 
            this.colcve_ubi.FieldName = "cve_ubi";
            this.colcve_ubi.Name = "colcve_ubi";
            this.colcve_ubi.Visible = true;
            this.colcve_ubi.VisibleIndex = 0;
            // 
            // colorden
            // 
            this.colorden.FieldName = "orden";
            this.colorden.Name = "colorden";
            this.colorden.Visible = true;
            this.colorden.VisibleIndex = 1;
            // 
            // colarea
            // 
            this.colarea.FieldName = "area";
            this.colarea.Name = "colarea";
            this.colarea.Visible = true;
            this.colarea.VisibleIndex = 2;
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
            this.toolStrip1.Size = new System.Drawing.Size(320, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::SWYRA.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 24);
            this.btnGuardar.Text = "Guardar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::SWYRA.Properties.Resources._1366681822_edit_clear;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 24);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(56, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmUbicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(314, 288);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUbicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ubicaciones";
            this.Load += new System.EventHandler(this.FrmUbicacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCveUbi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordenUbicacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private DevExpress.XtraGrid.GridControl gcAlmacen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource ordenUbicacionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_ubi;
        private DevExpress.XtraGrid.Columns.GridColumn colorden;
        private DevExpress.XtraGrid.Columns.GridColumn colarea;
        private DevExpress.XtraEditors.TextEdit txtOrden;
        private DevExpress.XtraEditors.TextEdit txtCveUbi;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label2;
        private DevExpress.XtraEditors.LookUpEdit cbArea;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource areasBindingSource;
    }
}