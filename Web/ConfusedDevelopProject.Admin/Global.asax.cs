using ConfusedDevelopProject.Core;
using ConfusedDevelopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.Mvc5;

namespace ConfusedDevelopProject.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            container.RegisterType<IDbContext, MyDbContext>();
            container.RegisterType<IRepository, Repository>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IUserContext, UserContext>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));//MVC注入
        }
    }
}
