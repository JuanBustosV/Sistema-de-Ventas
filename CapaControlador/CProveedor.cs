using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Conectar con capa Modelo
using CapaModelo;
using System.Data;

namespace CapaControlador
{
    public class CProveedor // Todos los métodos son STATIC
    {
        // Método Insertar que llama al método Insertar de la clase MProveedor
        // de la CapaModelo
        public static string Insertar(string razon_social, string sector_comercial, string tipo_documento, string num_documento,
                                string direccion, string telefono, string email, string url)
        {
            MProveedor Obj = new MProveedor
            {
                Razon_Social = razon_social,
                Sector_Comercial = sector_comercial,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Url = url
            };

            return Obj.Insertar(Obj);
        }

        // Método Editar que llama al método Editar de la clase MProveedor
        // de la CapaModelo
        public static string Editar(int idproveedor, string razon_social, string sector_comercial, string tipo_documento, string num_documento,
                                string direccion, string telefono, string email, string url)
        {
            MProveedor Obj = new MProveedor
            {
                Idproveedor = idproveedor,
                Razon_Social = razon_social,
                Sector_Comercial = sector_comercial,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Url = url
            };

            return Obj.Editar(Obj);
        }

        // Método Eliminar que llama al método Eliminar de la clase MProveedor
        // de la CapaModelo
        public static string Eliminar(int idproveedor)
        {
            MProveedor Obj = new MProveedor
            {
                Idproveedor = idproveedor
            };

            return Obj.Eliminar(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MProveedor
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MProveedor().Mostrar();
        }

        // Método BuscarRazon_Social que llama al método BuscarRazon_Social de la clase MProveedor
        // de la CapaModelo
        public static DataTable BuscarRazon_Social(string textobuscar)
        {
            MProveedor Obj = new MProveedor
            {
                TextoBuscar = textobuscar
            };

            return Obj.BuscarRazon_Social(Obj);
        }

        // Método BuscarNum_Documento que llama al método BuscarNum_Documento de la clase MProveedor
        // de la CapaModelo
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            MProveedor Obj = new MProveedor
            {
                TextoBuscar = textobuscar
            };

            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
