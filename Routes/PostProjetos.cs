namespace APITAREFAS.Routes;

using APITAREFAS.Data;
using APITAREFAS.Models;

public static class PostProjetos
{
    public static void MapPostProjetosRoutes(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/projetos");

        group.MapPost("/", async (ProjetoDto dto, APITAREFAS.Data.AppDbContext db) =>
        {
            if (string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Responsavel))
                return Results.BadRequest("Nome e Responsavel são obrigatórios.");

            var projeto = new Projeto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Responsavel = dto.Responsavel,
                DataInicio = dto.DataInicio,
                DataFimPrevista = dto.DataFimPrevista,
                ProgressoPercentual = Math.Clamp(dto.ProgressoPercentual, 0, 100),
                Status = string.IsNullOrWhiteSpace(dto.Status) ? "Planejado" : dto.Status
            };

            db.Projetos.Add(projeto);
            await db.SaveChangesAsync();

            return Results.Created($"/api/projetos/{projeto.Id}", projeto);
        });
    }
}