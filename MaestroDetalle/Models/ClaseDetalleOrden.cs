using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class ClaseDetalleOrden
    {
        [Key]
        public int Id_ClasDetOrd { set; get; }

        [Display(Name = "CANTIDAD")]
        public int Cantidad_ClasDetOrd { set; get; }
        [Display(Name = "PRECIO")]
        public decimal precio_ClasDetOrd { set; get; }

        // llave foranea - viene de ClaseProducto
        public int Id_Producto { set; get; }
        public virtual ClaseProducto ClaseProductos { set; get; }


        // llave foranea - viene de ClaseOrdenes
        public int Id_Ordenes { set; get; }
        public virtual ClaseOrdenes ClaseOrdenes { set; get; }
    }
}