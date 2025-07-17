using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //    public static void Validate(IValidator validator, object entity)

        //    {
        //        var result = validator.Validate(entity);
        //        if (!result.IsValid)
        //        {
        //            throw new ValidationException(result.Errors);
        //        }
        //    }

        public static void Validate(IValidator validator, object entity)
        {
            // Den korrekten ValidationContext dynamisch erstellen
            var contextType = typeof(ValidationContext<>).MakeGenericType(entity.GetType());
            var contextInstance = Activator.CreateInstance(contextType, entity);

            var result = (FluentValidation.Results.ValidationResult)validator
                .GetType()
                .GetMethod("Validate", new[] { contextType })
                .Invoke(validator, new[] { contextInstance });

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}