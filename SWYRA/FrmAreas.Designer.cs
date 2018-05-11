namespace SWYRA
{
    partial class FrmAreas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAreas));
            this.chkActivo = new DevExpress.XtraEditors.CheckEdit();
            this.txtAltura = new DevExpress.XtraEditors.TextEdit();
            this.txtArea = new DevExpress.XtraEditors.TextEdit();
            this.txtUbicacion = new DevExpress.XtraEditors.TextEdit();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.areasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.almacenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcPresentProd = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colareaid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colalmacen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colubicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colaream2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colaltura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colactivo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.almacenBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPresentProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkActivo
            // 
            this.chkActivo.Location = new System.Drawing.Point(282, 89);
            this.chkActivo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkActivo.Properties.Appearance.Options.UseFont = true;
            this.chkActivo.Properties.Caption = "Activo";
            this.chkActivo.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkActivo.Size = new System.Drawing.Size(56, 22);
            this.chkActivo.TabIndex = 41;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(282, 41);
            this.txtAltura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAltura.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAltura.Properties.Appearance.Options.UseFont = true;
            this.txtAltura.Properties.Appearance.Options.UseForeColor = true;
            this.txtAltura.Properties.DisplayFormat.FormatString = "#,##0.00";
            this.txtAltura.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtAltura.Properties.Mask.EditMask = "##0.00";
            this.txtAltura.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAltura.Size = new System.Drawing.Size(64, 20);
            this.txtAltura.TabIndex = 39;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(282, 17);
            this.txtArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtArea.Name = "txtArea";
            this.txtArea.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtArea.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArea.Properties.Appearance.Options.UseFont = true;
            this.txtArea.Properties.Appearance.Options.UseForeColor = true;
            this.txtArea.Properties.DisplayFormat.FormatString = "#,##0.00";
            this.txtArea.Properties.Mask.EditMask = "#,##0.00";
            this.txtArea.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtArea.Size = new System.Drawing.Size(64, 20);
            this.txtArea.TabIndex = 38;
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(94, 89);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtUbicacion.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUbicacion.Properties.Appearance.Options.UseFont = true;
            this.txtUbicacion.Properties.Appearance.Options.UseForeColor = true;
            this.txtUbicacion.Properties.MaxLength = 50;
            this.txtUbicacion.Size = new System.Drawing.Size(128, 22);
            this.txtUbicacion.TabIndex = 37;
            this.txtUbicacion.TextChanged += new System.EventHandler(this.txtUbicacion_TextChanged);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label15.Location = new System.Drawing.Point(350, 21);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(34, 15);
            this.Label15.TabIndex = 29;
            this.Label15.Text = "mts2";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label16.Location = new System.Drawing.Point(242, 45);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(38, 15);
            this.Label16.TabIndex = 28;
            this.Label16.Text = "Altura";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label17.Location = new System.Drawing.Point(248, 21);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(32, 15);
            this.Label17.TabIndex = 26;
            this.Label17.Text = "Área";
            // 
            // areasBindingSource
            // 
            this.areasBindingSource.DataSource = typeof(SWYRA.Areas);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(94, 65);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtNombre.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNombre.Properties.Appearance.Options.UseFont = true;
            this.txtNombre.Properties.Appearance.Options.UseForeColor = true;
            this.txtNombre.Size = new System.Drawing.Size(128, 22);
            this.txtNombre.TabIndex = 36;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(94, 17);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.AllowFocused = false;
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtCodigo.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Properties.Appearance.Options.UseForeColor = true;
            this.txtCodigo.Properties.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(128, 22);
            this.txtCodigo.TabIndex = 34;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label4.Location = new System.Drawing.Point(38, 67);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(52, 15);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Nombre";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label2.Location = new System.Drawing.Point(36, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(55, 15);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Almacen";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label1.Location = new System.Drawing.Point(26, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(65, 15);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Clave Área";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cbAlmacen);
            this.GroupBox1.Controls.Add(this.txtDescripcion);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.chkActivo);
            this.GroupBox1.Controls.Add(this.txtAltura);
            this.GroupBox1.Controls.Add(this.txtArea);
            this.GroupBox1.Controls.Add(this.txtUbicacion);
            this.GroupBox1.Controls.Add(this.txtNombre);
            this.GroupBox1.Controls.Add(this.txtCodigo);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.Label15);
            this.GroupBox1.Controls.Add(this.Label16);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.GroupBox1.Location = new System.Drawing.Point(10, 31);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(394, 137);
            this.GroupBox1.TabIndex = 40;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Área";
            // 
            // cbAlmacen
            // 
            this.cbAlmacen.Location = new System.Drawing.Point(94, 41);
            this.cbAlmacen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbAlmacen.Name = "cbAlmacen";
            this.cbAlmacen.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cbAlmacen.Properties.Appearance.Options.UseFont = true;
            this.cbAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbAlmacen.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Clave", "Clave", 58, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cbAlmacen.Properties.DataSource = this.almacenBindingSource;
            this.cbAlmacen.Properties.DisplayMember = "Nombre";
            this.cbAlmacen.Properties.NullText = "";
            this.cbAlmacen.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.cbAlmacen.Properties.ValueMember = "Nombre";
            this.cbAlmacen.Size = new System.Drawing.Size(128, 22);
            this.cbAlmacen.TabIndex = 44;
            // 
            // almacenBindingSource
            // 
            this.almacenBindingSource.DataSource = typeof(SWYRA.Almacen);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(94, 113);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtDescripcion.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescripcion.Properties.Appearance.Options.UseFont = true;
            this.txtDescripcion.Properties.Appearance.Options.UseForeColor = true;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(286, 22);
            this.txtDescripcion.TabIndex = 43;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(20, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 42;
            this.label3.Text = "Descripción";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label14.Location = new System.Drawing.Point(350, 45);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(27, 15);
            this.Label14.TabIndex = 30;
            this.Label14.Text = "mts";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Label6.Location = new System.Drawing.Point(29, 91);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(62, 15);
            this.Label6.TabIndex = 7;
            this.Label6.Text = "Ubicación";
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
            this.toolStrip1.Size = new System.Drawing.Size(413, 27);
            this.toolStrip1.TabIndex = 39;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Image = global::SWYRA.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(76, 24);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Image = global::SWYRA.Properties.Resources._new;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(68, 24);
            this.btnLimpiar.Text = "Nueva";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(51, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcPresentProd);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 370);
            this.panel1.TabIndex = 44;
            // 
            // gcPresentProd
            // 
            this.gcPresentProd.DataSource = this.areasBindingSource;
            this.gcPresentProd.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcPresentProd.Location = new System.Drawing.Point(10, 174);
            this.gcPresentProd.MainView = this.gridView1;
            this.gcPresentProd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcPresentProd.Name = "gcPresentProd";
            this.gcPresentProd.Size = new System.Drawing.Size(394, 188);
            this.gcPresentProd.TabIndex = 45;
            this.gcPresentProd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colareaid,
            this.colnombre,
            this.coldescripcion,
            this.colalmacen,
            this.colubicacion,
            this.colaream2,
            this.colaltura,
            this.colactivo});
            this.gridView1.GridControl = this.gcPresentProd;
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
            // colareaid
            // 
            this.colareaid.Caption = "ID";
            this.colareaid.FieldName = "areaid";
            this.colareaid.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colareaid.Name = "colareaid";
            this.colareaid.Visible = true;
            this.colareaid.VisibleIndex = 0;
            this.colareaid.Width = 40;
            // 
            // colnombre
            // 
            this.colnombre.Caption = "Área";
            this.colnombre.FieldName = "nombre";
            this.colnombre.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colnombre.Name = "colnombre";
            this.colnombre.Visible = true;
            this.colnombre.VisibleIndex = 1;
            this.colnombre.Width = 120;
            // 
            // coldescripcion
            // 
            this.coldescripcion.Caption = "Descripción";
            this.coldescripcion.FieldName = "descripcion";
            this.coldescripcion.Name = "coldescripcion";
            this.coldescripcion.Visible = true;
            this.coldescripcion.VisibleIndex = 2;
            // 
            // colalmacen
            // 
            this.colalmacen.Caption = "Almacen";
            this.colalmacen.FieldName = "stralmacen";
            this.colalmacen.Name = "colalmacen";
            this.colalmacen.Visible = true;
            this.colalmacen.VisibleIndex = 3;
            // 
            // colubicacion
            // 
            this.colubicacion.Caption = "Ubicación";
            this.colubicacion.FieldName = "ubicacion";
            this.colubicacion.Name = "colubicacion";
            this.colubicacion.Visible = true;
            this.colubicacion.VisibleIndex = 4;
            // 
            // colaream2
            // 
            this.colaream2.Caption = "Área (mts 2)";
            this.colaream2.FieldName = "aream2";
            this.colaream2.Name = "colaream2";
            this.colaream2.Visible = true;
            this.colaream2.VisibleIndex = 5;
            // 
            // colaltura
            // 
            this.colaltura.Caption = "Altura (mts)";
            this.colaltura.FieldName = "altura";
            this.colaltura.Name = "colaltura";
            this.colaltura.Visible = true;
            this.colaltura.VisibleIndex = 6;
            // 
            // colactivo
            // 
            this.colactivo.FieldName = "activo";
            this.colactivo.Name = "colactivo";
            this.colactivo.Visible = true;
            this.colactivo.VisibleIndex = 7;
            // 
            // FrmAreas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(413, 372);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmAreas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AREAS";
            this.Load += new System.EventHandler(this.FrmAreas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.almacenBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPresentProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraEditors.TextEdit txtAltura;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private DevExpress.XtraEditors.TextEdit txtUbicacion;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label17;
        private DevExpress.XtraEditors.TextEdit txtNombre;
        internal DevExpress.XtraEditors.TextEdit txtCodigo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource almacenBindingSource;
        private DevExpress.XtraEditors.LookUpEdit cbAlmacen;
        private System.Windows.Forms.BindingSource areasBindingSource;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcPresentProd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colareaid;
        private DevExpress.XtraGrid.Columns.GridColumn colnombre;
        private DevExpress.XtraGrid.Columns.GridColumn coldescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colalmacen;
        private DevExpress.XtraGrid.Columns.GridColumn colubicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colaream2;
        private DevExpress.XtraGrid.Columns.GridColumn colaltura;
        private DevExpress.XtraGrid.Columns.GridColumn colactivo;
    }
}