using DML.Application.SignUp.Models.Requests;
using DML.Domain.Entity;
using DML.Infrastructure;
using Microsoft.AspNetCore.Identity;


namespace DML.Application.SignUp.Commands;

public class SignUpCommand(UserManager<User> userManager, AppDbContext appDbContext)
{
    public async Task ExecuteAsync(SignUpRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            throw new Exception("Email and Password are required");

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            UserName = request.Email
        };
        var result = await userManager.CreateAsync(newUser, request.Password);

        if (!result.Succeeded)
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));

        await appDbContext.SaveChangesAsync();
    }
}
