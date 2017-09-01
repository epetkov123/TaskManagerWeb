using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entity
{
    public class Task : BaseEntity
    {
        public Task()
        {
            this.Times = new HashSet<Time>();
            this.Comments = new HashSet<Comment>();
            Assignee = null;
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int TimeDone { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? LastModified { get; set; }

        public bool IsDone { get; set; }

        public int CreatorId { get; set; }

        public int AssigneeId { get; set; }

        public virtual User Assignee { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Time> Times {get;set;}

        public virtual ICollection<Comment> Comments { get; set; }

    }
}
