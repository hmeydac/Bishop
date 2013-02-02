namespace Bishop.UI.Web.Models.Forms
{
    using System.Collections.Generic;

    public class Topic
    {
        public Topic()
        {
            this.Questions = new List<Question>();
        }

        public double Id { get; set; }

        public string Title { get; set; }

        public List<Question> Questions { get; set; }
    }
}