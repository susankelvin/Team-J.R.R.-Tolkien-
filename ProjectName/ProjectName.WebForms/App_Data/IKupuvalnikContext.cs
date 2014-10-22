namespace Kupuvalnik.WebForms.App_Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Kupuvalnik.WebForms.Models;

    public interface IKupuvalnikContext
    {
        IDbSet<Category> Categories { get; set; }

        IDbSet<Comodity> Comodities { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
