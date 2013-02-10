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

        public bool IsActive { get; set; }
    }
}
