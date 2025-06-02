using Microsoft.AspNetCore.Identity;

namespace DML.Domain.Entity;

public class User : IdentityUser<Guid>
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public IList<JournalEntry> JournalEntries { get; set; } = [];
}
