using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Conectar con las clases de la capa Controlador
using CapaControlador;

namespace CapaVista
{
    public partial class FrmArticulo : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        // comunicar con FrmVistaCategoria_Articulo - Buscar categorias
        private static FrmArticulo _Instancia;

        public static FrmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmArticulo();
            }
            return _Instancia;
        }

        public void setCategoria(string idcategoria, string nombre)
        {
            this.textBoxIdCategoria.Text = idcategoria;
            this.textBoxCategoria.Text = nombre;
        }
        // Constructor
        public FrmArticulo()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.textBoxNombre, "Ingrese el Nombre del Artículo");
            this.toolTipMensaje.SetToolTip(this.pictureBoxImagen, "Seleccione la Imagen del Artículo");
            this.toolTipMensaje.SetToolTip(this.textBoxCategoria, "Seleccione la Categoría del Artículo");
            this.toolTipMensaje.SetToolTip(this.comboBoxIdPresentacion, "Seleccione la Presentación del Artículo");

            this.textBoxIdCategoria.Visible = false;
            this.textBoxCategoria.ReadOnly = true;

            this.LLenarComboPresentacion();
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
            this.textBoxCodigo.Text = string.Empty;
            this.textBoxNombre.Text = string.Empty;
            this.textBoxDescripcion.Text = string.Empty;
            this.textBoxIdCategoria.Text = string.Empty;
            this.textBoxCategoria.Text = string.Empty;
            this.textBoxIdArticulo.Text = string.Empty;

            this.pictureBoxImagen.Image = global::CapaVista.Properties.Resources.file;
        }

        // Habilitar/Deshabilitar los controles textBoxes del formulario

        private void Habilitar(bool valor)
        {
            this.textBoxIdArticulo.ReadOnly = !valor;
            this.textBoxCodigo.ReadOnly = !valor;
            this.textBoxNombre.ReadOnly = !valor;
            this.textBoxDescripcion.ReadOnly = !valor;

            this.buttonBuscarCategoria.Enabled = valor;
            this.buttonCargar.Enabled = valor;
            this.buttonLimpiar.Enabled = valor;

            this.comboBoxIdPresentacion.Enabled = valor;
        }

        // Habilitar los botones 
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) // Si es nuevo o se va a editar
            {
                this.Habilitar(true);
                this.buttonNuevo.Enabled = false;
                this.buttonGuardar.Enabled = true;
                this.buttonEditar.Enabled = false;
                this.buttonCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.buttonNuevo.Enabled = true;
                this.buttonGuardar.Enabled = false;
                this.buttonEditar.Enabled = true;
                this.buttonCancelar.Enabled = false;
            }
        }

        // Método para ocultar columnas, hacer el select del procedimiento spmostrar_articulo SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 idarticulo, 2 codigo, 3 Nombre...
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna Idarticulo
            this.dataGridViewListado.Columns[6].Visible = false; // Columna idcategoria
            this.dataGridViewListado.Columns[8].Visible = false; // Columna idpresentacion
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CArticulo.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método Buscar Nombre
        private void BuscarNombre()
        {
            this.dataGridViewListado.DataSource = CArticulo.BuscarNombre(this.textBoxBuscar.Text);
            this.OcultarColumnas();
            this.labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método rellena combobox presentaciones
        private void LLenarComboPresentacion()
        {
            comboBoxIdPresentacion.DataSource = CPresentacion.Mostrar();
            comboBoxIdPresentacion.ValueMember = "idpresentacion";
            comboBoxIdPresentacion.DisplayMember = "nombre";
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult reult = dialog.ShowDialog();

            if (reult == DialogResult.OK)
            {
                this.pictureBoxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pictureBoxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.pictureBoxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxImagen.Image = global::CapaVista.Properties.Resources.file;
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
// ya lo hace en metodo botones            this.Habilitar(false); // Dehabilita los TextBoxes
            this.Botones();     // Poner los botones según se cree/edite o no
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
//            this.Habilitar(true);
            this.textBoxCodigo.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = ""; // En el tutorial no verifica el comboBox IdPresentacion y esto no puede ser NULL en Tabla Articulo SQL Server
                /* EL COMBOBOX NUNCA SE QUEDA VACÍO si la tabla presentaciones está vacía */
                if (this.textBoxCodigo.Text == string.Empty || this.textBoxNombre.Text == string.Empty ||
                         textBoxIdCategoria.Text == string.Empty || this.comboBoxIdPresentacion.DisplayMember == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProviderIcono.Clear();
                    if (textBoxCodigo.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxCodigo, "Ingrese un Valor");
                    if (textBoxNombre.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxNombre, "Ingrese un Valor");
                    // Mejoras respecto al tutorial de Youtube 
                    if (textBoxIdCategoria.Text == string.Empty)
                        errorProviderIcono.SetError(buttonBuscarCategoria, "Ingrese un Valor");
                    if (comboBoxIdPresentacion.DisplayMember == string.Empty)
                        errorProviderIcono.SetError(comboBoxIdPresentacion, "Ingrese un Valor");
                }
                else
                {   
                    // Para la imagen
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pictureBoxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();

                    if (this.IsNuevo) // Nuevo, insertamos
                    {
                        rpta = CArticulo.Insertar(this.textBoxCodigo.Text, this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.textBoxIdCategoria.Text),
                                            Convert.ToInt32(this.comboBoxIdPresentacion.SelectedValue)); // Obtiene el valor del índice elegido en el combobox
                    }
                    else // No es nuevo, se va a EDITAR
                    {
                        rpta = CArticulo.Editar(Convert.ToInt32(this.textBoxIdArticulo.Text),
                                            this.textBoxCodigo.Text, this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.textBoxIdCategoria.Text),
                                            Convert.ToInt32(this.comboBoxIdPresentacion.SelectedValue)); // Obtiene el valor del índice elegido en el combobox

                    }

                    if (rpta.Equals("OK")) // Guardado en BD
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el Registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el Registro");
                        }
                    }
                    else    // Error al insertar/actualizar en BD...
                    {
                        this.MensajeError(rpta);
                    }
                }

                this.IsNuevo = false;
                this.IsEditar = false;
                this.Botones(); // <- hace habilitar(false)
                this.Limpiar();
                this.Mostrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (!this.textBoxIdArticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                //this.Habilitar(true); sobra lo hace dentro de Botones()
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a modificar");
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones(); // dehabilita los textboxes
            this.Limpiar();
        }

        private void dataGridViewListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewListado.Columns["Eliminar"].Index) // si hago click en la columna Eliminar
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridViewListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            this.textBoxIdArticulo.Text = this.dataGridViewListado.CurrentRow.Cells["idarticulo"].Value.ToString();
            this.textBoxCodigo.Text = this.dataGridViewListado.CurrentRow.Cells["codigo"].Value.ToString();
            this.textBoxNombre.Text = this.dataGridViewListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.textBoxDescripcion.Text = this.dataGridViewListado.CurrentRow.Cells["descripcion"].Value.ToString();

            // Imagen
            byte[] imagenBuffer = (byte[]) this.dataGridViewListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pictureBoxImagen.Image = Image.FromStream(ms);
            this.pictureBoxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.textBoxIdCategoria.Text = this.dataGridViewListado.CurrentRow.Cells["idcategoria"].Value.ToString();
            this.textBoxCategoria.Text = this.dataGridViewListado.CurrentRow.Cells["categoria"].Value.ToString();

            // combobox
            this.comboBoxIdPresentacion.SelectedValue = Convert.ToString(dataGridViewListado.CurrentRow.Cells["idpresentacion"].Value);

            this.tabControl1.SelectedIndex = 1; // tab Mantenimiento
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

        private void buttonEliminar_Click(object sender, EventArgs e)
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
                            Rpta = CArticulo.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el Registro");
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

        private void buttonBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmVistaCategoria_Articulo form = new FrmVistaCategoria_Articulo();
            form.ShowDialog();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteArticulos frm = new FrmReporteArticulos();
            frm.ShowDialog();
        }
    }
}
