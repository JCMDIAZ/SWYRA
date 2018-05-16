namespace SWYRA
{
    partial class FrmAjustePedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAjustePedido));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcPaquetes = new DevExpress.XtraGrid.GridControl();
            this.detallePedidoMercBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvPaquetes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colconsec_empaque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltipopaquete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDetPedido = new DevExpress.XtraGrid.GridControl();
            this.detallePedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colnum_par = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_art = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldescr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcantsurtido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltot_partida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltdesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsubto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotimp4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colimporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colempaque = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTarimas = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAtados = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCubeta = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRollo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBulto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCajaMadera = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCajaCarton = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrioridad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOcurredom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTipoServicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPaquetes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaquetes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gcPaquetes);
            this.panel1.Controls.Add(this.gcDetPedido);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 633);
            this.panel1.TabIndex = 0;
            // 
            // gcPaquetes
            // 
            this.gcPaquetes.DataSource = this.detallePedidoMercBindingSource;
            gridLevelNode1.RelationName = "Level1";
            this.gcPaquetes.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcPaquetes.Location = new System.Drawing.Point(690, 30);
            this.gcPaquetes.MainView = this.gvPaquetes;
            this.gcPaquetes.Name = "gcPaquetes";
            this.gcPaquetes.Size = new System.Drawing.Size(231, 200);
            this.gcPaquetes.TabIndex = 30;
            this.gcPaquetes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPaquetes});
            // 
            // detallePedidoMercBindingSource
            // 
            this.detallePedidoMercBindingSource.AllowNew = false;
            this.detallePedidoMercBindingSource.DataSource = typeof(SWYRA.DetallePedidoMerc);
            // 
            // gvPaquetes
            // 
            this.gvPaquetes.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coltipopaquete,
            this.colconsec_empaque,
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
            this.colconsec_empaque.VisibleIndex = 1;
            this.colconsec_empaque.Width = 30;
            // 
            // coltipopaquete
            // 
            this.coltipopaquete.Caption = "Paquete";
            this.coltipopaquete.FieldName = "tipopaquete";
            this.coltipopaquete.Name = "coltipopaquete";
            this.coltipopaquete.Visible = true;
            this.coltipopaquete.VisibleIndex = 0;
            this.coltipopaquete.Width = 100;
            // 
            // coltotart
            // 
            this.coltotart.Caption = "Artículos";
            this.coltotart.FieldName = "totart";
            this.coltotart.Name = "coltotart";
            this.coltotart.Visible = true;
            this.coltotart.VisibleIndex = 2;
            this.coltotart.Width = 50;
            // 
            // gcDetPedido
            // 
            this.gcDetPedido.DataSource = this.detallePedidosBindingSource;
            gridLevelNode2.RelationName = "Level1";
            this.gcDetPedido.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gcDetPedido.Location = new System.Drawing.Point(9, 238);
            this.gcDetPedido.MainView = this.gridView1;
            this.gcDetPedido.Name = "gcDetPedido";
            this.gcDetPedido.Size = new System.Drawing.Size(912, 385);
            this.gcDetPedido.TabIndex = 6;
            this.gcDetPedido.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // detallePedidosBindingSource
            // 
            this.detallePedidosBindingSource.AllowNew = false;
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
            this.colnum_par,
            this.colcve_art,
            this.coldescr,
            this.colcantsurtido,
            this.colprec,
            this.coltot_partida,
            this.coltdesc,
            this.colsubto,
            this.coltotimp4,
            this.colimporte,
            this.colempaque});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gcDetPedido;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowViewCaption = true;
            this.gridView1.ViewCaption = "Detalle del Pedido";
            // 
            // colnum_par
            // 
            this.colnum_par.Caption = "#";
            this.colnum_par.FieldName = "num_par";
            this.colnum_par.Name = "colnum_par";
            this.colnum_par.Visible = true;
            this.colnum_par.VisibleIndex = 0;
            this.colnum_par.Width = 30;
            // 
            // colcve_art
            // 
            this.colcve_art.Caption = "Clave";
            this.colcve_art.FieldName = "cve_art";
            this.colcve_art.Name = "colcve_art";
            this.colcve_art.Visible = true;
            this.colcve_art.VisibleIndex = 1;
            // 
            // coldescr
            // 
            this.coldescr.Caption = "Descripción";
            this.coldescr.FieldName = "descr";
            this.coldescr.Name = "coldescr";
            this.coldescr.Visible = true;
            this.coldescr.VisibleIndex = 2;
            this.coldescr.Width = 250;
            // 
            // colcantsurtido
            // 
            this.colcantsurtido.Caption = "Cant.";
            this.colcantsurtido.FieldName = "cantsurtido";
            this.colcantsurtido.Name = "colcantsurtido";
            this.colcantsurtido.Visible = true;
            this.colcantsurtido.VisibleIndex = 3;
            this.colcantsurtido.Width = 40;
            // 
            // colprec
            // 
            this.colprec.Caption = "Precio";
            this.colprec.DisplayFormat.FormatString = "$ #,##0.00";
            this.colprec.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colprec.FieldName = "prec";
            this.colprec.Name = "colprec";
            this.colprec.Visible = true;
            this.colprec.VisibleIndex = 4;
            this.colprec.Width = 80;
            // 
            // coltot_partida
            // 
            this.coltot_partida.Caption = "Costo";
            this.coltot_partida.DisplayFormat.FormatString = "$ #,##0.00";
            this.coltot_partida.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.coltot_partida.FieldName = "tot_partida";
            this.coltot_partida.Name = "coltot_partida";
            this.coltot_partida.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tot_partida", "$ {0:n2}")});
            this.coltot_partida.Visible = true;
            this.coltot_partida.VisibleIndex = 5;
            this.coltot_partida.Width = 80;
            // 
            // coltdesc
            // 
            this.coltdesc.Caption = "Descuento";
            this.coltdesc.DisplayFormat.FormatString = "$ #,##0.00";
            this.coltdesc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.coltdesc.FieldName = "tdesc";
            this.coltdesc.Name = "coltdesc";
            this.coltdesc.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tdesc", "$ {0:n2}")});
            this.coltdesc.Visible = true;
            this.coltdesc.VisibleIndex = 6;
            this.coltdesc.Width = 80;
            // 
            // colsubto
            // 
            this.colsubto.Caption = "Sub Total";
            this.colsubto.DisplayFormat.FormatString = "$ #,##0.00";
            this.colsubto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colsubto.FieldName = "subto";
            this.colsubto.Name = "colsubto";
            this.colsubto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "subto", "$ {0:n2}")});
            this.colsubto.Visible = true;
            this.colsubto.VisibleIndex = 7;
            this.colsubto.Width = 80;
            // 
            // coltotimp4
            // 
            this.coltotimp4.Caption = "IVA";
            this.coltotimp4.DisplayFormat.FormatString = "$ #,##0.00";
            this.coltotimp4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.coltotimp4.FieldName = "totimp4";
            this.coltotimp4.Name = "coltotimp4";
            this.coltotimp4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "totimp4", "$ {0:n2}")});
            this.coltotimp4.Visible = true;
            this.coltotimp4.VisibleIndex = 8;
            this.coltotimp4.Width = 80;
            // 
            // colimporte
            // 
            this.colimporte.Caption = "Importe";
            this.colimporte.DisplayFormat.FormatString = "$ #,##0.00";
            this.colimporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colimporte.FieldName = "importe";
            this.colimporte.Name = "colimporte";
            this.colimporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "importe", "$ {0:n2}")});
            this.colimporte.Visible = true;
            this.colimporte.VisibleIndex = 9;
            this.colimporte.Width = 80;
            // 
            // colempaque
            // 
            this.colempaque.Caption = "Empacado en";
            this.colempaque.FieldName = "empaque";
            this.colempaque.Name = "colempaque";
            this.colempaque.Visible = true;
            this.colempaque.VisibleIndex = 10;
            this.colempaque.Width = 200;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTarimas);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtAtados);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtCubeta);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtRollo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtBulto);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtCajaMadera);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCajaCarton);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtUbicacion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPrioridad);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOcurredom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTipoServicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.deFecha);
            this.groupBox1.Controls.Add(this.txtPedido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 200);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Pedido";
            // 
            // txtTarimas
            // 
            this.txtTarimas.BackColor = System.Drawing.Color.White;
            this.txtTarimas.Location = new System.Drawing.Point(571, 164);
            this.txtTarimas.Name = "txtTarimas";
            this.txtTarimas.ReadOnly = true;
            this.txtTarimas.Size = new System.Drawing.Size(86, 20);
            this.txtTarimas.TabIndex = 28;
            this.txtTarimas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(592, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Tarimas";
            // 
            // txtAtados
            // 
            this.txtAtados.BackColor = System.Drawing.Color.White;
            this.txtAtados.Location = new System.Drawing.Point(479, 164);
            this.txtAtados.Name = "txtAtados";
            this.txtAtados.ReadOnly = true;
            this.txtAtados.Size = new System.Drawing.Size(86, 20);
            this.txtAtados.TabIndex = 26;
            this.txtAtados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(502, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Atados";
            // 
            // txtCubeta
            // 
            this.txtCubeta.BackColor = System.Drawing.Color.White;
            this.txtCubeta.Location = new System.Drawing.Point(387, 164);
            this.txtCubeta.Name = "txtCubeta";
            this.txtCubeta.ReadOnly = true;
            this.txtCubeta.Size = new System.Drawing.Size(86, 20);
            this.txtCubeta.TabIndex = 24;
            this.txtCubeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(407, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Cubetas";
            // 
            // txtRollo
            // 
            this.txtRollo.BackColor = System.Drawing.Color.White;
            this.txtRollo.Location = new System.Drawing.Point(295, 164);
            this.txtRollo.Name = "txtRollo";
            this.txtRollo.ReadOnly = true;
            this.txtRollo.Size = new System.Drawing.Size(86, 20);
            this.txtRollo.TabIndex = 22;
            this.txtRollo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(320, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Rollos";
            // 
            // txtBulto
            // 
            this.txtBulto.BackColor = System.Drawing.Color.White;
            this.txtBulto.Location = new System.Drawing.Point(203, 164);
            this.txtBulto.Name = "txtBulto";
            this.txtBulto.ReadOnly = true;
            this.txtBulto.Size = new System.Drawing.Size(86, 20);
            this.txtBulto.TabIndex = 20;
            this.txtBulto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(228, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Bultos";
            // 
            // txtCajaMadera
            // 
            this.txtCajaMadera.BackColor = System.Drawing.Color.White;
            this.txtCajaMadera.Location = new System.Drawing.Point(111, 164);
            this.txtCajaMadera.Name = "txtCajaMadera";
            this.txtCajaMadera.ReadOnly = true;
            this.txtCajaMadera.Size = new System.Drawing.Size(86, 20);
            this.txtCajaMadera.TabIndex = 18;
            this.txtCajaMadera.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(113, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Caja de Madera";
            // 
            // txtCajaCarton
            // 
            this.txtCajaCarton.BackColor = System.Drawing.Color.White;
            this.txtCajaCarton.Location = new System.Drawing.Point(19, 164);
            this.txtCajaCarton.Name = "txtCajaCarton";
            this.txtCajaCarton.ReadOnly = true;
            this.txtCajaCarton.Size = new System.Drawing.Size(86, 20);
            this.txtCajaCarton.TabIndex = 16;
            this.txtCajaCarton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Caja de Cartón";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.BackColor = System.Drawing.Color.White;
            this.txtUbicacion.Location = new System.Drawing.Point(454, 103);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.ReadOnly = true;
            this.txtUbicacion.Size = new System.Drawing.Size(206, 20);
            this.txtUbicacion.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ubicación del Pedido";
            // 
            // txtPrioridad
            // 
            this.txtPrioridad.BackColor = System.Drawing.Color.White;
            this.txtPrioridad.Location = new System.Drawing.Point(101, 103);
            this.txtPrioridad.Name = "txtPrioridad";
            this.txtPrioridad.ReadOnly = true;
            this.txtPrioridad.Size = new System.Drawing.Size(206, 20);
            this.txtPrioridad.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Prioridad";
            // 
            // txtOcurredom
            // 
            this.txtOcurredom.BackColor = System.Drawing.Color.White;
            this.txtOcurredom.Location = new System.Drawing.Point(454, 77);
            this.txtOcurredom.Name = "txtOcurredom";
            this.txtOcurredom.ReadOnly = true;
            this.txtOcurredom.Size = new System.Drawing.Size(206, 20);
            this.txtOcurredom.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ocurre o Domicilio";
            // 
            // txtTipoServicio
            // 
            this.txtTipoServicio.BackColor = System.Drawing.Color.White;
            this.txtTipoServicio.Location = new System.Drawing.Point(101, 77);
            this.txtTipoServicio.Name = "txtTipoServicio";
            this.txtTipoServicio.ReadOnly = true;
            this.txtTipoServicio.Size = new System.Drawing.Size(206, 20);
            this.txtTipoServicio.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo Servicio";
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.White;
            this.txtCliente.Location = new System.Drawing.Point(101, 51);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(559, 20);
            this.txtCliente.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cliente";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(454, 26);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.deFecha.Properties.Appearance.Options.UseBackColor = true;
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.ReadOnly = true;
            this.deFecha.Size = new System.Drawing.Size(206, 20);
            this.deFecha.TabIndex = 4;
            // 
            // txtPedido
            // 
            this.txtPedido.BackColor = System.Drawing.Color.White;
            this.txtPedido.Location = new System.Drawing.Point(101, 26);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.ReadOnly = true;
            this.txtPedido.Size = new System.Drawing.Size(206, 20);
            this.txtPedido.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Elaboración.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pedido Num.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(930, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::SWYRA.Properties.Resources.accept_page;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 24);
            this.btnGuardar.Text = "Aceptar y Enviar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            // FrmAjustePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(931, 636);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAjustePedido";
            this.Text = "ENVIO A FACTURACIÓN";
            this.Load += new System.EventHandler(this.FrmAjustePedido_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPaquetes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidoMercBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPaquetes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detallePedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrioridad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOcurredom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTipoServicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTarimas;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAtados;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCubeta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRollo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBulto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCajaMadera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCajaCarton;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.GridControl gcDetPedido;
        private System.Windows.Forms.BindingSource detallePedidosBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colnum_par;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_art;
        private DevExpress.XtraGrid.Columns.GridColumn colprec;
        private DevExpress.XtraGrid.Columns.GridColumn coltotimp4;
        private DevExpress.XtraGrid.Columns.GridColumn coltot_partida;
        private DevExpress.XtraGrid.Columns.GridColumn colcantsurtido;
        private DevExpress.XtraGrid.Columns.GridColumn coldescr;
        private DevExpress.XtraGrid.Columns.GridColumn coltdesc;
        private DevExpress.XtraGrid.Columns.GridColumn colsubto;
        private DevExpress.XtraGrid.Columns.GridColumn colimporte;
        private DevExpress.XtraGrid.GridControl gcPaquetes;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPaquetes;
        private DevExpress.XtraGrid.Columns.GridColumn colconsec_empaque;
        private DevExpress.XtraGrid.Columns.GridColumn coltipopaquete;
        private DevExpress.XtraGrid.Columns.GridColumn coltotart;
        private System.Windows.Forms.BindingSource detallePedidoMercBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colempaque;
    }
}