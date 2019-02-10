using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Conectar capa  modelo
using System.Data;
using CapaModelo;

namespace CapaControlador
{
    public class CTrabajador
    {
        // Métodos (statics) para comunicarnos con la capa modelo
        // Método Insertar que llama al método Insertar de la clase MTrabajador
        // de la CapaModelo
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                    string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            MTrabajador Obj = new MTrabajador
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Sexo = sexo,
                Fecha_Nacimiento = fecha_nacimiento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Acceso = acceso,
                Usuario = usuario,
                Password = password               
            };

            return Obj.Insertar(Obj);
        }

        // Método Editar que llama al método Editar de la clase MTrabajador
        // de la CapaModelo
        public static string Editar(int idtrabajador, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                     string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            MTrabajador Obj = new MTrabajador
            {
                Idtrabajador = idtrabajador, // No para modificarlo, si para hacer el where
                Nombre = nombre,
                Apellidos = apellidos,
                Sexo = sexo,
                Fecha_Nacimiento = fecha_nacimiento,
                Num_Documento = num_documento,
                Direccion = direccion,
                Telefono = telefono,
                Email = email,
                Acceso = acceso,
                Usuario = usuario,
                Password = password
            };

            return Obj.Editar(Obj);
        }

        // Método Eliminar que llama al método Eliminar de la clase MTrabajador
        // de la CapaModelo
        public static string Eliminar(int idtrabajador)
        {
            MTrabajador Obj = new MTrabajador
            {
                Idtrabajador = idtrabajador // Necesario para el Where...
            };

            return Obj.Eliminar(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MTrabajador
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MTrabajador().Mostrar(); // select top 100, sin parámetros
        }

        // Método BuscarApellidos que llama al método BuscarApellidos de la clase MTrabajador
        // de la CapaModelo
        public static DataTable BuscarApellidos(string textobuscar)
        {
            MTrabajador Obj = new MTrabajador
            {
                TextoBuscar = textobuscar
            };

            return Obj.BuscarApellidos(Obj);
        }

        // Método BuscarNum_Documento que llama al método BuscarNum_Documento de la clase MTrabajador
        // de la CapaModelo
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            MTrabajador Obj = new MTrabajador
            {
                TextoBuscar = textobuscar
            };

            return Obj.BuscarNum_Documento(Obj);
        }

        // Método Login que llama al método Login de la clase MTrabajador
        // de la CapaModelo
        public static DataTable Login(string usuario, string password)
        {
            MTrabajador Obj = new MTrabajador
            {
                Usuario = usuario,
                Password = password
            };

            return Obj.Login(Obj);
        }
    }
}
