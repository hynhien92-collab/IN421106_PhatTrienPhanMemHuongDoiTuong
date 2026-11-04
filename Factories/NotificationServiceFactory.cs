using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Factories;

using EduHub.Ch02.Interfaces;
using EduHub.Ch02.Services;

public enum NotificationChannel { Email, Sms, Slack }

public interface INotificationServiceFactory
{
    INotificationService Create(NotificationChannel channel);
}

public class NotificationServiceFactory : INotificationServiceFactory
{
    public INotificationService Create(NotificationChannel channel) => channel switch
    {
        NotificationChannel.Email => new EmailNotificationService(),
        NotificationChannel.Sms => new SmsNotificationService(),
        NotificationChannel.Slack => new SlackNotificationService(),
        _ => throw new ArgumentOutOfRangeException(nameof(channel))
    };
}

public class SmsNotificationService : INotificationService
{
    public void Send(string to, string message) => Console.WriteLine($"[SMS] To {to}: {message}");
}

public class SlackNotificationService : INotificationService
{
    public void Send(string to, string message) => Console.WriteLine($"[SLACK] To {to}: {message}");
}
public class EmailNotificationService : INotificationService
{
    public void Send(string to, string message) => Console.WriteLine($"[EMAIL] To {to}: {message}");
}