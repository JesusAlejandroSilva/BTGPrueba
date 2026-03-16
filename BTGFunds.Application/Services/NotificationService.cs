using BTGFunds.Application.Interfaces;
using BTGFunds.Domain.Entities;

namespace BTGFunds.Application.Services
{
    public class NotificationService : INotificationService
    {
        public Task Notify(User user, string message)
        {
            if (user.NotificationPreference == "SMS")
                Console.WriteLine($"SMS enviado a {user.Phone}: {message}");
            else
                Console.WriteLine($"Email enviado a {user.Email}: {message}");

            return Task.CompletedTask;
        }
    }
}
