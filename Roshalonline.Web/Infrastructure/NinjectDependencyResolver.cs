using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Roshalonline.Logic.Interfaces;
using Roshalonline.Web.Models;
using Roshalonline.Logic.Services;
using Roshalonline.Logic.MiddleEntities;

namespace Roshalonline.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
        public void AddBindings()
        {
            _kernel.Bind<IEntry<NewsME>>().To<NewsService>();
        }
    }
}