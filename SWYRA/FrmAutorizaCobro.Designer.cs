namespace SWYRA
{
    partial class FrmAutorizaCobro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutorizaCobro));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFactura = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.gpoFiltro = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tsTodos = new DevExpress.XtraEditors.ToggleSwitch();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.pedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colfecha_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcobrador_asignado_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_clpv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPorcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colimporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcondicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colobservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcontado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.ppIndicaciones = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.BtnAceptarIN = new System.Windows.Forms.Button();
            this.txtIndicaciones = new DevExpress.XtraEditors.MemoEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.gpoFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsTodos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(798, 27);
            this.toolStrip1.TabIndex = 41;
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
            // gpoFiltro
            // 
            this.gpoFiltro.Controls.Add(this.Label1);
            this.gpoFiltro.Controls.Add(this.tsTodos);
            this.gpoFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpoFiltro.Location = new System.Drawing.Point(0, 27);
            this.gpoFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.gpoFiltro.Name = "gpoFiltro";
            this.gpoFiltro.Padding = new System.Windows.Forms.Padding(2);
            this.gpoFiltro.Size = new System.Drawing.Size(798, 53);
            this.gpoFiltro.TabIndex = 42;
            this.gpoFiltro.TabStop = false;
            this.gpoFiltro.Text = " Filtrar Usuario ";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(34, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(94, 15);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "VER USUARIO :";
            // 
            // tsTodos
            // 
            this.tsTodos.Location = new System.Drawing.Point(128, 21);
            this.tsTodos.Margin = new System.Windows.Forms.Padding(2);
            this.tsTodos.Name = "tsTodos";
            this.tsTodos.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsTodos.Properties.Appearance.Options.UseFont = true;
            this.tsTodos.Properties.OffText = "ACTUAL";
            this.tsTodos.Properties.OnText = "TODOS";
            this.tsTodos.Size = new System.Drawing.Size(128, 24);
            this.tsTodos.TabIndex = 0;
            this.tsTodos.Toggled += new System.EventHandler(this.tsTodos_Toggled);
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
            this.gridControl1.TabIndex = 43;
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
            this.colfecha_doc,
            this.colcobrador_asignado_n,
            this.colcve_doc,
            this.colcve_clpv,
            this.colcliente,
            this.colPorcDesc,
            this.colimporte,
            this.colcondicion,
            this.colobservaciones,
            this.colcontado});
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
            // colfecha_doc
            // 
            this.colfecha_doc.Caption = "Fecha";
            this.colfecha_doc.DisplayFormat.FormatString = "d";
            this.colfecha_doc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colfecha_doc.FieldName = "fecha_doc";
            this.colfecha_doc.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colfecha_doc.Name = "colfecha_doc";
            this.colfecha_doc.Visible = true;
            this.colfecha_doc.VisibleIndex = 0;
            // 
            // colcobrador_asignado_n
            // 
            this.colcobrador_asignado_n.Caption = "Cobrador Asignado";
            this.colcobrador_asignado_n.FieldName = "cobrador_asignado_n";
            this.colcobrador_asignado_n.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcobrador_asignado_n.Name = "colcobrador_asignado_n";
            this.colcobrador_asignado_n.Visible = true;
            this.colcobrador_asignado_n.VisibleIndex = 1;
            this.colcobrador_asignado_n.Width = 150;
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
            this.colcve_doc.VisibleIndex = 2;
            this.colcve_doc.Width = 150;
            // 
            // colcve_clpv
            // 
            this.colcve_clpv.Caption = "# Cliente";
            this.colcve_clpv.FieldName = "cve_clpv";
            this.colcve_clpv.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcve_clpv.Name = "colcve_clpv";
            this.colcve_clpv.Visible = true;
            this.colcve_clpv.VisibleIndex = 3;
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
            this.colcliente.VisibleIndex = 4;
            this.colcliente.Width = 205;
            // 
            // colPorcDesc
            // 
            this.colPorcDesc.Caption = "Porc. Desc.";
            this.colPorcDesc.FieldName = "des_tot_porc";
            this.colPorcDesc.Name = "colPorcDesc";
            this.colPorcDesc.Visible = true;
            this.colPorcDesc.VisibleIndex = 5;
            // 
            // colimporte
            // 
            this.colimporte.Caption = "Importe";
            this.colimporte.DisplayFormat.FormatString = "$#,##0.00 MXN";
            this.colimporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colimporte.FieldName = "importe";
            this.colimporte.Name = "colimporte";
            this.colimporte.Visible = true;
            this.colimporte.VisibleIndex = 6;
            this.colimporte.Width = 160;
            // 
            // colcondicion
            // 
            this.colcondicion.Caption = "Condición";
            this.colcondicion.FieldName = "condicion";
            this.colcondicion.Name = "colcondicion";
            this.colcondicion.Visible = true;
            this.colcondicion.VisibleIndex = 7;
            this.colcondicion.Width = 205;
            // 
            // colobservaciones
            // 
            this.colobservaciones.Caption = "Observaciones";
            this.colobservaciones.FieldName = "observaciones";
            this.colobservaciones.Name = "colobservaciones";
            this.colobservaciones.Visible = true;
            this.colobservaciones.VisibleIndex = 8;
            this.colobservaciones.Width = 150;
            // 
            // colcontado
            // 
            this.colcontado.Caption = "Contado";
            this.colcontado.FieldName = "contado";
            this.colcontado.Name = "colcontado";
            this.colcontado.Visible = true;
            this.colcontado.VisibleIndex = 9;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.ShowNavigationHeader = DevExpress.Utils.DefaultBoolean.False;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "AUTORIZADO";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "AUTORIZADO DE CONTADO";
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "CANCELADO";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barLargeButtonItem1,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MaxItemId = 4;
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
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Id = 0;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            // 
            // ppIndicaciones
            // 
            this.ppIndicaciones.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ppIndicaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppIndicaciones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ppIndicaciones.Controls.Add(this.BtnAceptarIN);
            this.ppIndicaciones.Controls.Add(this.txtIndicaciones);
            this.ppIndicaciones.Controls.Add(this.label7);
            this.ppIndicaciones.Location = new System.Drawing.Point(284, 129);
            this.ppIndicaciones.Manager = this.barManager1;
            this.ppIndicaciones.Margin = new System.Windows.Forms.Padding(2);
            this.ppIndicaciones.Name = "ppIndicaciones";
            this.ppIndicaciones.Size = new System.Drawing.Size(268, 132);
            this.ppIndicaciones.TabIndex = 63;
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
            this.label7.Size = new System.Drawing.Size(162, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Indicaciones de cancelación";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 380);
            this.panel1.TabIndex = 68;
            // 
            // FrmAutorizaCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(798, 383);
            this.Controls.Add(this.ppIndicaciones);
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
            this.Name = "FrmAutorizaCobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AUTORIZACIÓN DE PEDIDOS";
            this.Load += new System.EventHandler(this.FrmAutorizaCobro_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gpoFiltro.ResumeLayout(false);
            this.gpoFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tsTodos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
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
        private DevExpress.XtraEditors.ToggleSwitch tsTodos;
        internal System.Windows.Forms.Label Label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcobrador_asignado_n;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_doc;
        private DevExpress.XtraGrid.Columns.GridColumn colcliente;
        private DevExpress.XtraGrid.Columns.GridColumn colcondicion;
        private DevExpress.XtraGrid.Columns.GridColumn colobservaciones;
        private System.Windows.Forms.BindingSource pedidosBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colimporte;
        private DevExpress.XtraGrid.Columns.GridColumn colcontado;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupControlContainer ppIndicaciones;
        internal System.Windows.Forms.Button BtnAceptarIN;
        private DevExpress.XtraEditors.MemoEdit txtIndicaciones;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha_doc;
        private System.Windows.Forms.ToolStripButton btnFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_clpv;
        private DevExpress.XtraGrid.Columns.GridColumn colPorcDesc;
    }
}