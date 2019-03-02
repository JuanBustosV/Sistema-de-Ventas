using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// comunicar capa Controlador
using CapaControlador;

namespace CapaVista.Consultas
{
    public partial class FrmConsulta_Stock_Articulos : Form
    {
        public FrmConsulta_Stock_Articulos()
        {
            InitializeComponent();
        }

        // Método para ocultar columnas, hacer el select del procedimiento spmostrar_articulo SQL Server
        // Para ver las Columnas, que serían al final: 0 Eliminar, 1 idarticulo, 2 codigo, 3 Nombre...
        private void OcultarColumnas()
        {
            this.dataGridViewListado.Columns[0].Visible = false; // Columna Eliminar            
        }

        // Método Mostrar 
        private void Mostrar()
        {
            this.dataGridViewListado.DataSource = CArticulo.StockArticulos();
            this.OcultarColumnas();
            labelTotal.Text = "Total de Registros: " + dataGridViewListado.Rows.Count;
        }

        private void FrmConsulta_Stock_Articulos_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
    }
}
