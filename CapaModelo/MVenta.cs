using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// SQL
using System.Data;
using System.Data.SqlClient;

namespace CapaModelo
{
    public class MVenta
    {
        // Atributos
        private int _Idventa;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Iva;

        // Propiedades
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Iva { get => _Iva; set => _Iva = value; }

        // Constructores
        public MVenta()
        {

        }

        public MVenta(int idventa, int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante,
                    string serie, string correlativo, decimal iva)
        {
            Idventa = idventa;
            Idcliente = idcliente;
            Idtrabajador = idtrabajador;
            Fecha = fecha;
            Tipo_Comprobante = tipo_comprobante;
            Serie = serie;
            Correlativo = correlativo;
            Iva = iva;
        }

        // Métodos
        // Método Disminuir Stock
        public string DisminuirStock(int iddetalle_ingreso, int cantidad)
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
                    CommandText = "spdisminuir_stock", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdDetalle_Ingreso = new SqlParameter
                {
                    ParameterName = "@iddetalle_ingreso", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = iddetalle_ingreso
                };
                SqlCmd.Parameters.Add(ParIdDetalle_Ingreso);

                SqlParameter ParCantidad = new SqlParameter
                {
                    ParameterName = "@cantidad", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = cantidad             
                };
                SqlCmd.Parameters.Add(ParCantidad);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Actualizó el Stock";

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

        // Método Insertar
        public string Insertar(MVenta Venta, List<MDetalle_Venta> Detalle)
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
                SqlCommand SqlCmd = new SqlCommand 
                {
                    Connection = SqlCon,
                    Transaction = SqlTrans,
                    CommandText = "spinsertar_venta", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdVenta = new SqlParameter
                {
                    ParameterName = "@idventa", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // valor se autogenera al insertar
                };
                SqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter
                {
                    ParameterName = "@idcliente",
                    SqlDbType = SqlDbType.Int,
                    Value = Venta.Idcliente
                };
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdTrabajador = new SqlParameter
                {
                    ParameterName = "@idtrabajador",
                    SqlDbType = SqlDbType.Int,
                    Value = Venta.Idtrabajador     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParIdTrabajador);                

                SqlParameter ParFecha = new SqlParameter
                {
                    ParameterName = "@fecha",
                    SqlDbType = SqlDbType.Date,
                    Value = Venta.Fecha
                };
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipo_Comprobante = new SqlParameter
                {
                    ParameterName = "@tipo_comprobante",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 20,
                    Value = Venta.Tipo_Comprobante
                };
                SqlCmd.Parameters.Add(ParTipo_Comprobante);

                SqlParameter ParSerie = new SqlParameter
                {
                    ParameterName = "@serie",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 4,
                    Value = Venta.Serie
                };
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter
                {
                    ParameterName = "@correlativo",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 7,
                    Value = Venta.Correlativo
                };
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIva = new SqlParameter
                {
                    ParameterName = "@igv",
                    SqlDbType = SqlDbType.Decimal,
                    Precision = 4,
                    Scale = 2,  // Decímales
                    Value = Venta.Iva
                };
                SqlCmd.Parameters.Add(ParIva);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingresó el Registro";

                // INSERTAMOS LOS DETALLES
                if (rpta.Equals("OK"))
                {
                    // Obtener el código del ingreso generado
                    this.Idventa = Convert.ToInt32(SqlCmd.Parameters["@idventa"].Value);

                    foreach (MDetalle_Venta det in Detalle)
                    {
                        det.Idventa = this.Idventa;
                        // LLamar al método insertar de la clase MDetalle_Venta
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTrans);
                        if (!rpta.Equals("OK"))
                        {
                            break; // salgo del foreach
                        }
                        else
                        {
                            // ACTUALIZAMOS EL STOCK
                            rpta = DisminuirStock(det.Iddetalle_Ingreso, det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
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
        // Método Eliminar
        public string Eliminar(MVenta Venta)
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
                    CommandText = "speliminar_venta", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdVenta = new SqlParameter
                {
                    ParameterName = "@idventa", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Value = Venta.Idventa
                };
                SqlCmd.Parameters.Add(ParIdVenta);

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK"; // Trigger

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
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_venta",
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
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscar_venta_fecha",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene dos parámetros
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter
                {
                    ParameterName = "@textobuscar2",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
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
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spmostrar_detalle_venta",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene 1 parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch //(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Mostrar artículos por su nombre
        public DataTable MostrarArticulo_Venta_Nombre(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("articulos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscararticulo_venta_nombre",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene 1 parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch //(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        // Mostrar artículos por su Código
        public DataTable MostrarArticulo_Venta_Codigo(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("articulos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = ConexionDB.Cn;
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,
                    CommandText = "spbuscararticulo_venta_codigo",
                    CommandType = CommandType.StoredProcedure
                };

                // el procedimiento tiene 1 parámetro
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@textobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch //(Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
