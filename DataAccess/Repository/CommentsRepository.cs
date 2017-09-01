using DataAccess.Entity;

namespace DataAccess.Repository
{
    public class CommentsRepository : BaseRepository<Comment>
    {
        public CommentsRepository(TaskManagerDb context) : base(context)
        {

        }
    }
}
