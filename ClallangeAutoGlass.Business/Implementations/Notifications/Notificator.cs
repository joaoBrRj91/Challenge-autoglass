using System;
using ClallangeAutoGlass.Business.Interfaces.Notifications;

namespace ClallangeAutoGlass.Business.Implementations.Notifications
{
	public class Notificator : INotificator
    {
        private List<Notification> notifications;


        public Notificator() => notifications = new List<Notification>();

        public List<Notification> GetNotifications() => notifications;

        public void Handle(Notification notification) => notifications.Add(notification);

        public bool IsHaveNotifications() => notifications.Any();

    }
}

