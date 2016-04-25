using System;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Filters
{
    public class MembershipRequiredAttribute : ActionFilterAttribute
    {
        private readonly Role _requiredRole;

        public MembershipRequiredAttribute(Role requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var loggedUser = filterContext.HttpContext.Session["user"] as User;

            if (loggedUser == null || loggedUser.Role < _requiredRole)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}
