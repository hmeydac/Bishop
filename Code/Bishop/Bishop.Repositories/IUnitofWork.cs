namespace Bishop.Repositories
{
    using System;
    using System.Linq;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IUnitOfWork Add<TEntity>(TEntity entity) where TEntity : class;

        IUnitOfWork Remove<TEntity>(TEntity entity) where TEntity : class;

        IQueryable<TEntity> Query<TEntity>(params string[] include) where TEntity : class;
    }
}
