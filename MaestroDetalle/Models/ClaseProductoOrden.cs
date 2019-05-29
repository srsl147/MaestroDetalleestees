using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class ClaseProductoOrden:ClaseProducto
    {
     
    

        [Display(Name = "CANTIDAD")]
        public int Cantidad_ClasDetOrd { set; get; }

        [Display(Name = "PRECIO PARCIAL")]
        public decimal parcial { get { return Unitprice_Producto * Cantidad_ClasDetOrd; } }
    }
}