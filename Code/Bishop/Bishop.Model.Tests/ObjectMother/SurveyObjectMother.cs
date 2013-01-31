namespace Bishop.Model.Tests.ObjectMother
{
    using Bishop.Model.Entities;

    public class SurveyObjectMother : ObjectMother<Survey>
    {
        public override Survey CreateInstance()
        {
            return new Survey();
        }

        public SurveyObjectMother WithTopic(Topic topic)
        {
            this.Instance.AddTopic(topic);
            return this;
        }
    }
}
