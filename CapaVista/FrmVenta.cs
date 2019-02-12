using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// conectar capa
using CapaControlador;

namespace CapaVista
{
    public partial class FrmVenta : Form
    {
        private bool IsNuevo = false;
        public int Idtrabajador; // el logeado
        private DataTable dtDetalle;

        private decimal totalPagado = 0;

        private static FrmVenta _Instancia;

        public static FrmVenta GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVenta();
            }
            return _Instancia;
        }

        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdCliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        public void setArticulo(string iddetalle_ingreso, string nombre, decimal precio_compra,
                        decimal precio_venta, int stock, DateTime fecha_vencimiento)
        {
            this.txtIdDetalle_ingreso.Text = iddetalle_ingreso; // cogo el iddetalle de ingreso, no el idarticulo
            this.textBoxArticulo.Text = nombre;
            this.txtPrecioCompra.Text = Convert.ToString(precio_compra);
            this.txtPrecioVenta.Text = Convert.ToString(precio_venta);
            this.txtStockActual.Text = Convert.ToString(stock);
            this.dtFecha_Vencimiento.Value = fecha_vencimiento;
        }

        public FrmVenta()
        {
            InitializeComponent();
            toolTipMensaje.SetToolTip(txtCliente, "Seleccione un Cliente");
            toolTipMensaje.SetToolTip(textBoxSerie, "Ingrese una serie del comprobante");
            toolTipMensaje.SetToolTip(textBoxCorrelativo, "Ingrese un número de comprobante");
            toolTipMensaje.SetToolTip(txtCantidad, "Ingrese la Cantidad del Artículo");
            toolTipMensaje.SetToolTip(textBoxArticulo, "Seleccione un Artículo");

            txtIdCliente.Visible = false;
            txtIdDetalle_ingreso.Visible = false;
            textBoxArticulo.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtStockActual.ReadOnly = true;
            txtPrecioCompra.ReadOnly = true;
            dtFecha_Vencimiento.Enabled = false;
        }

        // Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Limpiar todos los controles del formulario

        private void Limpiar()
        {
            this.textBoxIdVenta.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.textBoxSerie.Text = string.Empty;
            this.textBoxCorrelativo.Text = string.Empty;
            this.textBoxIva.Text = "21";
            this.lblTotal_Pagado.Text = "0.0";
            this.CrearTabla();
        }

        // Limpiar los controles del detalle de ingreso, al agregar hay que limpiar los campos detalle
        private void LimpiarDetalle()
        {
            this.txtIdDetalle_ingreso.Text = string.Empty;
            this.textBoxArticulo.Text = string.Empty;
            this.txtStockActual.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            txtDescuento.Text = string.Empty;            
        }

        // Habilitar/Deshabilitar los controles textBoxes del formulario

        private void Habilitar(bool valor)
        {
            this.textBoxIdVenta.ReadOnly = !valor;
            this.textBoxSerie.ReadOnly = !valor;
            this.textBoxCorrelativo.ReadOnly = !valor;
            this.textBoxIva.ReadOnly = !valor;
            txtCantidad.ReadOnly = !valor;            
            this.txtPrecioVenta.ReadOnly = !valor;
            txtDescuento.ReadOnly = !valor;

            this.dateTimePickerFecha.Enabled = valor;            
            this.buttonBuscarArt.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;

            this.cbTipo_Comprobante.Enabled = valor;
        }

        // Habilitar los botones 
        private void Botones()
        {
            if (this.IsNuevo/* || this.IsEditar*/) // Si es nuevo. LOS INGRESOS NO SE VAN A EDITAR, se anulan
            {
                this.Habilitar(true);
                this.buttonNuevo.Enabled = false;
                this.buttonGuardar.Enabled = true;
                this.buttonCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.buttonNuevo.Enabled = true;
                this.buttonGuardar.Enabled = false;
                this.buttonCancelar.Enabled = false;
            }
        }

        // Método para ocultar columnas, hacer el select del procedimiento spmostrar_venta SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 id¿?
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna id
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CVenta.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataGridViewListado.DataSource = CVenta.BuscarFechas(this.dateTimePicker1.Value.ToString("dd/MM/yyyy"),
                                                        this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            this.labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método MostrarDetalle
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = CVenta.MostrarDetalle(this.textBoxIdVenta.Text);
        }

        // Método CrearTabla
        private void CrearTabla()
        {
            if (dtDetalle != null)
                this.dtDetalle.Dispose();
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));            
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));            
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));            
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            
            // Relacionar nuestro DataGridView con nuestro DataTable
            this.dataListadoDetalle.DataSource = dtDetalle;
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia.Dispose(); // en el tutorial SOLO hace _Instancia = null;
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Venta vista = new FrmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void buttonBuscarArt_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Venta vista = new FrmVistaArticulo_Venta();
            vista.ShowDialog();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            Top = 0;
            Left = 0;
            Mostrar();
            Botones();
            CrearTabla();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            BuscarFechas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistemas de Vengas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)  // Usuario quiere eliminar el registro
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataGridViewListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = CVenta.Eliminar(Convert.ToInt32(Codigo));
        /* SQL SERVER */
                            // Los detalles de venta se eliminan en Cascada de esa venta
                            // Cada detalle ejecuta su trigger y se actualiza el stock

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente la Venta");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            this.textBoxIdVenta.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["cliente"].Value);
            this.dateTimePickerFecha.Value = Convert.ToDateTime(this.dataGridViewListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.textBoxSerie.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["serie"].Value);
            this.textBoxCorrelativo.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_Pagado.Text = Convert.ToDecimal(this.dataGridViewListado.CurrentRow.Cells["total"].Value).ToString("#0.00#");
            this.MostrarDetalle();

            this.tabControl1.SelectedIndex = 1;
        }

        private void checkBoxEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEliminar.Checked)
            {
                this.dataGridViewListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataGridViewListado.Columns[0].Visible = false;
            }
        }

        private void dataGridViewListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewListado.Columns["Eliminar"].Index) // si hago click en la columna Eliminar (ANULAR)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridViewListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            Botones();
            Limpiar();
            LimpiarDetalle();
            textBoxSerie.Focus();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            Botones();
            Limpiar();
            LimpiarDetalle();
            textBoxSerie.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";

                if (this.txtCliente.Text == string.Empty || this.textBoxSerie.Text == string.Empty ||
                         textBoxCorrelativo.Text == string.Empty || this.textBoxIva.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProviderIcono.Clear();
                    if (txtCliente.Text == string.Empty)
                        errorProviderIcono.SetError(btnBuscarCliente, "Ingrese un Valor");
                    if (textBoxSerie.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxSerie, "Ingrese un Valor");
                    if (textBoxCorrelativo.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxCorrelativo, "Ingrese un Valor");
                    if (textBoxIva.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxIva, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo) // Nuevo, insertamos
                    {
                        rpta = CVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text), Idtrabajador,
                                dateTimePickerFecha.Value, cbTipo_Comprobante.Text, textBoxSerie.Text, textBoxCorrelativo.Text,
                            Convert.ToDecimal(textBoxIva.Text), this.dtDetalle);
                    }

                    if (rpta.Equals("OK")) // Guardado en BD
                    {
                        //if (this.IsNuevo)
                        //{
                            this.MensajeOk("Se Insertó de forma correcta el Registro");
                        //}
                    }
                    else    // Error al insertar/actualizar en BD...
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones(); // <- hace habilitar(false)
                    this.Limpiar();
                    this.LimpiarDetalle();
                    this.Mostrar();
                    errorProviderIcono.Clear();
                    totalPagado = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.textBoxArticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty ||
                         txtDescuento.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProviderIcono.Clear();
                    if (textBoxArticulo.Text == string.Empty)
                        errorProviderIcono.SetError(buttonBuscarArt, "Ingrese un Valor");
                    if (txtCantidad.Text == string.Empty)
                        errorProviderIcono.SetError(txtCantidad, "Ingrese un Valor");
                    if (txtDescuento.Text == string.Empty)
                        errorProviderIcono.SetError(txtDescuento, "Ingrese un Valor");
                    if (txtPrecioVenta.Text == string.Empty)
                        errorProviderIcono.SetError(txtPrecioVenta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    // 1 comprobar el el artículo no esté ya en el listado de detalles    
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(txtIdDetalle_ingreso.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    } // Cantidad a vender <= stock
                    if (registrar && Convert.ToInt32(txtCantidad.Text)<=Convert.ToInt32(txtStockActual.Text)) // 2 insertar al datagrid si no estaba ya antes
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text)-
                                                Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                        // Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(txtIdDetalle_ingreso.Text);
                        row["articulo"] = this.textBoxArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(txtDescuento.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();

                        if (dataListadoDetalle.RowCount == 1) // con una fila hago las columnas de solo lectura
                        {
                            dataListadoDetalle.Columns["iddetalle_ingreso"].ReadOnly = true;
                            dataListadoDetalle.Columns["articulo"].ReadOnly = true;
                            dataListadoDetalle.Columns["subtotal"].ReadOnly = true;
                        }
                    }
                    else
                    {
                        MensajeError("No hay Stock Suficiente");
                    }
                    errorProviderIcono.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                // Disminuir el total Pagado
                this.totalPagado = totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotal_Pagado.Text = this.totalPagado.ToString("#0.00#");
                // Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para Quitar");
            }
        }

        private void dataListadoDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataListadoDetalle.RowCount > 0)
            {
                if (e.ColumnIndex == dataListadoDetalle.Columns["cantidad"].Index) // si cambia valor en celda de la columna STOCK_inicial
                {
                    decimal subTotal = Convert.ToDecimal(dataListadoDetalle.Rows[e.RowIndex].Cells["cantidad"].Value) * Convert.ToDecimal(dataListadoDetalle.Rows[e.RowIndex].Cells["precio_venta"].Value)-
                                    Convert.ToDecimal(dataListadoDetalle.Rows[e.RowIndex].Cells["descuento"].Value);
                    dataListadoDetalle.Columns["subtotal"].ReadOnly = false;
                    dataListadoDetalle.Rows[e.RowIndex].Cells["subtotal"].Value = subTotal;
                    dataListadoDetalle.Columns["subtotal"].ReadOnly = true;
                    // Recalculo el total pagado sumando todos los subtotales
                    totalPagado = 0;
                    foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                    {
                        totalPagado = totalPagado + Convert.ToDecimal(row.Cells["subtotal"].Value);
                    }

                    this.lblTotal_Pagado.Text = totalPagado.ToString("#0.00#");
                }
            }
        }
    }
}
