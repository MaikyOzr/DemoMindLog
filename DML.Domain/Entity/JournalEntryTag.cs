namespace DML.Domain.Entity;

public class JournalEntryTag
{
    public Guid JournalEntryId { get; set; }

    public JournalEntry JournalEntry { get; set; } = default!;

    public Guid TagId { get; set; }

    public Tag Tag { get; set; } = default!;
}
