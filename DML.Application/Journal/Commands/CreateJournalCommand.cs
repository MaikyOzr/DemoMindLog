using DML.Application.BaseResponse;
using DML.Application.Extension;
using DML.Application.Journal.Models.Request;
using DML.Domain.Entity;
using DML.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DML.Application.Journal.Commands;

public class CreateJournalCommand(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
{
    public async Task<Response> ExecuteAsync(CreateJournalRequest request)
    {
        bool isSave = true;
        var userId = httpContextAccessor.HttpContext.GetUserId();
        if (string.IsNullOrWhiteSpace(userId.ToString()))
            throw new Exception("User ID is required");

        var existUser = await appDbContext.Users.FindAsync(Guid.Parse(userId.ToString())) ?? throw new Exception("User not found!");

        var newJournal = new JournalEntry
        {
            Id = Guid.NewGuid(),
            Note = request.Note,
            Mood = (Domain.Enums.MoodEnum?)request.Mood,
            CreatedAt = DateTime.UtcNow,
            Tag = request.Tag,
            UserId = existUser.Id,
        };

        appDbContext.JournalEntries.Add(newJournal);
        await appDbContext.SaveChangesAsync();


        return new Response { IsSuccess = isSave, Id = newJournal.Id };
    }
}
