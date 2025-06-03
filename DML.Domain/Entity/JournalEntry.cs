using DML.Domain.Enums;

namespace DML.Domain.Entity;


public class JournalEntry
{
    public Guid Id { get; set; }
    
    public string? Note { get; set; }

    public string? Tag { get; set; }

    public MoodEnum? Mood { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; } = default!;

}
