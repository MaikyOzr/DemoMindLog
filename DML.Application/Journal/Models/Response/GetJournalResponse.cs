using DML.Application.Journal.Models.Enums;

namespace DML.Application.Journal.Models.Response;

public class GetJournalResponse
{
    public Guid Id { get; set; }

    public string? Note { get; set; }

    public string? Tag { get; set; }

    public MoodEnum? Mood { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}
