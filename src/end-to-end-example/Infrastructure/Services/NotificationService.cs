using Application.Interfaces;

namespace Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        public void Send(UserCreated message)
        {
            // Do nothing, for now.  We haven't implemented NServiceBus, or whatever it will be.
        }
    }
}