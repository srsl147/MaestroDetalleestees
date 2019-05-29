using MaestroDetalle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaestroDetalle.Controllers
{
    public class VentasController : Controller
    {
        private tiendaContext db = new tiendaContext();

        // GET: Ventas
        public ActionResult NuevaOrden()
        {
            Clase_OrdenVista OrdenVista = new Clase_OrdenVista();
            OrdenVista.ClaseCliente = new ClaseCliente_Orden();
            OrdenVista.ClaseProducto = new List<ClaseProductoOrden>();
            Session["OrdenVista"] = OrdenVista;

        var list = db.ClaseClientes.ToList();
            ViewBag.Id_Cliente = new SelectList(list, "Id_Cliente", "Nombre_Compañia_Cliente");

            return View(OrdenVista);
        }


        [HttpPost]
        public ActionResult NuevaOrden(Clase_OrdenVista OrdenVista) {

            OrdenVista = Session["OrdenVista"] as Clase_OrdenVista;
            int Id_Clientes = int.Parse(Request["Id_Cliente"]);
            DateTime fechaOrden = Convert.ToDateTime(Request["ClaseCliente.Fecha_Orden"]);

            ClaseOrdenes neworder = new ClaseOrdenes
            {
                Id_Cliente = Id_Clientes,
                Fecha_Orden = fechaOrden
            };

            db.ClaseOrdenes.Add(neworder);
            db.SaveChanges();
            int ultimaordenid = db.ClaseOrdenes.ToList().Select(o=> o.Id_Ordenes).Max();

            foreach (ClaseProductoOrden item in OrdenVista.ClaseProducto)
            {
                var detalle = new ClaseDetalleOrden()
                {
                    Id_Ordenes= ultimaordenid,
                    Id_Producto=item.Id_Producto,
                    Cantidad_ClasDetOrd = item.Cantidad_ClasDetOrd,
                    precio_ClasDetOrd= item.Unitprice_Producto,
                   


                };

                db.ClaseDetalleOrdenes.Add(detalle);
            }

            db.SaveChanges();

            OrdenVista = Session["OrdenVista"] as Clase_OrdenVista;
            var list = db.ClaseClientes.ToList();
            ViewBag.Id_Cliente = new SelectList(list, "Id_Cliente", "Nombre_Compañia_Cliente");

            return View(OrdenVista);
        }




        [HttpGet]
        public ActionResult AgregarProducto()
        {

            var listp = db.ClaseProductos.ToList();
            ViewBag.Id_Producto = new SelectList(listp, "Id_Producto", "Nombre_Producto");
            return View();

        }

        [HttpPost]
        public ActionResult AgregarProducto(ClaseProductoOrden productorden)
        {
            var OrdenVista = Session["OrdenVista"] as Clase_OrdenVista;
            var productid = int.Parse(Request["Id_Producto"]);
            var producto = db.ClaseProductos.Find(productid);

            productorden = new ClaseProductoOrden()
            {
                Id_Producto = producto.Id_Producto,
                Nombre_Producto=producto.Nombre_Producto,
                Unitprice_Producto= producto.Unitprice_Producto,
                Cantidad_ClasDetOrd= int.Parse(Request["Cantidad_ClasDetOrd"])
        };

            OrdenVista.ClaseProducto.Add(productorden);


            var list = db.ClaseClientes.ToList();
            ViewBag.Id_Cliente = new SelectList(list, "Id_Cliente", "Nombre_Compañia_Cliente");
            var listp = db.ClaseProductos.ToList();
            ViewBag.Id_Producto = new SelectList(listp, "Id_Producto", "Nombre_Producto");
            return View("NuevaOrden", OrdenVista);

        }
    }
}