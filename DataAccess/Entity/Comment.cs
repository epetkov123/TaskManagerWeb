using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Comment:BaseEntity
    {
        public int UserId { get; set; }

        public int TaskId { get; set; }

        [Required]
        public string Body { get; set; }

        public virtual User User { get; set; }

        public virtual Task Task { get; set; }
    }
}
