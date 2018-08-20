using System;

namespace PacmanWeb.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<TEntity> Set<TEntity>() where TEntity : class;

        void Save();
    }
}
