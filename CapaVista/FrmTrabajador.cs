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
    public partial class FrmTrabajador : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmTrabajador()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(textBoxNombre, "Ingrese el Nombre del Trabajador");
            this.toolTipMensaje.SetToolTip(textBoxApellidos, "Ingrese el Apellidos del Trabajador");
            this.toolTipMensaje.SetToolTip(textBoxUsuario, "Ingrese el Usuario para que el Trabajador ingrese al Sistema");
            this.toolTipMensaje.SetToolTip(textBoxPass, "Ingrese el Password del Trabajador");
            this.toolTipMensaje.SetToolTip(comboBoxAcceso, "Seleccione el nivel de Acceso del Trabajador");
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
            // Solo dejamos en blanco los textboxes, no los comboboxes
            this.textBoxNombre.Text = string.Empty;
            this.textBoxApellidos.Text = string.Empty;
            this.textBoxNumDoc.Text = string.Empty;
            this.textBoxDireccion.Text = string.Empty;
            this.textBoxTelefono.Text = string.Empty;
            this.textBoxEmail.Text = string.Empty;
            this.textBoxUsuario.Text = string.Empty;
            this.textBoxPass.Text = string.Empty;

            this.textBoxIdTrabajador.Text = string.Empty;
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
            this.textBoxUsuario.ReadOnly = !valor;
            this.textBoxPass.ReadOnly = !valor;

            this.textBoxIdTrabajador.ReadOnly = !valor;
            
            this.comboBoxSexo.Enabled = valor;
            this.comboBoxAcceso.Enabled = valor;
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
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 idtrabajador, 2 nombre
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna idtrabajador
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CapaControlador.CTrabajador.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.dataGridViewListado.DataSource = CTrabajador.BuscarApellidos(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataGridViewListado.DataSource = CTrabajador.BuscarNum_Documento(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Botones();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (comboBoxBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
            else if (comboBoxBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
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
                            Rpta = CTrabajador.Eliminar(Convert.ToInt32(Codigo));

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
            this.textBoxIdTrabajador.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idtrabajador"].Value);
            this.textBoxNombre.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);
            this.textBoxApellidos.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["apellidos"].Value);
            this.comboBoxSexo.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["sexo"].Value);
            this.dateTimePickerFechaN.Value = Convert.ToDateTime(this.dataGridViewListado.CurrentRow.Cells["fecha_nac"].Value);
            
            this.textBoxNumDoc.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["num_documento"].Value);
            this.textBoxDireccion.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["direccion"].Value);
            this.textBoxTelefono.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["telefono"].Value);
            this.textBoxEmail.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["email"].Value);
            this.comboBoxAcceso.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["acceso"].Value);
            this.textBoxUsuario.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["usuario"].Value);
            this.textBoxPass.Text = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["password"].Value);

            this.tabControl1.SelectedIndex = 1; // tab Mantenimiento
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones(); // <- Ya hace hablilitar()
            this.Limpiar();
            this.textBoxNombre.Focus();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar(); // <- Ya hace textBoxIdTrabajador.Text = string.Empty;
            errorProviderIcono.Clear();
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
                        || this.textBoxDireccion.Text == string.Empty || this.textBoxUsuario.Text == string.Empty || textBoxPass.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    problema = true;

                    errorProviderIcono.Clear();

                    if (this.textBoxNombre.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxNombre, "Ingrese un Valor");
                    if (this.textBoxApellidos.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxApellidos, "Ingrese un Valor");
                    if (this.textBoxNumDoc.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxNumDoc, "Ingrese un Valor");
                    if (this.textBoxDireccion.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxDireccion, "Ingrese un Valor");
                    if (this.textBoxUsuario.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxUsuario, "Ingrese un Valor");
                    if (this.textBoxPass.Text == string.Empty)
                        errorProviderIcono.SetError(textBoxPass, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo) // Nuevo, insertamos
                    {
                        rpta = CTrabajador.Insertar(this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxApellidos.Text.Trim().ToUpper(), this.comboBoxSexo.Text,
                                            this.dateTimePickerFechaN.Value, this.textBoxNumDoc.Text.Trim(), this.textBoxDireccion.Text.Trim(),
                                            this.textBoxTelefono.Text.Trim(), this.textBoxEmail.Text.Trim(),
                                            this.comboBoxAcceso.Text, this.textBoxUsuario.Text.Trim(), this.textBoxPass.Text.Trim());
                    }
                    else // No es nuevo, se va a EDITAR, if (this.IsEditar)
                    {
                        rpta = CTrabajador.Editar(Convert.ToInt32(textBoxIdTrabajador.Text), this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxApellidos.Text.Trim().ToUpper(), this.comboBoxSexo.Text,
                                            this.dateTimePickerFechaN.Value, this.textBoxNumDoc.Text.Trim(), this.textBoxDireccion.Text.Trim(),
                                            this.textBoxTelefono.Text.Trim(), this.textBoxEmail.Text.Trim(),
                                            this.comboBoxAcceso.Text, this.textBoxUsuario.Text.Trim(), this.textBoxPass.Text.Trim());
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
            if (!this.textBoxIdTrabajador.Text.Equals(""))
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
    }
}
