namespace SWYRA
{
    partial class FrmDeptos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeptos));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkActivo = new DevExpress.XtraEditors.CheckEdit();
            this.txtOffset = new DevExpress.XtraEditors.TextEdit();
            this.txtAltura = new DevExpress.XtraEditors.TextEdit();
            this.txtArea = new DevExpress.XtraEditors.TextEdit();
            this.txtZona = new DevExpress.XtraEditors.TextEdit();
            this.txtAbreviaura = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.Label12 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.alamcenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcAlmacen = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colClave = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbreviatura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZona = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coloffset = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOffset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbreviaura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alamcenBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::SWYRA.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(93, 24);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::SWYRA.Properties.Resources._1366681822_edit_clear;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(87, 24);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(61, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.chkActivo);
            this.GroupBox1.Controls.Add(this.txtOffset);
            this.GroupBox1.Controls.Add(this.txtAltura);
            this.GroupBox1.Controls.Add(this.txtArea);
            this.GroupBox1.Controls.Add(this.txtZona);
            this.GroupBox1.Controls.Add(this.txtAbreviaura);
            this.GroupBox1.Controls.Add(this.txtDescripcion);
            this.GroupBox1.Controls.Add(this.txtCodigo);
            this.GroupBox1.Controls.Add(this.Label12);
            this.GroupBox1.Controls.Add(this.Label13);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.Label15);
            this.GroupBox1.Controls.Add(this.Label16);
            this.GroupBox1.Controls.Add(this.Label17);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(13, 31);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(525, 149);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Almacenes";
            // 
            // chkActivo
            // 
            this.chkActivo.Location = new System.Drawing.Point(376, 109);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActivo.Properties.Appearance.Options.UseFont = true;
            this.chkActivo.Properties.Caption = "Activo";
            this.chkActivo.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkActivo.Size = new System.Drawing.Size(75, 22);
            this.chkActivo.TabIndex = 41;
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(376, 80);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffset.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOffset.Properties.Appearance.Options.UseFont = true;
            this.txtOffset.Properties.Appearance.Options.UseForeColor = true;
            this.txtOffset.Properties.DisplayFormat.FormatString = "#,##0.00";
            this.txtOffset.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtOffset.Properties.EditFormat.FormatString = "#,##0.00";
            this.txtOffset.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtOffset.Properties.Mask.EditMask = "##0.00";
            this.txtOffset.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOffset.Size = new System.Drawing.Size(86, 24);
            this.txtOffset.TabIndex = 40;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(376, 50);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltura.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAltura.Properties.Appearance.Options.UseFont = true;
            this.txtAltura.Properties.Appearance.Options.UseForeColor = true;
            this.txtAltura.Properties.DisplayFormat.FormatString = "#,##0.00";
            this.txtAltura.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtAltura.Properties.EditFormat.FormatString = "#,##0.00";
            this.txtAltura.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtAltura.Properties.Mask.EditMask = "##0.00";
            this.txtAltura.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAltura.Size = new System.Drawing.Size(86, 24);
            this.txtAltura.TabIndex = 39;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(376, 21);
            this.txtArea.Name = "txtArea";
            this.txtArea.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArea.Properties.Appearance.Options.UseFont = true;
            this.txtArea.Properties.Appearance.Options.UseForeColor = true;
            this.txtArea.Properties.Mask.EditMask = "#,##0.00";
            this.txtArea.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtArea.Size = new System.Drawing.Size(86, 24);
            this.txtArea.TabIndex = 38;
            // 
            // txtZona
            // 
            this.txtZona.Location = new System.Drawing.Point(125, 109);
            this.txtZona.Name = "txtZona";
            this.txtZona.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZona.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtZona.Properties.Appearance.Options.UseFont = true;
            this.txtZona.Properties.Appearance.Options.UseForeColor = true;
            this.txtZona.Properties.MaxLength = 50;
            this.txtZona.Size = new System.Drawing.Size(171, 24);
            this.txtZona.TabIndex = 37;
            this.txtZona.TextChanged += new System.EventHandler(this.txtZona_TextChanged);
            // 
            // txtAbreviaura
            // 
            this.txtAbreviaura.Location = new System.Drawing.Point(125, 80);
            this.txtAbreviaura.Name = "txtAbreviaura";
            this.txtAbreviaura.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbreviaura.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAbreviaura.Properties.Appearance.Options.UseFont = true;
            this.txtAbreviaura.Properties.Appearance.Options.UseForeColor = true;
            this.txtAbreviaura.Size = new System.Drawing.Size(171, 24);
            this.txtAbreviaura.TabIndex = 36;
            this.txtAbreviaura.TextChanged += new System.EventHandler(this.txtAbreviaura_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(125, 50);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescripcion.Properties.Appearance.Options.UseFont = true;
            this.txtDescripcion.Properties.Appearance.Options.UseForeColor = true;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(171, 24);
            this.txtDescripcion.TabIndex = 35;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(125, 21);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.AllowFocused = false;
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Properties.Appearance.Options.UseForeColor = true;
            this.txtCodigo.Properties.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(171, 24);
            this.txtCodigo.TabIndex = 34;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(467, 83);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(33, 18);
            this.Label12.TabIndex = 33;
            this.Label12.Text = "mts";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(321, 83);
            this.Label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(48, 18);
            this.Label13.TabIndex = 32;
            this.Label13.Text = "Offset";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(467, 55);
            this.Label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(33, 18);
            this.Label14.TabIndex = 30;
            this.Label14.Text = "mts";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(467, 26);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(41, 18);
            this.Label15.TabIndex = 29;
            this.Label15.Text = "mts2";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(326, 53);
            this.Label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(45, 18);
            this.Label16.TabIndex = 28;
            this.Label16.Text = "Altura";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(333, 24);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(38, 18);
            this.Label17.TabIndex = 26;
            this.Label17.Text = "Area";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(39, 83);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(81, 18);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Abreviatura";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(78, 111);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 18);
            this.Label6.TabIndex = 7;
            this.Label6.Text = "Zona";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(58, 53);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(62, 18);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Nombre";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(14, 24);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(106, 18);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Clave Almacen";
            // 
            // alamcenBindingSource
            // 
            this.alamcenBindingSource.DataSource = typeof(SWYRA.Almacen);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcAlmacen);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 456);
            this.panel1.TabIndex = 39;
            // 
            // gcAlmacen
            // 
            this.gcAlmacen.DataSource = this.alamcenBindingSource;
            this.gcAlmacen.Location = new System.Drawing.Point(13, 187);
            this.gcAlmacen.MainView = this.gridView1;
            this.gcAlmacen.Name = "gcAlmacen";
            this.gcAlmacen.Size = new System.Drawing.Size(525, 254);
            this.gcAlmacen.TabIndex = 45;
            this.gcAlmacen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colClave,
            this.colNombre,
            this.colAbreviatura,
            this.colZona,
            this.colArea,
            this.colAltura,
            this.coloffset,
            this.colActivo});
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
            // colClave
            // 
            this.colClave.Caption = "Clave";
            this.colClave.FieldName = "Clave";
            this.colClave.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colClave.Name = "colClave";
            this.colClave.Visible = true;
            this.colClave.VisibleIndex = 0;
            this.colClave.Width = 40;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Almacen";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            this.colNombre.Width = 120;
            // 
            // colAbreviatura
            // 
            this.colAbreviatura.Caption = "Abreviatura";
            this.colAbreviatura.FieldName = "Abreviatura";
            this.colAbreviatura.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colAbreviatura.Name = "colAbreviatura";
            this.colAbreviatura.Visible = true;
            this.colAbreviatura.VisibleIndex = 2;
            this.colAbreviatura.Width = 80;
            // 
            // colZona
            // 
            this.colZona.FieldName = "Zona";
            this.colZona.Name = "colZona";
            this.colZona.Visible = true;
            this.colZona.VisibleIndex = 3;
            // 
            // colArea
            // 
            this.colArea.Caption = "Área (mts2)";
            this.colArea.FieldName = "Area";
            this.colArea.Name = "colArea";
            this.colArea.Visible = true;
            this.colArea.VisibleIndex = 4;
            // 
            // colAltura
            // 
            this.colAltura.Caption = "Altura (mts)";
            this.colAltura.FieldName = "Altura";
            this.colAltura.Name = "colAltura";
            this.colAltura.Visible = true;
            this.colAltura.VisibleIndex = 5;
            // 
            // coloffset
            // 
            this.coloffset.Caption = "Offset (mts)";
            this.coloffset.FieldName = "offset";
            this.coloffset.Name = "coloffset";
            this.coloffset.Visible = true;
            this.coloffset.VisibleIndex = 6;
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 7;
            // 
            // FrmDeptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(551, 454);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeptos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ALMACEN";
            this.Load += new System.EventHandler(this.FrmDeptos_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOffset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAltura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtZona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbreviaura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alamcenBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.Label Label17;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraEditors.TextEdit txtOffset;
        private DevExpress.XtraEditors.TextEdit txtAltura;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private DevExpress.XtraEditors.TextEdit txtZona;
        private DevExpress.XtraEditors.TextEdit txtAbreviaura;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private System.Windows.Forms.BindingSource alamcenBindingSource;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcAlmacen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colClave;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colAbreviatura;
        private DevExpress.XtraGrid.Columns.GridColumn colZona;
        private DevExpress.XtraGrid.Columns.GridColumn colArea;
        private DevExpress.XtraGrid.Columns.GridColumn colAltura;
        private DevExpress.XtraGrid.Columns.GridColumn coloffset;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
    }
}