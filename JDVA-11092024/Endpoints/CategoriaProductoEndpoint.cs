using System;

namespace JDVA_11092024.Endpoints;

public static class CategoriaProductoEndpoint
{
    static List<object> data = new List<object>();

    public static void AddCategoriaProductoEndpoint(this WebApplication app)
    {
        app.MapGet("/categoriaProducto", () =>
        {
            return data;
        }).RequireAuthorization();

        app.MapPost("/categoriaProducto", (int id, string nombreCategoria, string descripcion) =>
        {
            data.Add(new {id, nombreCategoria, descripcion});
            return Results.Ok();
        }).RequireAuthorization();
    }

}