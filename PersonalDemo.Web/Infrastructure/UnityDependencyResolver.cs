using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace PersonalDemo.Web.Infrastructure
{
    public class UnityDependencyResolver:IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (!_container.IsRegistered(serviceType))
            {
                return null;
            }
            else
            {
                return _container.Resolve(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (!_container.IsRegistered(serviceType))
            {
                return new List<object>();
            }
            else
            {
                return _container.ResolveAll(serviceType);
            }
        }
    }
}