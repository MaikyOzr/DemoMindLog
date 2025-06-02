namespace DML.Domain.Entity;

public class JournalEntry
{
    public Guid Id { get; set; }
    
    public string? Note { get; set; }

    public int Mood { get; set; } // 0 - Sad, 1 - Neutral, 2 - Happy (0-10)

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? UpdatedAt { get; set; }
    
    public Guid UserId { get; set; }
    
    public User User { get; set; } = default!; 
}
