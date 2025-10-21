using APITAREFAS.Data;
using APITAREFAS.Routes;
using APITAREFAS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Sqlite") ?? "Data Source=projetos.db";
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<SeedService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seedService = scope.ServiceProvider.GetRequiredService<SeedService>();
    await seedService.SeedAsync();
}

app.MapGet("/", () => "Hello World!");
app.MapGetProjetosRoutes();
app.MapPostProjetosRoutes();
app.MapDeleteProjetosRoutes();

app.Run();
