using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITecsup.Models.Request
{
    public class ProductoRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double PrecioVenta { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}