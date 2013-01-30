namespace Bishop.Model.Entities
{
    using System.Collections.Generic;

    public class Survey
    {
        private List<Question> questions;

        public Survey()
        {
            this.questions = new List<Question>();
            this.Title = string.Empty;
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Question> Questions
        {
            get
            {
                return this.questions;
            }
        }

        public void AddQuestion(Question question)
        {
            this.questions.Add(question);
        }
    }
}
