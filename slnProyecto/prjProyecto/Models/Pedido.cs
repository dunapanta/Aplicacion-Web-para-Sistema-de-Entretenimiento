using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }

        public DateTime PedidoFecha { get; set; }

       public int ClienteId { get; set; }

        public decimal total { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual List<PedidoDetalle> PedidoDetalles { get; set; }

        public virtual List<Reporte> Reporte { get; set; }
    }
}