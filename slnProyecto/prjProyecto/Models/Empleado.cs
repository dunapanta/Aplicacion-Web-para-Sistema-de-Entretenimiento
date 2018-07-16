using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class Empleado
    {
        [Key]

        public int IdEmpleado { get; set; }

        [DisplayName("Cedula")]
        [Required(ErrorMessage = "Cedula requerida")]
        [MaxLength (10, ErrorMessage = "Cedula debe tener 10 digitos")]
        [MinLength(10, ErrorMessage ="Cedula debe tener 10 digitos")]
        [RegularExpression ("^[0-9]*$" , ErrorMessage ="Solo numeros")]
        public string CedulaEmpleado { get; set; }

        [DisplayName("Nombre Empleado")]
        [Required(ErrorMessage = "El Nombre es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "No mas de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Solo Letras")]
        public string NombreEmpleado { get; set; }

        [DisplayName("Apellido Empleado")]
        [Required(ErrorMessage = "El Apellido es Requerido")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "No mas de 50 caracteres")]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Solo Letras")]
        public string ApellidoEmpleado { get; set; }

        [DisplayName("Telefono")]
        [Required(ErrorMessage = "El Telefono es Requerido")]
        [MaxLength(7)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo numeros")]
        public string TelefonoEmp { get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "El Celular es Requerido")]
        [MaxLength(10)]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo numeros")]
        public string CelularEmp { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La Dirección es Requerida")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "No mas de 50 caracteres")]
        public string DireccionEmp { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email es Requerido")]
        [StringLength(50, ErrorMessage = "No mas de 50 caracteres")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string EmailEmp { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La Contraseña es Requerida", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Contrasena", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }


        [DisplayName("Salario")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser Positivo.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Salario es Requerido")]
        public decimal Salario { get; set; }

        [DisplayName("Fecha de ingreso")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Fecha de ingreso es Requerida")]
        public DateTime Fecha { get; set; }

    }
}