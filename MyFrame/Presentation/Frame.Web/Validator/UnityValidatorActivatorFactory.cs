using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Mvc;
using Microsoft.Practices.Unity;
using FluentValidation;
using Frame.Core.Infrastructure;

namespace Frame.Web.Validator
{
    public class UnityValidatorActivatorFactory:ValidatorFactoryBase
    {
        private readonly IUnityContainer _unityContainer;
        public UnityValidatorActivatorFactory(IUnityContainer unityContainer)
        {
            _unityContainer =unityContainer;
        }
        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator = null;
            try
            {
                validator=_unityContainer.Resolve(validatorType, validatorType.GetGenericArguments().First().FullName) as IValidator;

            }
            catch(Exception ex)
            {

            }
            return validator;
        }
    }
}