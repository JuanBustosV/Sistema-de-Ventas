using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Comunicar con Datos sql y capa Modelo
using System.Data;
using CapaModelo;

namespace CapaControlador
{
    public class CIngreso
    {
        // Método Insertar que llama al método Insertar de la clase MIngreso
        // de la CapaModelo
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha,
                string tipo_comprobante, string serie, string correlativo, decimal iva, string estado,
                DataTable dtDetalles)
        {
            MIngreso Obj = new MIngreso
            {
                Idtrabajador = idtrabajador,
                Idproveedor = idproveedor,
                Fecha = fecha,
                Tipo_Comprobante = tipo_comprobante,
                Serie = serie,
                Correlativo = correlativo,
                Iva = iva,
                Estado = estado
            };

            List<MDetalle_Ingreso> lDetalles = new List<MDetalle_Ingreso>();

            foreach (DataRow row in dtDetalles.Rows)
            {
                MDetalle_Ingreso detalle = new MDetalle_Ingreso
                {
                    Idarticulo = Convert.ToInt32(row["idarticulo"].ToString()),
                    Precio_Compra = Convert.ToDecimal(row["precio_compra"].ToString()),
                    Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString()),
                    Stock_Inicial = Convert.ToInt32(row["stock_inicial"].ToString()),
                    Stock_Actual = Convert.ToInt32(row["stock_inicial"].ToString()),
                    Fecha_Produccion = Convert.ToDateTime(row["fecha_produccion"].ToString()),
                    Fecha_Vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString())
                };

                lDetalles.Add(detalle);
            }

            return Obj.Insertar(Obj, lDetalles);
        }

        // Método Anular que llama al método Anular de la clase MIngreso
        // de la CapaModelo
        public static string Anular(int idingreso)
        {
            MIngreso Obj = new MIngreso
            {
                Idingreso = idingreso
            };

            return Obj.Anular(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MIngresso
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MIngreso().Mostrar();
        }

        // Método BuscarFechas que llama al método BuscarFechas de la clase MIngreso
        // de la CapaModelo
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            MIngreso Obj = new MIngreso();            

            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        // Método BuscarFechas que llama al método BuscarFechas de la clase MIngreso
        // de la CapaModelo
        public static DataTable MostrarDetalle(string textobuscar)
        {
            MIngreso Obj = new MIngreso();

            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
