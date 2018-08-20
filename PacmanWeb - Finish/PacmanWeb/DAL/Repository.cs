using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PacmanWeb.DAL
{
    public class Repository<TEntity> where TEntity : class
    {
        internal PacmanContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(PacmanContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        { 
            return dbSet;
        }

        public virtual void Create(TEntity entity)
        {
            context.Add(entity);
        }
    }
}

