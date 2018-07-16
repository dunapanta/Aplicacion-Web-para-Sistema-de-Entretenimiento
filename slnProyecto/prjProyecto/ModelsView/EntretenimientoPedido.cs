using prjProyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.ModelsView
{
    public class EntretenimientoPedido : Entretenimiento
    {
        public Entretenimiento Entretenimiento { get; set; }
        public List<Entretenimiento> LisEntretenimiento { get; set; }
        public List<EntretenimientoPedido> Entretenimientos { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public int Cantidad = 1;

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Subtotal { get { return Precio * Cantidad; } }
    }
}