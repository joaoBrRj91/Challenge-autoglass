using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Validations.Documents;
using FluentValidation;

namespace ClallangeAutoGlass.Business.Validations
{
	public class SupplierValidation :  AbstractValidator<Supplier>
	{
		public SupplierValidation()
		{
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The field {PropertyName} is required");

            RuleFor(c => c.Document)
                .NotEmpty().WithMessage("The field {PropertyName} is required");

            RuleFor(f => CnpjBusinessValidation.Validate(f.Document)).Equal(true)
                  .WithMessage("Document is not valid.");
        }
	}
}

