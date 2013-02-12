namespace Bishop.Model.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FillingSession
    {
        public FillingSession()
        {
            this.IsActive = true;
        }

        [Key]
        public Guid Id { get; set; }

        public Form Template { get; set; }

        public Guid ToContactId { get; set; }

        public bool IsActive { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}
