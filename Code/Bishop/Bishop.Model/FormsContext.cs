namespace Bishop.Model
{
    using System.Data.Entity;

    using Bishop.Model.Entities;

    public class FormsContext : DbContext
    {
        public DbSet<Form> Forms { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<FillingSession> FillingSessions { get; set; }
    }
}
