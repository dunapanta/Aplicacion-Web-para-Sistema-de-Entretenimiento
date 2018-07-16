using prjProyecto.Models;
using prjProyecto.ModelsView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace prjProyecto.Controllers
{
    //[Authorize(Roles = "Operador")]
    
    public class VentaController : Controller
    {

        ProyectoContext db = new ProyectoContext();
        // GET: Venta
        [Authorize(Roles = "Operador")]
        public ActionResult NuevoPedido(int? id, int? c, EntretenimientoPedido entrepedido)
        {

            if (id == null)
            {
                PedidoView pedidoView = new PedidoView();

                pedidoView.Cliente = new Cliente();
                pedidoView.Entretenimientos = new List<EntretenimientoPedido>();

                Session["PedidoView"] = pedidoView;

                var listaClientes = db.Clientes.ToList();
                ViewBag.ClienteId = new SelectList(listaClientes, "ClienteId", "NombreCliente");

                return View(pedidoView);
            }
            //postagregar
            if (c == 1)
            {


                var pedidoView = Session["PedidoView"] as PedidoView;
                var entre = db.Entretenimientoes.Find(id);
                entrepedido = new EntretenimientoPedido()
                {
                    IdEntrete = entre.IdEntrete,
                    Nombre = entre.Nombre,
                    PrecioVent = entre.PrecioVent
                };
                pedidoView.Entretenimientos.Add(entrepedido);

                Entretenimiento entret = new Entretenimiento()
                {
                    Stock = entre.Stock - 1
                };
                db.Entretenimientoes.Add(entret);

                var listaClientes = db.Clientes.ToList();
                ViewBag.ClienteId = new SelectList(listaClientes, "ClienteId", "NombreCliente");
                var listaEntre = db.Entretenimientoes.ToList();
                ViewBag.IdEntrete = new SelectList(listaEntre, "IdEntrete", "Nombre");

                return View("NuevoPedido", pedidoView);
            }
            else
            {
                // PedidoView pedidoView = new PedidoView();
                //EntretenimientoPedido entrepedido;
                var pedidoView = Session["PedidoView"] as PedidoView;
                var entre = db.Entretenimientoes.Find(id);
                entrepedido = new EntretenimientoPedido()
                {
                    IdEntrete = entre.IdEntrete,
                    Nombre = entre.Nombre,
                    Precio = entre.Precio
                };

                pedidoView.Entretenimientos.Add(entrepedido);

                var listaClientes = db.Clientes.ToList();
                ViewBag.ClienteId = new SelectList(listaClientes, "ClienteId", "NombreCliente");
                var listaEntre = db.Entretenimientoes.ToList();
                ViewBag.IdEntrete = new SelectList(listaEntre, "IdEntrete", "Nombre");

                return View("NuevoPedido", pedidoView);
            }

        }
        [Authorize(Roles = "Operador")]
        [HttpPost]

        public ActionResult NuevoPedido(PedidoView pedidoView ,Entretenimiento entretenimiento)
        {
            
            pedidoView = Session["PedidoView"] as PedidoView;
            int idCliente = int.Parse(Request["ClienteId"]);
            

            Pedido pedido = new Pedido()
            {
                ClienteId = idCliente,
                PedidoFecha = DateTime.Now,
                total = pedidoView.total
               
            };
            

           // LIsto Cabecera

            db.Pedidoes.Add(pedido);
            int  ultimoPedido = db.Pedidoes.ToList().Select(p => p.PedidoId).Max();

            foreach (EntretenimientoPedido item in pedidoView.Entretenimientos)
            {
                var detalle = new PedidoDetalle()
                {
                    PedidoId = ultimoPedido+1,
                    IdEntrete = item.IdEntrete,
                    PrecioVenta = item.PrecioVent,
                    PrecioAlquiler = item.Precio,
                    Cantidad = 1
                    
                };
                db.PedidoDetalles.Add(detalle);
                //var listaEntre = from u in db.Entretenimientoes
                //                 where u.CatPelicula.NombreGenero == genero
                //                 select u;
                //Entretenimiento entre = new Entretenimiento()
                //{
                //    Stock = pedidoView.Entretenimiento.Stock
                //};
                //db.Entretenimientoes.Add(entre);
            }

            db.SaveChanges();
            pedidoView = Session["PedidoView"] as PedidoView;
            var listaClientes = db.Clientes.ToList();
            ViewBag.ClienteId = new SelectList(listaClientes, "ClienteId", "NombreCliente");

            return View(pedidoView);

        }
        [Authorize(Roles = "Operador")]
        public ActionResult agregarProducto()
        {
            //var listaEntre = da.Entretenimientos.ToList();
            var listaEntre = db.Entretenimientoes.ToList();
            //ViewBag.IdEntrete = new SelectList(listaEntre, "IdEntrete", "Nombre");
            return View(listaEntre.ToList());
        }
        [Authorize(Roles = "Operador")]
        public ActionResult agregar()
        {

            var listaEntre = db.Entretenimientoes;
            ViewBag.IdEntrete = new SelectList(listaEntre, "IdEntrete", "Nombre");
            return View(listaEntre.ToList());

        }
        [Authorize(Roles = "Operador")]
        public ActionResult ventaProductoXCategoria(String categoria)
        {
            var listaEntre = from u in db.Entretenimientoes
                             where u.CatEntretenimiento.NombreCategoria == categoria
                             select u;
            return View(listaEntre.ToList());

        }
        [Authorize(Roles = "Operador")]
        public ActionResult ventaProductoXGenero(String genero)
        {
            var listaEntre = from u in db.Entretenimientoes
                             where u.CatPelicula.NombreGenero == genero
                             select u;
            return View(listaEntre.ToList());

        }
        [Authorize(Roles = "Operador")]
        public ActionResult ventaProductoXCategoriaA(String categoria)
        {
            var listaEntre = from u in db.Entretenimientoes
                             where u.CatEntretenimiento.NombreCategoria == categoria
                             select u;
            return View(listaEntre.ToList());

        }
        [Authorize(Roles = "Operador")]
        public ActionResult ventaProductoXGeneroA(String genero)
        {
            var listaEntre = from u in db.Entretenimientoes
                             where u.CatPelicula.NombreGenero == genero
                             select u;
            return View(listaEntre.ToList());

        }

        //factura
        [Authorize(Roles = "Operador")]
        public ActionResult factura()
        {
            
                var listapedido = db.Pedidoes;
                return View(listapedido.ToList());
           
        }
        [Authorize(Roles = "Operador")]
        public ActionResult ConsultaXNombre(string Nombre)
        {
            var listapedido = from u in db.Pedidoes
                              where u.Cliente.NombreCliente == Nombre
                              select u;
            return View(listapedido.ToList());
        }
        [Authorize(Roles = "Operador")]
        public ActionResult Detalle(int id)
        {
            var listadetalle = from u in db.PedidoDetalles
                              where u.PedidoId == id
                              select u;
            return View(listadetalle.ToList());
        }
        //Reporte Operador
        //Reporte venta
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteVentasOpe()
        {
            var listapedido = db.Pedidoes;
            return View(listapedido.ToList());

        }
        [HttpPost]
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteVentasOpe(Pedido pedido)
        {
            var listapedido = db.Pedidoes;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedido.total

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listapedido.ToList());

        }

        //Reporte ventaXnombre
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteXNombreOpe(string Nombre)
        {
            var listapedido = from u in db.Pedidoes
                              where u.Cliente.NombreCliente == Nombre
                              select u;
            return View(listapedido.ToList());
        }
        [HttpPost]
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteXNombreOpe(string Nombre, Pedido pedido)
        {
            var listapedido = db.Pedidoes;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedido.total

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listapedido.ToList());
        }

        //Reporte Entretenimiento
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteEntretenimientoOpe()
        {
            var listadetalle = db.PedidoDetalles;
            return View(listadetalle.ToList());

        }
        [HttpPost]
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteEntretenimientoOpe(PedidoDetalle pedidoDetalle)
        {
            var listadetalle = db.PedidoDetalles;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedidoDetalle.PrecioVenta + pedidoDetalle.PrecioAlquiler

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listadetalle.ToList());

        }

        //Reporte EntretenimientoXitem
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteXItemOpe(string Nombre)
        {
            var listadetalle = from u in db.PedidoDetalles
                               where u.Entretenimiento.Nombre == Nombre
                               select u;
            return View(listadetalle.ToList());
        }
        [HttpPost]
        [Authorize(Roles = "Operador")]
        public ActionResult ReporteXItemOpe(string Nombre, PedidoDetalle pedidoDetalle)
        {
            var listadetalle = db.PedidoDetalles;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedidoDetalle.PrecioVenta + pedidoDetalle.PrecioAlquiler

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listadetalle.ToList());
        }


        //Reporte Admin

        //Reporte venta
        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteVentas()
        {
            var listapedido = db.Pedidoes;
            return View(listapedido.ToList());

        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ReporteVentas(Pedido pedido)
        {
            var listapedido = db.Pedidoes;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedido.total 

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listapedido.ToList());

        }

        //Reporte ventaXnombre
        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteXNombre(string Nombre)
        {
            var listapedido = from u in db.Pedidoes
                              where u.Cliente.NombreCliente == Nombre
                              select u;
            return View(listapedido.ToList());
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ReporteXNombre(string Nombre, Pedido pedido)
        {
            var listapedido = db.Pedidoes;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedido.total

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listapedido.ToList());
        }

        //Reporte Entretenimiento
        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteEntretenimiento()
        {
            var listadetalle = db.PedidoDetalles;
            return View(listadetalle.ToList());

        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult ReporteEntretenimiento(PedidoDetalle pedidoDetalle)
        {
            var listadetalle = db.PedidoDetalles;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedidoDetalle.PrecioVenta + pedidoDetalle.PrecioAlquiler

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listadetalle.ToList());

        }

        //Reporte EntretenimientoXitem
        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteXItem(string Nombre)
        {
            var listadetalle = from u in db.PedidoDetalles
                               where u.Entretenimiento.Nombre == Nombre
                               select u;
            return View(listadetalle.ToList());
        }
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult ReporteXItem(string Nombre, PedidoDetalle pedidoDetalle)
        {
            var listadetalle = db.PedidoDetalles;
            Reporte reporte = new Reporte()
            {
                ReporteFecha = DateTime.Now,
                TotalRe = pedidoDetalle.PrecioVenta + pedidoDetalle.PrecioAlquiler

            };
            // LIsto Cabecera
            db.Reportes.Add(reporte);
            return View(listadetalle.ToList());
        }

        

    }
}