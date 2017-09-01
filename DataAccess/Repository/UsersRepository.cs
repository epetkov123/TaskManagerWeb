using DataAccess.Entity;
using System.Linq;

namespace DataAccess.Repository
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository(TaskManagerDb context) : base(context)
        {

        }

        public User GetByUsernameAndPassword(string username, string password)
        {
            using (TaskManagerDb context = new TaskManagerDb())
            {
                return context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
        }
    }
}
