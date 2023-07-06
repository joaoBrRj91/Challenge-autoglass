using System;
using ClallangeAutoGlass.Business.Entities;
using FluentValidation;

namespace ClallangeAutoGlass.Business.Validations
{
	public class ProductValidation :  AbstractValidator<Product>
	{
		public ProductValidation()
		{
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.FabricationDate)
                .NotEqual(d=>DateTime.MinValue).WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.ExpirationDate)
                .NotEqual(d => DateTime.MinValue).WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.FabricationDate)
               .LessThan(d => d.ExpirationDate).WithMessage("The field {PropertyName} need to be less than the expiration date");
        }
	}
}

