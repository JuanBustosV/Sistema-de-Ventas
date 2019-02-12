using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaControlador;

namespace CapaVista
{
    public partial class FrmIngreso : Form
    {
        public int Idtrabajador; // EL trabajador que se loggea, para los permisos

        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        // Porque abre otras ventanas de búsqueda (otros forms)
        private static FrmIngreso _Instancia;

        public static FrmIngreso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmIngreso(); // al cerrar form, _Instancia = null formclosing
            }
            return _Instancia;
        }

        public void setProveedor(string idproveedor, string nombre)
        {
            this.textBoxIdProveedor.Text = idproveedor;
            this.textBoxProveedor.Text = nombre;
        }

        public void setArticulo(string idarticulo, string nombre)
        {
            this.textBoxIdArticulo.Text = idarticulo;
            this.textBoxArticulo.Text = nombre;
        }

        public FrmIngreso()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.textBoxProveedor, "Seleccione el Proveedor");
            this.toolTipMensaje.SetToolTip(this.textBoxSerie, "Ingrese la Serie del Comprobante");
            this.toolTipMensaje.SetToolTip(this.textBoxCorrelativo, "Ingrese el número del Comprobante");
            this.toolTipMensaje.SetToolTip(this.textBoxStockIni, "Ingrese la cantidad de compra");
            this.toolTipMensaje.SetToolTip(this.textBoxArticulo, "Seleccione el Articulo");

            this.textBoxIdProveedor.Visible = false;
            this.textBoxIdArticulo.Visible = false;
            this.textBoxProveedor.ReadOnly = true;
            this.textBoxArticulo.ReadOnly = true;

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
            this.textBoxIdIngreso.Text = string.Empty;
            this.textBoxIdProveedor.Text = string.Empty;
            this.textBoxProveedor.Text = string.Empty;
            this.textBoxSerie.Text = string.Empty;
            this.textBoxCorrelativo.Text = string.Empty;
            this.textBoxIva.Text = "21";
            this.lblTotal_Pagado.Text = "0,0";
            this.CrearTabla();
        }

        // Limpiar los controles del detalle de ingreso
        private void LimpiarDetalle()
        {
            this.textBoxIdArticulo.Text = string.Empty;
            this.textBoxArticulo.Text = string.Empty;
            this.textBoxStockIni.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;            
        }

        // Habilitar/Deshabilitar los controles textBoxes del formulario

        private void Habilitar(bool valor)
        {
            this.textBoxIdIngreso.ReadOnly = !valor;
            this.textBoxSerie.ReadOnly = !valor;
            this.textBoxCorrelativo.ReadOnly = !valor;
            this.textBoxIva.ReadOnly = !valor;
            this.textBoxStockIni.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;

            this.dateTimePickerFecha.Enabled = valor;
            this.dtFecha_Produccion.Enabled = valor;
            this.dtFecha_Vencimiento.Enabled = valor;
            this.buttonBuscarArt.Enabled = valor;
            this.buttonBuscarProveedor.Enabled = valor;
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

        // Método para ocultar columnas, hacer el select del procedimiento spmostrar_articulo SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 idingreso
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna idingreso

        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CIngreso.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataGridViewListado.DataSource = CIngreso.BuscarFechas(this.dateTimePicker1.Value.ToString("dd/MM/yyyy"),
                                                        this.dateTimePicker2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            this.labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método MostrarDetalle
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = CIngreso.MostrarDetalle(this.textBoxIdIngreso.Text);            
        }

        // Método CrearTabla
        private void CrearTabla()
        {
            if (dtDetalle != null)
                this.dtDetalle.Dispose();
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));           
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));            
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));                    
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            
            // Relacionar nuestro DataGridView con nuestro DataTable
            this.dataListadoDetalle.DataSource = dtDetalle;
        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia.Dispose();
            _Instancia = null;
        }

        private void buttonBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor_Ingreso vista = new FrmVistaProveedor_Ingreso();
            vista.ShowDialog();
        }

        private void buttonBuscarArt_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Ingreso vista = new FrmVistaArticulo_Ingreso();
            vista.ShowDialog();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void buttonAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular los Registros", "Sistemas de Vengas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)  // Usuario quiere eliminar el registro
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataGridViewListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = CIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Anuló Correctamente el Ingreso");
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

        private void checkBoxAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAnular.Checked)
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

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Botones();
            this.CrearTabla();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
//            this.Habilitar(true);
            this.textBoxSerie.Focus();
            this.LimpiarDetalle();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones(); // dehabilita los textboxes
            this.Limpiar();
            this.LimpiarDetalle();
            this.errorProviderIcono.Clear();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = ""; 

                if (this.textBoxIdProveedor.Text == string.Empty || this.textBoxSerie.Text == string.Empty ||
                         textBoxCorrelativo.Text == string.Empty || this.textBoxIva.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProviderIcono.Clear();
                    if (textBoxIdProveedor.Text == string.Empty)
                        errorProviderIcono.SetError(buttonBuscarProveedor, "Ingrese un Valor");
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
                        rpta = CIngreso.Insertar(Idtrabajador, Convert.ToInt32(this.textBoxIdProveedor.Text),
                                dateTimePickerFecha.Value, cbTipo_Comprobante.Text, textBoxSerie.Text, textBoxCorrelativo.Text,
                            Convert.ToDecimal(textBoxIva.Text),"EMITIDO",this.dtDetalle); 
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
                if (this.textBoxIdArticulo.Text == string.Empty || this.textBoxStockIni.Text == string.Empty ||
                         txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProviderIcono.Clear();
                    if (textBoxIdArticulo.Text == string.Empty)
                        errorProviderIcono.SetError(buttonBuscarArt, "Ingrese un Valor");
                    if (textBoxStockIni.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxStockIni, "Ingrese un Valor");
                    if (txtPrecioCompra.Text == string.Empty)
                        errorProviderIcono.SetError(txtPrecioCompra, "Ingrese un Valor");
                    if (txtPrecioVenta.Text == string.Empty)
                        errorProviderIcono.SetError(txtPrecioVenta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                // 1 comprobar el el artículo no esté ya en el listado de detalles    
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(textBoxIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar) // 2 insertar al datagrid si no estaba ya
                    {
                        decimal subTotal = Convert.ToDecimal(this.textBoxStockIni.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotal_Pagado.Text = string.Format("{0:n}", totalPagado);//totalPagado.ToString("#0.00#");
                        // Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(textBoxIdArticulo.Text);
                        row["articulo"] = this.textBoxArticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(txtPrecioCompra.Text);
                        row["precio_venta"] = Convert.ToDecimal(txtPrecioVenta.Text);
                        row["stock_inicial"] = Convert.ToInt32(textBoxStockIni.Text);
                        row["fecha_produccion"] = dtFecha_Produccion.Value;
                        row["fecha_vencimiento"] = dtFecha_Vencimiento.Value;
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.LimpiarDetalle();

                        if (dataListadoDetalle.RowCount == 1) // Cuando ya tiene una fila hago las columnas solo lectura
                        {
                            dataListadoDetalle.Columns["idarticulo"].ReadOnly = true;
                            dataListadoDetalle.Columns["articulo"].ReadOnly = true;
                            dataListadoDetalle.Columns["subtotal"].ReadOnly = true;
                        }
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
                this.lblTotal_Pagado.Text = string.Format("{0:n}", totalPagado);//this.totalPagado.ToString("#0.00#");
                // Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para Quitar");
            }
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            this.textBoxIdIngreso.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idingreso"].Value);
            this.textBoxProveedor.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["proveedor"].Value);
            this.dateTimePickerFecha.Value = Convert.ToDateTime(this.dataGridViewListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipo_Comprobante.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.textBoxSerie.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["serie"].Value);
            this.textBoxCorrelativo.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotal_Pagado.Text = Convert.ToDecimal(this.dataGridViewListado.CurrentRow.Cells["total"].Value).ToString("#0.00#");
            this.MostrarDetalle();

            this.tabControl1.SelectedIndex = 1;
        }
        // Actualizar Total si cambia stock en el detalle
        private void dataListadoDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataListadoDetalle.RowCount > 0)
            {
                if (e.ColumnIndex == dataListadoDetalle.Columns["stock_inicial"].Index) // si cambia valor en celda de la columna STOCK_inicial
                {
                    decimal subTotal = Convert.ToDecimal(dataListadoDetalle.Rows[e.RowIndex].Cells["stock_inicial"].Value) * Convert.ToDecimal(dataListadoDetalle.Rows[e.RowIndex].Cells["precio_compra"].Value);
                    dataListadoDetalle.Columns["subtotal"].ReadOnly = false;
                    dataListadoDetalle.Rows[e.RowIndex].Cells["subtotal"].Value = subTotal;
                    dataListadoDetalle.Columns["subtotal"].ReadOnly = true;

                    // Recalculo el total pagado sumando todos los subtotales
                    totalPagado = 0;
                    foreach (DataGridViewRow row in dataListadoDetalle.Rows)
                    {
                        totalPagado = totalPagado + Convert.ToDecimal(row.Cells["subtotal"].Value);
                    }

                    this.lblTotal_Pagado.Text = string.Format("{0:n}", totalPagado);//totalPagado.ToString("#0.00#");
                }
            }
        }
    }
}
