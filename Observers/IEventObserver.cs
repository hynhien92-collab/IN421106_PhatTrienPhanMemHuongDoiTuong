using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Observers;

using EduHub.Ch02.Domain;

public interface IEventObserver
{
    void OnEventCreated(Event ev, Club club);
}

public class LogNotifier : IEventObserver
{
    private readonly Interfaces.IAppLogger _logger;
    public LogNotifier(Interfaces.IAppLogger logger) => _logger = logger;
    public void OnEventCreated(Event ev, Club club) => _logger.Info($"Observer-Log: Event '{ev.Title}' created in club '{club.Name}'");
}

public class EmailNotifier : IEventObserver
{
    private readonly Interfaces.INotificationService _notifier;
    public EmailNotifier(Interfaces.INotificationService notifier) => _notifier = notifier;
    public void OnEventCreated(Event ev, Club club) => _notifier.Send("all-members@dthu.edu.vn", $"New Event: '{ev.Title}'");
}