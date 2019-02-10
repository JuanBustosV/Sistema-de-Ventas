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
    public partial class FrmVistaArticulo_Ingreso : Form
    {
        public FrmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }

        // Método para ocultar columnas, hacer el select del procedimiento spmostrar_articulo SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 idarticulo, 2 codigo, 3 Nombre...
        private void OcultarColumnas()
        {
            //this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Idarticulo
            this.dataGridViewListado.Columns[5].Visible = false; // Columna idcategoria
            this.dataGridViewListado.Columns[7].Visible = false; // Columna idpresentacion
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

        private void FrmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngreso form = FrmIngreso.GetInstancia();
            string idarticulo, nombre;

            idarticulo = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idarticulo"].Value);
            nombre = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);

            form.setArticulo(idarticulo, nombre);
            this.Hide();        
        }
    }
}
