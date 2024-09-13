using System;

namespace JDVA_11092024.Endpoints;

public static class ProtectedEndpoint
{
    static List<object> data = new List<object>();

    public static void AddProtectedEndpoints (this WebApplication app)
    {
        app.MapGet("/protected", () =>
        {
            return data;
        }).RequireAuthorization();

        app.MapPost("/protected", (string name, string lastName) =>
        {
            data.Add(new{name, lastName});
            return Results.Ok();
        }).RequireAuthorization();
    }
}
