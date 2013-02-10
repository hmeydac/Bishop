namespace Bishop.Services
{
    using System;
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Repositories;

    public class FormService : EntityService, IFormService
    {
        public FormService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Form[] GetAll()
        {
            return this.UnitOfWork.Query<Form>(this.GetIncludeNames()).ToArray();
        }

        public Form[] GetList()
        {
            return this.UnitOfWork.Query<Form>().OrderBy(f => f.Title).ToArray();
        }

        public Form Get(Guid id)
        {
            return this.UnitOfWork.Query<Form>(this.GetIncludeNames()).SingleOrDefault(f => f.Id.Equals(id));
        }

        protected override string[] GetIncludeNames()
        {
            return new[] { "Topics", "Topics.Questions", "Topics.Questions.Answers" };
        }
    }
}
