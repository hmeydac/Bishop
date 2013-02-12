namespace Bishop.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PublishedForm
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsActive { get; set; }

        public string Title { get; set; }

        public Form Form { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
