using DML.Application.BaseResponse;
using DML.Application.Extension;
using DML.Application.Journal.Models.Request;
using DML.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DML.Application.Journal.Commands;

public class UpdateJournalCommand(AppDbContext context, IHttpContextAccessor httpContextAccessor)
{
    public async Task<Response> ExecuteAsync(Guid id, UpdateJournalRequest editJournalRequest) 
    {
        var userId = httpContextAccessor.HttpContext.GetUserId();
        if (string.IsNullOrWhiteSpace(userId.ToString()))
            throw new Exception("User ID is required");

        var existUser = await context.Users.FindAsync(userId) ?? throw new Exception("User not found!");

        var existJournal = await context.JournalEntries.Where(x=> x.Id == id).AsTracking().FirstOrDefaultAsync() 
            ?? throw new Exception("Journal not found!");

        existJournal.Note = editJournalRequest.Note;
        existJournal.Tag = editJournalRequest.Tag;

        await context.SaveChangesAsync();

        return new Response
        {
            Id = existJournal.Id,
            IsSuccess = true,
        };
    }
}
