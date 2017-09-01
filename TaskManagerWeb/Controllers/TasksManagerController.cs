using DataAccess;
using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerWeb.Models;

namespace TaskManagerWeb.Controllers
{
    public class TasksManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository(new TaskManagerDb());
            ViewData["task"] = tasksRepository.GetAll()
                .Where(i => i.AssigneeId == AuthenticationManager.LoggedUser.Id || i.CreatorId == AuthenticationManager.LoggedUser.Id).ToList();    

            return View();
        }
        public ActionResult TaskDetails(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository(new TaskManagerDb());
            TimesRepository timesRepository = new TimesRepository(new TaskManagerDb());
            CommentsRepository commentsRepository = new CommentsRepository(new TaskManagerDb());

            var times = timesRepository.GetAll();
            if (times != null)
            {
                ViewData["times"] = times.Where(i => i.TaskId == id).ToList();
            }
            else
            {
                ViewData["times"] = times;
            }
            
            var comments = commentsRepository.GetAll();
            if(comments != null)
            {
                ViewData["comments"] = comments.Where(c => c.TaskId == id).ToList();
            }
            else
            {
                ViewData["comments"] = comments;
            }

            ViewData["task"] = tasksRepository.GetById(id);

            return View();
        }
        [HttpGet]
        public ActionResult EditTask(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository(new TaskManagerDb());
            UsersRepository usersRepository = new UsersRepository(new TaskManagerDb());

            Task task = null;
            if (id == null)
            {
                task = new Task();
                task.CreatorId = AuthenticationManager.LoggedUser.Id;
                task.DateCreated = DateTime.Now;
                task.LastModified = DateTime.Now;
                task.IsDone = false;
            }
            else
                task = tasksRepository.GetById(id.Value);

            ViewData["task"] = task;
            ViewData["users"] = usersRepository.GetAll();

            return View();
        }
        [HttpPost]
        public ActionResult ChangeStatus(Task task)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            task.LastModified = DateTime.Now;

            TasksRepository tasksRepository = new TasksRepository(new TaskManagerDb());
            tasksRepository.Save(task);

            return RedirectToAction("EditComment", "CommentsManager", new { taskId = task.Id});
        }
        [HttpPost]
        public ActionResult EditTask(Task task)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            task.LastModified = DateTime.Now;

            TasksRepository tasksRepository = new TasksRepository(new TaskManagerDb());
            tasksRepository.Save(task);

            return RedirectToAction("Index", "TasksManager");
        }
        public ActionResult DeleteTask(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TasksRepository tasksRepository = new TasksRepository(new TaskManagerDb());
            Task task = tasksRepository.GetById(id);
            tasksRepository.Delete(task);

            return RedirectToAction("Index", "TasksManager");
        }
	}
}