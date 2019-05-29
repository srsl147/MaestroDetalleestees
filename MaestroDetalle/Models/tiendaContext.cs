using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MaestroDetalle.Models
{
    public class tiendaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public tiendaContext() : base("name=tiendaContext")
        {
        }

        public System.Data.Entity.DbSet<MaestroDetalle.Models.ClaseCliente> ClaseClientes { get; set; }

        public System.Data.Entity.DbSet<MaestroDetalle.Models.ClaseOrdenes> ClaseOrdenes { get; set; }

        public System.Data.Entity.DbSet<MaestroDetalle.Models.ClaseDetalleOrden> ClaseDetalleOrdenes { get; set; }

        public System.Data.Entity.DbSet<MaestroDetalle.Models.ClaseProducto> ClaseProductos { get; set; }
    }
}
