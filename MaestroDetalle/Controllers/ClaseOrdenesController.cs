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
    public class ClaseOrdenesController : Controller
    {
        private tiendaContext db = new tiendaContext();

        // GET: ClaseOrdenes
        public ActionResult Index()
        {
            var claseOrdenes = db.ClaseOrdenes.Include(c => c.ClaseCliente);
            return View(claseOrdenes.ToList());
        }

        // GET: ClaseOrdenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseOrdenes claseOrdenes = db.ClaseOrdenes.Find(id);
            if (claseOrdenes == null)
            {
                return HttpNotFound();
            }
            return View(claseOrdenes);
        }

        // GET: ClaseOrdenes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.ClaseClientes, "Id_Cliente", "Nombre_Compañia_Cliente");
            return View();
        }

        // POST: ClaseOrdenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Ordenes,Fecha_Orden,Id_Cliente")] ClaseOrdenes claseOrdenes)
        {
            if (ModelState.IsValid)
            {
                db.ClaseOrdenes.Add(claseOrdenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.ClaseClientes, "Id_Cliente", "Nombre_Compañia_Cliente", claseOrdenes.Id_Cliente);
            return View(claseOrdenes);
        }

        // GET: ClaseOrdenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseOrdenes claseOrdenes = db.ClaseOrdenes.Find(id);
            if (claseOrdenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.ClaseClientes, "Id_Cliente", "Nombre_Compañia_Cliente", claseOrdenes.Id_Cliente);
            return View(claseOrdenes);
        }

        // POST: ClaseOrdenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Ordenes,Fecha_Orden,Id_Cliente")] ClaseOrdenes claseOrdenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claseOrdenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.ClaseClientes, "Id_Cliente", "Nombre_Compañia_Cliente", claseOrdenes.Id_Cliente);
            return View(claseOrdenes);
        }

        // GET: ClaseOrdenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseOrdenes claseOrdenes = db.ClaseOrdenes.Find(id);
            if (claseOrdenes == null)
            {
                return HttpNotFound();
            }
            return View(claseOrdenes);
        }

        // POST: ClaseOrdenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClaseOrdenes claseOrdenes = db.ClaseOrdenes.Find(id);
            db.ClaseOrdenes.Remove(claseOrdenes);
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
