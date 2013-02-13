using Bishop.Model.Entities;
using Bishop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bishop.Services
{
    public class CompanyService :  EntityService, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Company Get(Guid id)
        {
            return this.UnitOfWork.Query<Company>().FirstOrDefault(f => f.Id.Equals(id));
        }

        public Company[] GetAll()
        {
            return this.UnitOfWork.Query<Company>(this.GetIncludeNames()).ToArray();
        }

        protected override string[] GetIncludeNames()
        {
            return new[] { "Contacts" };
        }
    }
}
