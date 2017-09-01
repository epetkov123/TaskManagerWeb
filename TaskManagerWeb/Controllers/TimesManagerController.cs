using DataAccess;
using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Web.Mvc;
using TaskManagerWeb.Models;

namespace TaskManagerWeb.Controllers
{
    public class TimesManagerController : Controller
    {
        [HttpGet]
        public ActionResult EditTime(int? taskId, int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TimesRepository timesRepository = new TimesRepository(new TaskManagerDb());

            Time time = null;
            if (id == null)
            {
                time = new Time();
                time.DateTaken = DateTime.Now;
                time.TaskId = taskId.Value;
                time.UserId = AuthenticationManager.LoggedUser.Id;
            }
            else
            {
                time = timesRepository.GetById(id.Value);
            }

            ViewData["times"] = time;

            return View();
        }

        [HttpPost]
        public ActionResult EditTime(Time time)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            time.DateTaken = DateTime.Now;

            TimesRepository timesRepository = new TimesRepository(new TaskManagerDb());
            timesRepository.Save(time);

            return RedirectToAction("TaskDetails", "TasksManager", new { id = time.TaskId });
        }

        public ActionResult DeleteTime(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            TimesRepository timesRepository = new TimesRepository(new TaskManagerDb());
            Time time = timesRepository.GetById(id);
            timesRepository.Delete(time);

            return RedirectToAction("TaskDetails", "TasksManager", new { id = time.TaskId });
        }
    }
}