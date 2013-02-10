namespace Bishop.Tests.Scenarios.ObjectMothers
{
    using Bishop.Model.Entities;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    public class FillingSessionMother : ObjectMother
    {
        public FillingSession GetBasicSession()
        {
            return new FillingSessionBuilder()
            .WithRandomId()
                .IsActive(true)
                .Build();
        }
    }
}
