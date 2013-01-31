namespace Bishop.Model
{
    using System.Data.Entity;

    using Bishop.Model.Entities;

    public class SurveyContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }
    }
}
