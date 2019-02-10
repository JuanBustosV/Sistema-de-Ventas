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
    public partial class FrmVistaProveedor_Ingreso : Form
    {
        public FrmVistaProveedor_Ingreso()
        {
            InitializeComponent();
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

        private void FrmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
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

        private void dataGridViewListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngreso frm = FrmIngreso.GetInstancia();
            string idproveedor, nombre;

            idproveedor = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["idproveedor"].Value);
            nombre = Convert.ToString(this.dataGridViewListado.CurrentRow.Cells["razon_social"].Value);

            frm.setProveedor(idproveedor, nombre);
            this.Hide();
        }
    }
}
