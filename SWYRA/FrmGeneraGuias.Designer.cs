namespace SWYRA
{
    partial class FrmGeneraGuias
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGeneraGuias));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcIndicacion = new DevExpress.XtraGrid.GridControl();
            this.detallePedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcve_art = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcomen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGuias = new DevExpress.XtraGrid.GridControl();
            this.detallePedidoMercBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvGuias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcve_art_guia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprecio_guia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colconsec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtConsec = new System.Windows.Forms.TextBox();
            this.txtPrecio = new DevExpress.XtraEditors.SpinEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDescr = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lsPaqueteria = new DevExpress.XtraEditors.LookUpEdit();
            this.inventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnQuitar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.gcAsiganado = new DevExpress.XtraGrid.GridControl();
            this.gvAsignado = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colconsec_empaque1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcodigo_barra1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltipopaquete1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotart2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gcPaquetes = new DevExpress.XtraGrid.GridControl();
            this.gvPaquetes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colconsec_empaque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcodigo_barra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltipopaquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIndicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuias)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsPaqueteria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAsiganado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsignado)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPaquetes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaquetes)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcIndicacion);
            this.panel1.Controls.Add(this.gcGuias);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 534);
            this.panel1.TabIndex = 0;
            // 
            // gcIndicacion
            // 
            this.gcIndicacion.DataSource = this.detallePedidosBindingSource;
            this.gcIndicacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            gridLevelNode1.RelationName = "Level1";
            this.gcIndicacion.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcIndicacion.Location = new System.Drawing.Point(0, 388);
            this.gcIndicacion.MainView = this.gridView1;
            this.gcIndicacion.Name = "gcIndicacion";
            this.gcIndicacion.Size = new System.Drawing.Size(680, 146);
            this.gcIndicacion.TabIndex = 5;
            this.gcIndicacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // detallePedidosBindingSource
            // 
            this.detallePedidosBindingSource.DataSource = typeof(SWYRA.DetallePedidos);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ViewCaption.FontSizeDelta = 2;
            this.gridView1.Appearance.ViewCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gridView1.Appearance.ViewCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridView1.Appearance.ViewCaption.Image = global::SWYRA.Properties.Resources.next;
            this.gridView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.Options.UseForeColor = true;
            this.gridView1.Appearance.ViewCaption.Options.UseImage = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcve_art,
            this.coldescr1,
            this.colcomen});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gcIndicacion;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Indicaciones";
            // 
            // colcve_art
            // 
            this.colcve_art.Caption = "Artículo";
            this.colcve_art.FieldName = "cve_art";
            this.colcve_art.Name = "colcve_art";
            this.colcve_art.Visible = true;
            this.colcve_art.VisibleIndex = 0;
            this.colcve_art.Width = 45;
            // 
            // coldescr1
            // 
            this.coldescr1.Caption = "Descripción";
            this.coldescr1.FieldName = "descr";
            this.coldescr1.Name = "coldescr1";
            this.coldescr1.Visible = true;
            this.coldescr1.VisibleIndex = 1;
            this.coldescr1.Width = 250;
            // 
            // colcomen
            // 
            this.colcomen.Caption = "Indicación";
            this.colcomen.FieldName = "comen";
            this.colcomen.Name = "colcomen";
            this.colcomen.Visible = true;
            this.colcomen.VisibleIndex = 2;
            this.colcomen.Width = 350;
            // 
            // gcGuias
            // 
            this.gcGuias.DataSource = this.detallePedidoMercBindingSource;
            this.gcGuias.Location = new System.Drawing.Point(236, 237);
            this.gcGuias.MainView = this.gvGuias;
            this.gcGuias.Name = "gcGuias";
            this.gcGuias.Size = new System.Drawing.Size(437, 145);
            this.gcGuias.TabIndex = 5;
            this.gcGuias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvGuias});
            // 
            // detallePedidoMercBindingSource
            // 
            this.detallePedidoMercBindingSource.DataSource = typeof(SWYRA.DetallePedidoMerc);
            // 
            // gvGuias
            // 
            this.gvGuias.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcve_art_guia,
            this.coldescr,
            this.colprecio_guia,
            this.colconsec});
            this.gvGuias.GridControl = this.gcGuias;
            this.gvGuias.Name = "gvGuias";
            this.gvGuias.OptionsBehavior.Editable = false;
            this.gvGuias.OptionsMenu.EnableFooterMenu = false;
            this.gvGuias.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvGuias.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gvGuias.OptionsView.ColumnAutoWidth = false;
            this.gvGuias.OptionsView.ShowGroupPanel = false;
            this.gvGuias.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvGuias_FocusedRowChanged);
            this.gvGuias.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gvGuias_FocusedColumnChanged);
            // 
            // colcve_art_guia
            // 
            this.colcve_art_guia.Caption = "Clave";
            this.colcve_art_guia.FieldName = "cve_art_guia";
            this.colcve_art_guia.Name = "colcve_art_guia";
            this.colcve_art_guia.Visible = true;
            this.colcve_art_guia.VisibleIndex = 0;
            this.colcve_art_guia.Width = 60;
            // 
            // coldescr
            // 
            this.coldescr.Caption = "Descripción";
            this.coldescr.FieldName = "descr";
            this.coldescr.Name = "coldescr";
            this.coldescr.Visible = true;
            this.coldescr.VisibleIndex = 1;
            this.coldescr.Width = 250;
            // 
            // colprecio_guia
            // 
            this.colprecio_guia.Caption = "Precio";
            this.colprecio_guia.DisplayFormat.FormatString = "$ #,##0.00";
            this.colprecio_guia.FieldName = "precio_guia";
            this.colprecio_guia.Name = "colprecio_guia";
            this.colprecio_guia.Visible = true;
            this.colprecio_guia.VisibleIndex = 2;
            // 
            // colconsec
            // 
            this.colconsec.Caption = "#";
            this.colconsec.FieldName = "consec";
            this.colconsec.Name = "colconsec";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtConsec);
            this.groupBox2.Controls.Add(this.txtPrecio);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblDescr);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lsPaqueteria);
            this.groupBox2.Controls.Add(this.btnQuitar);
            this.groupBox2.Controls.Add(this.btnAgregar);
            this.groupBox2.Controls.Add(this.gcAsiganado);
            this.groupBox2.Location = new System.Drawing.Point(230, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 204);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Guía";
            // 
            // txtConsec
            // 
            this.txtConsec.Location = new System.Drawing.Point(6, 71);
            this.txtConsec.Name = "txtConsec";
            this.txtConsec.Size = new System.Drawing.Size(38, 20);
            this.txtConsec.TabIndex = 9;
            this.txtConsec.Text = "0";
            this.txtConsec.Visible = false;
            // 
            // txtPrecio
            // 
            this.txtPrecio.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPrecio.Location = new System.Drawing.Point(79, 41);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPrecio.Properties.EditFormat.FormatString = "$ #,##0.00";
            this.txtPrecio.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
            this.txtPrecio.Properties.Mask.EditMask = "c";
            this.txtPrecio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrecio.Properties.MaxValue = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtPrecio.Size = new System.Drawing.Size(116, 20);
            this.txtPrecio.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Precio";
            // 
            // lblDescr
            // 
            this.lblDescr.AutoSize = true;
            this.lblDescr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescr.Location = new System.Drawing.Point(201, 20);
            this.lblDescr.MaximumSize = new System.Drawing.Size(240, 30);
            this.lblDescr.Name = "lblDescr";
            this.lblDescr.Size = new System.Drawing.Size(0, 15);
            this.lblDescr.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Paquetería";
            // 
            // lsPaqueteria
            // 
            this.lsPaqueteria.Location = new System.Drawing.Point(79, 19);
            this.lsPaqueteria.Name = "lsPaqueteria";
            this.lsPaqueteria.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.lsPaqueteria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lsPaqueteria.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("cve_art", 60, "Artículo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("descr", 250, "Decripción"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("precio", "Precio", 60, DevExpress.Utils.FormatType.None, "$ #,##0.00", true, DevExpress.Utils.HorzAlignment.Default)});
            this.lsPaqueteria.Properties.DataSource = this.inventarioBindingSource;
            this.lsPaqueteria.Properties.DisplayMember = "cve_art";
            this.lsPaqueteria.Properties.NullText = "";
            this.lsPaqueteria.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lsPaqueteria.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.OnlyInPopup;
            this.lsPaqueteria.Properties.ValueMember = "cve_art";
            this.lsPaqueteria.Size = new System.Drawing.Size(116, 20);
            this.lsPaqueteria.TabIndex = 3;
            this.lsPaqueteria.EditValueChanged += new System.EventHandler(this.lsPaqueteria_EditValueChanged);
            // 
            // inventarioBindingSource
            // 
            this.inventarioBindingSource.DataSource = typeof(SWYRA.Inventario);
            // 
            // btnQuitar
            // 
            this.btnQuitar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnQuitar.ImageUri.Uri = "Backward";
            this.btnQuitar.Location = new System.Drawing.Point(5, 140);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(39, 37);
            this.btnQuitar.TabIndex = 2;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnAgregar.ImageUri.Uri = "Forward";
            this.btnAgregar.Location = new System.Drawing.Point(4, 97);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(39, 37);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gcAsiganado
            // 
            this.gcAsiganado.DataSource = this.detallePedidoMercBindingSource;
            this.gcAsiganado.Location = new System.Drawing.Point(49, 69);
            this.gcAsiganado.MainView = this.gvAsignado;
            this.gcAsiganado.Name = "gcAsiganado";
            this.gcAsiganado.Size = new System.Drawing.Size(394, 130);
            this.gcAsiganado.TabIndex = 0;
            this.gcAsiganado.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAsignado});
            // 
            // gvAsignado
            // 
            this.gvAsignado.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colconsec_empaque1,
            this.colcodigo_barra1,
            this.coltipopaquete1,
            this.coltotart2});
            this.gvAsignado.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvAsignado.GridControl = this.gcAsiganado;
            this.gvAsignado.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never;
            this.gvAsignado.Name = "gvAsignado";
            this.gvAsignado.OptionsBehavior.Editable = false;
            this.gvAsignado.OptionsMenu.EnableFooterMenu = false;
            this.gvAsignado.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvAsignado.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvAsignado.OptionsSelection.MultiSelect = true;
            this.gvAsignado.OptionsView.ColumnAutoWidth = false;
            this.gvAsignado.OptionsView.ShowGroupPanel = false;
            // 
            // colconsec_empaque1
            // 
            this.colconsec_empaque1.Caption = "#";
            this.colconsec_empaque1.FieldName = "consec_empaque";
            this.colconsec_empaque1.Name = "colconsec_empaque1";
            this.colconsec_empaque1.Visible = true;
            this.colconsec_empaque1.VisibleIndex = 0;
            this.colconsec_empaque1.Width = 40;
            // 
            // colcodigo_barra1
            // 
            this.colcodigo_barra1.Caption = "Código";
            this.colcodigo_barra1.FieldName = "codigo_barra";
            this.colcodigo_barra1.Name = "colcodigo_barra1";
            this.colcodigo_barra1.Visible = true;
            this.colcodigo_barra1.VisibleIndex = 1;
            this.colcodigo_barra1.Width = 100;
            // 
            // coltipopaquete1
            // 
            this.coltipopaquete1.Caption = "Paquete";
            this.coltipopaquete1.FieldName = "tipopaquete";
            this.coltipopaquete1.Name = "coltipopaquete1";
            this.coltipopaquete1.Visible = true;
            this.coltipopaquete1.VisibleIndex = 2;
            this.coltipopaquete1.Width = 100;
            // 
            // coltotart2
            // 
            this.coltotart2.Caption = "Artículos";
            this.coltotart2.FieldName = "totart";
            this.coltotart2.Name = "coltotart2";
            this.coltotart2.Visible = true;
            this.coltotart2.VisibleIndex = 3;
            this.coltotart2.Width = 60;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gcPaquetes);
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 355);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paquetes por asignar";
            // 
            // gcPaquetes
            // 
            this.gcPaquetes.DataSource = this.detallePedidoMercBindingSource;
            this.gcPaquetes.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.RelationName = "Level1";
            this.gcPaquetes.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gcPaquetes.Location = new System.Drawing.Point(3, 16);
            this.gcPaquetes.MainView = this.gvPaquetes;
            this.gcPaquetes.Name = "gcPaquetes";
            this.gcPaquetes.Size = new System.Drawing.Size(224, 336);
            this.gcPaquetes.TabIndex = 0;
            this.gcPaquetes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPaquetes});
            // 
            // gvPaquetes
            // 
            this.gvPaquetes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colconsec_empaque,
            this.colcodigo_barra,
            this.coltipopaquete,
            this.coltotart});
            this.gvPaquetes.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvPaquetes.GridControl = this.gcPaquetes;
            this.gvPaquetes.Name = "gvPaquetes";
            this.gvPaquetes.OptionsBehavior.Editable = false;
            this.gvPaquetes.OptionsMenu.EnableFooterMenu = false;
            this.gvPaquetes.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvPaquetes.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvPaquetes.OptionsSelection.MultiSelect = true;
            this.gvPaquetes.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gvPaquetes.OptionsView.ColumnAutoWidth = false;
            this.gvPaquetes.OptionsView.ShowGroupPanel = false;
            // 
            // colconsec_empaque
            // 
            this.colconsec_empaque.Caption = "#";
            this.colconsec_empaque.FieldName = "consec_empaque";
            this.colconsec_empaque.Name = "colconsec_empaque";
            this.colconsec_empaque.Visible = true;
            this.colconsec_empaque.VisibleIndex = 0;
            this.colconsec_empaque.Width = 30;
            // 
            // colcodigo_barra
            // 
            this.colcodigo_barra.Caption = "Código";
            this.colcodigo_barra.FieldName = "codigo_barra";
            this.colcodigo_barra.Name = "colcodigo_barra";
            this.colcodigo_barra.Visible = true;
            this.colcodigo_barra.VisibleIndex = 1;
            this.colcodigo_barra.Width = 100;
            // 
            // coltipopaquete
            // 
            this.coltipopaquete.Caption = "Paquete";
            this.coltipopaquete.FieldName = "tipopaquete";
            this.coltipopaquete.Name = "coltipopaquete";
            this.coltipopaquete.Visible = true;
            this.coltipopaquete.VisibleIndex = 2;
            this.coltipopaquete.Width = 80;
            // 
            // coltotart
            // 
            this.coltotart.Caption = "Artículos";
            this.coltotart.FieldName = "totart";
            this.coltotart.Name = "coltotart";
            this.coltotart.Visible = true;
            this.coltotart.VisibleIndex = 3;
            this.coltotart.Width = 40;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnLimpiar,
            this.btnEliminar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(680, 27);
            this.toolStrip1.TabIndex = 2;
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
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::SWYRA.Properties.Resources._new;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(71, 24);
            this.btnLimpiar.Text = "Nueva";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SWYRA.Properties.Resources.delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(77, 24);
            this.btnEliminar.Text = "Cancelar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            // FrmGeneraGuias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(682, 535);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGeneraGuias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GENERACION DE SERVICIO";
            this.Load += new System.EventHandler(this.FrmGeneraGuias_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcIndicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGuias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvGuias)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsPaqueteria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcAsiganado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAsignado)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPaquetes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaquetes)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gcGuias;
        private DevExpress.XtraGrid.Views.Grid.GridView gvGuias;
        private DevExpress.XtraGrid.GridControl gcAsiganado;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAsignado;
        private DevExpress.XtraGrid.GridControl gcPaquetes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPaquetes;
        private DevExpress.XtraEditors.SimpleButton btnQuitar;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.LookUpEdit lsPaqueteria;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblDescr;
        internal System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SpinEdit txtPrecio;
        private System.Windows.Forms.BindingSource detallePedidoMercBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colconsec_empaque;
        private DevExpress.XtraGrid.Columns.GridColumn colcodigo_barra;
        private DevExpress.XtraGrid.Columns.GridColumn coltipopaquete;
        private DevExpress.XtraGrid.Columns.GridColumn coltotart;
        private System.Windows.Forms.BindingSource inventarioBindingSource;
        private System.Windows.Forms.TextBox txtConsec;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_art_guia;
        private DevExpress.XtraGrid.Columns.GridColumn coldescr;
        private DevExpress.XtraGrid.Columns.GridColumn colprecio_guia;
        private DevExpress.XtraGrid.Columns.GridColumn colconsec_empaque1;
        private DevExpress.XtraGrid.Columns.GridColumn colcodigo_barra1;
        private DevExpress.XtraGrid.Columns.GridColumn coltipopaquete1;
        private DevExpress.XtraGrid.Columns.GridColumn coltotart2;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn colconsec;
        private DevExpress.XtraGrid.GridControl gcIndicacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource detallePedidosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_art;
        private DevExpress.XtraGrid.Columns.GridColumn coldescr1;
        private DevExpress.XtraGrid.Columns.GridColumn colcomen;
    }
}