namespace Bishop.Repositories
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public EntityFrameworkUnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public IUnitOfWork Add<TEntity>(TEntity entity) where TEntity : class
        {
            this.GetDbSet<TEntity>().Add(entity);
            return this;
        }

        public IUnitOfWork Remove<TEntity>(TEntity entity) where TEntity : class
        {
            this.GetDbSet<TEntity>().Remove(entity);
            return this;
        }

        public IQueryable<TEntity> Query<TEntity>(params string[] include) where TEntity : class
        {
            var dataSet = this.GetDbSet<TEntity>();
            DbQuery<TEntity> dataQuery = null;
            foreach (var includeName in include)
            {
                dataQuery = dataSet.Include(includeName);
            }

            if (dataQuery == null)
            {
                return this.GetDbSet<TEntity>();
            }

            return dataQuery.AsQueryable();
        }

        internal DbSet<T> GetDbSet<T>() where T : class
        {
            return this.context.Set<T>();
        }
    }
}
