using DML.Application.BaseResponse;
using DML.Application.Journal.Commands;
using DML.Application.Journal.Models.Request;

namespace DML.Web.Endpoints;

public static class JournalEndpoint
{
    public static void MapJournalEndpoints(this WebApplication app)
    {
        app.MapPost("/api/journal", async (CreateJournalRequest request, CreateJournalCommand command) =>
        {
            var response = await command.ExecuteAsync(request);
            return Results.Ok(response);
        })
        .WithName("CreateJournal")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        ;
    }
}
