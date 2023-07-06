using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Notifications;
using ClallangeAutoGlass.Business.Interfaces.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace ClallangeAutoGlass.Business.Implementations.Services
{
	public class BaseService
	{
        private readonly INotificator notificator;

        protected BaseService(INotificator notificator)
		{
            this.notificator = notificator;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensage)
        {
            notificator.Handle(new Notification(mensage));
        }

        protected bool RunValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}

