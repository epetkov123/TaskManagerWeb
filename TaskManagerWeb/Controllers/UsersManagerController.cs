using DataAccess;
using DataAccess.Entity;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerWeb.Models;

namespace TaskManagerWeb.Controllers
{
    public class UsersManagerController : Controller
    {
        public ActionResult Index()
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository(new TaskManagerDb());
            ViewData["users"] = usersRepository.GetAll();

            return View();
        }
        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository(new TaskManagerDb());

            User user = null;
            if (id == null)
                user = new User();
            else
                user = usersRepository.GetById(id.Value);

            ViewData["user"] = user;

            return View();
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository(new TaskManagerDb());
            usersRepository.Save(user);

            return RedirectToAction("Index", "UsersManager");
        }

        public ActionResult DeleteUser(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            UsersRepository usersRepository = new UsersRepository(new TaskManagerDb());
            User user = usersRepository.GetById(id);
            usersRepository.Delete(user);

            return RedirectToAction("Index", "UsersManager");
        }
	}
}