using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }

        public DateTime FacturaFecha { get; set; }

        public int PedidoId { get; set; }

        public decimal total { get; set; }

        public virtual Pedido Pedido { get; set; }

        public virtual List<PedidoDetalle> PedidoDetalles { get; set; }
    }
}