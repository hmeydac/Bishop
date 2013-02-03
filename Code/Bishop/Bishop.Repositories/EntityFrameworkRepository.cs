namespace Bishop.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> dataSet;

        public EntityFrameworkRepository(IUnitOfWork unitOfWork)
        {
            var entityFrameworkUnitOfWork = unitOfWork as EntityFrameworkUnitOfWork;
            if (entityFrameworkUnitOfWork == null)
            {
                throw new Exception("Repository requires an Entity Framework Unit of Work");
            }

            this.dataSet = entityFrameworkUnitOfWork.GetDbSet<TEntity>();

        }

        public void Add(TEntity entity)
        {
            this.dataSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            this.dataSet.Remove(entity);
        }

        public IQueryable<TEntity> Query()
        {
            return this.dataSet;
        }
    }
}
