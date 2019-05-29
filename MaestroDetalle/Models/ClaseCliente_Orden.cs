using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class ClaseCliente_Orden: ClaseCliente
    {
        [Display(Name = "fecha de orden")]
        [DataType(DataType.Date)]
        public DateTime Fecha_Orden { set; get; }
    }
}