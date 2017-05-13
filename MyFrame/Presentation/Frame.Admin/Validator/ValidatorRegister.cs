using FluentValidation;
using Frame.Core.Infrastructure.DependencyManagement;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Frame.Admin.Validator
{
    public class ValidatorRegister : IDependencyRegistrar
    {
        public void Register(IUnityContainer container)
        {
            var validatorTypes = this.GetType().Assembly.GetTypes().Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)));
            foreach (var item in validatorTypes)
            {
                var type = item.BaseType.GetGenericArguments().First();
                container.RegisterType(typeof(IValidator<>),item,type.FullName,new ContainerControlledLifetimeManager());
            }
        }
    }
}