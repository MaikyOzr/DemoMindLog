using DML.Application.BaseResponse;
using DML.Application.Journal.Commands;
using DML.Application.Journal.Models.Request;

namespace DML.Web.Endpoints;

public static class JournalEndpoint
{
    public static void MapJournalEndpoints(this WebApplication app)
    {
        app.MapPost("/journal", async (CreateJournalRequest request, CreateJournalCommand command) =>
        {
            return await command.ExecuteAsync(request);
        })
        .WithName("CreateJournal")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization();

        app.MapGet("/journal", async (GetJournalCommand command) =>
        {
            return await command.ExecuteAsync();
        })
        .WithName("GetJournal")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization();
    }
}
