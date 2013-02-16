namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    using System;

    using Bishop.Model.Entities;

    public class PublishedFormBuilder : ObjectBuilder<PublishedForm>
    {
        public PublishedFormBuilder WithRandomId()
        {
            this.Instance.Id = Guid.NewGuid();
            return this;
        }

        public PublishedFormBuilder WithTitle(string title)
        {
            this.Instance.Title = title;
            return this;
        }

        public PublishedFormBuilder WithFromDate(DateTime date)
        {
            this.Instance.FromDate = date;
            return this;
        }

        public PublishedFormBuilder WithExpirationDate(DateTime date)
        {
            this.Instance.ExpirationDate = date;
            return this;
        }
    }
}
