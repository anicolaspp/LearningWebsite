using System.Web.Mvc;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;

namespace LearningWebsite.Controllers
{
    public class ControllerBase : Controller
    {
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
    }
}