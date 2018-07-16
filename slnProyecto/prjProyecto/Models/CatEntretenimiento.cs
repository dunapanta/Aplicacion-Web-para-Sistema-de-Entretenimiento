using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class CatEntretenimiento
    {
        [Key]

        public int IdCatEntrete { get; set; }

        [DisplayName("Nombre Entretenimiento")]
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "No mas de 50 caracteres")]
        public string NombreCategoria { get; set; }


        public virtual List<Entretenimiento> Entretenimiento { get; set; }
    }
}