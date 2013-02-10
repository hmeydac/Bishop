namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    using System;

    using Bishop.Model.Entities;

    public class FillingSessionBuilder : ObjectBuilder<FillingSession>
    {
        public FillingSessionBuilder IsActive(bool isActive)
        {
            this.Instance.IsActive = isActive;
            return this;
        }

        public FillingSessionBuilder WithRandomId()
        {
            this.Instance.Id = Guid.NewGuid();
            return this;
        }
    }
}
