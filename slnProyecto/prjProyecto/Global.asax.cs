using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using prjProyecto.Controllers;
using prjProyecto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace prjProyecto
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.ProyectoContext,
                Migrations.Configuration>());
            ApplicationDbContext db = new ApplicationDbContext();
            CreateRoles(db);
            CreateSuperuser(db);
            CreateOperatoruser(db);
            AddPermisionsToAdministrator(db);
            AddPermisionsToOperator(db);
            db.Dispose();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermisionsToOperator(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("daniel@operador.com");

            if (!userManager.IsInRole(user.Id, "Operador"))
            {
                userManager.AddToRole(user.Id, "Operador");
            }
        }

        private void AddPermisionsToAdministrator(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName("francisco@administrador.com");

            if (!userManager.IsInRole(user.Id, "Administrador"))
            {
                userManager.AddToRole(user.Id, "Administrador");
            }


        }

        public void AddPermisionsToCustomuser(ApplicationDbContext db, Empleado empleado)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName(empleado.EmailEmp);

            if (!userManager.IsInRole(user.Id, "Operador"))
            {
                userManager.AddToRole(user.Id, "Operador");
            }


        }
        public void AddPermisionsToAdmin(ApplicationDbContext db, Administrador account)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var user = userManager.FindByName(account.Email);
            if (!userManager.IsInRole(user.Id, "Administrador"))
            {
                userManager.AddToRole(user.Id, "Administrador");
            }


        }

        public void CreateCustomOperatoruser(ApplicationDbContext db, Empleado empleado)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName(empleado.EmailEmp);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = empleado.EmailEmp,
                    Email = empleado.EmailEmp
                };

                userManager.Create(user, empleado.Contrasena);
            }
        }

        public void CreateCustomAdminuser(ApplicationDbContext db, Administrador account)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName(account.Email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = account.Email,
                    Email = account.Email
                };

                userManager.Create(user, account.Password);
            }
        }

        private void CreateOperatoruser(ApplicationDbContext db)
        {

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName("daniel@operador.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "daniel@operador.com",
                    Email = "daniel@operador.com"
                };

                userManager.Create(user, "Operador123.");
            }
        }

        private void CreateSuperuser(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName("francisco@administrador.com");
            if(user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "francisco@administrador.com",
                    Email = "francisco@administrador.com"
                };

                userManager.Create(user, "Admin123.");
            }
        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleAdministrador = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleAdministrador.RoleExists("Administrador"))
            {
                roleAdministrador.Create(new IdentityRole("Administrador"));
            }

            if (!roleAdministrador.RoleExists("Operador"))
            {
                roleAdministrador.Create(new IdentityRole("Operador"));
            }
        }
    }
}
