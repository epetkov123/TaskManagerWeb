using DataAccess.Entity;

namespace DataAccess.Repository
{
    public class TimesRepository : BaseRepository<Time>
    {
        public TimesRepository(TaskManagerDb context) : base(context)
        {
            
        }
    }
}
