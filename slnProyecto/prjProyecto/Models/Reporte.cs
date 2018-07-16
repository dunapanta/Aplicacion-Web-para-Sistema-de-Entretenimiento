using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class Reporte
    {
        [Key]
        public int ReporteId { get; set; }

        public DateTime ReporteFecha { get; set; }

        public int ClienteId { get; set; }

        public decimal TotalRe { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Pedido Pedido { get; set; }


        public virtual List<PedidoDetalle> PedidoDetalles { get; set; }
    }
}