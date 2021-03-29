using BLL.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP2.Infractructure
{
    public class ShopDependencyResolver : IDependencyResolver
    {
        IKernel kernel = new StandardKernel(new ShopDIModule());
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}