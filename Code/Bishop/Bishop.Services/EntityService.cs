namespace Bishop.Services
{
    using Bishop.Repositories;

    public abstract class EntityService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected EntityService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        protected abstract string[] GetIncludeNames();
    }
}
