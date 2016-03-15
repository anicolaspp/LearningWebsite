using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Filters
{
    public class LoginRequiredAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var loggedUser = filterContext.HttpContext.Session["user"] as string;

            if (loggedUser == null)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                
                filterContext.Cancel = true;
            }
        }
    }
}
