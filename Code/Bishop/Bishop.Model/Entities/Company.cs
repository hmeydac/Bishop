namespace Bishop.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Company
    {
        private readonly List<Contact> contacts;

        public Company()
        {
            this.contacts = new List<Contact>();
            this.Name = string.Empty;
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactName { get; set; }
        
        public string ContactEmail { get; set; }

        public IList<Contact> Contacts
        {
            get { return this.contacts; }
        }
    }
}
