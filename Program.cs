using APITAREFAS.Data;
using APITAREFAS.Routes;
using APITAREFAS.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

