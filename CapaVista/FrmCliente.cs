using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Comunicación capa Controlador
using CapaControlador;

namespace CapaVista
{
    public partial class FrmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmCliente()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.textBoxNombre, " Ingrese el Nombre del Cliente");
            this.toolTipMensaje.SetToolTip(this.textBoxApellidos, " Ingrese los Apellidos del Cliente");
            this.toolTipMensaje.SetToolTip(this.textBoxDireccion, " Ingrese la dirección del Cliente");
            this.toolTipMensaje.SetToolTip(this.textBoxNumDoc, " Ingrese el número de documento del Cliente");
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
            this.textBoxNombre.Text = string.Empty;
            this.textBoxApellidos.Text = string.Empty;
            this.textBoxNumDoc.Text = string.Empty;
            this.textBoxDireccion.Text = string.Empty;
            this.textBoxTelefono.Text = string.Empty;          
            this.textBoxEmail.Text = string.Empty;

            this.textBoxIdCliente.Text = string.Empty;
        }

        // Habilitar los controles del formulario

        private void Habilitar(bool valor)  // habilitar solo si se van a editar los controles, Nuevo, Editar
        {
            this.textBoxNombre.ReadOnly = !valor;
            this.textBoxApellidos.ReadOnly = !valor;
            this.textBoxDireccion.ReadOnly = !valor;
            this.textBoxNumDoc.ReadOnly = !valor;
            this.textBoxTelefono.ReadOnly = !valor;          
            this.textBoxEmail.ReadOnly = !valor;
            this.textBoxIdCliente.ReadOnly = !valor;

            this.comboBoxTipoDoc.Enabled = valor;            
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

        // Método para ocultar columnas, hacer el select del procedimiento mostrarcliente SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 idcliente, 2 nombre
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna idcliente
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CCliente.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.dataGridViewListado.DataSource = CCliente.BuscarApellidos(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataGridViewListado.DataSource = CCliente.BuscarNum_Documento(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Botones();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (comboBoxBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (comboBoxBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
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
                            Rpta = CCliente.Eliminar(Convert.ToInt32(Codigo));

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
        // Muestra/Oculta columna de checkboxes eliminar del datagridview
        private void checkBoxEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEliminar.Checked) // Check marcado
            {
                this.dataGridViewListado.Columns[0].Visible = true; // Muestra col Eliminar
            }
            else // check desmarcado
            {
                this.dataGridViewListado.Columns[0].Visible = false; // Oculta col Eliminar
            }
        }

        private void dataGridViewListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridViewListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            this.textBoxIdCliente.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idcliente"].Value);
            this.textBoxNombre.Text = this.dataGridViewListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.textBoxApellidos.Text = this.dataGridViewListado.CurrentRow.Cells["apellidos"].Value.ToString();
            this.comboBoxSexo.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["sexo"].Value);
            this.dateTimePickerFechaN.Value = Convert.ToDateTime(this.dataGridViewListado.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.comboBoxTipoDoc.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["tipo_documento"].Value);
            this.textBoxNumDoc.Text = this.dataGridViewListado.CurrentRow.Cells["num_documento"].Value.ToString();
            this.textBoxDireccion.Text = this.dataGridViewListado.CurrentRow.Cells["direccion"].Value.ToString();
            this.textBoxTelefono.Text = this.dataGridViewListado.CurrentRow.Cells["telefono"].Value.ToString();
            this.textBoxEmail.Text = this.dataGridViewListado.CurrentRow.Cells["email"].Value.ToString();            

            this.tabControl1.SelectedIndex = 1; // tab Mantenimiento
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.textBoxNombre.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            bool problema = false;
            try
            {
                string rpta = "";
                // En comboboxes tipo documento siempre va a haber algún dato, nunca va a estar vacío, luego no hace falta comprobar
// Apellidos y Direccion al importar la BD permitia valores nulos, lo he cambiado, ya no acepta valores NULOS
                if (this.textBoxNombre.Text == string.Empty || textBoxApellidos.Text == string.Empty || textBoxNumDoc.Text == string.Empty
                        || this.textBoxDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    problema = true;

//                    errorProviderIcono.Clear();
                    if (this.textBoxNombre.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxNombre, "Ingrese un Valor");
                    if (this.textBoxApellidos.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxApellidos, "Ingrese un Valor");
                    if (this.textBoxNumDoc.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxNumDoc, "Ingrese un Valor");
                    if (this.textBoxDireccion.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo) // Nuevo, insertamos
                    {
                        rpta = CCliente.Insertar(this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxApellidos.Text.Trim().ToUpper(), this.comboBoxSexo.Text,
                                            this.dateTimePickerFechaN.Value, this.comboBoxTipoDoc.Text,
                                            this.textBoxNumDoc.Text.Trim(), this.textBoxDireccion.Text.Trim(),
                                            this.textBoxTelefono.Text.Trim(), this.textBoxEmail.Text.Trim());
                    }
                    else // No es nuevo, se va a EDITAR, if (this.IsEditar)
                    {
                        rpta = CCliente.Editar(Convert.ToInt32(textBoxIdCliente.Text), this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxApellidos.Text.Trim().ToUpper(), this.comboBoxSexo.Text,
                                            this.dateTimePickerFechaN.Value, this.comboBoxTipoDoc.Text,
                                            this.textBoxNumDoc.Text.Trim(), this.textBoxDireccion.Text.Trim(),
                                            this.textBoxTelefono.Text.Trim(), this.textBoxEmail.Text.Trim());
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
                if (!problema)
                {
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();

                    errorProviderIcono.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (!this.textBoxIdCliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.IsNuevo = false; // de mi cosecha
                this.Botones();
                //                this.Habilitar(true);
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
            this.Botones();
            this.Limpiar();
            errorProviderIcono.Clear();
        }
    }
}
