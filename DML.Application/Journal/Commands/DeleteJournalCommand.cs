using DML.Application.Extension;
using DML.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace DML.Application.Journal.Commands;

public class DeleteJournalCommand(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
{
    public async Task<bool> ExecuteAsync(Guid id) 
    {
        var userId = httpContextAccessor.HttpContext.GetUserId();
        
        if (string.IsNullOrWhiteSpace(userId.ToString()))
            throw new Exception("User ID is required");

        var existUser = await appDbContext.Users.FindAsync(userId) ?? throw new Exception("User not found!");

        var journal = await appDbContext.JournalEntries.FindAsync(id) ?? throw new Exception("Journal not found!");
        
        appDbContext.JournalEntries.Remove(journal);
        
        await appDbContext.SaveChangesAsync();
        return true;
    }
}
