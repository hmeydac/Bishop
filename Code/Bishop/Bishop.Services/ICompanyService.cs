using Bishop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bishop.Services
{
    public interface ICompanyService
    {
        Company[] GetAll();

        Company Get(Guid id);
    }
}
