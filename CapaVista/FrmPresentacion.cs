using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Para comunicar con capa CONTROLADOR (negocio en el curso)
using CapaControlador;

namespace CapaVista
{
    public partial class FrmPresentacion : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmPresentacion()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.textBoxNombre, "Ingrese el Nombre de la Presentación");
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
            this.textBoxDescripcion.Text = string.Empty;
            this.textBoxIdPresentacion.Text = string.Empty;
        }

        // Habilitar/Deshabilitar los controles textBoxes del formulario

        private void Habilitar(bool valor)
        {
            this.textBoxNombre.ReadOnly = !valor;
            this.textBoxDescripcion.ReadOnly = !valor;
            this.textBoxIdPresentacion.ReadOnly = !valor;
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

        // Método para ocultar columnas, hacer el select del procedimiento mostrarcategoria SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 Idpresentacion, 2 Nombre, 3 Descripcion
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna Idpresentacion
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CPresentacion.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método Buscar Nombre
        private void BuscarNombre()
        {
            this.dataGridViewListado.DataSource = CPresentacion.BuscarNombre(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        private void FrmPresentacion_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false); // Dehabilita los TextBoxes
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
            this.Habilitar(true);
            this.textBoxNombre.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.textBoxNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProviderIcono.SetError(textBoxNombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo) // Nuevo, insertamos
                    {
                        rpta = CPresentacion.Insertar(this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxDescripcion.Text.Trim());
                    }
                    else // No es nuevo, se va a EDITAR
                    {
                        rpta = CPresentacion.Editar(Convert.ToInt32(textBoxIdPresentacion.Text),
                                            this.textBoxNombre.Text.Trim().ToUpper(),
                                            this.textBoxDescripcion.Text.Trim());
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
            if (!this.textBoxIdPresentacion.Text.Equals(""))
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
                            Rpta = CPresentacion.Eliminar(Convert.ToInt32(Codigo));

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
            if (e.ColumnIndex == dataGridViewListado.Columns["Eliminar"].Index) // si hago click en la columna Eliminar
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell) dataGridViewListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            this.textBoxIdPresentacion.Text = this.dataGridViewListado.CurrentRow.Cells["idpresentacion"].Value.ToString();
            this.textBoxNombre.Text = this.dataGridViewListado.CurrentRow.Cells["nombre"].Value.ToString();
            this.textBoxDescripcion.Text = this.dataGridViewListado.CurrentRow.Cells["descripcion"].Value.ToString();

            this.tabControl1.SelectedIndex = 1; // tab Mantenimiento
        }
    }
}
