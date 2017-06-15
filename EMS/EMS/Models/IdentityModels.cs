﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EMS.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; internal set; }

        public string Surname { get; internal set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Reingenieria_EMS.Models.Cursos> Cursos { get; set; }

        public System.Data.Entity.DbSet<Reingenieria_EMS.Models.GruposClase> GruposClases { get; set; }
        
        public System.Data.Entity.DbSet<Reingenieria.Models.Docencia> Docencias { get; set; }

        public System.Data.Entity.DbSet<Reingenieria.Models.Matricula> Matriculas { get; set; }

        public System.Data.Entity.DbSet<Reingenieria_EMS.Models.Evaluacion> Evaluacions { get; set; }
    }
}