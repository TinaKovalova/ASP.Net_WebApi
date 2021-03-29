using ASP2.Infractructure;
using BLL.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASP2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            IKernel kernel = new StandardKernel(new ShopDIModule());
            DependencyResolver.SetResolver(new ShopDependencyResolver());
           
        }
    }
}
