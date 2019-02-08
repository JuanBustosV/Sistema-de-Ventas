using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Para conexion a DB
using CapaModelo;
using System.Data;

namespace CapaControlador
{
    public class CCategoria
    {
        // Método Insertar que llama al método Insertar de la clase MCategoria
        // de la CapaModelo
        public static string Insertar(string nombre, string descripcion)
        {
            MCategoria Obj = new MCategoria
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

        // Método Editar que llama al método Editar de la clase MCategoria
        // de la CapaModelo
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            MCategoria Obj = new MCategoria();
            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        // Método Eliminar que llama al método Eliminar de la clase MCategoria
        // de la CapaModelo
        public static string Eliminar(int idcategoria)
        {
            MCategoria Obj = new MCategoria();
            Obj.Idcategoria = idcategoria;

            return Obj.Eliminar(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MCategoria
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MCategoria().Mostrar();
        }

        // Método BuscarNombre que llama al método BuscarNombre de la clase MCategoria
        // de la CapaModelo
        public static DataTable BuscarNombre(string textobuscar)
        {
            MCategoria Obj = new MCategoria();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNombre(Obj);
        }
    }
}
