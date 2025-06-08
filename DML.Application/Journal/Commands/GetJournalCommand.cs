using DML.Application.Extension;
using DML.Application.Journal.Models.Response;
using DML.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DML.Application.Journal.Commands;

public class GetJournalCommand(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
{
    public async Task<List<GetJournalResponse>> ExecuteAsync() 
    {
        var userId = httpContextAccessor.HttpContext.GetUserId();
        if (string.IsNullOrWhiteSpace(userId.ToString()))
            throw new Exception("User ID is required");

        var existUser = await appDbContext.Users.FindAsync(userId) ?? throw new Exception("User not found!");

        var journals = await appDbContext.JournalEntries
        .Where(x => x.UserId == userId)
        .Select(journal => new GetJournalResponse
        {
            Id = journal.Id,
            Note = journal.Note,
            Mood = (Models.Enums.MoodEnum?)journal.Mood,
            Tag = journal.Tag,
            CreatedAt = journal.CreatedAt,
            UpdatedAt = journal.UpdatedAt
        })
        .ToListAsync();

        if (journals == null || !journals.Any())
            throw new Exception("No journals found for the user.");

        return journals;
    }
}
