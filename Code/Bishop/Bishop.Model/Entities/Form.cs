namespace Bishop.Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Bishop.Framework.Exceptions;

    public class Form
    {
        private readonly List<Topic> topics;

        public Form()
        {
            this.topics = new List<Topic>();
            this.Title = string.Empty;
        }

        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public IList<Topic> Topics
        {
            get { return this.topics; }
        }
    }
}
