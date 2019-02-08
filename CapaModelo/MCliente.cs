using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Conectar SQL Server
using System.Data;
using System.Data.SqlClient;

namespace CapaModelo
{
    public class MCliente
    {
        // Variables
        private int _Idcliente;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;

        // Propiedades Métodos Setter & Getter

        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        // Constructores

        public MCliente()
        {

        }

        public MCliente(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                    string tipo_documento, string num_documento, string direccion, string telefono, string email, string textobuscar)
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }

        // Métodos
        // Método Insertar
        public string Insertar(MCliente Cliente)
        {
            string rpta = ""; // Respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Código
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCon.Open();
                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand // caso SIMPLIFICADO, ver las otras funciones
                {
                    Connection = SqlCon,
                    CommandText = "spinsertar_cliente", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdCliente = new SqlParameter
                {
                    ParameterName = "@idcliente", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // valor se autogenera al insertar
                };
                SqlCmd.Parameters.Add(ParIdCliente); // Guarda el ID una vez que se ejecute el procedimiento SQL

                SqlParameter ParNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Cliente.Nombre     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter
                {
                    ParameterName = "@apellidos",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 40,
                    Value = Cliente.Apellidos
                };
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter
                {
                    ParameterName = "@sexo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1,
                    Value = Cliente.Sexo
                };
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter
                {
                    ParameterName = "@fecha_nacimiento",
                    SqlDbType = SqlDbType.Date,                    
                    Value = Cliente.Fecha_Nacimiento
                };
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParTipoDocumento = new SqlParameter
                {
                    ParameterName = "@tipo_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Cliente.Tipo_Documento
                };
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter
                {
                    ParameterName = "@num_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 11,
                    Value = Cliente.Num_Documento
                };
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter
                {
                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Cliente.Direccion
                };
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 10,
                    Value = Cliente.Telefono
                };
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Cliente.Email
                };
                SqlCmd.Parameters.Add(ParEmail);              

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingresó el Registro";
                //ParIdCliente; <- ahora ya guarda el ID del registro insertado, salida procedimiento
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Método Editar
        public string Editar(MCliente Cliente)
        {
            string rpta = ""; // Respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Código
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCon.Open();
                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "speditar_cliente", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdCliente = new SqlParameter
                {
                    ParameterName = "@idcliente", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Cliente.Idcliente
                };
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Cliente.Nombre     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter
                {
                    ParameterName = "@apellidos",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 40,
                    Value = Cliente.Apellidos
                };
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter
                {
                    ParameterName = "@sexo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1,
                    Value = Cliente.Sexo
                };
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter
                {
                    ParameterName = "@fecha_nacimiento",
                    SqlDbType = SqlDbType.Date,
                    Value = Cliente.Fecha_Nacimiento
                };
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParTipoDocumento = new SqlParameter
                {
                    ParameterName = "@tipo_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Cliente.Tipo_Documento
                };
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter
                {
                    ParameterName = "@num_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 11,
                    Value = Cliente.Num_Documento
                };
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter
                {
                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Cliente.Direccion
                };
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 10,
                    Value = Cliente.Telefono
                };
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Cliente.Email
                };
                SqlCmd.Parameters.Add(ParEmail);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Método Eliminar
        public string Eliminar(MCliente Cliente)
        {
            string rpta = ""; // Respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Código
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCon.Open();
                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "speliminar_cliente", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdCliente = new SqlParameter
                {
                    ParameterName = "@idcliente", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Cliente.Idcliente
                };
                SqlCmd.Parameters.Add(ParIdCliente);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Eliminó el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }

            return rpta;
        }

        // Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_cliente",
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Método Buscar Apellidos
        public DataTable BuscarApellidos(MCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente"); // Pongo nombre de mi datatable "cliente"
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_cliente_apellidos",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene un parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Cliente.TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Método Buscar Num Documento
        public DataTable BuscarNum_Documento(MCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_cliente_num_documento",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene un parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Cliente.TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
