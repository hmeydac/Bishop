namespace Bishop.Tests.Scenarios.ObjectMothers
{
    using System;

    using Bishop.Model.Entities;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    public class PublishedFormMother : ObjectMother
    {
        public PublishedForm GetBasicPublishedForm()
        {
            return new PublishedFormBuilder()
                .WithRandomId()
                .WithTitle("Test")
                .WithFromDate(DateTime.Now)
                .WithExpirationDate(DateTime.Now.AddDays(2))
                .Build();
        }

        public PublishedForm[] GetArrayPublishedForm()
        {
            return new[]
                       {
                           new PublishedFormBuilder().WithRandomId()
                                                     .WithTitle("Test 1")
                                                     .WithFromDate(DateTime.Now)
                                                     .WithExpirationDate(DateTime.Now.AddDays(2))
                                                     .Build(),
                           new PublishedFormBuilder().WithRandomId()
                                                     .WithTitle("Test 2")
                                                     .WithFromDate(DateTime.Now)
                                                     .WithExpirationDate(DateTime.Now.AddDays(5))
                                                     .Build(),
                           new PublishedFormBuilder().WithRandomId()
                                                     .WithTitle("Test 3")
                                                     .WithFromDate(DateTime.Now)
                                                     .WithExpirationDate(DateTime.Now.AddDays(1))
                                                     .Build()
                       };
        }
    }
}
