using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// capa Modelo
using CapaModelo;
using System.Data;

namespace CapaControlador
{
    public class CVenta
    {
        // Método Insertar que llama al método Insertar de la clase MVenta
        // de la CapaModelo
        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha,
                string tipo_comprobante, string serie, string correlativo, decimal iva, 
                DataTable dtDetalles)
        {
            MVenta Obj = new MVenta // Cabecera de la venta
            {
                Idcliente = idcliente,
                Idtrabajador = idtrabajador,
                Fecha = fecha,
                Tipo_Comprobante = tipo_comprobante,
                Serie = serie,
                Correlativo = correlativo,
                Iva = iva,                
            };

            List<MDetalle_Venta> lDetalles = new List<MDetalle_Venta>();

            foreach (DataRow row in dtDetalles.Rows)
            {
                MDetalle_Venta detalle = new MDetalle_Venta
                {
                    Iddetalle_Ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString()),
                    Cantidad = Convert.ToInt32(row["cantidad"].ToString()),
                    Precio_Venta = Convert.ToDecimal(row["precio_venta"].ToString()),
                    Descuento = Convert.ToDecimal(row["descuento"].ToString()),
                };

                lDetalles.Add(detalle);
            }

            return Obj.Insertar(Obj, lDetalles);
        }

        // Método Eliminar que llama al método Eliminar de la clase MVenta
        // de la CapaModelo
        public static string Eliminar(int idventa)
        {
            MVenta Obj = new MVenta
            {
                Idventa = idventa
            };

            return Obj.Eliminar(Obj);
        }

        // Método Mostrar que llama al método Mostrar de la clase MVenta
        // de la CapaModelo
        public static DataTable Mostrar()
        {
            return new MVenta().Mostrar();
        }

        // Método BuscarFechas que llama al método BuscarFechas de la clase MVenta
        // de la CapaModelo
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            MVenta Obj = new MVenta();

            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        // Método BuscarFechas que llama al método BuscarFechas de la clase MVenta
        // de la CapaModelo
        public static DataTable MostrarDetalle(string textobuscar)
        {
            MVenta Obj = new MVenta();

            return Obj.MostrarDetalle(textobuscar);
        }

        // Método BuscarArticulo_Venta_Nombre que llama al método BuscarArticulo_Venta_Nombre de la clase MVenta
        // de la CapaModelo
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            MVenta Obj = new MVenta();

            return Obj.MostrarArticulo_Venta_Nombre(textobuscar);
        }

        // Método BuscarArticulo_Venta_Codigo que llama al método BuscarArticulo_Venta_Codigo de la clase MVenta
        // de la CapaModelo
        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            MVenta Obj = new MVenta();

            return Obj.MostrarArticulo_Venta_Codigo(textobuscar);
        }
    }
}
