namespace APITAREFAS.Services;

using APITAREFAS.Data;
using APITAREFAS.Models;
using Microsoft.EntityFrameworkCore;

public class SeedService
{
    private readonly AppDbContext _db;

    public SeedService(AppDbContext db)
    {
        _db = db;
    }

    public async Task SeedAsync()
    {
        // Cria ou aplica migrações automaticamente
        await _db.Database.MigrateAsync();

        // Evita duplicar dados se já existirem
        if (await _db.Projetos.AnyAsync())
            return;

        var rnd = new Random(42);
        var responsaveis = new[] { "Ana", "Bruno", "Carla", "Diego", "Elisa", "Fabio" };
        var status = new[] { "Planejado", "EmAndamento", "Concluido" };

        // Gera automaticamente 60 registros para teste
        var projetos = Enumerable.Range(1, 60).Select(i =>
        {
            var inicio = DateTime.Today.AddDays(-rnd.Next(0, 120));
            DateTime? fimPrev = rnd.Next(0, 2) == 0 ? inicio.AddDays(rnd.Next(15, 90)) : null;

            return new Projeto
            {
                Nome = $"Projeto {i:D2}",
                Descricao = $"Projeto gerado automaticamente para testes #{i}",
                Responsavel = responsaveis[rnd.Next(responsaveis.Length)],
                DataInicio = inicio,
                DataFimPrevista = fimPrev,
                ProgressoPercentual = rnd.Next(0, 101),
                Status = status[rnd.Next(status.Length)]
            };
        }).