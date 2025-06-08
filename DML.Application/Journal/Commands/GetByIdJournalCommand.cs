using DML.Application.Extension;
using DML.Application.Journal.Models.Response;
using DML.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DML.Application.Journal.Commands;

public class GetByIdJournalCommand(AppDbContext context, IHttpContextAccessor httpContextAccessor)
{
    public async Task<GetJournalResponse> ExecuteAsync(Guid id) 
    {
        var userId = httpContextAccessor.HttpContext.GetUserId();
        if (string.IsNullOrWhiteSpace(userId.ToString()))
            throw new Exception("User ID is required");

        var existUser = await context.Users.FindAsync(userId) ?? throw new Exception("User not found!");

        var journal = await context.JournalEntries.Where(x => x.Id == id)
            .Select(journal=> new GetJournalResponse {
                Id = journal.Id,
                Note = journal.Note,
                Tag = journal.Tag,
                Mood = (Models.Enums.MoodEnum?)journal.Mood,
                CreatedAt = journal.CreatedAt,
                UpdatedAt = journal.UpdatedAt
            })
            .AsNoTracking().FirstOrDefaultAsync() ?? throw new Exception("Jounals is empty");

        return journal;
    }
}
