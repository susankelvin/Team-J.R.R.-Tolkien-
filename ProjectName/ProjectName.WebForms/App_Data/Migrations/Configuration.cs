namespace Kupuvalnik.WebForms.App_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Kupuvalnik.WebForms.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<KupuvalnikDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KupuvalnikDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category
                {
                    Name = "Cars"
                });
                context.Categories.Add(new Category
                {
                    Name = "Clothes"
                });
                context.Categories.Add(new Category
                {
                    Name = "Apples"
                });
                context.Categories.Add(new Category
                {
                    Name = "Peshos"
                });
                context.SaveChanges();
            }
        }
    }
}
