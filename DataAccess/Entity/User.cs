using System;
using System.Collections.Generic;

namespace DataAccess.Entity
{
    public class User:BaseEntity
    {
        public User()
        {
            this.CreatedTasks = new HashSet<Task>();
            this.AssignedTasks = new HashSet<Task>();
            this.Times = new HashSet<Time>();
            this.Comments = new HashSet<Comment>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Task> CreatedTasks { get; set; }

        public virtual ICollection<Task> AssignedTasks { get; set; }

        public virtual ICollection<Time> Times { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
