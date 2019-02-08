namespace CapaVista
{
    partial class FrmCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.comboBoxBuscar = new System.Windows.Forms.ComboBox();
            this.dataGridViewListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.textBoxNumDoc = new System.Windows.Forms.TextBox();
            this.labelTipoDoc = new System.Windows.Forms.Label();
            this.labelApellidos = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxIdCliente = new System.Windows.Forms.TextBox();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.checkBoxEliminar = new System.Windows.Forms.CheckBox();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.textBoxBuscar = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.labelClientes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProviderIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxApellidos = new System.Windows.Forms.TextBox();
            this.labelSexo = new System.Windows.Forms.Label();
            this.comboBoxSexo = new System.Windows.Forms.ComboBox();
            this.labelFechaN = new System.Windows.Forms.Label();
            this.dateTimePickerFechaN = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEmail.Location = new System.Drawing.Point(378, 243);
            this.textBoxEmail.MaxLength = 50;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(189, 20);
            this.textBoxEmail.TabIndex = 20;
            // 
            // comboBoxBuscar
            // 
            this.comboBoxBuscar.FormattingEnabled = true;
            this.comboBoxBuscar.Items.AddRange(new object[] {
            "Documento",
            "Apellidos"});
            this.comboBoxBuscar.Location = new System.Drawing.Point(16, 32);
            this.comboBoxBuscar.Name = "comboBoxBuscar";
            this.comboBoxBuscar.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBuscar.TabIndex = 8;
            this.comboBoxBuscar.Text = "Documento";
            // 
            // dataGridViewListado
            // 
            this.dataGridViewListado.AllowUserToAddRows = false;
            this.dataGridViewListado.AllowUserToDeleteRows = false;
            this.dataGridViewListado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewListado.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewListado.Location = new System.Drawing.Point(16, 117);
            this.dataGridViewListado.MultiSelect = false;
            this.dataGridViewListado.Name = "dataGridViewListado";
            this.dataGridViewListado.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListado.Size = new System.Drawing.Size(741, 256);
            this.dataGridViewListado.TabIndex = 7;
            this.dataGridViewListado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewListado_CellContentClick);
            this.dataGridViewListado.DoubleClick += new System.EventHandler(this.dataGridViewListado_DoubleClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(777, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerFechaN);
            this.groupBox1.Controls.Add(this.labelFechaN);
            this.groupBox1.Controls.Add(this.comboBoxSexo);
            this.groupBox1.Controls.Add(this.labelSexo);
            this.groupBox1.Controls.Add(this.textBoxApellidos);
            this.groupBox1.Controls.Add(this.textBoxEmail);
            this.groupBox1.Controls.Add(this.labelEmail);
            this.groupBox1.Controls.Add(this.textBoxTelefono);
            this.groupBox1.Controls.Add(this.labelTelefono);
            this.groupBox1.Controls.Add(this.comboBoxTipoDoc);
            this.groupBox1.Controls.Add(this.textBoxNumDoc);
            this.groupBox1.Controls.Add(this.labelTipoDoc);
            this.groupBox1.Controls.Add(this.labelApellidos);
            this.groupBox1.Controls.Add(this.buttonCancelar);
            this.groupBox1.Controls.Add(this.buttonEditar);
            this.groupBox1.Controls.Add(this.buttonGuardar);
            this.groupBox1.Controls.Add(this.buttonNuevo);
            this.groupBox1.Controls.Add(this.textBoxDireccion);
            this.groupBox1.Controls.Add(this.textBoxNombre);
            this.groupBox1.Controls.Add(this.textBoxIdCliente);
            this.groupBox1.Controls.Add(this.labelDireccion);
            this.groupBox1.Controls.Add(this.labelNombre);
            this.groupBox1.Controls.Add(this.labelCodigo);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 343);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clientes";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(334, 246);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 13);
            this.labelEmail.TabIndex = 19;
            this.labelEmail.Text = "E-mail:";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTelefono.Location = new System.Drawing.Point(98, 243);
            this.textBoxTelefono.MaxLength = 10;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(189, 20);
            this.textBoxTelefono.TabIndex = 16;
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(24, 246);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(52, 13);
            this.labelTelefono.TabIndex = 15;
            this.labelTelefono.Text = "Teléfono:";
            // 
            // comboBoxTipoDoc
            // 
            this.comboBoxTipoDoc.FormattingEnabled = true;
            this.comboBoxTipoDoc.Items.AddRange(new object[] {
            "DNI",
            "NIF",
            "PAS"});
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(119, 140);
            this.comboBoxTipoDoc.MaxLength = 20;
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(100, 21);
            this.comboBoxTipoDoc.TabIndex = 14;
            this.comboBoxTipoDoc.Text = "DNI";
            // 
            // textBoxNumDoc
            // 
            this.textBoxNumDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxNumDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNumDoc.Location = new System.Drawing.Point(225, 141);
            this.textBoxNumDoc.MaxLength = 11;
            this.textBoxNumDoc.Name = "textBoxNumDoc";
            this.textBoxNumDoc.Size = new System.Drawing.Size(246, 20);
            this.textBoxNumDoc.TabIndex = 13;
            // 
            // labelTipoDoc
            // 
            this.labelTipoDoc.AutoSize = true;
            this.labelTipoDoc.Location = new System.Drawing.Point(24, 143);
            this.labelTipoDoc.Name = "labelTipoDoc";
            this.labelTipoDoc.Size = new System.Drawing.Size(89, 13);
            this.labelTipoDoc.TabIndex = 12;
            this.labelTipoDoc.Text = "Tipo Documento:";
            // 
            // labelApellidos
            // 
            this.labelApellidos.AutoSize = true;
            this.labelApellidos.Location = new System.Drawing.Point(348, 82);
            this.labelApellidos.Name = "labelApellidos";
            this.labelApellidos.Size = new System.Drawing.Size(52, 13);
            this.labelApellidos.TabIndex = 10;
            this.labelApellidos.Text = "Apellidos:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Image = global::CapaVista.Properties.Resources.error2;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(523, 286);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(105, 35);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "&Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Image = global::CapaVista.Properties.Resources.modificar;
            this.buttonEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditar.Location = new System.Drawing.Point(396, 286);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(105, 35);
            this.buttonEditar.TabIndex = 8;
            this.buttonEditar.Text = "E&ditar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::CapaVista.Properties.Resources.disco;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(275, 286);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(105, 35);
            this.buttonGuardar.TabIndex = 7;
            this.buttonGuardar.Text = "&Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.Image = global::CapaVista.Properties.Resources.nuevo;
            this.buttonNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNuevo.Location = new System.Drawing.Point(154, 286);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(105, 35);
            this.buttonNuevo.TabIndex = 6;
            this.buttonNuevo.Text = "&Nuevo";
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDireccion.Location = new System.Drawing.Point(98, 169);
            this.textBoxDireccion.MaxLength = 100;
            this.textBoxDireccion.Multiline = true;
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDireccion.Size = new System.Drawing.Size(373, 66);
            this.textBoxDireccion.TabIndex = 5;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxNombre.Location = new System.Drawing.Point(98, 79);
            this.textBoxNombre.MaxLength = 50;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(244, 20);
            this.textBoxNombre.TabIndex = 4;
            // 
            // textBoxIdCliente
            // 
            this.textBoxIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxIdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIdCliente.Location = new System.Drawing.Point(98, 39);
            this.textBoxIdCliente.Name = "textBoxIdCliente";
            this.textBoxIdCliente.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdCliente.TabIndex = 3;
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(24, 172);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(55, 13);
            this.labelDireccion.TabIndex = 2;
            this.labelDireccion.Text = "Direccion:";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(24, 82);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre:";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(24, 42);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(43, 13);
            this.labelCodigo.TabIndex = 0;
            this.labelCodigo.Text = "Código:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(537, 80);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(96, 13);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "Total de Registros:";
            // 
            // checkBoxEliminar
            // 
            this.checkBoxEliminar.AutoSize = true;
            this.checkBoxEliminar.Location = new System.Drawing.Point(16, 79);
            this.checkBoxEliminar.Name = "checkBoxEliminar";
            this.checkBoxEliminar.Size = new System.Drawing.Size(62, 17);
            this.checkBoxEliminar.TabIndex = 5;
            this.checkBoxEliminar.Text = "Eliminar";
            this.checkBoxEliminar.UseVisualStyleBackColor = true;
            this.checkBoxEliminar.CheckedChanged += new System.EventHandler(this.checkBoxEliminar_CheckedChanged);
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.Image = global::CapaVista.Properties.Resources.imprimir;
            this.buttonImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImprimir.Location = new System.Drawing.Point(652, 26);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(105, 35);
            this.buttonImprimir.TabIndex = 4;
            this.buttonImprimir.Text = "&Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Image = global::CapaVista.Properties.Resources.eliminar;
            this.buttonEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEliminar.Location = new System.Drawing.Point(540, 26);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(105, 35);
            this.buttonEliminar.TabIndex = 3;
            this.buttonEliminar.Text = "&Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Image = global::CapaVista.Properties.Resources.Buscar_p;
            this.buttonBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBuscar.Location = new System.Drawing.Point(428, 26);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(105, 35);
            this.buttonBuscar.TabIndex = 2;
            this.buttonBuscar.Text = "&Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // textBoxBuscar
            // 
            this.textBoxBuscar.Location = new System.Drawing.Point(158, 34);
            this.textBoxBuscar.Name = "textBoxBuscar";
            this.textBoxBuscar.Size = new System.Drawing.Size(246, 20);
            this.textBoxBuscar.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBoxBuscar);
            this.tabPage1.Controls.Add(this.dataGridViewListado);
            this.tabPage1.Controls.Add(this.labelTotal);
            this.tabPage1.Controls.Add(this.checkBoxEliminar);
            this.tabPage1.Controls.Add(this.buttonImprimir);
            this.tabPage1.Controls.Add(this.buttonEliminar);
            this.tabPage1.Controls.Add(this.buttonBuscar);
            this.tabPage1.Controls.Add(this.textBoxBuscar);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(777, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(785, 415);
            this.tabControl1.TabIndex = 10;
            // 
            // labelClientes
            // 
            this.labelClientes.AutoSize = true;
            this.labelClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientes.ForeColor = System.Drawing.Color.Maroon;
            this.labelClientes.Location = new System.Drawing.Point(12, 10);
            this.labelClientes.Name = "labelClientes";
            this.labelClientes.Size = new System.Drawing.Size(109, 29);
            this.labelClientes.TabIndex = 9;
            this.labelClientes.Text = "Clientes";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CapaVista.Properties.Resources.Users_2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(210, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 61);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // errorProviderIcono
            // 
            this.errorProviderIcono.ContainerControl = this;
            // 
            // toolTipMensaje
            // 
            this.toolTipMensaje.IsBalloon = true;
            // 
            // textBoxApellidos
            // 
            this.textBoxApellidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxApellidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxApellidos.Location = new System.Drawing.Point(406, 79);
            this.textBoxApellidos.MaxLength = 40;
            this.textBoxApellidos.Name = "textBoxApellidos";
            this.textBoxApellidos.Size = new System.Drawing.Size(222, 20);
            this.textBoxApellidos.TabIndex = 21;
            // 
            // labelSexo
            // 
            this.labelSexo.AutoSize = true;
            this.labelSexo.Location = new System.Drawing.Point(24, 112);
            this.labelSexo.Name = "labelSexo";
            this.labelSexo.Size = new System.Drawing.Size(34, 13);
            this.labelSexo.TabIndex = 22;
            this.labelSexo.Text = "Sexo:";
            // 
            // comboBoxSexo
            // 
            this.comboBoxSexo.FormattingEnabled = true;
            this.comboBoxSexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.comboBoxSexo.Location = new System.Drawing.Point(119, 109);
            this.comboBoxSexo.MaxLength = 1;
            this.comboBoxSexo.Name = "comboBoxSexo";
            this.comboBoxSexo.Size = new System.Drawing.Size(79, 21);
            this.comboBoxSexo.TabIndex = 23;
            this.comboBoxSexo.Text = "M";
            // 
            // labelFechaN
            // 
            this.labelFechaN.AutoSize = true;
            this.labelFechaN.Location = new System.Drawing.Point(225, 112);
            this.labelFechaN.Name = "labelFechaN";
            this.labelFechaN.Size = new System.Drawing.Size(96, 13);
            this.labelFechaN.TabIndex = 24;
            this.labelFechaN.Text = "Fecha Nacimiento:";
            // 
            // dateTimePickerFechaN
            // 
            this.dateTimePickerFechaN.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaN.Location = new System.Drawing.Point(338, 110);
            this.dateTimePickerFechaN.Name = "dateTimePickerFechaN";
            this.dateTimePickerFechaN.Size = new System.Drawing.Size(133, 20);
            this.dateTimePickerFechaN.TabIndex = 25;
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 481);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelClientes);
            this.Name = "FrmCliente";
            this.Text = ".:. Mantenimiento de Clientes .:.";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.ComboBox comboBoxBuscar;
        private System.Windows.Forms.DataGridView dataGridViewListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.ComboBox comboBoxTipoDoc;
        private System.Windows.Forms.TextBox textBoxNumDoc;
        private System.Windows.Forms.Label labelTipoDoc;
        private System.Windows.Forms.Label labelApellidos;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxIdCliente;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.CheckBox checkBoxEliminar;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label labelClientes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProviderIcono;
        private System.Windows.Forms.ToolTip toolTipMensaje;
        private System.Windows.Forms.TextBox textBoxApellidos;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaN;
        private System.Windows.Forms.Label labelFechaN;
        private System.Windows.Forms.ComboBox comboBoxSexo;
        private System.Windows.Forms.Label labelSexo;
    }
}