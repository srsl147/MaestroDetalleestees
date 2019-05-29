using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class ClaseCliente
    {
        [Key]
        [Display(Name = "Codigo Cliente")]
        public int Id_Cliente { set; get; }

        [Required(ErrorMessage ="el campo {0} es obligatorio")]
        [Display(Name = "Nombre de la compañia")]
        public string Nombre_Compañia_Cliente { set; get; }

        [Display(Name = "Nombre de contacto")]
        public string Nombre_Contacto_Cliente { set; get; }
        

        public virtual ICollection<ClaseOrdenes> ClaseOrdenes { set; get; }
}
}