namespace Application.Interfaces
{
    public interface INotificationService
    {
        void Send(UserCreated message);

    }

    public class UserCreated
    {
        public long Id { get; set; }
    }
}