using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            labelHora.Text = DateTime.Now.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToString();
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = CapaControlador.CTrabajador.Login(this.textBoxUsuario.Text, this.textBoxPassword.Text);
            // Evaluar si existe el Usuario
            if (Datos.Rows.Count == 0)
            {
                MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmPrincipalMDI frm = new FrmPrincipalMDI();
                frm.Idtrabajador = Datos.Rows[0][0].ToString(); // orden columnas que sale en el splogin SQL Server
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();

                frm.Show();
                this.Hide();
            }
        }
    }
}
