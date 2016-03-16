using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Implementations;
using Ninject;
using WebGrease.Configuration;

namespace LearningWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyResolver.SetResolver(new NinjectResolver());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public class NinjectResolver : IDependencyResolver
    {
        private readonly IKernel _kernel = new StandardKernel();

        public NinjectResolver()
        {
            _kernel.Bind<IUserService>().To<UserService>();
            _kernel.Bind<IUserRepository>().To<UserRepository>();
            _kernel.Bind<ICourseMaterialRepository>().To<CourseMaterialRepository>();
        }

        public object GetService(Type serviceType)
        {
           return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}
