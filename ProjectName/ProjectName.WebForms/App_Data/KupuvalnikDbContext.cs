using Microsoft.AspNet.Identity.EntityFramework;
using Kupuvalnik.WebForms.App_Data.Migrations;
using Kupuvalnik.WebForms.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kupuvalnik.WebForms.App_Data
{
    public class KupuvalnikDbContext : IdentityDbContext<ApplicationUser>, IKupuvalnikContext
    {
        public KupuvalnikDbContext()
            : base("KupuvalnikConnectionString", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KupuvalnikDbContext, Configuration>());
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Comodity> Comodities { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static KupuvalnikDbContext Create()
        {
            return new KupuvalnikDbContext();
        }


    }
}
