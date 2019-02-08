using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// conectar con capa Modelo y conectar con SQL
using CapaModelo;
using System.Data;

namespace CapaControlador
{
    public class CArticulo  // Todos los métodos son STATIC!
    {
        // Método Insertar que llama al método Insertar de la clase MArticulo
        // de la CapaModelo
        public static string Insertar(string codigo, string nombre, string descripcion,
                                byte[] imagen, int idcategoria, int idpresentacion)
        {
            MArticulo Obj = new MArticulo
            {
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = descripcion,
                Imagen = imagen,
                Idcategoria = idcategoria,
                Idpresentacion = idpresentacion
            };

            /*
            MArticulo Obj = new MArticulo();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            */
            return Obj.Insertar(Obj);
        }

        // Método Editar que llama al método Editar de la clase MArticulo
        // de la CapaModelo
        public static string Editar(int idarticulo, string codigo, string nombre, string descripcion,
                                byte[] imagen, int idcategoria, int idpresentacion)
        {
            MArticulo Obj = new MArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;

            return Obj.Editar(Obj);
        }

        // Método Eliminar que llama al método Eliminar de la clase MArticulo
        // de la CapaModelo
        public static string Eliminar(int idarticulo)
        {
            MArticulo Obj = new MArticulo();
            Obj.Idarticulo = idarticulo;

            return Obj.Eliminar(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MArticulo
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MArticulo().Mostrar();
        }

        // Método BuscarNombre que llama al método BuscarNombre de la clase MArticulo
        // de la CapaModelo
        public static DataTable BuscarNombre(string textobuscar)
        {
            MArticulo Obj = new MArticulo();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNombre(Obj);
        }
    }
}
