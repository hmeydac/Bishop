namespace Bishop.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Contact
    {
        public Contact()
        {
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.IsAdministrator = false;
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsAdministrator { get; set; }
    }
}
