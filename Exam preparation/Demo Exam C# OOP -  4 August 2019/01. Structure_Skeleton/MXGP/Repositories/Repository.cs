using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;
        public Repository()
        {
            this.models = new List<T>();
        }

        public List<T> Models
        {
            get
            {
                return this.models;
            }
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models.ToList();
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            if (!this.models.Contains(model))
            {
                return false;
            }

            this.models.Remove(model);

            return true;
        }
    }
}
