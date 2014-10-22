using Kupuvalnik.WebForms.App_Data.Repositories;
using System;
using System.Collections.Generic;
using Kupuvalnik.WebForms.Models;

namespace Kupuvalnik.WebForms.App_Data
{
    public class KupuvalnikData: IKupuvalnikData
    {
        private IKupuvalnikContext context;

        private IDictionary<Type, object> repositories;

        public KupuvalnikData()
            : this(new KupuvalnikDbContext())
        {
        }

        public KupuvalnikData(IKupuvalnikContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IGenericRepository<Comodity> Comodities
        {
            get
            {
                return this.GetRepository<Comodity>();
            }
        }

        public IGenericRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
