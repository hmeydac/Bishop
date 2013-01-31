namespace Bishop.Model.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SurveyContext>
    {
        public Configuration()
        {
            // TODO: Remove this in Production
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
