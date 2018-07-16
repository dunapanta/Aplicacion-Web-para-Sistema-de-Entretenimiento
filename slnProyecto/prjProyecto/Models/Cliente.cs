using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class Cliente
    {
        [Key]

        public int ClienteId { get; set; }

        [DisplayName("Nombre Cliente")]
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "No mas de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Solo Letras")]
        public string NombreCliente { get; set; }


        [DisplayName("Apellido Cliente")]
        [Required(ErrorMessage = "El Apellido es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "No mas de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Solo Letras")]
        public string ApellidoCliente { get; set; }

        [DisplayName("Cedula")]
        [Required(ErrorMessage = "Cedula requerida")]
        [MaxLength(10, ErrorMessage = "Cedula debe tener 10 digitos")]
        [MinLength(10, ErrorMessage = "Cedula debe tener 10 digitos")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo numeros")]
        public string Cedula { get; set; }


        [DisplayName("Telefono")]
        [Required(ErrorMessage = "El Telefono es Requerido")]
        [MaxLength(7)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo numeros")]
        public string Telefono { get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "El Celular es Requerido")]
        [MaxLength(10)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo numeros")]
        public string Celular { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La Dirección es Requerida")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "No mas de 50 caracteres")]
        public string Direccion { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email es Requerido")]
        [StringLength(50, ErrorMessage = "No mas de 50 caracteres")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        public virtual List<Pedido> Pedidos { get; set; }

        public virtual List<Reporte> Reporte { get; set; }
    }
}