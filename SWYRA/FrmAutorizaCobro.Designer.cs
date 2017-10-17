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
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.gpoFiltro = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tsTodos = new DevExpress.XtraEditors.ToggleSwitch();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.pedidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colcobrador_asignado_n = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcve_doc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colimporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfechaaut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfecha_cancela = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcondicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colindicaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcontado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barLargeButtonItem1 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.ppIndicaciones = new DevExpress.XtraBars.PopupControlContainer(this.components);
            this.BtnAceptarIN = new System.Windows.Forms.Button();
            this.txtIndicaciones = new DevExpress.XtraEditors.MemoEdit();
            this.label7 = new System.Windows.Forms.Label();
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
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 27);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::SWYRA.Properties.Resources.Logout_32x32;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(60, 24);
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gpoFiltro
            // 
            this.gpoFiltro.Controls.Add(this.Label1);
            this.gpoFiltro.Controls.Add(this.tsTodos);
            this.gpoFiltro.Location = new System.Drawing.Point(12, 30);
            this.gpoFiltro.Name = "gpoFiltro";
            this.gpoFiltro.Size = new System.Drawing.Size(1040, 65);
            this.gpoFiltro.TabIndex = 42;
            this.gpoFiltro.TabStop = false;
            this.gpoFiltro.Text = " Filtrar Usuario ";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(46, 30);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(117, 18);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "VER USUARIO :";
            // 
            // tsTodos
            // 
            this.tsTodos.Location = new System.Drawing.Point(170, 26);
            this.tsTodos.Name = "tsTodos";
            this.tsTodos.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsTodos.Properties.Appearance.Options.UseFont = true;
            this.tsTodos.Properties.OffText = "ACTUAL";
            this.tsTodos.Properties.OnText = "TODOS";
            this.tsTodos.Size = new System.Drawing.Size(170, 27);
            this.tsTodos.TabIndex = 0;
            this.tsTodos.Toggled += new System.EventHandler(this.tsTodos_Toggled);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.pedidosBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 113);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1040, 346);
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
            this.colcobrador_asignado_n,
            this.colcve_doc,
            this.colcliente,
            this.colimporte,
            this.colfechaaut,
            this.colfecha_cancela,
            this.colcondicion,
            this.colindicaciones,
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
            // colcobrador_asignado_n
            // 
            this.colcobrador_asignado_n.Caption = "Cobrador Asignado";
            this.colcobrador_asignado_n.FieldName = "cobrador_asignado_n";
            this.colcobrador_asignado_n.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colcobrador_asignado_n.Name = "colcobrador_asignado_n";
            this.colcobrador_asignado_n.Visible = true;
            this.colcobrador_asignado_n.VisibleIndex = 0;
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
            this.colcve_doc.VisibleIndex = 1;
            this.colcve_doc.Width = 90;
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
            // colimporte
            // 
            this.colimporte.Caption = "Importe";
            this.colimporte.DisplayFormat.FormatString = "$#,##0.00 MXN";
            this.colimporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colimporte.FieldName = "importe";
            this.colimporte.Name = "colimporte";
            this.colimporte.Visible = true;
            this.colimporte.VisibleIndex = 3;
            this.colimporte.Width = 160;
            // 
            // colfechaaut
            // 
            this.colfechaaut.Caption = "Fecha Autorización";
            this.colfechaaut.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colfechaaut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colfechaaut.FieldName = "fechaaut";
            this.colfechaaut.Name = "colfechaaut";
            this.colfechaaut.Visible = true;
            this.colfechaaut.VisibleIndex = 4;
            this.colfechaaut.Width = 110;
            // 
            // colfecha_cancela
            // 
            this.colfecha_cancela.Caption = "Fecha Cancelado";
            this.colfecha_cancela.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.colfecha_cancela.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colfecha_cancela.FieldName = "fecha_cancela";
            this.colfecha_cancela.Name = "colfecha_cancela";
            this.colfecha_cancela.Visible = true;
            this.colfecha_cancela.VisibleIndex = 5;
            this.colfecha_cancela.Width = 110;
            // 
            // colcondicion
            // 
            this.colcondicion.Caption = "Condición";
            this.colcondicion.FieldName = "condicion";
            this.colcondicion.Name = "colcondicion";
            this.colcondicion.Visible = true;
            this.colcondicion.VisibleIndex = 6;
            this.colcondicion.Width = 205;
            // 
            // colindicaciones
            // 
            this.colindicaciones.Caption = "Indicaciones";
            this.colindicaciones.FieldName = "indicaciones";
            this.colindicaciones.Name = "colindicaciones";
            this.colindicaciones.Visible = true;
            this.colindicaciones.VisibleIndex = 7;
            this.colindicaciones.Width = 150;
            // 
            // colcontado
            // 
            this.colcontado.Caption = "Contado";
            this.colcontado.FieldName = "contado";
            this.colcontado.Name = "colcontado";
            this.colcontado.Visible = true;
            this.colcontado.VisibleIndex = 8;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1064, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 471);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1064, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 471);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1064, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 471);
            // 
            // barLargeButtonItem1
            // 
            this.barLargeButtonItem1.Id = 0;
            this.barLargeButtonItem1.Name = "barLargeButtonItem1";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "CANCELADO";
            this.barButtonItem3.Id = 3;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // ppIndicaciones
            // 
            this.ppIndicaciones.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.ppIndicaciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ppIndicaciones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.ppIndicaciones.Controls.Add(this.BtnAceptarIN);
            this.ppIndicaciones.Controls.Add(this.txtIndicaciones);
            this.ppIndicaciones.Controls.Add(this.label7);
            this.ppIndicaciones.Location = new System.Drawing.Point(200, 149);
            this.ppIndicaciones.Manager = this.barManager1;
            this.ppIndicaciones.Name = "ppIndicaciones";
            this.ppIndicaciones.Size = new System.Drawing.Size(357, 163);
            this.ppIndicaciones.TabIndex = 63;
            this.ppIndicaciones.Visible = false;
            // 
            // BtnAceptarIN
            // 
            this.BtnAceptarIN.BackColor = System.Drawing.Color.Firebrick;
            this.BtnAceptarIN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnAceptarIN.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptarIN.ForeColor = System.Drawing.Color.White;
            this.BtnAceptarIN.Location = new System.Drawing.Point(209, 107);
            this.BtnAceptarIN.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAceptarIN.Name = "BtnAceptarIN";
            this.BtnAceptarIN.Size = new System.Drawing.Size(131, 46);
            this.BtnAceptarIN.TabIndex = 20;
            this.BtnAceptarIN.Text = "ACEPTAR";
            this.BtnAceptarIN.UseVisualStyleBackColor = false;
            this.BtnAceptarIN.Click += new System.EventHandler(this.BtnAceptarIN_Click);
            // 
            // txtIndicaciones
            // 
            this.txtIndicaciones.Location = new System.Drawing.Point(17, 35);
            this.txtIndicaciones.MenuManager = this.barManager1;
            this.txtIndicaciones.Name = "txtIndicaciones";
            this.txtIndicaciones.Size = new System.Drawing.Size(324, 65);
            this.txtIndicaciones.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 18);
            this.label7.TabIndex = 18;
            this.label7.Text = "Indicaciones de cancelación";
            // 
            // FrmAutorizaCobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 471);
            this.Controls.Add(this.ppIndicaciones);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.gpoFiltro);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private DevExpress.XtraGrid.Columns.GridColumn colfecha_cancela;
        private DevExpress.XtraGrid.Columns.GridColumn colcondicion;
        private DevExpress.XtraGrid.Columns.GridColumn colindicaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colfechaaut;
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
    }
}