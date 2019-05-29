using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MaestroDetalle.Models;

namespace MaestroDetalle.Controllers
{
    public class ClaseProductosController : Controller
    {
        private tiendaContext db = new tiendaContext();

        // GET: ClaseProductos
        public ActionResult Index()
        {
            return View(db.ClaseProductos.ToList());
        }

        // GET: ClaseProductos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseProducto claseProducto = db.ClaseProductos.Find(id);
            if (claseProducto == null)
            {
                return HttpNotFound();
            }
            return View(claseProducto);
        }

        // GET: ClaseProductos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClaseProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Producto,Nombre_Producto,Unitprice_Producto")] ClaseProducto claseProducto)
        {
            if (ModelState.IsValid)
            {
                db.ClaseProductos.Add(claseProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claseProducto);
        }

        // GET: ClaseProductos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseProducto claseProducto = db.ClaseProductos.Find(id);
            if (claseProducto == null)
            {
                return HttpNotFound();
            }
            return View(claseProducto);
        }

        // POST: ClaseProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Producto,Nombre_Producto,Unitprice_Producto")] ClaseProducto claseProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claseProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claseProducto);
        }

        // GET: ClaseProductos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseProducto claseProducto = db.ClaseProductos.Find(id);
            if (claseProducto == null)
            {
                return HttpNotFound();
            }
            return View(claseProducto);
        }

        // POST: ClaseProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClaseProducto claseProducto = db.ClaseProductos.Find(id);
            db.ClaseProductos.Remove(claseProducto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult BusquedaFiltro (string Nombre_Producto) {

            var BusquedaProduct = from bp in db.ClaseProductos select bp;

            if (!string.IsNullOrEmpty(Nombre_Producto)) {

                BusquedaProduct = BusquedaProduct.Where(np => np.Nombre_Producto.Contains(Nombre_Producto));

              
            }

            return View(BusquedaProduct);


        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
