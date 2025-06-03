using DML.Application.BaseResponse;
using DML.Application.Journal.Commands;
using DML.Application.Journal.Models.Request;
using Microsoft.AspNetCore.Http;

namespace DML.Web.Endpoints;

public static class JournalEndpoint
{
    public static void MapJournalEndpoints(this WebApplication app)
    {
        app.MapPost("/api/journal", async (CreateJournalRequest request, CreateJournalCommand command) =>
        {
            return await command.ExecuteAsync(request);
        })
        .WithName("CreateJournal")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization();
    }
}
