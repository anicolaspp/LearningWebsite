using System.Web.Mvc;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;

namespace LearningWebsite.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public abstract string PageName { get; }

        public UserViewModel GetLoggedUser()
        {
            var loggedUser = Session["user"] as User;

            loggedUser = loggedUser ?? new User {Role = Role.Guest};

            return new UserViewModel
            {
                Role = loggedUser.Role,
                UserName = loggedUser.PersonName,
                Id = loggedUser.Id
            };   
        }

        protected ActionResult GetErrorPage(string message)
        {
            return View("~/Views/Shared/Error.cshtml", new ErrorModel
            {
                UserViewModel = GetLoggedUser(),
                PageName = PageName,
                ErrorMessage = message,
            });
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewData = new ViewDataDictionary(new ErrorModel
                {
                    UserViewModel = GetLoggedUser(),
                    ErrorMessage = filterContext.Exception.Message,
                    PageName = PageName
                }),
                ViewName = "~/Views/Shared/Error.cshtml",
            };
            
        }
    }
}