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
    public class MProveedor
    {
        // Variables
        private int _Idproveedor;
        private string _Razon_Social;
        private string _Sector_Comercial;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;

        // Propiedades

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Razon_Social { get => _Razon_Social; set => _Razon_Social = value; }
        public string Sector_Comercial { get => _Sector_Comercial; set => _Sector_Comercial = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        // Constructores
        public MProveedor()
        {

        }

        public MProveedor(int idproveedor, string razon_social, string sector_comercial, string tipo_documento,
                    string num_documento, string direccion, string telefono, string email, string url, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.Razon_Social = razon_social;
            this.Sector_Comercial = sector_comercial;
            this.Tipo_Documento = tipo_documento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Url = url;
            this.TextoBuscar = textobuscar;
        }

        // MÉTODOS

        // Método Insertar
        public string Insertar(MProveedor Proveedor)
        {
            string rpta = ""; // Respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Código
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCon.Open();
                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand // Ojo UNICO caso SIMPLIFICADO, ver las otras funciones
                {
                    Connection = SqlCon,
                    CommandText = "spinsertar_proveedor", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor"; // <- Nombre variable en el procedimiento almacenado SQL Server
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Direction = ParameterDirection.Output; // valor se autogenera al insertar
                SqlCmd.Parameters.Add(ParIdproveedor); // Guarda el ID una vez que se ejecute el procedimiento SQL

                SqlParameter ParRazonSocial = new SqlParameter
                {
                    ParameterName = "@razon_social",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = Proveedor.Razon_Social     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParSectorComercial = new SqlParameter
                {
                    ParameterName = "@sector_comercial",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Proveedor.Sector_Comercial
                };
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter
                {
                    ParameterName = "@tipo_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Proveedor.Tipo_Documento
                };
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter
                {
                    ParameterName = "@num_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 11,
                    Value = Proveedor.Num_Documento
                };
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter
                {
                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Proveedor.Direccion
                };
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 10,
                    Value = Proveedor.Telefono
                };
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Proveedor.Email
                };
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter
                {
                    ParameterName = "@url",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Proveedor.Url
                };
                SqlCmd.Parameters.Add(ParUrl);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingresó el Registro";
                //ParIdproveedor; <- ahora ya guarda el ID del registro insertado, salida procedimiento
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
        public string Editar(MProveedor Proveedor)
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
                    CommandText = "speditar_proveedor", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdproveedor = new SqlParameter
                {
                    ParameterName = "@idproveedor", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Proveedor.Idproveedor
                };
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParRazonSocial = new SqlParameter
                {
                    ParameterName = "@razon_social",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 150,
                    Value = Proveedor.Razon_Social     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParSectorComercial = new SqlParameter
                {
                    ParameterName = "@sector_comercial",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Proveedor.Sector_Comercial
                };
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParTipoDocumento = new SqlParameter
                {
                    ParameterName = "@tipo_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Proveedor.Tipo_Documento
                };
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter
                {
                    ParameterName = "@num_documento",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 11,
                    Value = Proveedor.Num_Documento
                };
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter
                {
                    ParameterName = "@direccion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Proveedor.Direccion
                };
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter
                {
                    ParameterName = "@telefono",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 10,
                    Value = Proveedor.Telefono
                };
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter
                {
                    ParameterName = "@email",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Proveedor.Email
                };
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter
                {
                    ParameterName = "@url",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Proveedor.Url
                };
                SqlCmd.Parameters.Add(ParUrl);

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
        public string Eliminar(MProveedor Proveedor)
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
                    CommandText = "speliminar_proveedor", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdproveedor = new SqlParameter
                {
                    ParameterName = "@idproveedor", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Proveedor.Idproveedor
                };
                SqlCmd.Parameters.Add(ParIdproveedor);

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
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_proveedor",
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

        // Método Buscar Razon Social
        public DataTable BuscarRazon_Social(MProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_proveedor_razon_social",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene un parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Proveedor.TextoBuscar
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
        public DataTable BuscarNum_Documento(MProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_proveedor_num_documento",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene un parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Proveedor.TextoBuscar
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
