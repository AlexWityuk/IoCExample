using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IoCExample.Models;
using Ninject;

namespace IoCExample.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //kernel.Bind<IRepository>().To<BooksRepository>().WithConstructorArgument("db", new BooksModel());
            kernel.Bind<IRepository>().To<BooksRepository>().WithPropertyValue("Db", new BooksModel());
        }
    }
}