namespace Kupuvalnik.WebForms.App_Data
{
    using Kupuvalnik.WebForms.App_Data.Repositories;
    using Kupuvalnik.WebForms.Models;

    public interface IKupuvalnikData
    {
        IGenericRepository<Category> Categories { get; }

        IGenericRepository<Comodity> Comodities { get; }

        IGenericRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}
