using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// sql
using System.Data;
using System.Data.SqlClient;

namespace CapaModelo
{
    public class MIngreso
    {
        // Variables
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Iva; // Igv
        private string _Estado;

        // Propiedades

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Iva { get => _Iva; set => _Iva = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        // Constructores
        public MIngreso()
        {

        }

        public MIngreso(int idingreso, int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante,
                string serie, string correlativo, decimal iva, string estado)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Iva = iva;
            this.Estado = estado;
        }
        // Métodos
        // Método Insertar
        public string Insertar(MIngreso Ingreso, List<MDetalle_Ingreso> Detalle)
        {
            string rpta = ""; // Respuesta
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                // Código
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCon.Open();
                // ESTABLECER LA TRANSACCIÓN
                SqlTransaction SqlTrans = SqlCon.BeginTransaction(); // para hacer una transacción única con todos los detalles

                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand // Ojo UNICO caso SIMPLIFICADO, ver las otras funciones
                {
                    Connection = SqlCon,
                    Transaction = SqlTrans,
                    CommandText = "spinsertar_ingreso", // Procedimiento almacenado en SQL Server
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

                SqlParameter ParIdIngreso = new SqlParameter
                {
                    ParameterName = "@idingreso", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // valor se autogenera al insertar
                };
                SqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdTrabajador = new SqlParameter
                {
                    ParameterName = "@idtrabajador",
                    SqlDbType = SqlDbType.Int,                    
                    Value = Ingreso.Idtrabajador     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParIdProveedor = new SqlParameter
                {
                    ParameterName = "@idproveedor",
                    SqlDbType = SqlDbType.Int,
                    Value = Ingreso.Idproveedor
                };
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFecha = new SqlParameter
                {
                    ParameterName = "@fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = Ingreso.Fecha
                };
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_Comprobante = new SqlParameter
                {
                    ParameterName = "@tipo_comprobante",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Ingreso.Tipo_Comprobante
                };
                SqlCmd.Parameters.Add(ParTipo_Comprobante);

                SqlParameter ParSerie = new SqlParameter
                {
                    ParameterName = "@serie",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4,
                    Value = Ingreso.Serie
                };
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter
                {
                    ParameterName = "@correlativo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 7,
                    Value = Ingreso.Correlativo
                };
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIva = new SqlParameter
                {
                    ParameterName = "@igv",
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 4,
                    Scale = 2,  // Decímales
                    Value = Ingreso.Iva
                };
                SqlCmd.Parameters.Add(ParIva);

                SqlParameter ParEstado = new SqlParameter
                {
                    ParameterName = "@estado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 7,
                    Value = Ingreso.Estado
                };
                SqlCmd.Parameters.Add(ParEstado);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingresó el Registro";

                // INSERTAMOS LOS DETALLES
                if (rpta.Equals("OK"))
                {
                    // Obtener el código del ingreso generado
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@idingreso"].Value);

                    foreach (MDetalle_Ingreso det in Detalle)
                    {
                        det.Idingreso = this.Idingreso;
                        // LLamar al método insertar de la clase MDetalle_Ingreso
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTrans);
                        if (!rpta.Equals("OK"))
                        {
                            break; // salgo del foreach
                        }
                    }
                }
                if (rpta.Equals("OK")) {
                    SqlTrans.Commit();      // Confirma y realiza la inserción Ingreso y detalles
                }
                else
                {
                    SqlTrans.Rollback();    // Aborto la inserción del Ingreso y sus detalles
                }
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

        // Método Anular
        public string Anular(MIngreso Ingreso)
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
                    CommandText = "spanular_ingreso", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdIngreso = new SqlParameter
                {
                    ParameterName = "@idingreso", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Ingreso.Idingreso
                };
                SqlCmd.Parameters.Add(ParIdIngreso);

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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_ingreso",
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

        // Método BuscarFechas
        public DataTable BuscarFechas(string TextoBuscar, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_ingreso_fecha",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene dos parámetros
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter
                {
                    ParameterName = "@textobuscar2",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = TextoBuscar2
                };
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Método MostrarDetalle
        public DataTable MostrarDetalle(String TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_detalle_ingreso",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene 1 parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = TextoBuscar
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
