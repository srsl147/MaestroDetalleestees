using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class Clase_OrdenVista
    {
        public ClaseCliente_Orden ClaseCliente { set; get; }

        public ClaseProductoOrden Titulo { set; get; }

        public List<ClaseProductoOrden> ClaseProducto { set; get; }
    }
}