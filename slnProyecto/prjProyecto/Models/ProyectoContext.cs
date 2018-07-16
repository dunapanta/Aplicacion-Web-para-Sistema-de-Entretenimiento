using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prjProyecto.Models
{
    public class ProyectoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProyectoContext() : base("name=ProyectoContext")
        {
        }

        public System.Data.Entity.DbSet<prjProyecto.Models.CatEntretenimiento> CatEntretenimientoes { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.CatPelicula> CatPeliculas { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.Empleado> Empleadoes { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.Entretenimiento> Entretenimientoes { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.PedidoDetalle> PedidoDetalles { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.Reporte> Reportes { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.Factura> Facturas { get; set; }

        public System.Data.Entity.DbSet<prjProyecto.Models.Administrador> Administradors { get; set; }
    }
}
