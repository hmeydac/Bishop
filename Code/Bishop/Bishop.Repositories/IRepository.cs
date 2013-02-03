namespace Bishop.Repositories
{
    using System.Linq;

    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);

        IQueryable<TEntity> Query();
    }
}
