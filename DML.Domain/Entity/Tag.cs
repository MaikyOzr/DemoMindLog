namespace DML.Domain.Entity;

public class Tag
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!; 

    public IList<JournalEntry> JournalEntries { get; set; } = [];
}
