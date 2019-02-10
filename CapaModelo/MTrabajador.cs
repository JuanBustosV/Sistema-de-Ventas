using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Conectar SQL Server y usar objetos de BD
using System.Data;
using System.Data.SqlClient;

namespace CapaModelo
{
    public class MTrabajador
    {
        // atributos
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Password;
        private string _TextoBuscar;

        // Propiedades

        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        // Constructores
        public MTrabajador()
        {

        }

        public MTrabajador(int idtrabajador, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
                    string num_documento, string direccion, string telefono, string email, string acceso,
                    string usuario, string password, string textobuscar)
        {
            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;
        }

        // Métodos

        // Método Insertar
        public string Insertar(MTrabajador Trabajador)
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
                    CommandText = "spinsertar_trabajador", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdTrabajador = new SqlParameter
                {
                    ParameterName = "@idtrabajador", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // valor se autogenera al insertar
                };
                SqlCmd.Parameters.Add(ParIdTrabajador); // Guarda el ID una vez que se ejecute el procedimiento SQL

                SqlParameter ParNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Nombre     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter
                {
                    ParameterName = "@apellidos",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 40,
                    Value = Trabajador.Apellidos
                };
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter
                {
                    ParameterName = "@sexo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1,
                    Value = Trabajador.Sexo
                };
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter
                {
                    ParameterName = "@fecha_nacimiento",
                    SqlDbType = SqlDbType.Date, // Podría ser VarChar y entonces Size = 50;
                    Value = Trabajador.Fecha_Nacimiento
                };
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParNumDocumento = new SqlParameter
                {
                    ParameterName = "@num_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 8,
                    Value = Trabajador.Num_Documento
                };
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter
                {
                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Trabajador.Direccion
                };
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 10,
                    Value = Trabajador.Telefono
                };
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Trabajador.Email
                };
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter
                {
                    ParameterName = "@acceso",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Acceso
                };
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter
                {
                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Usuario
                };
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Password
                };
                SqlCmd.Parameters.Add(ParPassword);

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
        public string Editar(MTrabajador Trabajador)
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
                    CommandText = "speditar_trabajador", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdTrabajador = new SqlParameter
                {
                    ParameterName = "@idtrabajador", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Trabajador.Idtrabajador
                };
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Nombre     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter
                {
                    ParameterName = "@apellidos",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 40,
                    Value = Trabajador.Apellidos
                };
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter
                {
                    ParameterName = "@sexo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1,
                    Value = Trabajador.Sexo
                };
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter
                {
                    ParameterName = "@fecha_nacimiento",
                    SqlDbType = SqlDbType.Date, // Podría ser VarChar y entonces Size = 50;
                    Value = Trabajador.Fecha_Nacimiento
                };
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParNumDocumento = new SqlParameter
                {
                    ParameterName = "@num_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 8,
                    Value = Trabajador.Num_Documento
                };
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter
                {
                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Trabajador.Direccion
                };
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 10,
                    Value = Trabajador.Telefono
                };
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Trabajador.Email
                };
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter
                {
                    ParameterName = "@acceso",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Acceso
                };
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter
                {
                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Usuario
                };
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Password
                };
                SqlCmd.Parameters.Add(ParPassword);

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
        public string Eliminar(MTrabajador Trabajador)
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
                    CommandText = "speliminar_trabajador", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdTrabajador = new SqlParameter
                {
                    ParameterName = "@idtrabajador", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Trabajador.Idtrabajador
                };
                SqlCmd.Parameters.Add(ParIdTrabajador);

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
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_trabajador",
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
        public DataTable BuscarApellidos(MTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador"); // Pongo nombre de mi datatable "cliente"
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_trabajador_apellidos",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene un parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 40,
                    Value = Trabajador.TextoBuscar
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
        public DataTable BuscarNum_Documento(MTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_trabajador_num_documento",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene un parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 40,
                    Value = Trabajador.TextoBuscar
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

        // Método LOGIN
        public DataTable Login(MTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "splogin",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene dos parámetro
                SqlParameter ParUsuario = new SqlParameter
                {
                    ParameterName = "@usuario",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Usuario
                };
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter
                {
                    ParameterName = "@password",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Trabajador.Password
                };
                SqlCmd.Parameters.Add(ParPassword);

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
