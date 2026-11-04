using System;
using System.Collections.Generic;
using System.Text;

namespace EduHub.Ch02.Strategies;

public record ClubStat(string ClubName, int MembersCount, int EventsCount);

public interface IReportStrategy
{
    string Name { get; }
    string Render(IReadOnlyList<ClubStat> stats);
}

public class CsvReportStrategy : IReportStrategy
{
    public string Name => "CSV";
    public string Render(IReadOnlyList<ClubStat> stats)
    {
        var header = "ClubName,MembersCount,EventsCount";
        var lines = stats.Select(s => $"{s.ClubName},{s.MembersCount},{s.EventsCount}");
        return header + "\n" + string.Join("\n", lines);
    }
}

public class ConsoleReportStrategy : IReportStrategy
{
    public string Name => "Console";
    public string Render(IReadOnlyList<ClubStat> stats)
    {
        return string.Join("\n", stats.Select(s => $"Club: {s.ClubName} | Members: {s.MembersCount} | Events: {s.EventsCount}"));
    }
}