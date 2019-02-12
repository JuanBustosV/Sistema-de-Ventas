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
    public partial class FrmVistaCliente_Venta : Form
    {
        public FrmVistaCliente_Venta()
        {
            InitializeComponent();
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

        private void FrmVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            Mostrar();
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

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta form = FrmVenta.GetInstancia();
            string idcliente, nombre;

            idcliente = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idcliente"].Value);
            nombre = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["apellidos"].Value)+" "+
                    Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);

            form.setCliente(idcliente, nombre);
            this.Hide();
        }
    }
}
