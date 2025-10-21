namespace APITAREFAS.Routes;

using APITAREFAS.Data;
using Microsoft.EntityFrameworkCore;

public static class DeleteProjetos
{
    public static void MapDeleteProjetosRoutes(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/projetos");

        group.MapDelete("/{id:int}", async (int id, AppDbContext db) =>
        {
            var projeto = await db.Projetos.FirstOrDefaultAsync(p => p.Id == id);
            if (projeto is null) return Results.NotFound();

            db.Projetos.Remove(projeto);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}