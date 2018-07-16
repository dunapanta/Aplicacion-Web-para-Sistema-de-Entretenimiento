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
    public class EntretenimientoesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: Entretenimientoes
        public ActionResult Index()
        {
            var entretenimientoes = db.Entretenimientoes.Include(e => e.CatEntretenimiento).Include(e => e.CatPelicula);
            return View(entretenimientoes.ToList());
        }

        // GET: Entretenimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entretenimiento entretenimiento = db.Entretenimientoes.Find(id);
            if (entretenimiento == null)
            {
                return HttpNotFound();
            }
            return View(entretenimiento);
        }

        // GET: Entretenimientoes/Create
        public ActionResult Create()
        {
            ViewBag.IdCatEntrete = new SelectList(db.CatEntretenimientoes, "IdCatEntrete", "NombreCategoria");
            ViewBag.IdCatGenero = new SelectList(db.CatPeliculas, "IdCatGenero", "NombreGenero");
            return View();
        }

        // POST: Entretenimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEntrete,IdCatEntrete,IdCatGenero,Nombre,Descripcion,Stock,Precio,PrecioVent")] Entretenimiento entretenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entretenimientoes.Add(entretenimiento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.IdCatEntrete = new SelectList(db.CatEntretenimientoes, "IdCatEntrete", "NombreCategoria", entretenimiento.IdCatEntrete);
                ViewBag.IdCatGenero = new SelectList(db.CatPeliculas, "IdCatGenero", "NombreGenero", entretenimiento.IdCatGenero);
                return View(entretenimiento);
            }
            catch
            {
                return View(entretenimiento);
            }
        }

        // GET: Entretenimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entretenimiento entretenimiento = db.Entretenimientoes.Find(id);
            if (entretenimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCatEntrete = new SelectList(db.CatEntretenimientoes, "IdCatEntrete", "NombreCategoria", entretenimiento.IdCatEntrete);
            ViewBag.IdCatGenero = new SelectList(db.CatPeliculas, "IdCatGenero", "NombreGenero", entretenimiento.IdCatGenero);
            return View(entretenimiento);
        }

        // POST: Entretenimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEntrete,IdCatEntrete,IdCatGenero,Nombre,Descripcion,Stock,Precio,PrecioVent")] Entretenimiento entretenimiento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(entretenimiento).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.IdCatEntrete = new SelectList(db.CatEntretenimientoes, "IdCatEntrete", "NombreCategoria", entretenimiento.IdCatEntrete);
                ViewBag.IdCatGenero = new SelectList(db.CatPeliculas, "IdCatGenero", "NombreGenero", entretenimiento.IdCatGenero);
                return View(entretenimiento);
            }
            catch
            {
                return View(entretenimiento);
            }
        }

        // GET: Entretenimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entretenimiento entretenimiento = db.Entretenimientoes.Find(id);
            if (entretenimiento == null)
            {
                return HttpNotFound();
            }
            return View(entretenimiento);
        }

        // POST: Entretenimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Entretenimiento entretenimiento)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                     entretenimiento = db.Entretenimientoes.Find(id);
                    db.Entretenimientoes.Remove(entretenimiento);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(entretenimiento);
            }
            catch
            {
                return View(entretenimiento);
            }
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
