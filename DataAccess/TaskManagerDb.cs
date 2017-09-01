namespace DataAccess
{
    using DataAccess.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    public class TaskManagerDb : DbContext
    {
        public TaskManagerDb()
            : base("name=TaskManagerDb")
        {
            Database.SetInitializer(new CustomInitalizer());
        }

        public virtual DbSet<Time> Times { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignedTasks)
                .WithRequired(t => t.Assignee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedTasks)
                .WithRequired(t => t.Creator)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithRequired(c => c.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Times)
                .WithRequired(w => w.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasMany(t => t.Comments)
                .WithRequired(c => c.Task)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Task>()
                .HasMany(t => t.Times)
                .WithRequired(w => w.Task)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);

        }

        public class CustomInitalizer : DropCreateDatabaseIfModelChanges<TaskManagerDb>
        { 
            protected override void Seed(TaskManagerDb context)
            {
                context.Users.AddOrUpdate(u => u.Id, new User
                {
                    IsAdmin = true,
                    FirstName = "Admin",
                    LastName = "Adminov",
                    Username = "admin",
                    Password = "123"
                });

                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}