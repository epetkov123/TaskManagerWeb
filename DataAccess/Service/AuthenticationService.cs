using DataAccess.Entity;
using DataAccess.Repository;

namespace DataAccess.Service
{
    public class AuthenticationService
    {
        public User LoggedUser { get; private set; }

        public void AuthenticateUser(string username, string password)
        {
            UsersRepository userRepo = new UsersRepository(new TaskManagerDb());
            LoggedUser = userRepo.GetByUsernameAndPassword(username, password);
        }
    }
}
