namespace Bishop.Model.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bishop.Framework.Exceptions;

    public class Survey
    {
        private readonly List<Topic> topics;

        public Survey()
        {
            this.topics = new List<Topic>();
            this.Title = string.Empty;
        }

        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Topic> Topics
        {
            get { return this.topics; }
        }

        public void AddTopic(Topic topic)
        {
            this.topics.Add(topic);
        }

        public void RemoveTopic(Topic topic)
        {
            if (!this.topics.Contains(topic))
            {
                throw new NotFoundException("Could not find Topic to remove.");
            }

            this.topics.Remove(topic);
        }
    }
}
