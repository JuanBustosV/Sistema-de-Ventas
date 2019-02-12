namespace CapaVista
{
    partial class FrmVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonBuscarArt = new System.Windows.Forms.Button();
            this.txtIdDetalle_ingreso = new System.Windows.Forms.TextBox();
            this.labelArticulo = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotal_Pagado = new System.Windows.Forms.Label();
            this.lblTotalPag = new System.Windows.Forms.Label();
            this.dataListadoDetalle = new System.Windows.Forms.DataGridView();
            this.groupBoxDetalles = new System.Windows.Forms.GroupBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.labelDescuento = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtFecha_Vencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFecVen = new System.Windows.Forms.Label();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.textBoxArticulo = new System.Windows.Forms.TextBox();
            this.labelIva = new System.Windows.Forms.Label();
            this.textBoxIva = new System.Windows.Forms.TextBox();
            this.textBoxCorrelativo = new System.Windows.Forms.TextBox();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.labelFecha = new System.Windows.Forms.Label();
            this.cbTipo_Comprobante = new System.Windows.Forms.ComboBox();
            this.labelNum = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.textBoxSerie = new System.Windows.Forms.TextBox();
            this.labelComprobante = new System.Windows.Forms.Label();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.textBoxIdVenta = new System.Windows.Forms.TextBox();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.labelFIni = new System.Windows.Forms.Label();
            this.errorProviderIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnComprobante = new System.Windows.Forms.Button();
            this.labelFFin = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewListado = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.labelTotal = new System.Windows.Forms.Label();
            this.checkBoxEliminar = new System.Windows.Forms.CheckBox();
            this.buttonImprimir = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.toolTipMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.labelVentas = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).BeginInit();
            this.groupBoxDetalles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderIcono)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBuscarArt
            // 
            this.buttonBuscarArt.Image = global::CapaVista.Properties.Resources.Buscar_p;
            this.buttonBuscarArt.Location = new System.Drawing.Point(200, 17);
            this.buttonBuscarArt.Name = "buttonBuscarArt";
            this.buttonBuscarArt.Size = new System.Drawing.Size(40, 31);
            this.buttonBuscarArt.TabIndex = 22;
            this.buttonBuscarArt.UseVisualStyleBackColor = true;
            this.buttonBuscarArt.Click += new System.EventHandler(this.buttonBuscarArt_Click);
            // 
            // txtIdDetalle_ingreso
            // 
            this.txtIdDetalle_ingreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdDetalle_ingreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdDetalle_ingreso.Location = new System.Drawing.Point(12, 4);
            this.txtIdDetalle_ingreso.Name = "txtIdDetalle_ingreso";
            this.txtIdDetalle_ingreso.ReadOnly = true;
            this.txtIdDetalle_ingreso.Size = new System.Drawing.Size(56, 20);
            this.txtIdDetalle_ingreso.TabIndex = 20;
            // 
            // labelArticulo
            // 
            this.labelArticulo.AutoSize = true;
            this.labelArticulo.Location = new System.Drawing.Point(9, 27);
            this.labelArticulo.Name = "labelArticulo";
            this.labelArticulo.Size = new System.Drawing.Size(45, 13);
            this.labelArticulo.TabIndex = 19;
            this.labelArticulo.Text = "Articulo:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::CapaVista.Properties.Resources.eliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(509, 23);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(105, 35);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 434);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotal_Pagado);
            this.groupBox1.Controls.Add(this.lblTotalPag);
            this.groupBox1.Controls.Add(this.dataListadoDetalle);
            this.groupBox1.Controls.Add(this.groupBoxDetalles);
            this.groupBox1.Controls.Add(this.labelIva);
            this.groupBox1.Controls.Add(this.textBoxIva);
            this.groupBox1.Controls.Add(this.textBoxCorrelativo);
            this.groupBox1.Controls.Add(this.dateTimePickerFecha);
            this.groupBox1.Controls.Add(this.labelFecha);
            this.groupBox1.Controls.Add(this.cbTipo_Comprobante);
            this.groupBox1.Controls.Add(this.labelNum);
            this.groupBox1.Controls.Add(this.btnBuscarCliente);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.txtIdCliente);
            this.groupBox1.Controls.Add(this.labelCliente);
            this.groupBox1.Controls.Add(this.textBoxSerie);
            this.groupBox1.Controls.Add(this.labelComprobante);
            this.groupBox1.Controls.Add(this.buttonCancelar);
            this.groupBox1.Controls.Add(this.buttonGuardar);
            this.groupBox1.Controls.Add(this.buttonNuevo);
            this.groupBox1.Controls.Add(this.textBoxIdVenta);
            this.groupBox1.Controls.Add(this.labelCodigo);
            this.groupBox1.Location = new System.Drawing.Point(6, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(877, 407);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ventas";
            // 
            // lblTotal_Pagado
            // 
            this.lblTotal_Pagado.AutoSize = true;
            this.lblTotal_Pagado.Location = new System.Drawing.Point(97, 370);
            this.lblTotal_Pagado.Name = "lblTotal_Pagado";
            this.lblTotal_Pagado.Size = new System.Drawing.Size(22, 13);
            this.lblTotal_Pagado.TabIndex = 29;
            this.lblTotal_Pagado.Text = "0.0";
            // 
            // lblTotalPag
            // 
            this.lblTotalPag.AutoSize = true;
            this.lblTotalPag.Location = new System.Drawing.Point(6, 370);
            this.lblTotalPag.Name = "lblTotalPag";
            this.lblTotalPag.Size = new System.Drawing.Size(83, 13);
            this.lblTotalPag.TabIndex = 28;
            this.lblTotalPag.Text = "Total Pagado: €";
            // 
            // dataListadoDetalle
            // 
            this.dataListadoDetalle.AllowUserToAddRows = false;
            this.dataListadoDetalle.AllowUserToDeleteRows = false;
            this.dataListadoDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoDetalle.Location = new System.Drawing.Point(7, 211);
            this.dataListadoDetalle.Name = "dataListadoDetalle";
            this.dataListadoDetalle.Size = new System.Drawing.Size(864, 145);
            this.dataListadoDetalle.TabIndex = 27;
            this.dataListadoDetalle.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataListadoDetalle_CellValueChanged);
            // 
            // groupBoxDetalles
            // 
            this.groupBoxDetalles.Controls.Add(this.txtDescuento);
            this.groupBoxDetalles.Controls.Add(this.labelDescuento);
            this.groupBoxDetalles.Controls.Add(this.txtStockActual);
            this.groupBoxDetalles.Controls.Add(this.btnQuitar);
            this.groupBoxDetalles.Controls.Add(this.btnAgregar);
            this.groupBoxDetalles.Controls.Add(this.dtFecha_Vencimiento);
            this.groupBoxDetalles.Controls.Add(this.lblFecVen);
            this.groupBoxDetalles.Controls.Add(this.txtPrecioCompra);
            this.groupBoxDetalles.Controls.Add(this.lblPrecioCompra);
            this.groupBoxDetalles.Controls.Add(this.txtPrecioVenta);
            this.groupBoxDetalles.Controls.Add(this.lblPrecioVenta);
            this.groupBoxDetalles.Controls.Add(this.txtCantidad);
            this.groupBoxDetalles.Controls.Add(this.lblCantidad);
            this.groupBoxDetalles.Controls.Add(this.buttonBuscarArt);
            this.groupBoxDetalles.Controls.Add(this.textBoxArticulo);
            this.groupBoxDetalles.Controls.Add(this.txtIdDetalle_ingreso);
            this.groupBoxDetalles.Controls.Add(this.labelArticulo);
            this.groupBoxDetalles.Location = new System.Drawing.Point(6, 104);
            this.groupBoxDetalles.Name = "groupBoxDetalles";
            this.groupBoxDetalles.Size = new System.Drawing.Size(865, 100);
            this.groupBoxDetalles.TabIndex = 26;
            this.groupBoxDetalles.TabStop = false;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Location = new System.Drawing.Point(650, 61);
            this.txtDescuento.MaxLength = 16;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(65, 20);
            this.txtDescuento.TabIndex = 37;
            // 
            // labelDescuento
            // 
            this.labelDescuento.AutoSize = true;
            this.labelDescuento.Location = new System.Drawing.Point(570, 63);
            this.labelDescuento.Name = "labelDescuento";
            this.labelDescuento.Size = new System.Drawing.Size(62, 13);
            this.labelDescuento.TabIndex = 36;
            this.labelDescuento.Text = "Descuento:";
            // 
            // txtStockActual
            // 
            this.txtStockActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtStockActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStockActual.Location = new System.Drawing.Point(169, 61);
            this.txtStockActual.MaxLength = 16;
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(65, 20);
            this.txtStockActual.TabIndex = 35;
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = global::CapaVista.Properties.Resources.Remove;
            this.btnQuitar.Location = new System.Drawing.Point(784, 59);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(50, 30);
            this.btnQuitar.TabIndex = 34;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::CapaVista.Properties.Resources.agregar_p;
            this.btnAgregar.Location = new System.Drawing.Point(784, 17);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(50, 30);
            this.btnAgregar.TabIndex = 33;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtFecha_Vencimiento
            // 
            this.dtFecha_Vencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha_Vencimiento.Location = new System.Drawing.Point(652, 21);
            this.dtFecha_Vencimiento.Name = "dtFecha_Vencimiento";
            this.dtFecha_Vencimiento.Size = new System.Drawing.Size(107, 20);
            this.dtFecha_Vencimiento.TabIndex = 32;
            // 
            // lblFecVen
            // 
            this.lblFecVen.AutoSize = true;
            this.lblFecVen.Location = new System.Drawing.Point(570, 26);
            this.lblFecVen.Name = "lblFecVen";
            this.lblFecVen.Size = new System.Drawing.Size(71, 13);
            this.lblFecVen.TabIndex = 31;
            this.lblFecVen.Text = "Fecha Venc.:";
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtPrecioCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioCompra.Location = new System.Drawing.Point(376, 24);
            this.txtPrecioCompra.MaxLength = 16;
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioCompra.TabIndex = 28;
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Location = new System.Drawing.Point(293, 26);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(79, 13);
            this.lblPrecioCompra.TabIndex = 27;
            this.lblPrecioCompra.Text = "Precio Compra:";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtPrecioVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioVenta.Location = new System.Drawing.Point(376, 61);
            this.txtPrecioVenta.MaxLength = 16;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioVenta.TabIndex = 26;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(293, 63);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(71, 13);
            this.lblPrecioVenta.TabIndex = 25;
            this.lblPrecioVenta.Text = "Precio Venta:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidad.Location = new System.Drawing.Point(72, 61);
            this.txtCantidad.MaxLength = 16;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(65, 20);
            this.txtCantidad.TabIndex = 24;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(11, 63);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 23;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // textBoxArticulo
            // 
            this.textBoxArticulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxArticulo.Location = new System.Drawing.Point(72, 24);
            this.textBoxArticulo.MaxLength = 50;
            this.textBoxArticulo.Name = "textBoxArticulo";
            this.textBoxArticulo.Size = new System.Drawing.Size(122, 20);
            this.textBoxArticulo.TabIndex = 21;
            // 
            // labelIva
            // 
            this.labelIva.AutoSize = true;
            this.labelIva.Location = new System.Drawing.Point(679, 80);
            this.labelIva.Name = "labelIva";
            this.labelIva.Size = new System.Drawing.Size(27, 13);
            this.labelIva.TabIndex = 25;
            this.labelIva.Text = "IVA:";
            // 
            // textBoxIva
            // 
            this.textBoxIva.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIva.Location = new System.Drawing.Point(712, 78);
            this.textBoxIva.MaxLength = 7;
            this.textBoxIva.Name = "textBoxIva";
            this.textBoxIva.Size = new System.Drawing.Size(48, 20);
            this.textBoxIva.TabIndex = 24;
            // 
            // textBoxCorrelativo
            // 
            this.textBoxCorrelativo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxCorrelativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCorrelativo.Location = new System.Drawing.Point(449, 78);
            this.textBoxCorrelativo.MaxLength = 7;
            this.textBoxCorrelativo.Name = "textBoxCorrelativo";
            this.textBoxCorrelativo.Size = new System.Drawing.Size(115, 20);
            this.textBoxCorrelativo.TabIndex = 23;
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(658, 30);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(107, 20);
            this.dateTimePickerFecha.TabIndex = 22;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(602, 35);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(40, 13);
            this.labelFecha.TabIndex = 21;
            this.labelFecha.Text = "Fecha:";
            // 
            // cbTipo_Comprobante
            // 
            this.cbTipo_Comprobante.FormattingEnabled = true;
            this.cbTipo_Comprobante.Items.AddRange(new object[] {
            "TICKET",
            "BOLETA",
            "FACTURA",
            "GUIA REMISION"});
            this.cbTipo_Comprobante.Location = new System.Drawing.Point(133, 77);
            this.cbTipo_Comprobante.Name = "cbTipo_Comprobante";
            this.cbTipo_Comprobante.Size = new System.Drawing.Size(107, 21);
            this.cbTipo_Comprobante.TabIndex = 20;
            this.cbTipo_Comprobante.Text = "TICKET";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(332, 80);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(47, 13);
            this.labelNum.TabIndex = 19;
            this.labelNum.Text = "Número:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::CapaVista.Properties.Resources.Buscar_p;
            this.btnBuscarCliente.Location = new System.Drawing.Point(488, 27);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(40, 31);
            this.btnBuscarCliente.TabIndex = 18;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Location = new System.Drawing.Point(360, 34);
            this.txtCliente.MaxLength = 50;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(122, 20);
            this.txtCliente.TabIndex = 17;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtIdCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdCliente.Location = new System.Drawing.Point(360, 8);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(73, 20);
            this.txtIdCliente.TabIndex = 16;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(297, 37);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(42, 13);
            this.labelCliente.TabIndex = 15;
            this.labelCliente.Text = "Cliente:";
            // 
            // textBoxSerie
            // 
            this.textBoxSerie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSerie.Location = new System.Drawing.Point(395, 78);
            this.textBoxSerie.MaxLength = 4;
            this.textBoxSerie.Name = "textBoxSerie";
            this.textBoxSerie.Size = new System.Drawing.Size(48, 20);
            this.textBoxSerie.TabIndex = 11;
            // 
            // labelComprobante
            // 
            this.labelComprobante.AutoSize = true;
            this.labelComprobante.Location = new System.Drawing.Point(59, 80);
            this.labelComprobante.Name = "labelComprobante";
            this.labelComprobante.Size = new System.Drawing.Size(73, 13);
            this.labelComprobante.TabIndex = 10;
            this.labelComprobante.Text = "Comprobante:";
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Image = global::CapaVista.Properties.Resources.error2;
            this.buttonCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelar.Location = new System.Drawing.Point(735, 362);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(105, 35);
            this.buttonCancelar.TabIndex = 9;
            this.buttonCancelar.Text = "&Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Image = global::CapaVista.Properties.Resources.disco;
            this.buttonGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGuardar.Location = new System.Drawing.Point(624, 362);
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
            this.buttonNuevo.Location = new System.Drawing.Point(513, 362);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(105, 35);
            this.buttonNuevo.TabIndex = 6;
            this.buttonNuevo.Text = "&Nuevo";
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // textBoxIdVenta
            // 
            this.textBoxIdVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxIdVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxIdVenta.Location = new System.Drawing.Point(133, 34);
            this.textBoxIdVenta.Name = "textBoxIdVenta";
            this.textBoxIdVenta.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdVenta.TabIndex = 3;
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Location = new System.Drawing.Point(59, 37);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(43, 13);
            this.labelCodigo.TabIndex = 0;
            this.labelCodigo.Text = "Código:";
            // 
            // labelFIni
            // 
            this.labelFIni.AutoSize = true;
            this.labelFIni.Location = new System.Drawing.Point(34, 23);
            this.labelFIni.Name = "labelFIni";
            this.labelFIni.Size = new System.Drawing.Size(68, 13);
            this.labelFIni.TabIndex = 0;
            this.labelFIni.Text = "Fecha Inicio:";
            // 
            // errorProviderIcono
            // 
            this.errorProviderIcono.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 460);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnComprobante);
            this.tabPage1.Controls.Add(this.labelFFin);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.dataGridViewListado);
            this.tabPage1.Controls.Add(this.labelTotal);
            this.tabPage1.Controls.Add(this.checkBoxEliminar);
            this.tabPage1.Controls.Add(this.buttonImprimir);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.buttonBuscar);
            this.tabPage1.Controls.Add(this.labelFIni);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 434);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnComprobante
            // 
            this.btnComprobante.Image = global::CapaVista.Properties.Resources.imprimir;
            this.btnComprobante.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComprobante.Location = new System.Drawing.Point(652, 23);
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(120, 35);
            this.btnComprobante.TabIndex = 11;
            this.btnComprobante.Text = "&Comprobante";
            this.btnComprobante.UseVisualStyleBackColor = true;
            // 
            // labelFFin
            // 
            this.labelFFin.AutoSize = true;
            this.labelFFin.Location = new System.Drawing.Point(192, 23);
            this.labelFFin.Name = "labelFFin";
            this.labelFFin.Size = new System.Drawing.Size(57, 13);
            this.labelFFin.TabIndex = 10;
            this.labelFFin.Text = "Fecha Fin:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(195, 47);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(37, 47);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // dataGridViewListado
            // 
            this.dataGridViewListado.AllowUserToAddRows = false;
            this.dataGridViewListado.AllowUserToDeleteRows = false;
            this.dataGridViewListado.AllowUserToOrderColumns = true;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewListado.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewListado.Location = new System.Drawing.Point(6, 99);
            this.dataGridViewListado.MultiSelect = false;
            this.dataGridViewListado.Name = "dataGridViewListado";
            this.dataGridViewListado.ReadOnly = true;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dataGridViewListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewListado.Size = new System.Drawing.Size(877, 320);
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
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(539, 76);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(96, 13);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "Total de Registros:";
            // 
            // checkBoxEliminar
            // 
            this.checkBoxEliminar.AutoSize = true;
            this.checkBoxEliminar.Location = new System.Drawing.Point(16, 76);
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
            this.buttonImprimir.Location = new System.Drawing.Point(778, 23);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(105, 35);
            this.buttonImprimir.TabIndex = 4;
            this.buttonImprimir.Text = "&Imprimir";
            this.buttonImprimir.UseVisualStyleBackColor = true;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Image = global::CapaVista.Properties.Resources.Buscar_p;
            this.buttonBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBuscar.Location = new System.Drawing.Point(373, 23);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(105, 35);
            this.buttonBuscar.TabIndex = 2;
            this.buttonBuscar.Text = "&Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // toolTipMensaje
            // 
            this.toolTipMensaje.IsBalloon = true;
            // 
            // labelVentas
            // 
            this.labelVentas.AutoSize = true;
            this.labelVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentas.ForeColor = System.Drawing.Color.Maroon;
            this.labelVentas.Location = new System.Drawing.Point(13, 14);
            this.labelVentas.Name = "labelVentas";
            this.labelVentas.Size = new System.Drawing.Size(92, 29);
            this.labelVentas.TabIndex = 11;
            this.labelVentas.Text = "Ventas";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CapaVista.Properties.Resources.pencil_scale;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(266, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 61);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // FrmVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(945, 608);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelVentas);
            this.Name = "FrmVenta";
            this.Text = ".:. Mantenimiento de Ventas .:.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVenta_FormClosing);
            this.Load += new System.EventHandler(this.FrmVenta_Load);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoDetalle)).EndInit();
            this.groupBoxDetalles.ResumeLayout(false);
            this.groupBoxDetalles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderIcono)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuscarArt;
        private System.Windows.Forms.TextBox txtIdDetalle_ingreso;
        private System.Windows.Forms.Label labelArticulo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotal_Pagado;
        private System.Windows.Forms.Label lblTotalPag;
        private System.Windows.Forms.DataGridView dataListadoDetalle;
        private System.Windows.Forms.GroupBox groupBoxDetalles;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DateTimePicker dtFecha_Vencimiento;
        private System.Windows.Forms.Label lblFecVen;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox textBoxArticulo;
        private System.Windows.Forms.Label labelIva;
        private System.Windows.Forms.TextBox textBoxIva;
        private System.Windows.Forms.TextBox textBoxCorrelativo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.ComboBox cbTipo_Comprobante;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.TextBox textBoxSerie;
        private System.Windows.Forms.Label labelComprobante;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.TextBox textBoxIdVenta;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelFIni;
        private System.Windows.Forms.ErrorProvider errorProviderIcono;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnComprobante;
        private System.Windows.Forms.Label labelFFin;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridViewListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.CheckBox checkBoxEliminar;
        private System.Windows.Forms.Button buttonImprimir;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Label labelVentas;
        private System.Windows.Forms.ToolTip toolTipMensaje;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label labelDescuento;
        private System.Windows.Forms.TextBox txtStockActual;
    }
}