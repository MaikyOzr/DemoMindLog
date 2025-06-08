using DML.Application.BaseResponse;
using DML.Application.Journal.Commands;
using DML.Application.Journal.Models.Request;
using Microsoft.AspNetCore.Mvc;

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

        app.MapPatch("/journal/{id}", 
            async (UpdateJournalRequest request, UpdateJournalCommand command, [FromRoute] Guid id) =>
        {
            return await command.ExecuteAsync(id, request);
        })
        .WithName("UpdateJournal")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization();


        app.MapGet("/journal", async (GetJournalCommand command) =>
        {
            return await command.ExecuteAsync();
        })
        .WithName("GetJournals")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization();

        app.MapGet("/journal/{id}", async (GetByIdJournalCommand command, [FromRoute]Guid id) =>
        {
            return await command.ExecuteAsync(id);
        })
        .WithName("GetJournal")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization();

        app.MapDelete("/journal/{id}", async (DeleteJournalCommand command, [FromRoute] Guid id) =>
        {
            return await command.ExecuteAsync(id);
        })
        .WithName("DeleteJournal")
        .Produces<Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .RequireAuthorization();
    }
}
