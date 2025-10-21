namespace APITAREFAS.Routes;

using APITAREFAS.Data;
using Microsoft.EntityFrameworkCore;

public static class GetProjetos
{
    public static void MapGetProjetosRoutes(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/projetos");

        group.MapGet("/", async (AppDbContext db) =>
            Results.Ok(await db.Projetos.AsNoTracking().ToListAsync()));

        group.MapGet("/{id:int}", async (int id, AppDbContext db) =>
        {
            var item = await db.Projetos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return item is null ? Results.NotFound() : Results.Ok(item);
        });
    }
}