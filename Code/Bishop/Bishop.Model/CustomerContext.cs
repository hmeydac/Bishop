using Bishop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bishop.Model
{
    public class CustomerContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
