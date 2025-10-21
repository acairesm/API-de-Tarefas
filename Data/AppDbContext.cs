namespace APITAREFAS.Data;

using APITAREFAS.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Projeto> Projetos => Set<Projeto>();
}