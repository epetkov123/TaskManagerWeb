using DataAccess.Entity;

namespace DataAccess.Repository
{ 
    public class TasksRepository : BaseRepository<Task>
    {
        public TasksRepository(TaskManagerDb context) : base(context)
        {

        }
    }
}
