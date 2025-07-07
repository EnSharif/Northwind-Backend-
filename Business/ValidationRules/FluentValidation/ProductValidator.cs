using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).Length(2,30);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(p => p.UnitPrice).GreaterThan(0).When(p => p.CategoryId == 1); //  CategoryId 1 morethen UnitPrice 0
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Product name must start with 'A'"); // Custom rule


        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
