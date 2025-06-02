using DML.Application.SignUp.Models.Requests;
using DML.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DML.Application.SignUp.Commands;

public class SignInCommnad(AppDbContext appDbContext)
{
    public async Task<bool> ExecuteAsync(SingInRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            throw new Exception("Email and Password are required");
        

        var user = await appDbContext.Users
            .FirstOrDefaultAsync(u => u.Email == request.Email) ?? throw new Exception("User doesn`t exist!");

        return true;
    }
}
