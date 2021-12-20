using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation 
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) 
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) 
        {
            //product validator'ın instancaını oluştur. çalışma tipini bul. 
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //productvalidator'ın generic argumanlaarından ilkini bul. <product> 
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //methodun parametrelerinden , product validator'ın sıfırında argumanına eşit
            // olan parametreleri bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities) 
            {
                ValidationTool.Validate(validator, entity); 
            }
        }
    }
}
