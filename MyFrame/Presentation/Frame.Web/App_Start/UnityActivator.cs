using Frame.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Mvc;
using FluentValidation.Mvc;
using Frame.Web.Validator;
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Frame.Web.App_Start.UnityActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Frame.Web.App_Start.UnityActivator), "Shutdown")]

namespace Frame.Web.App_Start
{
    public static class UnityActivator
    {
        public static void Start()
        {
            EngineContext.Initialize(false);
            var container = ServiceContainer.Current;
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            UnityValidatorActivatorFactory validatorFactory = new UnityValidatorActivatorFactory(ServiceContainer.Current);
            ModelValidatorProviders.Providers.Insert(0, new FluentValidationModelValidatorProvider(validatorFactory));
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = ServiceContainer.Current;
            container.Dispose();
        }

    }
}