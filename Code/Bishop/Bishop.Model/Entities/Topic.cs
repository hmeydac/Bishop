namespace Bishop.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bishop.Framework.Exceptions;

    public class Topic
    {
        private readonly List<Question> questions;

        public Topic()
        {
            this.questions = new List<Question>();
            this.Title = string.Empty;
        }

        [Key]
        public double Id { get; set; }

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

        public void RemoveQuestion(Question question)
        {
            if (!this.questions.Contains(question))
            {
                throw new NotFoundException("Could not find Topic to remove.");
            }

            this.questions.Remove(question);
        }
    }
}