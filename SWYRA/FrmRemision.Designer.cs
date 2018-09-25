namespace SWYRA
{
    partial class FrmRemision
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
            DevExpress.XtraGrid.Columns.GridColumn coltotcajacarton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRemision));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFactura = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.pedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcve_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_clpv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltiposervicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colocurredomicilio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotcajamadera = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotbultos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotrollos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotcubetas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotatados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltottarimas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotcostoguias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstatusPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFlete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bbPaqueteria = new DevExpress.XtraBars.BarButtonItem();
            this.bbFacturacion = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bbLevGuia = new DevExpress.XtraBars.BarButtonItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ppFlete = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.txtFlete = new DevExpress.XtraEditors.TextEdit();
            this.BtnAceptarTS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            coltotcajacarton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppFlete)).BeginInit();
            this.ppFlete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlete.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // coltotcajacarton
            // 
            coltotcajacarton.Caption = "Caja Carton";
            coltotcajacarton.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            coltotcajacarton.FieldName = "totcajacarton";
            coltotcajacarton.Name = "coltotcajacarton";
            coltotcajacarton.Visible = true;
            coltotcajacarton.VisibleIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFactura,
            this.btnSalir,
            this.toolStripButton1});
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
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(83, 24);
            this.toolStripButton1.Text = "Actualizar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // pedidosBindingSource
            // 
            this.pedidosBindingSource.DataSource = typeof(SWYRA.Pedidos);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.pedidosBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 27);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(798, 356);
            this.gridControl1.TabIndex = 43;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridControl1_MouseDown);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colcve_doc,
            this.colcve_clpv,
            this.colcliente,
            this.coltiposervicio,
            this.colocurredomicilio,
            this.colfecha_doc,
            coltotcajacarton,
            this.coltotcajamadera,
            this.coltotbultos,
            this.coltotrollos,
            this.coltotcubetas,
            this.coltotatados,
            this.coltottarimas,
            this.coltotcostoguias,
            this.colEstatusPedido,
            this.colFlete});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
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
            this.colcve_doc.Width = 100;
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
            // colocurredomicilio
            // 
            this.colocurredomicilio.Caption = "Ocurre a Domicilio";
            this.colocurredomicilio.FieldName = "ocurredomicilio";
            this.colocurredomicilio.Name = "colocurredomicilio";
            this.colocurredomicilio.Visible = true;
            this.colocurredomicilio.VisibleIndex = 4;
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
            this.colfecha_doc.VisibleIndex = 5;
            this.colfecha_doc.Width = 90;
            // 
            // coltotcajamadera
            // 
            this.coltotcajamadera.Caption = "Caja Madera";
            this.coltotcajamadera.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltotcajamadera.FieldName = "totcajamadera";
            this.coltotcajamadera.Name = "coltotcajamadera";
            this.coltotcajamadera.Visible = true;
            this.coltotcajamadera.VisibleIndex = 7;
            // 
            // coltotbultos
            // 
            this.coltotbultos.Caption = "Bultos";
            this.coltotbultos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltotbultos.FieldName = "totbultos";
            this.coltotbultos.Name = "coltotbultos";
            this.coltotbultos.Visible = true;
            this.coltotbultos.VisibleIndex = 8;
            // 
            // coltotrollos
            // 
            this.coltotrollos.Caption = "Rollos";
            this.coltotrollos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltotrollos.FieldName = "totrollos";
            this.coltotrollos.Name = "coltotrollos";
            this.coltotrollos.Visible = true;
            this.coltotrollos.VisibleIndex = 9;
            // 
            // coltotcubetas
            // 
            this.coltotcubetas.Caption = "Cubetas";
            this.coltotcubetas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltotcubetas.FieldName = "totcubetas";
            this.coltotcubetas.Name = "coltotcubetas";
            this.coltotcubetas.Visible = true;
            this.coltotcubetas.VisibleIndex = 10;
            // 
            // coltotatados
            // 
            this.coltotatados.Caption = "Atados";
            this.coltotatados.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltotatados.FieldName = "totatados";
            this.coltotatados.Name = "coltotatados";
            this.coltotatados.Visible = true;
            this.coltotatados.VisibleIndex = 11;
            // 
            // coltottarimas
            // 
            this.coltottarimas.Caption = "Tarimas";
            this.coltottarimas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.coltottarimas.FieldName = "tottarimas";
            this.coltottarimas.Name = "coltottarimas";
            this.coltottarimas.Visible = true;
            this.coltottarimas.VisibleIndex = 12;
            // 
            // coltotcostoguias
            // 
            this.coltotcostoguias.Caption = "Costo x guias";
            this.coltotcostoguias.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.coltotcostoguias.Name = "coltotcostoguias";
            this.coltotcostoguias.Visible = true;
            this.coltotcostoguias.VisibleIndex = 13;
            // 
            // colEstatusPedido
            // 
            this.colEstatusPedido.Caption = "ESTATUS";
            this.colEstatusPedido.FieldName = "estatuspedido";
            this.colEstatusPedido.Name = "colEstatusPedido";
            this.colEstatusPedido.Visible = true;
            this.colEstatusPedido.VisibleIndex = 14;
            // 
            // colFlete
            // 
            this.colFlete.Caption = "FLETE";
            this.colFlete.FieldName = "flete";
            this.colFlete.Name = "colFlete";
            this.colFlete.Visible = true;
            this.colFlete.VisibleIndex = 15;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPaqueteria),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbFacturacion),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // bbPaqueteria
            // 
            this.bbPaqueteria.Caption = "Asigna Empresa de Paquetería";
            this.bbPaqueteria.Id = 0;
            this.bbPaqueteria.Name = "bbPaqueteria";
            this.bbPaqueteria.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPaqueteria_ItemClick);
            // 
            // bbFacturacion
            // 
            this.bbFacturacion.Caption = "Enviar a Facturación";
            this.bbFacturacion.Id = 2;
            this.bbFacturacion.Name = "bbFacturacion";
            this.bbFacturacion.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbFacturacion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbFacturacion_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Imprimir Etiquetas";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbPaqueteria,
            this.bbLevGuia,
            this.bbFacturacion,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(798, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 383);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(798, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 383);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(798, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 383);
            // 
            // bbLevGuia
            // 
            this.bbLevGuia.Caption = "Levantamiento de Guía";
            this.bbLevGuia.Id = 1;
            this.bbLevGuia.Name = "bbLevGuia";
            // 
            // timer1
            // 
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ppFlete
            // 
            this.ppFlete.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ppFlete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppFlete.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ppFlete.Controls.Add(this.txtFlete);
            this.ppFlete.Controls.Add(this.BtnAceptarTS);
            this.ppFlete.Controls.Add(this.label4);
            this.ppFlete.Location = new System.Drawing.Point(265, 146);
            this.ppFlete.Manager = this.barManager1;
            this.ppFlete.Margin = new System.Windows.Forms.Padding(2);
            this.ppFlete.Name = "ppFlete";
            this.ppFlete.Size = new System.Drawing.Size(268, 90);
            this.ppFlete.TabIndex = 48;
            this.ppFlete.Visible = false;
            // 
            // txtFlete
            // 
            this.txtFlete.Location = new System.Drawing.Point(53, 18);
            this.txtFlete.MenuManager = this.barManager1;
            this.txtFlete.Name = "txtFlete";
            this.txtFlete.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFlete.Properties.MaxLength = 50;
            this.txtFlete.Size = new System.Drawing.Size(202, 18);
            this.txtFlete.TabIndex = 14;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "FLETE";
            // 
            // FrmRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(798, 383);
            this.Controls.Add(this.ppFlete);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmRemision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GENERACION DE RESUMEN";
            this.Load += new System.EventHandler(this.FrmRemision_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pedidosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ppFlete)).EndInit();
            this.ppFlete.ResumeLayout(false);
            this.ppFlete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFlete.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.BindingSource pedidosBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_doc;
        private DevExpress.XtraGrid.Columns.GridColumn colcliente;
        private DevExpress.XtraGrid.Columns.GridColumn coltiposervicio;
        private DevExpress.XtraGrid.Columns.GridColumn colocurredomicilio;
        private DevExpress.XtraGrid.Columns.GridColumn colfecha_doc;
        private DevExpress.XtraGrid.Columns.GridColumn coltotcajamadera;
        private DevExpress.XtraGrid.Columns.GridColumn coltotbultos;
        private DevExpress.XtraGrid.Columns.GridColumn coltotrollos;
        private DevExpress.XtraGrid.Columns.GridColumn coltotcubetas;
        private DevExpress.XtraGrid.Columns.GridColumn coltotatados;
        private DevExpress.XtraGrid.Columns.GridColumn coltottarimas;
        private DevExpress.XtraGrid.Columns.GridColumn coltotcostoguias;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbPaqueteria;
        private DevExpress.XtraBars.BarButtonItem bbFacturacion;
        private DevExpress.XtraBars.BarButtonItem bbLevGuia;
        private System.Windows.Forms.ToolStripButton btnFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colcve_clpv;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGrid.Columns.GridColumn colEstatusPedido;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colFlete;
        private DevExpress.XtraBars.PopupControlContainer ppFlete;
        private DevExpress.XtraEditors.TextEdit txtFlete;
        internal System.Windows.Forms.Button BtnAceptarTS;
        internal System.Windows.Forms.Label label4;
    }
}