namespace SWYRA
{
    partial class FrmEstatusPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstatusPedido));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFactura = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.gpoFiltro = new System.Windows.Forms.GroupBox();
            this.chkActual = new DevExpress.XtraEditors.CheckEdit();
            this.txtFechFin = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFechIni = new DevExpress.XtraEditors.DateEdit();
            this.Label1 = new System.Windows.Forms.Label();
            this.cbEstatusPed = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.pedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcve_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_clpv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltiposervicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colestatuspedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colocurredomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha_cancela = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcondicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnombre_vendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcapturo_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcobrador_autorizo_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsurtidor_asignado_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colempaquetador_asignado_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coletiquetador_asignado_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsurtidor_area_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colporc_surtidoreal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colporc_surtido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colporc_empaque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colindicaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcausa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.ppTipoServicio = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.BtnAceptarTS = new System.Windows.Forms.Button();
            this.cbTipoServicio = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.ppPrioridad = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.BtnAceptarPR = new System.Windows.Forms.Button();
            this.cbPrioridad = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.ppEntrega = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.BtnAceptarEN = new System.Windows.Forms.Button();
            this.cbEntrega = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.ppIndicaciones = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.BtnAceptarIN = new System.Windows.Forms.Button();
            this.txtIndicaciones = new DevExpress.XtraEditors.MemoEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.gpoFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstatusPed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppTipoServicio)).BeginInit();
            this.ppTipoServicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoServicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppPrioridad)).BeginInit();
            this.ppPrioridad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPrioridad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppEntrega)).BeginInit();
            this.ppEntrega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEntrega.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppIndicaciones)).BeginInit();
            this.ppIndicaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicaciones.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFactura,
            this.btnExportar,
            this.btnSalir,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(798, 27);
            this.toolStrip1.TabIndex = 40;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFactura
            // 
            this.btnFactura.Image = global::SWYRA.Properties.Resources.full_page;
            this.btnFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(80, 24);
            this.btnFactura.Text = "Resumen";
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::SWYRA.Properties.Resources._1366839417_Arzo_Icons_Icon_96_2;
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(74, 24);
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
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
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(83, 24);
            this.toolStripButton1.Text = "Actualizar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // gpoFiltro
            // 
            this.gpoFiltro.Controls.Add(this.chkActual);
            this.gpoFiltro.Controls.Add(this.txtFechFin);
            this.gpoFiltro.Controls.Add(this.label3);
            this.gpoFiltro.Controls.Add(this.label2);
            this.gpoFiltro.Controls.Add(this.txtFechIni);
            this.gpoFiltro.Controls.Add(this.Label1);
            this.gpoFiltro.Controls.Add(this.cbEstatusPed);
            this.gpoFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpoFiltro.Location = new System.Drawing.Point(0, 27);
            this.gpoFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.gpoFiltro.Name = "gpoFiltro";
            this.gpoFiltro.Padding = new System.Windows.Forms.Padding(2);
            this.gpoFiltro.Size = new System.Drawing.Size(798, 53);
            this.gpoFiltro.TabIndex = 41;
            this.gpoFiltro.TabStop = false;
            this.gpoFiltro.Text = " Filtrar Pedidos ";
            // 
            // chkActual
            // 
            this.chkActual.EditValue = true;
            this.chkActual.Location = new System.Drawing.Point(648, 22);
            this.chkActual.Margin = new System.Windows.Forms.Padding(2);
            this.chkActual.Name = "chkActual";
            this.chkActual.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActual.Properties.Appearance.Options.UseFont = true;
            this.chkActual.Properties.Caption = "DATOS ACTUALES";
            this.chkActual.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkActual.Size = new System.Drawing.Size(124, 22);
            this.chkActual.TabIndex = 43;
            this.chkActual.CheckedChanged += new System.EventHandler(this.chkActual_CheckedChanged);
            // 
            // txtFechFin
            // 
            this.txtFechFin.EditValue = null;
            this.txtFechFin.Location = new System.Drawing.Point(514, 21);
            this.txtFechFin.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechFin.Name = "txtFechFin";
            this.txtFechFin.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechFin.Properties.Appearance.Options.UseFont = true;
            this.txtFechFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechFin.Size = new System.Drawing.Size(110, 22);
            this.txtFechFin.TabIndex = 42;
            this.txtFechFin.TextChanged += new System.EventHandler(this.txtFechFin_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(495, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "al";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(254, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Elaboración";
            // 
            // txtFechIni
            // 
            this.txtFechIni.EditValue = null;
            this.txtFechIni.Location = new System.Drawing.Point(380, 21);
            this.txtFechIni.Margin = new System.Windows.Forms.Padding(2);
            this.txtFechIni.Name = "txtFechIni";
            this.txtFechIni.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechIni.Properties.Appearance.Options.UseFont = true;
            this.txtFechIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtFechIni.Size = new System.Drawing.Size(110, 22);
            this.txtFechIni.TabIndex = 3;
            this.txtFechIni.TextChanged += new System.EventHandler(this.txtFechIni_TextChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(13, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 15);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Estatus Pedido";
            // 
            // cbEstatusPed
            // 
            this.cbEstatusPed.Location = new System.Drawing.Point(106, 21);
            this.cbEstatusPed.Margin = new System.Windows.Forms.Padding(2);
            this.cbEstatusPed.Name = "cbEstatusPed";
            this.cbEstatusPed.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEstatusPed.Properties.Appearance.Options.UseFont = true;
            this.cbEstatusPed.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEstatusPed.Properties.Items.AddRange(new object[] {
            "AUTORIZACION",
            "SURTIR",
            "DETENIDO",
            "EMPAQUE",
            "REMISION",
            "GUIAS",
            "MODIFICACION",
            "CANCELACION",
            "TERMINADO",
            "TODOS"});
            this.cbEstatusPed.Size = new System.Drawing.Size(128, 22);
            this.cbEstatusPed.TabIndex = 0;
            this.cbEstatusPed.SelectedValueChanged += new System.EventHandler(this.cbEstatusPed_SelectedValueChanged);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.pedidosBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 80);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(798, 303);
            this.gridControl1.TabIndex = 42;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // pedidosBindingSource
            // 
            this.pedidosBindingSource.DataSource = typeof(SWYRA.Pedidos);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcve_doc,
            this.colcve_clpv,
            this.colcliente,
            this.coltiposervicio,
            this.colestatuspedido,
            this.colocurredomicilio,
            this.colfecha_doc,
            this.colfecha_cancela,
            this.colcondicion,
            this.colnombre_vendedor,
            this.colcapturo_n,
            this.colcobrador_autorizo_n,
            this.colsurtidor_asignado_n,
            this.colempaquetador_asignado_n,
            this.coletiquetador_asignado_n,
            this.colsurtidor_area_n,
            this.colporc_surtidoreal,
            this.colporc_surtido,
            this.colporc_empaque,
            this.colindicaciones,
            this.collote,
            this.colcausa});
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
            // colcve_clpv
            // 
            this.colcve_clpv.Caption = "# Cliente";
            this.colcve_clpv.FieldName = "cve_clpv";
            this.colcve_clpv.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcve_clpv.Name = "colcve_clpv";
            this.colcve_clpv.Visible = true;
            this.colcve_clpv.VisibleIndex = 1;
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
            this.colcliente.VisibleIndex = 2;
            this.colcliente.Width = 205;
            // 
            // coltiposervicio
            // 
            this.coltiposervicio.Caption = "Tipo Servicio";
            this.coltiposervicio.FieldName = "tiposervicio";
            this.coltiposervicio.Name = "coltiposervicio";
            this.coltiposervicio.Visible = true;
            this.coltiposervicio.VisibleIndex = 3;
            this.coltiposervicio.Width = 90;
            // 
            // colestatuspedido
            // 
            this.colestatuspedido.Caption = "Estatus Pedido";
            this.colestatuspedido.FieldName = "estatuspedido";
            this.colestatuspedido.Name = "colestatuspedido";
            this.colestatuspedido.Visible = true;
            this.colestatuspedido.VisibleIndex = 4;
            this.colestatuspedido.Width = 120;
            // 
            // colocurredomicilio
            // 
            this.colocurredomicilio.Caption = "Ocurre a Domicilio";
            this.colocurredomicilio.FieldName = "ocurredomicilio";
            this.colocurredomicilio.Name = "colocurredomicilio";
            this.colocurredomicilio.Visible = true;
            this.colocurredomicilio.VisibleIndex = 5;
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
            this.colfecha_doc.VisibleIndex = 6;
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
            this.colfecha_cancela.VisibleIndex = 7;
            this.colfecha_cancela.Width = 110;
            // 
            // colcondicion
            // 
            this.colcondicion.Caption = "Condición";
            this.colcondicion.FieldName = "condicion";
            this.colcondicion.Name = "colcondicion";
            this.colcondicion.Visible = true;
            this.colcondicion.VisibleIndex = 8;
            this.colcondicion.Width = 205;
            // 
            // colnombre_vendedor
            // 
            this.colnombre_vendedor.Caption = "Vendedor";
            this.colnombre_vendedor.FieldName = "nombre_vendedor";
            this.colnombre_vendedor.Name = "colnombre_vendedor";
            this.colnombre_vendedor.Visible = true;
            this.colnombre_vendedor.VisibleIndex = 9;
            this.colnombre_vendedor.Width = 150;
            // 
            // colcapturo_n
            // 
            this.colcapturo_n.Caption = "Asistente Venta";
            this.colcapturo_n.FieldName = "capturo_n";
            this.colcapturo_n.Name = "colcapturo_n";
            this.colcapturo_n.Visible = true;
            this.colcapturo_n.VisibleIndex = 10;
            this.colcapturo_n.Width = 150;
            // 
            // colcobrador_autorizo_n
            // 
            this.colcobrador_autorizo_n.Caption = "Cobrador Autorizo";
            this.colcobrador_autorizo_n.CustomizationCaption = "a";
            this.colcobrador_autorizo_n.FieldName = "cobrador_autorizo_n";
            this.colcobrador_autorizo_n.Name = "colcobrador_autorizo_n";
            this.colcobrador_autorizo_n.Visible = true;
            this.colcobrador_autorizo_n.VisibleIndex = 11;
            this.colcobrador_autorizo_n.Width = 150;
            // 
            // colsurtidor_asignado_n
            // 
            this.colsurtidor_asignado_n.Caption = "Surtidor Asignado";
            this.colsurtidor_asignado_n.FieldName = "surtidor_asignado_n";
            this.colsurtidor_asignado_n.Name = "colsurtidor_asignado_n";
            this.colsurtidor_asignado_n.Visible = true;
            this.colsurtidor_asignado_n.VisibleIndex = 12;
            this.colsurtidor_asignado_n.Width = 150;
            // 
            // colempaquetador_asignado_n
            // 
            this.colempaquetador_asignado_n.Caption = "Empaquetador Asignado";
            this.colempaquetador_asignado_n.FieldName = "empaquetador_asignado_n";
            this.colempaquetador_asignado_n.Name = "colempaquetador_asignado_n";
            this.colempaquetador_asignado_n.Visible = true;
            this.colempaquetador_asignado_n.VisibleIndex = 13;
            this.colempaquetador_asignado_n.Width = 150;
            // 
            // coletiquetador_asignado_n
            // 
            this.coletiquetador_asignado_n.Caption = "Etiquetador Asignado";
            this.coletiquetador_asignado_n.FieldName = "etiquetador_asignado_n";
            this.coletiquetador_asignado_n.Name = "coletiquetador_asignado_n";
            this.coletiquetador_asignado_n.Visible = true;
            this.coletiquetador_asignado_n.VisibleIndex = 14;
            this.coletiquetador_asignado_n.Width = 150;
            // 
            // colsurtidor_area_n
            // 
            this.colsurtidor_area_n.Caption = "Surtidor Broca";
            this.colsurtidor_area_n.FieldName = "surtidor_area_n";
            this.colsurtidor_area_n.Name = "colsurtidor_area_n";
            this.colsurtidor_area_n.Visible = true;
            this.colsurtidor_area_n.VisibleIndex = 15;
            this.colsurtidor_area_n.Width = 150;
            // 
            // colporc_surtidoreal
            // 
            this.colporc_surtidoreal.Caption = "Porcentaje Surtido";
            this.colporc_surtidoreal.DisplayFormat.FormatString = "#0.00 %";
            this.colporc_surtidoreal.FieldName = "porc_surtidoReal";
            this.colporc_surtidoreal.Name = "colporc_surtidoreal";
            this.colporc_surtidoreal.Visible = true;
            this.colporc_surtidoreal.VisibleIndex = 16;
            this.colporc_surtidoreal.Width = 150;
            // 
            // colporc_surtido
            // 
            this.colporc_surtido.Caption = "Avance Surtido";
            this.colporc_surtido.DisplayFormat.FormatString = "#0.00 %";
            this.colporc_surtido.FieldName = "porc_surtido";
            this.colporc_surtido.Name = "colporc_surtido";
            this.colporc_surtido.Visible = true;
            this.colporc_surtido.VisibleIndex = 17;
            this.colporc_surtido.Width = 150;
            // 
            // colporc_empaque
            // 
            this.colporc_empaque.Caption = "Avance Empaque";
            this.colporc_empaque.DisplayFormat.FormatString = "#0.00 %";
            this.colporc_empaque.FieldName = "porc_empaque";
            this.colporc_empaque.Name = "colporc_empaque";
            this.colporc_empaque.Visible = true;
            this.colporc_empaque.VisibleIndex = 18;
            this.colporc_empaque.Width = 150;
            // 
            // colindicaciones
            // 
            this.colindicaciones.Caption = "Indicaciones";
            this.colindicaciones.FieldName = "indicaciones";
            this.colindicaciones.Name = "colindicaciones";
            this.colindicaciones.Visible = true;
            this.colindicaciones.VisibleIndex = 19;
            this.colindicaciones.Width = 150;
            // 
            // collote
            // 
            this.collote.Caption = "Lote";
            this.collote.FieldName = "lote";
            this.collote.Name = "collote";
            this.collote.Visible = true;
            this.collote.VisibleIndex = 20;
            this.collote.Width = 90;
            // 
            // colcausa
            // 
            this.colcausa.Caption = "Causa Detenido";
            this.colcausa.FieldName = "causadetenido";
            this.colcausa.Name = "colcausa";
            this.colcausa.Visible = true;
            this.colcausa.VisibleIndex = 21;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.ShowNavigationHeader = DevExpress.Utils.DefaultBoolean.False;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Cambiar Prioridad";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Cambiar Tipo Servicio";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Cambiar Tipo de Entrega";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Indicaciones";
            this.barButtonItem4.Id = 4;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Impresion Etiquetas";
            this.barButtonItem6.Id = 7;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.CloseButtonAffectAllTabs = false;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItem5,
            this.barButtonItem6});
            this.barManager1.MaxItemId = 8;
            this.barManager1.OptionsLayout.AllowAddNewItems = false;
            this.barManager1.PopupShowMode = DevExpress.XtraBars.PopupShowMode.Classic;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(798, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 383);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(798, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 383);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(798, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 383);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "barStaticItem1";
            this.barStaticItem1.Id = 0;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Id = 6;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // ppTipoServicio
            // 
            this.ppTipoServicio.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ppTipoServicio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppTipoServicio.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ppTipoServicio.Controls.Add(this.BtnAceptarTS);
            this.ppTipoServicio.Controls.Add(this.cbTipoServicio);
            this.ppTipoServicio.Controls.Add(this.label4);
            this.ppTipoServicio.Location = new System.Drawing.Point(295, 132);
            this.ppTipoServicio.Manager = this.barManager1;
            this.ppTipoServicio.Margin = new System.Windows.Forms.Padding(2);
            this.ppTipoServicio.Name = "ppTipoServicio";
            this.ppTipoServicio.Size = new System.Drawing.Size(268, 90);
            this.ppTipoServicio.TabIndex = 47;
            this.ppTipoServicio.Visible = false;
            // 
            // BtnAceptarTS
            // 
            this.BtnAceptarTS.BackColor = System.Drawing.Color.Firebrick;
            this.BtnAceptarTS.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAceptarTS.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptarTS.ForeColor = System.Drawing.Color.White;
            this.BtnAceptarTS.Location = new System.Drawing.Point(157, 41);
            this.BtnAceptarTS.Name = "BtnAceptarTS";
            this.BtnAceptarTS.Size = new System.Drawing.Size(98, 37);
            this.BtnAceptarTS.TabIndex = 13;
            this.BtnAceptarTS.Text = "ACEPTAR";
            this.BtnAceptarTS.UseVisualStyleBackColor = false;
            this.BtnAceptarTS.Click += new System.EventHandler(this.BtnAceptarTS_Click);
            // 
            // cbTipoServicio
            // 
            this.cbTipoServicio.Location = new System.Drawing.Point(104, 16);
            this.cbTipoServicio.Margin = new System.Windows.Forms.Padding(2);
            this.cbTipoServicio.Name = "cbTipoServicio";
            this.cbTipoServicio.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoServicio.Properties.Appearance.Options.UseFont = true;
            this.cbTipoServicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTipoServicio.Properties.Items.AddRange(new object[] {
            "LOCAL",
            "LOCAL URGENTE",
            "FORANEO",
            "FORANEO URGENTE"});
            this.cbTipoServicio.Size = new System.Drawing.Size(152, 22);
            this.cbTipoServicio.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de Servicio";
            // 
            // ppPrioridad
            // 
            this.ppPrioridad.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ppPrioridad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppPrioridad.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ppPrioridad.Controls.Add(this.BtnAceptarPR);
            this.ppPrioridad.Controls.Add(this.cbPrioridad);
            this.ppPrioridad.Controls.Add(this.label5);
            this.ppPrioridad.Location = new System.Drawing.Point(506, 99);
            this.ppPrioridad.Manager = this.barManager1;
            this.ppPrioridad.Margin = new System.Windows.Forms.Padding(2);
            this.ppPrioridad.Name = "ppPrioridad";
            this.ppPrioridad.Size = new System.Drawing.Size(268, 90);
            this.ppPrioridad.TabIndex = 52;
            this.ppPrioridad.Visible = false;
            // 
            // BtnAceptarPR
            // 
            this.BtnAceptarPR.BackColor = System.Drawing.Color.Firebrick;
            this.BtnAceptarPR.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAceptarPR.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptarPR.ForeColor = System.Drawing.Color.White;
            this.BtnAceptarPR.Location = new System.Drawing.Point(158, 39);
            this.BtnAceptarPR.Name = "BtnAceptarPR";
            this.BtnAceptarPR.Size = new System.Drawing.Size(98, 37);
            this.BtnAceptarPR.TabIndex = 16;
            this.BtnAceptarPR.Text = "ACEPTAR";
            this.BtnAceptarPR.UseVisualStyleBackColor = false;
            this.BtnAceptarPR.Click += new System.EventHandler(this.BtnAceptarPR_Click);
            // 
            // cbPrioridad
            // 
            this.cbPrioridad.Location = new System.Drawing.Point(104, 14);
            this.cbPrioridad.Margin = new System.Windows.Forms.Padding(2);
            this.cbPrioridad.Name = "cbPrioridad";
            this.cbPrioridad.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrioridad.Properties.Appearance.Options.UseFont = true;
            this.cbPrioridad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPrioridad.Properties.Items.AddRange(new object[] {
            "URGENTE",
            "NORMAL"});
            this.cbPrioridad.Size = new System.Drawing.Size(152, 22);
            this.cbPrioridad.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Prioridad";
            // 
            // ppEntrega
            // 
            this.ppEntrega.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ppEntrega.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppEntrega.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ppEntrega.Controls.Add(this.BtnAceptarEN);
            this.ppEntrega.Controls.Add(this.cbEntrega);
            this.ppEntrega.Controls.Add(this.label6);
            this.ppEntrega.Location = new System.Drawing.Point(295, 249);
            this.ppEntrega.Manager = this.barManager1;
            this.ppEntrega.Margin = new System.Windows.Forms.Padding(2);
            this.ppEntrega.Name = "ppEntrega";
            this.ppEntrega.Size = new System.Drawing.Size(268, 90);
            this.ppEntrega.TabIndex = 57;
            this.ppEntrega.Visible = false;
            // 
            // BtnAceptarEN
            // 
            this.BtnAceptarEN.BackColor = System.Drawing.Color.Firebrick;
            this.BtnAceptarEN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAceptarEN.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptarEN.ForeColor = System.Drawing.Color.White;
            this.BtnAceptarEN.Location = new System.Drawing.Point(157, 39);
            this.BtnAceptarEN.Name = "BtnAceptarEN";
            this.BtnAceptarEN.Size = new System.Drawing.Size(98, 37);
            this.BtnAceptarEN.TabIndex = 19;
            this.BtnAceptarEN.Text = "ACEPTAR";
            this.BtnAceptarEN.UseVisualStyleBackColor = false;
            this.BtnAceptarEN.Click += new System.EventHandler(this.BtnAceptarEN_Click);
            // 
            // cbEntrega
            // 
            this.cbEntrega.Location = new System.Drawing.Point(104, 14);
            this.cbEntrega.Margin = new System.Windows.Forms.Padding(2);
            this.cbEntrega.Name = "cbEntrega";
            this.cbEntrega.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntrega.Properties.Appearance.Options.UseFont = true;
            this.cbEntrega.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbEntrega.Properties.Items.AddRange(new object[] {
            "DOMICILIO",
            "OCURRE",
            "PASAN"});
            this.cbEntrega.Size = new System.Drawing.Size(152, 22);
            this.cbEntrega.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Entrega";
            // 
            // ppIndicaciones
            // 
            this.ppIndicaciones.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ppIndicaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppIndicaciones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ppIndicaciones.Controls.Add(this.BtnAceptarIN);
            this.ppIndicaciones.Controls.Add(this.txtIndicaciones);
            this.ppIndicaciones.Controls.Add(this.label7);
            this.ppIndicaciones.Location = new System.Drawing.Point(22, 108);
            this.ppIndicaciones.Manager = this.barManager1;
            this.ppIndicaciones.Margin = new System.Windows.Forms.Padding(2);
            this.ppIndicaciones.Name = "ppIndicaciones";
            this.ppIndicaciones.Size = new System.Drawing.Size(268, 132);
            this.ppIndicaciones.TabIndex = 62;
            this.ppIndicaciones.Visible = false;
            // 
            // BtnAceptarIN
            // 
            this.BtnAceptarIN.BackColor = System.Drawing.Color.Firebrick;
            this.BtnAceptarIN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAceptarIN.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptarIN.ForeColor = System.Drawing.Color.White;
            this.BtnAceptarIN.Location = new System.Drawing.Point(157, 87);
            this.BtnAceptarIN.Name = "BtnAceptarIN";
            this.BtnAceptarIN.Size = new System.Drawing.Size(98, 37);
            this.BtnAceptarIN.TabIndex = 20;
            this.BtnAceptarIN.Text = "ACEPTAR";
            this.BtnAceptarIN.UseVisualStyleBackColor = false;
            this.BtnAceptarIN.Click += new System.EventHandler(this.BtnAceptarIN_Click);
            // 
            // txtIndicaciones
            // 
            this.txtIndicaciones.Location = new System.Drawing.Point(13, 28);
            this.txtIndicaciones.Margin = new System.Windows.Forms.Padding(2);
            this.txtIndicaciones.MenuManager = this.barManager1;
            this.txtIndicaciones.Name = "txtIndicaciones";
            this.txtIndicaciones.Size = new System.Drawing.Size(243, 53);
            this.txtIndicaciones.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Indicaciones";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 383);
            this.panel1.TabIndex = 67;
            // 
            // FrmEstatusPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(798, 383);
            this.Controls.Add(this.ppIndicaciones);
            this.Controls.Add(this.ppEntrega);
            this.Controls.Add(this.ppPrioridad);
            this.Controls.Add(this.ppTipoServicio);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gpoFiltro);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmEstatusPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ESTATUS PEDIDO";
            this.Load += new System.EventHandler(this.FrmEstatusPedido_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gpoFiltro.ResumeLayout(false);
            this.gpoFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbEstatusPed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppTipoServicio)).EndInit();
            this.ppTipoServicio.ResumeLayout(false);
            this.ppTipoServicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoServicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppPrioridad)).EndInit();
            this.ppPrioridad.ResumeLayout(false);
            this.ppPrioridad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPrioridad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppEntrega)).EndInit();
            this.ppEntrega.ResumeLayout(false);
            this.ppEntrega.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbEntrega.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppIndicaciones)).EndInit();
            this.ppIndicaciones.ResumeLayout(false);
            this.ppIndicaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIndicaciones.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.GroupBox gpoFiltro;
        private DevExpress.XtraEditors.ComboBoxEdit cbEstatusPed;
        internal System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit txtFechIni;
        private DevExpress.XtraEditors.DateEdit txtFechFin;
        internal System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckEdit chkActual;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource pedidosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_doc;
        private DevExpress.XtraGrid.Columns.GridColumn colcliente;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha_doc;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha_cancela;
        private DevExpress.XtraGrid.Columns.GridColumn colcondicion;
        private DevExpress.XtraGrid.Columns.GridColumn coltiposervicio;
        private DevExpress.XtraGrid.Columns.GridColumn colestatuspedido;
        private DevExpress.XtraGrid.Columns.GridColumn colocurredomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colcapturo_n;
        private DevExpress.XtraGrid.Columns.GridColumn colcobrador_autorizo_n;
        private DevExpress.XtraGrid.Columns.GridColumn colsurtidor_asignado_n;
        private DevExpress.XtraGrid.Columns.GridColumn colempaquetador_asignado_n;
        private DevExpress.XtraGrid.Columns.GridColumn coletiquetador_asignado_n;
        private DevExpress.XtraGrid.Columns.GridColumn colsurtidor_area_n;
        private DevExpress.XtraGrid.Columns.GridColumn colporc_surtido;
        private DevExpress.XtraGrid.Columns.GridColumn colporc_empaque;
        private DevExpress.XtraGrid.Columns.GridColumn colindicaciones;
        private DevExpress.XtraGrid.Columns.GridColumn collote;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.PopupControlContainer ppTipoServicio;
        private DevExpress.XtraEditors.ComboBoxEdit cbTipoServicio;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button BtnAceptarTS;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.PopupControlContainer ppPrioridad;
        internal System.Windows.Forms.Button BtnAceptarPR;
        private DevExpress.XtraEditors.ComboBoxEdit cbPrioridad;
        internal System.Windows.Forms.Label label5;
        private DevExpress.XtraBars.PopupControlContainer ppEntrega;
        internal System.Windows.Forms.Button BtnAceptarEN;
        private DevExpress.XtraEditors.ComboBoxEdit cbEntrega;
        internal System.Windows.Forms.Label label6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.PopupControlContainer ppIndicaciones;
        internal System.Windows.Forms.Button BtnAceptarIN;
        private DevExpress.XtraEditors.MemoEdit txtIndicaciones;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn colnombre_vendedor;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_clpv;
        private System.Windows.Forms.ToolStripButton btnFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colporc_surtidoreal;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraGrid.Columns.GridColumn colcausa;
    }
}