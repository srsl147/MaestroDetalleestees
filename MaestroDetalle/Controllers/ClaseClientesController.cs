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
    public class ClaseClientesController : Controller
    {
        private tiendaContext db = new tiendaContext();

        // GET: ClaseClientes
        public ActionResult Index()
        {
            return View(db.ClaseClientes.ToList());
        }

        // GET: ClaseClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseCliente claseCliente = db.ClaseClientes.Find(id);
            if (claseCliente == null)
            {
                return HttpNotFound();
            }
            return View(claseCliente);
        }

        // GET: ClaseClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClaseClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cliente,Nombre_Compañia_Cliente,Nombre_Contacto_Cliente")] ClaseCliente claseCliente)
        {
            if (ModelState.IsValid)
            {
                db.ClaseClientes.Add(claseCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(claseCliente);
        }

        // GET: ClaseClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseCliente claseCliente = db.ClaseClientes.Find(id);
            if (claseCliente == null)
            {
                return HttpNotFound();
            }
            return View(claseCliente);
        }

        // POST: ClaseClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cliente,Nombre_Compañia_Cliente,Nombre_Contacto_Cliente")] ClaseCliente claseCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claseCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(claseCliente);
        }

        // GET: ClaseClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClaseCliente claseCliente = db.ClaseClientes.Find(id);
            if (claseCliente == null)
            {
                return HttpNotFound();
            }
            return View(claseCliente);
        }

        // POST: ClaseClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClaseCliente claseCliente = db.ClaseClientes.Find(id);
            db.ClaseClientes.Remove(claseCliente);
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
