using Accounting.Project;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Cria uma instância do Startup
var startup = new Startup(builder.Configuration);

// Adicione serviços ao contêiner.
startup.ConfigureServices(builder.Services);

// Adicione o serviço ITempDataDictionaryFactory
builder.Services.AddSingleton<ITempDataDictionaryFactory, TempDataDictionaryFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Accounting.Project Project", Version = "v1" });
});

var app = builder.Build();

// Configura o pipeline de solicitação HTTP.
startup.Configure(app, app.Environment);

app.MapControllers();

app.Run();
