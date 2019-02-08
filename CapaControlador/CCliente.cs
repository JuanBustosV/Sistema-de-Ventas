using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Para clases de SQL y uso de la capa Modelo
using System.Data;
using CapaModelo;

namespace CapaControlador
{
    public class CCliente
    {
        // Métodos (statics) para comunicarnos con la capa modelo
        // Método Insertar que llama al método Insertar de la clase MCliente
        // de la CapaModelo
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                    string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            MCliente Obj = new MCliente
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Sexo = sexo,
                Fecha_Nacimiento = fecha_nacimiento,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };

            return Obj.Insertar(Obj);
        }

        // Método Editar que llama al método Editar de la clase MCliente
        // de la CapaModelo
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                    string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            MCliente Obj = new MCliente
            {
                Idcliente = idcliente, // No para modificarlo, si para hacer el where
                Nombre = nombre,
                Apellidos = apellidos,
                Sexo = sexo,
                Fecha_Nacimiento = fecha_nacimiento,
                Tipo_Documento = tipo_documento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };

            return Obj.Editar(Obj);
        }

        // Método Eliminar que llama al método Eliminar de la clase MCliente
        // de la CapaModelo
        public static string Eliminar(int idcliente)
        {
            MCliente Obj = new MCliente
            {
                Idcliente = idcliente // Necesario para el Where...
            };

            return Obj.Eliminar(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MCliente
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MCliente().Mostrar();
        }

        // Método BuscarApellidos que llama al método BuscarApellidos de la clase MCliente
        // de la CapaModelo
        public static DataTable BuscarApellidos(string textobuscar)
        {
            MCliente Obj = new MCliente
            {
                TextoBuscar = textobuscar
            };

            return Obj.BuscarApellidos(Obj);
        }

        // Método BuscarNum_Documento que llama al método BuscarNum_Documento de la clase MCliente
        // de la CapaModelo
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            MCliente Obj = new MCliente
            {
                TextoBuscar = textobuscar
            };

            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
