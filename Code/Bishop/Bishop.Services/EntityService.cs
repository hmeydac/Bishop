using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
