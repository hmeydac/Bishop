namespace Bishop.Tests.Scenarios.ObjectBuilders
{
    using System;

    using Bishop.Model.Entities;

    public class FormBuilder : ObjectBuilder<Form>
    {
        public FormBuilder WithRandomId()
        {
            this.Instance.Id = Guid.NewGuid();
            return this;
        }

        public FormBuilder WithTopic(Topic topic)
        {
            this.Instance.Topics.Add(topic);
            return this;
        }

        public FormBuilder WithTitle(string title)
        {
            this.Instance.Title = title;
            return this;
        }
    }
}
