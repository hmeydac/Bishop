namespace Bishop.Tests.ObjectMothers
{
    using System;

    using Bishop.Model.Entities;

    public class FormObjectMother : ObjectMother<Form>
    {
        public override Form CreateInstance()
        {
            return new Form();
        }

        public FormObjectMother WithRandomId()
        {
            var seed = int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber);
            this.Instance.Id = new Random(seed).Next(0, 9000000);
            return this;
        }

        public FormObjectMother WithTopic(Topic topic)
        {
            this.Instance.Topics.Add(topic);
            return this;
        }
    }
}
