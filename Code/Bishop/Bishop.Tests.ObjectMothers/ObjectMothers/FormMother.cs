namespace Bishop.Tests.Scenarios.ObjectMothers
{
    using Bishop.Model.Entities;
    using Bishop.Tests.Scenarios.ObjectBuilders;

    public class FormMother : ObjectMother
    {
        public Form GetBasicSurvey()
        {
            var topic = new TopicMother()
                .GetDefaultTopic("Topic Name");
              

           var form = new FormBuilder()
                .WithRandomId()
                .WithTitle("Basic Survey")
                .WithTopic(topic)
                .Build();

           return form;
        }
    }
}
