using System.Net;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Interfaces.Notifications;

namespace ChallengeAutoGlass.Application.AppServices
{
    public abstract class BaseAppService
    {
        private readonly INotificator notificator;

        protected BaseAppService(INotificator notificator) => this.notificator = notificator;


        protected BaseResponse CreateResponseResultByStatusCode(HttpStatusCode statusCodeResult, object? result = null)
            => new BaseResponse
            {
                IsSuccess = !notificator.IsHaveNotifications(),
                StatusCode = notificator.IsHaveNotifications() ? HttpStatusCode.BadRequest : statusCodeResult,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList(),
                Result = result
            };
    }
}

