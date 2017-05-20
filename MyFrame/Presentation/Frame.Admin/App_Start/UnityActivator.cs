using FluentValidation.Mvc;
using Frame.Admin.Validator;
using Frame.Core.Infrastructure;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Frame.Admin.App_Start.UnityActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Frame.Admin.App_Start.UnityActivator), "Shutdown")]

namespace Frame.Admin.App_Start
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

            //验证流
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            UnityValidatorActivatorFactory validatorFactory = new UnityValidatorActivatorFactory(ServiceContainer.Current);
            ModelValidatorProviders.Providers.Insert(0, new FluentValidationModelValidatorProvider(validatorFactory));


            //企业库【异常/日志】
            var entLibConfigPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"EntLibConfig.config");
            var configSouce = new FileConfigurationSource(entLibConfigPath);
            ExceptionPolicyFactory exceptionPolicyFactory = new ExceptionPolicyFactory(configSouce);
            ExceptionPolicy.SetExceptionManager(exceptionPolicyFactory.CreateManager());

            LogWriterFactory logWriterFactory = new LogWriterFactory(configSouce);
            Logger.SetLogWriter(logWriterFactory.Create());
        }

        /// <summary>Disposes the Unity container when the application is shut down.</summary>
        public static void Shutdown()
        {
            var container = ServiceContainer.Current;
            container.Dispose();
        }

    }
}