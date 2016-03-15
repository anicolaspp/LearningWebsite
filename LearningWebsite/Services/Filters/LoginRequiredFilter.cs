using System.Web.Mvc;

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
