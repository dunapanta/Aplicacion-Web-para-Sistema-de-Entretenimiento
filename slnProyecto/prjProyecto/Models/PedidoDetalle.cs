using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class PedidoDetalle
    {
        [Key]
        public int PedidoDetalleId { get; set; }

        public int PedidoId { get; set; }

       public int IdEntrete { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioVenta { get; set; }

        public decimal PrecioAlquiler { get; set; }

        public virtual Pedido Pedidos { get; set; }

        public virtual Reporte Reporte { get; set; }


        public virtual Entretenimiento Entretenimiento { get; set; }

    }
}