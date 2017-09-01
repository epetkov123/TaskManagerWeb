using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Time:BaseEntity
    {
        [Required]
        public int TimeTaken { get; set; }

        public DateTime? DateTaken { get; set; }

        public int UserId { get; set; }

        public int TaskId { get; set; }

        public virtual User User { get; set; }

        public virtual Task Task { get; set; }
    }
}
