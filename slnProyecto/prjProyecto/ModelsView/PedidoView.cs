
using prjProyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjProyecto.ModelsView
{
    public class PedidoView
    {
        public Cliente Cliente { get; set; }
        public Factura Factura { get; set; }
        public EntretenimientoPedido Titulos { get; set; }
        public decimal total { get; set; }
        public Entretenimiento Entretenimiento { get; set; }
        public List<Entretenimiento> LisEntretenimientos { get; set; }
        public List<EntretenimientoPedido> Entretenimientos { get; set; }

    }
}