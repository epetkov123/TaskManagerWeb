using DataAccess.Entity;
using DataAccess.Repository;
using System.Web.Mvc;
using TaskManagerWeb.Models;
using DataAccess;

namespace TaskManagerWeb.Controllers
{
    public class CommentsManagerController : Controller
    {
        [HttpGet]
        public ActionResult EditComment(int? taskId, int? id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            CommentsRepository commentsRepository = new CommentsRepository(new TaskManagerDb());

            Comment comment = null;
            if (id == null)
            {
                comment = new Comment();
                comment.TaskId = taskId.Value;
                comment.UserId = AuthenticationManager.LoggedUser.Id;
            }
            else
            {
                comment = commentsRepository.GetById(id.Value);
            }

            ViewData["comments"] = comment;

            return View();
        }

        [HttpPost]
        public ActionResult EditComment(Comment comment)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            CommentsRepository commentsRepository = new CommentsRepository(new TaskManagerDb());
            commentsRepository.Save(comment);

            return RedirectToAction("TaskDetails", "TasksManager", new { id = comment.TaskId});
        }

        public ActionResult DeleteComment(int id)
        {
            if (AuthenticationManager.LoggedUser == null)
                return RedirectToAction("Login", "Home");

            CommentsRepository commentsRepository = new CommentsRepository(new TaskManagerDb());
            Comment comment = commentsRepository.GetById(id);
            commentsRepository.Delete(comment);

            return RedirectToAction("TaskDetails", "TasksManager", new { id = comment.TaskId });
        }
    }
}