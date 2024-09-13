using System;
using JDVA_11092024.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace JDVA_11092024.Endpoints;

public static class AccounEndpoint
{
    public static void AddAccountEndpoints(this WebApplication app)
    {
        app.MapPost("/account/login", (string login, string password, IJwtAuthenticatioService authService) =>
        {
            if (login == "admin" && password == "12345")
        {
            var token = authService.Authenticate(login);

            return Results.Ok(token);
        }
        else
        {
            return Results.Unauthorized();
        }
        });
    }
}
