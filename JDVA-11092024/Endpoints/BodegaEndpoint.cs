using System;

namespace JDVA_11092024.Endpoints;

public static class BodegaEndpoint
{
    static List<object> data = new List<object>();

    public static void AddBodegaEndpoint(this WebApplication app)
    {

        app.MapPost("/bodega", (int id, string nombre, string descripcion) =>
        {
            data.Add(new {id, nombre, descripcion});
            return Results.Ok();
        }).RequireAuthorization();

        app.MapGet("/bodega{id}", (int id) =>
        {
            var bodega = data.FirstOrDefault(b =>
            {
                var idProp = b.GetType().GetProperty("id");
                return idProp != null && (int)idProp.GetValue(b) == id;
            });

            return bodega;
        }).RequireAuthorization();

        // app.MapDelete("/bodega", () =>
        // {
        //     data = new List<object>();   
        //     return Results.Ok();
        // }).RequireAuthorization();
    }

}
