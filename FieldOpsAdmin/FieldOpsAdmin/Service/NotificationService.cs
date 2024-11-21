
using FieldOpsAdmin.Components.Model;
namespace FieldOpsAdmin.Service
{
    public class NotificationService
    {
        private List<Notification> notifications = new List<Notification>();

        public void AddNotification(Notification notification)
        {
            notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return notifications;
        }
    }
}
