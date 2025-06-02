using DML.Application.SignUp.Commands;
using DML.Application.SignUp.Models.Requests;

namespace DML.Web.Endpoints;

public static class AuthEndpoint
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/auth/signup", async (SignUpRequest request, SignUpCommand command) =>
        {
            await command.ExecuteAsync(request);
            return Results.Ok("User registered successfully.");
        });

        app.MapPost("/auth/signin", async (SingInRequest request, SignInCommnad command) =>
        {
            await command.ExecuteAsync(request);
            return Results.Ok("User signed in successfully.");
        });
    }
}
