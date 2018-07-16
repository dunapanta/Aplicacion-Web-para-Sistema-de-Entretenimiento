using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class Entretenimiento
    {
        [Key]

        public int IdEntrete{ get; set; }

        public int IdCatEntrete { get; set; }
        public virtual CatEntretenimiento CatEntretenimiento { get; set; }

        //Genero

        public int IdCatGenero { get; set; }
        public virtual CatPelicula CatPelicula { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "No mas de 50 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Descripcion")]
        [Required(ErrorMessage = "LaDescripciones Requerida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "No mas de 100 caracteres")]
        public string Descripcion { get; set; }

        [DisplayName("Stock")]
        [Required(ErrorMessage = "El Stock es Requerido")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser Positivo.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public int Stock { get; set; }

        [DisplayName("Precio Alquiler")]
        [Required(ErrorMessage = "El Precio es Requerido")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser Positivo.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Precio { get; set; }

        [DisplayName("Precio Venta")]
        [Required(ErrorMessage = "El Precio es Requerido")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser Positivo.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PrecioVent { get; set; }

        public virtual List<PedidoDetalle> PedidoDetalles { get; set; }
    }
}