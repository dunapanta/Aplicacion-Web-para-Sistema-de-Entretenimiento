using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class CatPelicula
    {
        [Key]

        public int IdCatGenero { get; set; }

        [DisplayName("Nombre Genero")]
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "No mas de 50 caracteres")]
        public string NombreGenero { get; set; }

        public virtual List<Entretenimiento> Entretenimientos { get; set; }
    }
}