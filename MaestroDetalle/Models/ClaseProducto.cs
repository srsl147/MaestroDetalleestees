using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class ClaseProducto
    {
        [Key]
        public int Id_Producto { set; get; }

        [Display(Name = "PRODUCTO")]
        public string Nombre_Producto { set; get; }

        [Display(Name = "PRECIO")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Unitprice_Producto { set; get; }

        // relacion con ClaseDetalleOrden
        public virtual ICollection<ClaseDetalleOrden> ClaseDetalleOrden { set; get; }
    }
}