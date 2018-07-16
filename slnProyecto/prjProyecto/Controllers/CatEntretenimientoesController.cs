using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prjProyecto.Models;

namespace prjProyecto.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CatEntretenimientoesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: CatEntretenimientoes
        public ActionResult Index()
        {
            return View(db.CatEntretenimientoes.ToList());
        }

        // GET: CatEntretenimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatEntretenimiento catEntretenimiento = db.CatEntretenimientoes.Find(id);
            if (catEntretenimiento == null)
            {
                return HttpNotFound();
            }
            return View(catEntretenimiento);
        }

        // GET: CatEntretenimientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatEntretenimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCatEntrete,NombreCategoria")] CatEntretenimiento catEntretenimiento)
        {
            if (ModelState.IsValid)
            {
                db.CatEntretenimientoes.Add(catEntretenimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catEntretenimiento);
        }

        // GET: CatEntretenimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatEntretenimiento catEntretenimiento = db.CatEntretenimientoes.Find(id);
            if (catEntretenimiento == null)
            {
                return HttpNotFound();
            }
            return View(catEntretenimiento);
        }

        // POST: CatEntretenimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCatEntrete,NombreCategoria")] CatEntretenimiento catEntretenimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catEntretenimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catEntretenimiento);
        }

        // GET: CatEntretenimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatEntretenimiento catEntretenimiento = db.CatEntretenimientoes.Find(id);
            if (catEntretenimiento == null)
            {
                return HttpNotFound();
            }
            return View(catEntretenimiento);
        }

        // POST: CatEntretenimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatEntretenimiento catEntretenimiento = db.CatEntretenimientoes.Find(id);
            db.CatEntretenimientoes.Remove(catEntretenimiento);
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
