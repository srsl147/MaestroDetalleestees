using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class ClaseOrdenes
    {

        [Key]
        [Display(Name = "Numero de orden")]
        public int Id_Ordenes { set; get; }

        // [DisplayFormat(DataFormatString ="{0:dd/mm/aa}",ApplyFormatInEditMode =true)]
        [Display(Name = "fecha de ordenlll")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Orden { set; get; }

        // llave foranea - viene de ClaseCliente
        public int Id_Cliente { set; get; }
        public virtual ClaseCliente ClaseCliente { set; get; }

      

        // relacion con ClaseDetalleOrden
        public virtual ICollection<ClaseDetalleOrden> ClaseDetalleOrden { set; get; }
    }
}