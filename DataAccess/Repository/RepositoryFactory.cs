using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RepositoryFactory
    {
        /*
        public static UsersRepository GetUsersRepository()
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["TaskManagerConnectionString"].ConnectionString;
            return new UsersRepository(connectionString);
        }

        public static TasksRepository GetTasksRepository()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["TaskManagerConnectionString"].ConnectionString;
            return new TasksRepository(connectionString);
        }

        public static TimesRepository GetTimesRepository()
        {
            string path = ConfigurationManager.AppSettings["dataPath"];
            return new TimesRepository(path + @"\times.txt");
        }

        public static TimesRepository GetTimesRepository()
        {
            string path = ConfigurationManager.AppSettings["dataPath"];
            return new TimesRepository(path + @"\Times.txt");
        }
        */
    }
}
