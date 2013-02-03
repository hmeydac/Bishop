namespace Bishop.Services
{
    using System.Linq;

    using Bishop.Model.Entities;
    using Bishop.Repositories;

    public class FormService
    {
        private readonly IUnitOfWork unitOfWork;

        private string[] includeNames = { "Topics", "Topics.Questions", "Topics.Questions.Answers" };


        public FormService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Form[] GetAll()
        {
            return this.unitOfWork.Query<Form>(this.includeNames).ToArray();
        }

        public Form Get(long id)
        {
            return this.unitOfWork.Query<Form>(this.includeNames).SingleOrDefault(f => f.Id.Equals(id));
        }
    }
}
