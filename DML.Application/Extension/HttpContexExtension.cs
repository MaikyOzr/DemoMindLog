using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace DML.Application.Extension;

public static class HttpContexExtension
{
    public static Guid GetUserId(this HttpContext httpContext)
    {
        var userIdStr = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!Guid.TryParse(userIdStr, out var userId))
            throw new Exception("User ID is missing or invalid");

        return userId;
    }
}
