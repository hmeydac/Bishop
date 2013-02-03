namespace Bishop.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
        public long Id { get; set; }

        public string Title { get; set; }

        public IList<Question> Questions
        {
            get
            {
                return this.questions;
            }
        }
    }
}