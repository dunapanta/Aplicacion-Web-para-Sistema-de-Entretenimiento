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
    public class CatPeliculasController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: CatPeliculas
        public ActionResult Index()
        {
            return View(db.CatPeliculas.ToList());
        }

        // GET: CatPeliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatPelicula catPelicula = db.CatPeliculas.Find(id);
            if (catPelicula == null)
            {
                return HttpNotFound();
            }
            return View(catPelicula);
        }

        // GET: CatPeliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatPeliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCatGenero,NombreGenero")] CatPelicula catPelicula)
        {
            if (ModelState.IsValid)
            {
                db.CatPeliculas.Add(catPelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catPelicula);
        }

        // GET: CatPeliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatPelicula catPelicula = db.CatPeliculas.Find(id);
            if (catPelicula == null)
            {
                return HttpNotFound();
            }
            return View(catPelicula);
        }

        // POST: CatPeliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCatGenero,NombreGenero")] CatPelicula catPelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catPelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catPelicula);
        }

        // GET: CatPeliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatPelicula catPelicula = db.CatPeliculas.Find(id);
            if (catPelicula == null)
            {
                return HttpNotFound();
            }
            return View(catPelicula);
        }

        // POST: CatPeliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatPelicula catPelicula = db.CatPeliculas.Find(id);
            db.CatPeliculas.Remove(catPelicula);
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
