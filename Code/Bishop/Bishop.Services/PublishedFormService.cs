namespace Bishop.Services
{
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Repositories;

    public class PublishedFormService : EntityService, IPublishedFormService
    {
        public PublishedFormService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public PublishedForm[] GetAllActive()
        {
            return this.UnitOfWork.Query<PublishedForm>(this.GetIncludeNames()).Where(f => f.IsActive).ToArray();
        }

        protected override string[] GetIncludeNames()
        {
            return new[] { "Form" };
        }
    }
}
