using System;

namespace PacmanWeb.DAL
{
    public class UnitOfWork  : IUnitOfWork
    {
        private PacmanContext context;

        public UnitOfWork(PacmanContext context)
        {
            this.context = context;
        }

        public Repository<TEntity> Set<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(context);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
