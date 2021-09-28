using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Models
{
    public class ReporteCompra
    {
        public String nombreCliente { get; set; }
        public DateTime fechaCompra { get; set; }
        public String nombreProducto { get; set; }
        public int cantidadProducto { get; set; }
        public int precioProducto { get; set; }
        public int totalProducto { get; set; }
    }
}