using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Para conexion a DB
using System.Data;
using System.Data.SqlClient;

namespace CapaModelo
{
    public class MCategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;

        private string _TextoBuscar;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }

        public string Nombre { get => _Nombre; set => _Nombre = value; }

        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        // Constructor Vacío
        public MCategoria()
        {

        }

        // Constructor con parámetros
        public MCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }

        // Método Insertar
        public string Insertar(MCategoria Categoria)
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
                    CommandText = "spinsertar_categoria", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };
                /* ANTES
                 * 
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                 * 
                */

                SqlParameter ParIdcategoria = new SqlParameter
                {
                    ParameterName = "@idcategoria", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // valor se autogenera al insertar
                };
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter
                {
                    ParameterName = "@nombre",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Categoria.Nombre     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter
                {
                    ParameterName = "@descripcion",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 256,
                    Value = Categoria.Descripcion
                };
                SqlCmd.Parameters.Add(ParDescripcion);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingresó el Registro";

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
        public string Editar(MCategoria Categoria)
        {
            string rpta = ""; // Respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Código
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCon.Open();
                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria"; // Procedimiento almacenado en SQL Server
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria"; // <- Nombre variable en el procedimiento almacenado SQL Server
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Categoria.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Categoria.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

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
        public string Eliminar(MCategoria Categoria)
        {
            string rpta = ""; // Respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Código
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCon.Open();
                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_categoria"; // Procedimiento almacenado en SQL Server
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoria = new SqlParameter();
                ParIdcategoria.ParameterName = "@idcategoria"; // <- Nombre variable en el procedimiento almacenado SQL Server
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = Categoria.Idcategoria;
                SqlCmd.Parameters.Add(ParIdcategoria);

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
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Método BuscarNombre
        public DataTable BuscarNombre(MCategoria Categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                // el procedimiento tiene un parámetro
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
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
