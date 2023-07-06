using System;
using ClallangeAutoGlass.Business.Implementations.Notifications;

namespace ClallangeAutoGlass.Business.Interfaces.Notifications
{
	public interface INotificator
    {
        bool IsHaveNotifications();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}

