namespace SWYRA
{
    partial class FrmEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpleados));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.GpoEmpleados = new System.Windows.Forms.GroupBox();
            this.cbArea = new DevExpress.XtraEditors.LookUpEdit();
            this.areasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLetra = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Chkact = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.Txtcpass = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Txtpass = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.perfilBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lstAlamcenAsignado = new System.Windows.Forms.ListBox();
            this.usuarioAlmacenBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lstAlmacen = new System.Windows.Forms.ListBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lbalmacen2 = new System.Windows.Forms.LinkLabel();
            this.lbalmacen = new System.Windows.Forms.LinkLabel();
            this.DelBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.LinkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gcUsuarios = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            this.GpoEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioAlmacenBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsuarios)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(506, 27);
            this.toolStrip1.TabIndex = 0;
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
            this.btnLimpiar.Text = "Nuevo";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
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
            // GpoEmpleados
            // 
            this.GpoEmpleados.Controls.Add(this.cbArea);
            this.GpoEmpleados.Controls.Add(this.label11);
            this.GpoEmpleados.Controls.Add(this.label10);
            this.GpoEmpleados.Controls.Add(this.txtLetra);
            this.GpoEmpleados.Controls.Add(this.label9);
            this.GpoEmpleados.Controls.Add(this.label8);
            this.GpoEmpleados.Controls.Add(this.Chkact);
            this.GpoEmpleados.Controls.Add(this.Label4);
            this.GpoEmpleados.Controls.Add(this.TxtCodigo);
            this.GpoEmpleados.Controls.Add(this.Txtcpass);
            this.GpoEmpleados.Controls.Add(this.Label1);
            this.GpoEmpleados.Controls.Add(this.Label5);
            this.GpoEmpleados.Controls.Add(this.Label2);
            this.GpoEmpleados.Controls.Add(this.Txtpass);
            this.GpoEmpleados.Controls.Add(this.TxtNombre);
            this.GpoEmpleados.Controls.Add(this.Label7);
            this.GpoEmpleados.Controls.Add(this.cbCategoria);
            this.GpoEmpleados.Location = new System.Drawing.Point(14, 25);
            this.GpoEmpleados.Name = "GpoEmpleados";
            this.GpoEmpleados.Size = new System.Drawing.Size(250, 200);
            this.GpoEmpleados.TabIndex = 13;
            this.GpoEmpleados.TabStop = false;
            // 
            // cbArea
            // 
            this.cbArea.Location = new System.Drawing.Point(129, 173);
            this.cbArea.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbArea.Name = "cbArea";
            this.cbArea.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArea.Properties.Appearance.Options.UseFont = true;
            this.cbArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbArea.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("almacen", "almacen", 66, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nombre", "nombre", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cbArea.Properties.DataSource = this.areasBindingSource;
            this.cbArea.Properties.DisplayMember = "nombre";
            this.cbArea.Properties.NullText = "";
            this.cbArea.Properties.ValueMember = "areaid";
            this.cbArea.Size = new System.Drawing.Size(106, 22);
            this.cbArea.TabIndex = 28;
            this.cbArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbArea_KeyUp);
            // 
            // areasBindingSource
            // 
            this.areasBindingSource.DataSource = typeof(SWYRA.Areas);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(92, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.TabIndex = 37;
            this.label11.Text = "Área";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(2, 176);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 36;
            this.label10.Text = "Letra ERP";
            // 
            // txtLetra
            // 
            this.txtLetra.Enabled = false;
            this.txtLetra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLetra.Location = new System.Drawing.Point(64, 173);
            this.txtLetra.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLetra.MaxLength = 1;
            this.txtLetra.Name = "txtLetra";
            this.txtLetra.Size = new System.Drawing.Size(18, 21);
            this.txtLetra.TabIndex = 35;
            this.txtLetra.TextChanged += new System.EventHandler(this.txtLetra_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(62, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "Módulo";
            // 
            // Chkact
            // 
            this.Chkact.AutoSize = true;
            this.Chkact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkact.Location = new System.Drawing.Point(184, 146);
            this.Chkact.Name = "Chkact";
            this.Chkact.Size = new System.Drawing.Size(57, 19);
            this.Chkact.TabIndex = 9;
            this.Chkact.Text = "Activo";
            this.Chkact.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(2, 97);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(101, 15);
            this.Label4.TabIndex = 32;
            this.Label4.Text = "Conf. Contraseña";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigo.Location = new System.Drawing.Point(104, 19);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(133, 21);
            this.TxtCodigo.TabIndex = 4;
            // 
            // Txtcpass
            // 
            this.Txtcpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtcpass.Location = new System.Drawing.Point(104, 94);
            this.Txtcpass.Name = "Txtcpass";
            this.Txtcpass.PasswordChar = '*';
            this.Txtcpass.Size = new System.Drawing.Size(133, 21);
            this.Txtcpass.TabIndex = 7;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(54, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 15);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "Codigo";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(32, 72);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(70, 15);
            this.Label5.TabIndex = 30;
            this.Label5.Text = "Contraseña";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(50, 46);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 15);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Nombre";
            // 
            // Txtpass
            // 
            this.Txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtpass.Location = new System.Drawing.Point(104, 69);
            this.Txtpass.Name = "Txtpass";
            this.Txtpass.PasswordChar = '*';
            this.Txtpass.Size = new System.Drawing.Size(133, 21);
            this.Txtpass.TabIndex = 6;
            // 
            // TxtNombre
            // 
            this.TxtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TxtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre.Location = new System.Drawing.Point(104, 44);
            this.TxtNombre.MaxLength = 50;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(133, 21);
            this.TxtNombre.TabIndex = 5;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(65, 122);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(35, 15);
            this.Label7.TabIndex = 28;
            this.Label7.Text = "Perfil";
            // 
            // cbCategoria
            // 
            this.cbCategoria.DataSource = this.perfilBindingSource;
            this.cbCategoria.DisplayMember = "descripcion";
            this.cbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(104, 119);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(133, 23);
            this.cbCategoria.TabIndex = 8;
            this.cbCategoria.ValueMember = "descripcion";
            this.cbCategoria.SelectedValueChanged += new System.EventHandler(this.cbCategoria_SelectedValueChanged);
            // 
            // perfilBindingSource
            // 
            this.perfilBindingSource.DataSource = typeof(SWYRA.Perfil);
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataSource = typeof(SWYRA.Usuarios);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.lstAlamcenAsignado);
            this.GroupBox1.Controls.Add(this.lstAlmacen);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.lbalmacen2);
            this.GroupBox1.Controls.Add(this.lbalmacen);
            this.GroupBox1.Controls.Add(this.DelBtn);
            this.GroupBox1.Controls.Add(this.AddBtn);
            this.GroupBox1.Controls.Add(this.LinkLabel1);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.Location = new System.Drawing.Point(14, 232);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(482, 224);
            this.GroupBox1.TabIndex = 27;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Datos de Almacen";
            // 
            // lstAlamcenAsignado
            // 
            this.lstAlamcenAsignado.DataSource = this.usuarioAlmacenBindingSource;
            this.lstAlamcenAsignado.DisplayMember = "nombre";
            this.lstAlamcenAsignado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAlamcenAsignado.FormattingEnabled = true;
            this.lstAlamcenAsignado.ItemHeight = 15;
            this.lstAlamcenAsignado.Location = new System.Drawing.Point(283, 63);
            this.lstAlamcenAsignado.Name = "lstAlamcenAsignado";
            this.lstAlamcenAsignado.ScrollAlwaysVisible = true;
            this.lstAlamcenAsignado.Size = new System.Drawing.Size(147, 139);
            this.lstAlamcenAsignado.TabIndex = 13;
            this.lstAlamcenAsignado.ValueMember = "nombre";
            // 
            // usuarioAlmacenBindingSource
            // 
            this.usuarioAlmacenBindingSource.DataSource = typeof(SWYRA.UsuarioAlmacen);
            // 
            // lstAlmacen
            // 
            this.lstAlmacen.DataSource = this.usuarioAlmacenBindingSource;
            this.lstAlmacen.DisplayMember = "nombre";
            this.lstAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAlmacen.FormattingEnabled = true;
            this.lstAlmacen.ItemHeight = 15;
            this.lstAlmacen.Location = new System.Drawing.Point(49, 63);
            this.lstAlmacen.Name = "lstAlmacen";
            this.lstAlmacen.ScrollAlwaysVisible = true;
            this.lstAlmacen.Size = new System.Drawing.Size(147, 139);
            this.lstAlmacen.TabIndex = 10;
            this.lstAlmacen.ValueMember = "nombre";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(283, 36);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(157, 13);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "ALMACENES ASIGNADOS";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(89, 36);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(81, 13);
            this.Label6.TabIndex = 33;
            this.Label6.Text = "ALMACENES";
            // 
            // lbalmacen2
            // 
            this.lbalmacen2.AutoSize = true;
            this.lbalmacen2.Location = new System.Drawing.Point(219, 195);
            this.lbalmacen2.Name = "lbalmacen2";
            this.lbalmacen2.Size = new System.Drawing.Size(10, 13);
            this.lbalmacen2.TabIndex = 32;
            this.lbalmacen2.TabStop = true;
            this.lbalmacen2.Text = ".";
            // 
            // lbalmacen
            // 
            this.lbalmacen.AutoSize = true;
            this.lbalmacen.Location = new System.Drawing.Point(236, 54);
            this.lbalmacen.Name = "lbalmacen";
            this.lbalmacen.Size = new System.Drawing.Size(10, 13);
            this.lbalmacen.TabIndex = 31;
            this.lbalmacen.TabStop = true;
            this.lbalmacen.Text = ".";
            // 
            // DelBtn
            // 
            this.DelBtn.Image = global::SWYRA.Properties.Resources.back;
            this.DelBtn.Location = new System.Drawing.Point(218, 146);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(44, 42);
            this.DelBtn.TabIndex = 12;
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Image = global::SWYRA.Properties.Resources.next;
            this.AddBtn.Location = new System.Drawing.Point(218, 83);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(44, 42);
            this.AddBtn.TabIndex = 11;
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // LinkLabel1
            // 
            this.LinkLabel1.AutoSize = true;
            this.LinkLabel1.Location = new System.Drawing.Point(236, 195);
            this.LinkLabel1.Name = "LinkLabel1";
            this.LinkLabel1.Size = new System.Drawing.Size(10, 13);
            this.LinkLabel1.TabIndex = 25;
            this.LinkLabel1.TabStop = true;
            this.LinkLabel1.Text = ".";
            this.LinkLabel1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GroupBox1);
            this.panel1.Controls.Add(this.gcUsuarios);
            this.panel1.Controls.Add(this.GpoEmpleados);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 467);
            this.panel1.TabIndex = 35;
            // 
            // gcUsuarios
            // 
            this.gcUsuarios.DataSource = this.usuariosBindingSource;
            this.gcUsuarios.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcUsuarios.Location = new System.Drawing.Point(267, 25);
            this.gcUsuarios.MainView = this.gridView1;
            this.gcUsuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcUsuarios.Name = "gcUsuarios";
            this.gcUsuarios.Size = new System.Drawing.Size(230, 200);
            this.gcUsuarios.TabIndex = 46;
            this.gcUsuarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUsuario,
            this.colNombre,
            this.colCategoria,
            this.colActivo});
            this.gridView1.GridControl = this.gcUsuarios;
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
            // colUsuario
            // 
            this.colUsuario.Caption = "Id";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 0;
            this.colUsuario.Width = 40;
            // 
            // colNombre
            // 
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 1;
            this.colNombre.Width = 150;
            // 
            // colCategoria
            // 
            this.colCategoria.FieldName = "Categoria";
            this.colCategoria.Name = "colCategoria";
            this.colCategoria.Visible = true;
            this.colCategoria.VisibleIndex = 2;
            this.colCategoria.Width = 90;
            // 
            // colActivo
            // 
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 3;
            this.colActivo.Width = 40;
            // 
            // FrmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(506, 467);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "USUARIOS";
            this.Load += new System.EventHandler(this.FrmEmpleados_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GpoEmpleados.ResumeLayout(false);
            this.GpoEmpleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfilBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioAlmacenBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.GroupBox GpoEmpleados;
        internal System.Windows.Forms.CheckBox Chkact;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox TxtCodigo;
        internal System.Windows.Forms.TextBox Txtcpass;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox Txtpass;
        internal System.Windows.Forms.TextBox TxtNombre;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.ComboBox cbCategoria;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.LinkLabel lbalmacen2;
        internal System.Windows.Forms.LinkLabel lbalmacen;
        internal System.Windows.Forms.Button DelBtn;
        internal System.Windows.Forms.Button AddBtn;
        internal System.Windows.Forms.LinkLabel LinkLabel1;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private System.Windows.Forms.BindingSource perfilBindingSource;
        private System.Windows.Forms.BindingSource usuarioAlmacenBindingSource;
        internal System.Windows.Forms.ListBox lstAlamcenAsignado;
        internal System.Windows.Forms.ListBox lstAlmacen;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLetra;
        internal System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.LookUpEdit cbArea;
        private System.Windows.Forms.BindingSource areasBindingSource;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gcUsuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
    }
}