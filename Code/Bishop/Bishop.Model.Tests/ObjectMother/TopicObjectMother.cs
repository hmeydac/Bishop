namespace Bishop.Model.Tests.ObjectMother
{
    using Bishop.Model.Entities;

    public class TopicObjectMother : ObjectMother<Topic>
    {
        public override Topic CreateInstance()
        {
            return new Topic();
        }

        public TopicObjectMother WithTitle(string title)
        {
            this.Instance.Title = title;
            return this;
        }

        public TopicObjectMother WithQuestion(Question question)
        {
            this.Instance.AddQuestion(question);
            return this;
        }
    }
}
