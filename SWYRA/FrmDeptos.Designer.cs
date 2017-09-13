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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.dgAlmacen = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new DevExpress.XtraEditors.TextEdit();
            this.claveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abreviaturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alturaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offsetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alamcenBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgAlmacen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alamcenBindingSource)).BeginInit();
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
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::SWYRA.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 24);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Image = global::SWYRA.Properties.Resources._1366681822_edit_clear;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 24);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(62, 24);
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
            this.chkActivo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.txtOffset.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffset.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtOffset.Properties.Appearance.Options.UseFont = true;
            this.txtOffset.Properties.Appearance.Options.UseForeColor = true;
            this.txtOffset.Properties.DisplayFormat.FormatString = "#,##0.00";
            this.txtOffset.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtOffset.Properties.EditFormat.FormatString = "#,##0.00";
            this.txtOffset.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtOffset.Properties.Mask.EditMask = "##0.00";
            this.txtOffset.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOffset.Size = new System.Drawing.Size(86, 22);
            this.txtOffset.TabIndex = 40;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(376, 50);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAltura.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAltura.Properties.Appearance.Options.UseFont = true;
            this.txtAltura.Properties.Appearance.Options.UseForeColor = true;
            this.txtAltura.Properties.DisplayFormat.FormatString = "#,##0.00";
            this.txtAltura.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtAltura.Properties.EditFormat.FormatString = "#,##0.00";
            this.txtAltura.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtAltura.Properties.Mask.EditMask = "##0.00";
            this.txtAltura.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtAltura.Size = new System.Drawing.Size(86, 22);
            this.txtAltura.TabIndex = 39;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(376, 21);
            this.txtArea.Name = "txtArea";
            this.txtArea.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArea.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArea.Properties.Appearance.Options.UseFont = true;
            this.txtArea.Properties.Appearance.Options.UseForeColor = true;
            this.txtArea.Properties.Mask.EditMask = "#,##0.00";
            this.txtArea.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtArea.Size = new System.Drawing.Size(86, 22);
            this.txtArea.TabIndex = 38;
            // 
            // txtZona
            // 
            this.txtZona.Location = new System.Drawing.Point(125, 109);
            this.txtZona.Name = "txtZona";
            this.txtZona.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtZona.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtZona.Properties.Appearance.Options.UseFont = true;
            this.txtZona.Properties.Appearance.Options.UseForeColor = true;
            this.txtZona.Properties.MaxLength = 50;
            this.txtZona.Size = new System.Drawing.Size(171, 22);
            this.txtZona.TabIndex = 37;
            this.txtZona.TextChanged += new System.EventHandler(this.txtZona_TextChanged);
            // 
            // txtAbreviaura
            // 
            this.txtAbreviaura.Location = new System.Drawing.Point(125, 80);
            this.txtAbreviaura.Name = "txtAbreviaura";
            this.txtAbreviaura.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbreviaura.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAbreviaura.Properties.Appearance.Options.UseFont = true;
            this.txtAbreviaura.Properties.Appearance.Options.UseForeColor = true;
            this.txtAbreviaura.Size = new System.Drawing.Size(171, 22);
            this.txtAbreviaura.TabIndex = 36;
            this.txtAbreviaura.TextChanged += new System.EventHandler(this.txtAbreviaura_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(125, 50);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescripcion.Properties.Appearance.Options.UseFont = true;
            this.txtDescripcion.Properties.Appearance.Options.UseForeColor = true;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(171, 22);
            this.txtDescripcion.TabIndex = 35;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(125, 21);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.AllowFocused = false;
            this.txtCodigo.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCodigo.Properties.Appearance.Options.UseFont = true;
            this.txtCodigo.Properties.Appearance.Options.UseForeColor = true;
            this.txtCodigo.Properties.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(171, 22);
            this.txtCodigo.TabIndex = 34;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label12.Location = new System.Drawing.Point(469, 83);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(30, 15);
            this.Label12.TabIndex = 33;
            this.Label12.Text = "mts";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label13.Location = new System.Drawing.Point(324, 83);
            this.Label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(44, 15);
            this.Label13.TabIndex = 32;
            this.Label13.Text = "Offset";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(469, 55);
            this.Label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(30, 15);
            this.Label14.TabIndex = 30;
            this.Label14.Text = "mts";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label15.Location = new System.Drawing.Point(469, 26);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(38, 15);
            this.Label15.TabIndex = 29;
            this.Label15.Text = "mts2";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label16.Location = new System.Drawing.Point(324, 55);
            this.Label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(44, 15);
            this.Label16.TabIndex = 28;
            this.Label16.Text = "Altura";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label17.Location = new System.Drawing.Point(332, 26);
            this.Label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(36, 15);
            this.Label17.TabIndex = 26;
            this.Label17.Text = "Area";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(39, 83);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(79, 15);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Abreviatura";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(79, 112);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 15);
            this.Label6.TabIndex = 7;
            this.Label6.Text = "Zona";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(60, 55);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(58, 15);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Nombre";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 26);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(101, 15);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Clave Almacen";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.Firebrick;
            this.BtnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnBuscar.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.White;
            this.BtnBuscar.Location = new System.Drawing.Point(453, 188);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(85, 30);
            this.BtnBuscar.TabIndex = 13;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // dgAlmacen
            // 
            this.dgAlmacen.AllowUserToAddRows = false;
            this.dgAlmacen.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.NullValue = "NA";
            this.dgAlmacen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAlmacen.AutoGenerateColumns = false;
            this.dgAlmacen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgAlmacen.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAlmacen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.claveDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.abreviaturaDataGridViewTextBoxColumn,
            this.zonaDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.alturaDataGridViewTextBoxColumn,
            this.offsetDataGridViewTextBoxColumn,
            this.activoDataGridViewCheckBoxColumn});
            this.dgAlmacen.DataSource = this.alamcenBindingSource;
            this.dgAlmacen.Location = new System.Drawing.Point(13, 226);
            this.dgAlmacen.Margin = new System.Windows.Forms.Padding(4);
            this.dgAlmacen.MultiSelect = false;
            this.dgAlmacen.Name = "dgAlmacen";
            this.dgAlmacen.ReadOnly = true;
            this.dgAlmacen.RowHeadersWidth = 20;
            this.dgAlmacen.RowTemplate.Height = 24;
            this.dgAlmacen.Size = new System.Drawing.Size(525, 215);
            this.dgAlmacen.TabIndex = 30;
            this.dgAlmacen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAlmacen_CellClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(255, 189);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBuscar.Properties.Appearance.Options.UseFont = true;
            this.txtBuscar.Properties.Appearance.Options.UseForeColor = true;
            this.txtBuscar.Properties.MaxLength = 50;
            this.txtBuscar.Size = new System.Drawing.Size(191, 26);
            this.txtBuscar.TabIndex = 38;
            // 
            // claveDataGridViewTextBoxColumn
            // 
            this.claveDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.claveDataGridViewTextBoxColumn.DataPropertyName = "Clave";
            this.claveDataGridViewTextBoxColumn.HeaderText = "Clave";
            this.claveDataGridViewTextBoxColumn.Name = "claveDataGridViewTextBoxColumn";
            this.claveDataGridViewTextBoxColumn.ReadOnly = true;
            this.claveDataGridViewTextBoxColumn.Width = 72;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 87;
            // 
            // abreviaturaDataGridViewTextBoxColumn
            // 
            this.abreviaturaDataGridViewTextBoxColumn.DataPropertyName = "Abreviatura";
            this.abreviaturaDataGridViewTextBoxColumn.HeaderText = "Abreviatura";
            this.abreviaturaDataGridViewTextBoxColumn.MinimumWidth = 25;
            this.abreviaturaDataGridViewTextBoxColumn.Name = "abreviaturaDataGridViewTextBoxColumn";
            this.abreviaturaDataGridViewTextBoxColumn.ReadOnly = true;
            this.abreviaturaDataGridViewTextBoxColumn.Width = 110;
            // 
            // zonaDataGridViewTextBoxColumn
            // 
            this.zonaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zonaDataGridViewTextBoxColumn.DataPropertyName = "Zona";
            this.zonaDataGridViewTextBoxColumn.HeaderText = "Zona";
            this.zonaDataGridViewTextBoxColumn.MinimumWidth = 25;
            this.zonaDataGridViewTextBoxColumn.Name = "zonaDataGridViewTextBoxColumn";
            this.zonaDataGridViewTextBoxColumn.ReadOnly = true;
            this.zonaDataGridViewTextBoxColumn.Width = 70;
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "Area";
            this.areaDataGridViewTextBoxColumn.HeaderText = "Area";
            this.areaDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            this.areaDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaDataGridViewTextBoxColumn.Width = 67;
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            this.alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            this.alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            this.alturaDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            this.alturaDataGridViewTextBoxColumn.ReadOnly = true;
            this.alturaDataGridViewTextBoxColumn.Width = 74;
            // 
            // offsetDataGridViewTextBoxColumn
            // 
            this.offsetDataGridViewTextBoxColumn.DataPropertyName = "offset";
            this.offsetDataGridViewTextBoxColumn.HeaderText = "offset";
            this.offsetDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.offsetDataGridViewTextBoxColumn.Name = "offsetDataGridViewTextBoxColumn";
            this.offsetDataGridViewTextBoxColumn.ReadOnly = true;
            this.offsetDataGridViewTextBoxColumn.Width = 72;
            // 
            // activoDataGridViewCheckBoxColumn
            // 
            this.activoDataGridViewCheckBoxColumn.DataPropertyName = "Activo";
            this.activoDataGridViewCheckBoxColumn.HeaderText = "Activo";
            this.activoDataGridViewCheckBoxColumn.Name = "activoDataGridViewCheckBoxColumn";
            this.activoDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activoDataGridViewCheckBoxColumn.Width = 52;
            // 
            // alamcenBindingSource
            // 
            this.alamcenBindingSource.DataSource = typeof(SWYRA.Almacen);
            // 
            // FrmDeptos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 454);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgAlmacen);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeptos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmDeptos";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgAlmacen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuscar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alamcenBindingSource)).EndInit();
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
        internal System.Windows.Forms.Button BtnBuscar;
        internal System.Windows.Forms.DataGridView dgAlmacen;
        internal DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.CheckEdit chkActivo;
        private DevExpress.XtraEditors.TextEdit txtOffset;
        private DevExpress.XtraEditors.TextEdit txtAltura;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private DevExpress.XtraEditors.TextEdit txtZona;
        private DevExpress.XtraEditors.TextEdit txtAbreviaura;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtBuscar;
        private System.Windows.Forms.BindingSource alamcenBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn claveDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn abreviaturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn offsetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activoDataGridViewCheckBoxColumn;
    }
}