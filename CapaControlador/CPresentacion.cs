using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Conectar con SQL Server
using CapaModelo;
using System.Data;

namespace CapaControlador
{
    public class CPresentacion
    {
        // Método Insertar que llama al método Insertar de la clase MPresentacion
        // de la CapaModelo
        public static string Insertar(string nombre, string descripcion)
        {
            MPresentacion Obj = new MPresentacion
            {
                Nombre = nombre,
                Descripcion = descripcion
            };

            /*
            MCategoria Obj = new MCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            */
            return Obj.Insertar(Obj);
        }

        // Método Editar que llama al método Editar de la clase MPresentacion
        // de la CapaModelo
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            MPresentacion Obj = new MPresentacion();
            Obj.Idpresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        // Método Eliminar que llama al método Eliminar de la clase MPresentacion
        // de la CapaModelo
        public static string Eliminar(int idpresentacion)
        {
            MPresentacion Obj = new MPresentacion();
            Obj.Idpresentacion = idpresentacion;

            return Obj.Eliminar(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MPresentacion
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MPresentacion().Mostrar();
        }

        // Método BuscarNombre que llama al método BuscarNombre de la clase MPresentacion
        // de la CapaModelo
        public static DataTable BuscarNombre(string textobuscar)
        {
            MPresentacion Obj = new MPresentacion();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNombre(Obj);
        }
    }
}
