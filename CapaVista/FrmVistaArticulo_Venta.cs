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
    public partial class FrmVistaArticulo_Venta : Form
    {
        public FrmVistaArticulo_Venta()
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


        // Método BuscarNombre
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dataGridViewListado.DataSource = CVenta.MostrarArticulo_Venta_Nombre(this.textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método BuscarCodigo
        private void MostrarArticulo_Venta_Codigo()
        {
            this.dataGridViewListado.DataSource = CVenta.MostrarArticulo_Venta_Codigo(this.textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }


        private void FrmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (comboBoxBuscar.Text.Equals("Codigo"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (comboBoxBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta form = FrmVenta.GetInstancia();
            string iddetalle_ingreso, nombre;
            decimal precio_compra, precio_venta;
            int cantidad;
            DateTime fecha_vencimiento;

            iddetalle_ingreso = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            nombre = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);
            precio_compra = Convert.ToDecimal(this.dataGridViewListado.CurrentRow.Cells["precio_compra"].Value);
            precio_venta = Convert.ToDecimal(this.dataGridViewListado.CurrentRow.Cells["precio_venta"].Value);
            cantidad = Convert.ToInt32(this.dataGridViewListado.CurrentRow.Cells["stock_actual"].Value);
            fecha_vencimiento = Convert.ToDateTime(this.dataGridViewListado.CurrentRow.Cells["fecha_vencimiento"].Value);

            form.setArticulo(iddetalle_ingreso, nombre,precio_compra,precio_venta,cantidad,fecha_vencimiento);
            this.Hide();
        }
    }
}
