using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Conectar capa Controlador
using CapaControlador;

namespace CapaVista
{
    public partial class FrmVistaCategoria_Articulo : Form
    {
        public FrmVistaCategoria_Articulo()
        {
            InitializeComponent();
        }

        // Método para ocultar columnas, hacer el select del procedimiento mostrarcategoria SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 Idcategoria, 2 Nombre, 3 Descripcion
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar
            this.dataGridViewListado.Columns[1].Visible = false; // Columna Idcategoría
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CCategoria.Mostrar();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        // Método Buscar Nombre
        private void BuscarNombre()
        {
            this.dataGridViewListado.DataSource = CCategoria.BuscarNombre(textBoxBuscar.Text);
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void FrmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            FrmArticulo form = FrmArticulo.GetInstancia();

            string pIdcategoria, pNombre;
            // En Cells van los nombres tabla categorias en la BD, SQL Server
            pIdcategoria = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idcategoria"].Value);
            pNombre = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["nombre"].Value);

            form.setCategoria(pIdcategoria, pNombre);
            this.Hide();
        }
    }
}
