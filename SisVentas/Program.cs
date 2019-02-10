using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// 
using CapaVista;

namespace SisVentas
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
// Form principal para mostrar
            Application.Run(new FrmLogin());
        // Probar FrmArticulo es diferente, por desde ahí buscar categorías
 //           Application.Run(FrmArticulo.GetInstancia());
        }
    }
}
