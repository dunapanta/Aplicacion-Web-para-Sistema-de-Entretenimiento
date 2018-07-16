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
    public class PedidoDetallesController : Controller
    {
        private ProyectoContext db = new ProyectoContext();

        // GET: PedidoDetalles
        public ActionResult Index()
        {
            var pedidoDetalles = db.PedidoDetalles.Include(p => p.Entretenimiento).Include(p => p.Pedidos);
            return View(pedidoDetalles.ToList());
        }

        // GET: PedidoDetalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalles.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            return View(pedidoDetalle);
        }

        // GET: PedidoDetalles/Create
        public ActionResult Create()
        {
            ViewBag.IdEntrete = new SelectList(db.Entretenimientoes, "IdEntrete", "Nombre");
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId");
            return View();
        }

        // POST: PedidoDetalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PedidoDetalleId,PedidoId,IdEntrete,Cantidad,PrecioVenta,PrecioAlquiler")] PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                db.PedidoDetalles.Add(pedidoDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEntrete = new SelectList(db.Entretenimientoes, "IdEntrete", "Nombre", pedidoDetalle.IdEntrete);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", pedidoDetalle.PedidoId);
            return View(pedidoDetalle);
        }

        // GET: PedidoDetalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalles.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEntrete = new SelectList(db.Entretenimientoes, "IdEntrete", "Nombre", pedidoDetalle.IdEntrete);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", pedidoDetalle.PedidoId);
            return View(pedidoDetalle);
        }

        // POST: PedidoDetalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PedidoDetalleId,PedidoId,IdEntrete,Cantidad,PrecioVenta,PrecioAlquiler")] PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEntrete = new SelectList(db.Entretenimientoes, "IdEntrete", "Nombre", pedidoDetalle.IdEntrete);
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "PedidoId", "PedidoId", pedidoDetalle.PedidoId);
            return View(pedidoDetalle);
        }

        // GET: PedidoDetalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoDetalle pedidoDetalle = db.PedidoDetalles.Find(id);
            if (pedidoDetalle == null)
            {
                return HttpNotFound();
            }
            return View(pedidoDetalle);
        }

        // POST: PedidoDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoDetalle pedidoDetalle = db.PedidoDetalles.Find(id);
            db.PedidoDetalles.Remove(pedidoDetalle);
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
