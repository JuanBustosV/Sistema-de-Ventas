using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// conectar con la capa controlador
using CapaControlador;

namespace CapaVista
{
    public partial class FrmProveedor : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmProveedor()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.textBoxRazonSocial, "Ingrese Razón Social del Proveedor");
            this.toolTipMensaje.SetToolTip(this.textBoxNumDoc, "Ingrese Número de Documento del Proveedor");
            this.toolTipMensaje.SetToolTip(this.textBoxDireccion, "Ingrese la dirección del Proveedor");
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
            this.textBoxRazonSocial.Text = string.Empty;
            this.textBoxNumDoc.Text = string.Empty;
            this.textBoxDireccion.Text = string.Empty;
            this.textBoxTelefono.Text = string.Empty;
            this.textBoxUrl.Text = string.Empty;
            this.textBoxEmail.Text = string.Empty;
            this.textBoxIdProveedor.Text = string.Empty;
        }

        // Habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.textBoxRazonSocial.ReadOnly = !valor;
            this.textBoxDireccion.ReadOnly = !valor;
            this.textBoxNumDoc.ReadOnly = !valor;
            this.textBoxTelefono.ReadOnly = !valor;
            this.textBoxUrl.ReadOnly = !valor;
            this.textBoxEmail.ReadOnly = !valor;
            this.textBoxIdProveedor.ReadOnly = !valor;

            this.comboBoxTipoDoc.Enabled = valor;
            this.comboBoxSectorComercial.Enabled = valor;
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
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 idproveedor, 2 razon_social ...
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna Idproveedor
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CProveedor.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarRazon_Social
        private void BuscarRazon_Social()
        {
            this.dataGridViewListado.DataSource = CProveedor.BuscarRazon_Social(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataGridViewListado.DataSource = CProveedor.BuscarNum_Documento(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Botones();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (comboBoxBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
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
                            Rpta = CProveedor.Eliminar(Convert.ToInt32(Codigo));

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

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.textBoxRazonSocial.Focus();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
// En comboboxes tipo documento y sector comercial siempre va a haber algún dato, nunca va a estar vacío, luego no hace falta comprobar
                if (this.textBoxRazonSocial.Text == string.Empty || textBoxNumDoc.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorProviderIcono.Clear();
                    errorProviderIcono.SetError(textBoxRazonSocial, "Ingrese un Valor");
                    errorProviderIcono.SetError(textBoxNumDoc, "Ingrese un Valor");
                    // Hacer lo mismo con direccion?, en SQL Server permito que sea NULO
//                    errorProviderIcono.SetError(textBoxDireccion, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo) // Nuevo, insertamos
                    {
                        rpta = CProveedor.Insertar(this.textBoxRazonSocial.Text.Trim().ToUpper(),
                                            this.comboBoxSectorComercial.Text.Trim(), this.comboBoxTipoDoc.Text.Trim(),
                                            this.textBoxNumDoc.Text.Trim(), this.textBoxDireccion.Text.Trim(),
                                            this.textBoxTelefono.Text.Trim(), this.textBoxEmail.Text.Trim(),
                                            this.textBoxUrl.Text.Trim());
                    }
                    else // No es nuevo, se va a EDITAR
                    {
                        rpta = CProveedor.Editar(Convert.ToInt32(textBoxIdProveedor.Text), this.textBoxRazonSocial.Text.Trim().ToUpper(),
                                            this.comboBoxSectorComercial.Text.Trim(), this.comboBoxTipoDoc.Text.Trim(),
                                            this.textBoxNumDoc.Text.Trim(), this.textBoxDireccion.Text.Trim(),
                                            this.textBoxTelefono.Text.Trim(), this.textBoxEmail.Text.Trim(),
                                            this.textBoxUrl.Text.Trim());
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
                this.Botones();
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
            if (!this.textBoxIdProveedor.Text.Equals(""))
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
            this.textBoxIdProveedor.Text = this.dataGridViewListado.CurrentRow.Cells["idproveedor"].Value.ToString();
            this.textBoxRazonSocial.Text = this.dataGridViewListado.CurrentRow.Cells["razon_social"].Value.ToString();
            this.comboBoxSectorComercial.Text = this.dataGridViewListado.CurrentRow.Cells["sector_comercial"].Value.ToString();
            this.comboBoxTipoDoc.Text = this.dataGridViewListado.CurrentRow.Cells["tipo_documento"].Value.ToString();
            this.textBoxNumDoc.Text = this.dataGridViewListado.CurrentRow.Cells["num_documento"].Value.ToString();
            this.textBoxDireccion.Text = this.dataGridViewListado.CurrentRow.Cells["direccion"].Value.ToString();
            this.textBoxTelefono.Text = this.dataGridViewListado.CurrentRow.Cells["telefono"].Value.ToString();
            this.textBoxEmail.Text = this.dataGridViewListado.CurrentRow.Cells["email"].Value.ToString();
            this.textBoxUrl.Text = this.dataGridViewListado.CurrentRow.Cells["url"].Value.ToString();

            this.tabControl1.SelectedIndex = 1; // tab Mantenimiento
        }
    }
}
