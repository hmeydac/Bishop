using Bishop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    public class CompanyBuilder : ObjectBuilder<Company>
    {
        public CompanyBuilder WithRandomId()
        {
            this.Instance.Id = Guid.NewGuid();
            return this;
        }

        public CompanyBuilder WithTopic(Contact contact)
        {
            this.Instance.Contacts.Add(contact);
            return this;
        }

        public CompanyBuilder WithName(string name)
        {
            this.Instance.Name = name;
            return this;
        }
    }
}
