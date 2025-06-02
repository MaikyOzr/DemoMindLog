using DML.Application.BaseResponse;
using DML.Application.Journal.Models.Request;
using DML.Domain.Entity;
using DML.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace DML.Application.Journal.Commands;

public class CreateJournalCommand(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
{
    public async Task<Response> ExecuteAsync(CreateJournalRequest request)
    {
        bool isSave = true;
        //var userId = httpContextAccessor.HttpContext?.User.FindFirst("id")?.Value;
        //if (string.IsNullOrWhiteSpace(userId))
        //    throw new Exception("User ID is required");
        
        //var existUser = await appDbContext.Users.FindAsync(Guid.Parse(userId)) ?? throw new Exception("User not found!");

        var newJournal = new JournalEntry
        {
            Id = Guid.NewGuid(),
            Note = request.Note,
            Mood = (Domain.Enums.MoodEnum?)request.Mood,
            CreatedAt = DateTime.UtcNow,
            Tag = request.Tag,
        };

        appDbContext.JournalEntries.Add(newJournal);
        await appDbContext.SaveChangesAsync();


        return new Response { IsSuccess = isSave, Id = newJournal.Id };
    }
}
