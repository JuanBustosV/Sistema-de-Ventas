using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Conexión SQL Server
using System.Data.SqlClient;
using System.Data;

namespace CapaModelo
{
    public class MDetalle_Venta
    {
        // Atributos
        private int _Iddetalle_Venta;
        private int _Idventa;
        private int _Iddetalle_Ingreso;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Descuento;


        // Propiedades
        public int Iddetalle_Venta { get => _Iddetalle_Venta; set => _Iddetalle_Venta = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Iddetalle_Ingreso { get => _Iddetalle_Ingreso; set => _Iddetalle_Ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }

        // Construcctores
        public MDetalle_Venta()
        {

        }

        public MDetalle_Venta(int iddetalle_venta,int idventa, int iddetalle_ingreso,
                    int cantidad, decimal precio_venta, decimal descuento)
        {
            Iddetalle_Venta = iddetalle_venta;
            Idventa = idventa;
            Iddetalle_Ingreso = iddetalle_ingreso;
            Cantidad = cantidad;
            Precio_Venta = precio_venta;
            Descuento = descuento;
        }

        // Método Insertar
        public string Insertar(MDetalle_Venta Detalle_Venta,
            ref SqlConnection SqlCon, ref SqlTransaction SqlTrans)
        {
            string rpta = ""; // Respuesta
            try
            {
                // Establecer el Comando SQL
                SqlCommand SqlCmd = new SqlCommand // Ojo UNICO caso SIMPLIFICADO, ver las otras funciones
                {
                    Connection = SqlCon,
                    Transaction = SqlTrans,
                    CommandText = "spinsertar_detalle_venta", // Procedimiento almacenado en SQL Server
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter ParIdDetalle_Venta = new SqlParameter
                {
                    ParameterName = "@iddetalle_venta", // <- Nombre variable en el procedimiento almacenado SQL Server
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output // valor se autogenera al insertar
                };
                SqlCmd.Parameters.Add(ParIdDetalle_Venta);

                SqlParameter ParIdVenta = new SqlParameter
                {
                    ParameterName = "@idventa",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Venta.Idventa     // Establezco valor del parámetro para la BD
                };
                SqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdDetalle_Ingreso = new SqlParameter
                {
                    ParameterName = "@iddetalle_ingreso",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Venta.Iddetalle_Ingreso
                };
                SqlCmd.Parameters.Add(ParIdDetalle_Ingreso);

                SqlParameter ParCantidad = new SqlParameter
                {
                    ParameterName = "@cantidad",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Venta.Cantidad
                };
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecio_Venta = new SqlParameter
                {
                    ParameterName = "@precio_venta",
                    SqlDbType = SqlDbType.Money,
                    Value = Detalle_Venta.Precio_Venta
                };
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParDescuento = new SqlParameter
                {
                    ParameterName = "@descuento",
                    SqlDbType = SqlDbType.Int,
                    Value = Detalle_Venta.Descuento
                };
                SqlCmd.Parameters.Add(ParDescuento);                

                // Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se Ingresó el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            // UN INGRESO TENDRÁ UNO O MÁS DETALLES, DETALLE NI ABRE NI CIERRA LA CONEXIÓN            

            return rpta;
        }
    }
}
