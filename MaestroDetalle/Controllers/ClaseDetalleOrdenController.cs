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
    public class ClaseDetalleOrdenController : Controller
    {
        private tiendaContext db = new tiendaContext();

        // GET: ClaseDetalleOrden
        public ActionResult Index()
        {
            var claseDetalleOrdens = db.ClaseDetalleOrdenes.Include(c => c.ClaseOrdenes).Include(c => c.ClaseProductos);
            return View(claseDetalleOrdens.ToList());
        }

        // GET: ClaseDetalleOrden/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseDetalleOrden claseDetalleOrden = db.ClaseDetalleOrdenes.Find(id);
            if (claseDetalleOrden == null)
            {
                return HttpNotFound();
            }
            return View(claseDetalleOrden);
        }

        // GET: ClaseDetalleOrden/Create
        public ActionResult Create()
        {
            ViewBag.Id_Ordenes = new SelectList(db.ClaseOrdenes, "Id_Ordenes", "Id_Ordenes");
            ViewBag.Id_Producto = new SelectList(db.ClaseProductos, "Id_Producto", "Nombre_Producto");
            return View();
        }

        // POST: ClaseDetalleOrden/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_ClasDetOrd,Cantidad_ClasDetOrd,precio_ClasDetOrd,Id_Producto,Id_Ordenes")] ClaseDetalleOrden claseDetalleOrden)
        {
            if (ModelState.IsValid)
            {
                db.ClaseDetalleOrdenes.Add(claseDetalleOrden);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Ordenes = new SelectList(db.ClaseOrdenes, "Id_Ordenes", "Id_Ordenes", claseDetalleOrden.Id_Ordenes);
            ViewBag.Id_Producto = new SelectList(db.ClaseProductos, "Id_Producto", "Nombre_Producto", claseDetalleOrden.Id_Producto);
            return View(claseDetalleOrden);
        }

        // GET: ClaseDetalleOrden/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseDetalleOrden claseDetalleOrden = db.ClaseDetalleOrdenes.Find(id);
            if (claseDetalleOrden == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Ordenes = new SelectList(db.ClaseOrdenes, "Id_Ordenes", "Id_Ordenes", claseDetalleOrden.Id_Ordenes);
            ViewBag.Id_Producto = new SelectList(db.ClaseProductos, "Id_Producto", "Nombre_Producto", claseDetalleOrden.Id_Producto);
            return View(claseDetalleOrden);
        }

        // POST: ClaseDetalleOrden/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ClasDetOrd,Cantidad_ClasDetOrd,precio_ClasDetOrd,Id_Producto,Id_Ordenes")] ClaseDetalleOrden claseDetalleOrden)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claseDetalleOrden).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Ordenes = new SelectList(db.ClaseOrdenes, "Id_Ordenes", "Id_Ordenes", claseDetalleOrden.Id_Ordenes);
            ViewBag.Id_Producto = new SelectList(db.ClaseProductos, "Id_Producto", "Nombre_Producto", claseDetalleOrden.Id_Producto);
            return View(claseDetalleOrden);
        }

        // GET: ClaseDetalleOrden/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseDetalleOrden claseDetalleOrden = db.ClaseDetalleOrdenes.Find(id);
            if (claseDetalleOrden == null)
            {
                return HttpNotFound();
            }
            return View(claseDetalleOrden);
        }

        // POST: ClaseDetalleOrden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClaseDetalleOrden claseDetalleOrden = db.ClaseDetalleOrdenes.Find(id);
            db.ClaseDetalleOrdenes.Remove(claseDetalleOrden);
            db.SaveChanges();
            return RedirectToAction("Index");
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
