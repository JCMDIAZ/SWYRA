namespace SWYRA
{
    partial class FrmCondiciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCondiciones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcCondiciones = new DevExpress.XtraGrid.GridControl();
            this.inventarioCondicionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcve_art = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomentario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colaplicaexist = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colexistencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colactivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtExistencia = new DevExpress.XtraEditors.TextEdit();
            this.chkEstablece = new DevExpress.XtraEditors.CheckEdit();
            this.meCondicion = new DevExpress.XtraEditors.MemoEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.chkActivo = new DevExpress.XtraEditors.CheckEdit();
            this.cbProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.inventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondiciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioCondicionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExistencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstablece.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meCondicion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcCondiciones);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 449);
            this.panel1.TabIndex = 0;
            // 
            // gcCondiciones
            // 
            this.gcCondiciones.DataSource = this.inventarioCondicionBindingSource;
            this.gcCondiciones.Location = new System.Drawing.Point(12, 207);
            this.gcCondiciones.MainView = this.gridView1;
            this.gcCondiciones.Name = "gcCondiciones";
            this.gcCondiciones.Size = new System.Drawing.Size(525, 232);
            this.gcCondiciones.TabIndex = 47;
            this.gcCondiciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gcCondiciones.Load += new System.EventHandler(this.gcPresentaciones_Load);
            // 
            // inventarioCondicionBindingSource
            // 
            this.inventarioCondicionBindingSource.DataSource = typeof(SWYRA.InventarioCondicion);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcve_art,
            this.coldescr,
            this.colcomentario,
            this.colaplicaexist,
            this.colexistencia,
            this.colactivo});
            this.gridView1.GridControl = this.gcCondiciones;
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
            // colcve_art
            // 
            this.colcve_art.Caption = "Clave Artículo";
            this.colcve_art.FieldName = "cve_art";
            this.colcve_art.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcve_art.Name = "colcve_art";
            this.colcve_art.Visible = true;
            this.colcve_art.VisibleIndex = 0;
            this.colcve_art.Width = 60;
            // 
            // coldescr
            // 
            this.coldescr.Caption = "Descripcioón";
            this.coldescr.FieldName = "descr";
            this.coldescr.Name = "coldescr";
            this.coldescr.Visible = true;
            this.coldescr.VisibleIndex = 1;
            this.coldescr.Width = 250;
            // 
            // colcomentario
            // 
            this.colcomentario.Caption = "Condición";
            this.colcomentario.FieldName = "comentario";
            this.colcomentario.Name = "colcomentario";
            this.colcomentario.Visible = true;
            this.colcomentario.VisibleIndex = 2;
            this.colcomentario.Width = 250;
            // 
            // colaplicaexist
            // 
            this.colaplicaexist.Caption = "Aplica Existencia";
            this.colaplicaexist.FieldName = "aplicaexist";
            this.colaplicaexist.Name = "colaplicaexist";
            this.colaplicaexist.Visible = true;
            this.colaplicaexist.VisibleIndex = 3;
            this.colaplicaexist.Width = 40;
            // 
            // colexistencia
            // 
            this.colexistencia.Caption = "Existencia";
            this.colexistencia.FieldName = "existencia";
            this.colexistencia.Name = "colexistencia";
            this.colexistencia.Visible = true;
            this.colexistencia.VisibleIndex = 4;
            this.colexistencia.Width = 40;
            // 
            // colactivo
            // 
            this.colactivo.Caption = "Activo";
            this.colactivo.FieldName = "activo";
            this.colactivo.Name = "colactivo";
            this.colactivo.Visible = true;
            this.colactivo.VisibleIndex = 5;
            this.colactivo.Width = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtExistencia);
            this.groupBox1.Controls.Add(this.chkEstablece);
            this.groupBox1.Controls.Add(this.meCondicion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkActivo);
            this.groupBox1.Controls.Add(this.cbProducto);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 171);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto Presentación";
            // 
            // txtExistencia
            // 
            this.txtExistencia.EditValue = 0D;
            this.txtExistencia.Location = new System.Drawing.Point(424, 116);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtExistencia.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExistencia.Properties.Appearance.Options.UseFont = true;
            this.txtExistencia.Properties.Appearance.Options.UseForeColor = true;
            this.txtExistencia.Properties.DisplayFormat.FormatString = "#,##0";
            this.txtExistencia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtExistencia.Properties.EditFormat.FormatString = "#,##0";
            this.txtExistencia.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtExistencia.Properties.Mask.EditMask = "#,##0.00";
            this.txtExistencia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtExistencia.Size = new System.Drawing.Size(86, 24);
            this.txtExistencia.TabIndex = 4;
            // 
            // chkEstablece
            // 
            this.chkEstablece.Location = new System.Drawing.Point(6, 117);
            this.chkEstablece.Name = "chkEstablece";
            this.chkEstablece.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkEstablece.Properties.Appearance.Options.UseFont = true;
            this.chkEstablece.Properties.Caption = "Establecer Condicion de existencia si la existencia del  es";
            this.chkEstablece.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkEstablece.Size = new System.Drawing.Size(409, 22);
            this.chkEstablece.TabIndex = 3;
            // 
            // meCondicion
            // 
            this.meCondicion.Location = new System.Drawing.Point(120, 51);
            this.meCondicion.Name = "meCondicion";
            this.meCondicion.Properties.MaxLength = 250;
            this.meCondicion.Size = new System.Drawing.Size(390, 60);
            this.meCondicion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(43, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 50;
            this.label1.Text = "Condición";
            // 
            // chkActivo
            // 
            this.chkActivo.Location = new System.Drawing.Point(435, 146);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkActivo.Properties.Appearance.Options.UseFont = true;
            this.chkActivo.Properties.Caption = "Activo";
            this.chkActivo.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkActivo.Size = new System.Drawing.Size(75, 22);
            this.chkActivo.TabIndex = 5;
            // 
            // cbProducto
            // 
            this.cbProducto.Location = new System.Drawing.Point(120, 21);
            this.cbProducto.Name = "cbProducto";
            this.cbProducto.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbProducto.Properties.Appearance.Options.UseFont = true;
            this.cbProducto.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cbProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbProducto.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cve_art", 80, "Clave Artículo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("descr", 150, "Descripción"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("lin_prod", 65, "Línea Prod"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("exist", "Existencia", 65, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("status", 65, "Estatus")});
            this.cbProducto.Properties.DataSource = this.inventarioBindingSource;
            this.cbProducto.Properties.DisplayMember = "descr";
            this.cbProducto.Properties.HeaderClickMode = DevExpress.XtraEditors.Controls.HeaderClickMode.AutoSearch;
            this.cbProducto.Properties.ImmediatePopup = true;
            this.cbProducto.Properties.KeyMember = "cve_art;descr";
            this.cbProducto.Properties.NullText = "";
            this.cbProducto.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.cbProducto.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cbProducto.Properties.ValueMember = "cve_art";
            this.cbProducto.Size = new System.Drawing.Size(390, 24);
            this.cbProducto.TabIndex = 1;
            // 
            // inventarioBindingSource
            // 
            this.inventarioBindingSource.DataSource = typeof(SWYRA.Inventario);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label2.Location = new System.Drawing.Point(43, 26);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(69, 18);
            this.Label2.TabIndex = 45;
            this.Label2.Text = "Producto";
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
            this.toolStrip1.Size = new System.Drawing.Size(551, 27);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Image = global::SWYRA.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 24);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Image = global::SWYRA.Properties.Resources._1366681822_edit_clear;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(85, 24);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FrmCondiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(552, 448);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCondiciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Condiciones de Productos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCondiciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioCondicionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtExistencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkEstablece.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meCondicion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraEditors.LookUpEdit cbProducto;
        internal System.Windows.Forms.Label Label2;
        private DevExpress.XtraEditors.CheckEdit chkEstablece;
        private DevExpress.XtraEditors.MemoEdit meCondicion;
        internal System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtExistencia;
        private DevExpress.XtraGrid.GridControl gcCondiciones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource inventarioCondicionBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_art;
        private DevExpress.XtraGrid.Columns.GridColumn coldescr;
        private DevExpress.XtraGrid.Columns.GridColumn colcomentario;
        private DevExpress.XtraGrid.Columns.GridColumn colaplicaexist;
        private DevExpress.XtraGrid.Columns.GridColumn colexistencia;
        private DevExpress.XtraGrid.Columns.GridColumn colactivo;
        private System.Windows.Forms.BindingSource inventarioBindingSource;
    }
}