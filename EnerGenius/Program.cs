using EnerGenius.Repositories;
using EnerGenius.Services;
using EnerGenius.Services.Interfaces;
using EnerGenius.Settings;
using OpenAI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configurar MongoDB
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.Configure<IASettings>(
    builder.Configuration.GetSection("IASettings"));

// Adicionar repositórios ao container de dependências
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<CaixaRepository>();
builder.Services.AddScoped<UsinaRepository>();
builder.Services.AddScoped<ContaConsumoRepository>();

// Configurar OpenAI
builder.Services.AddOpenAIService(options =>
{
    options.ApiKey = builder.Configuration["OpenAI:Abacaxi"];
});

// Adicionar serviços personalizados
builder.Services.AddSingleton<GenerativeAIService>();
//builder.Services.AddSingleton<IAService>();

// Adicionar serviços específicos ao container
builder.Services.AddScoped<ICaixaService, CaixaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsinaService, UsinaService>();
builder.Services.AddScoped<IGenerativeAIService, GenerativeAIService>();

// Adicionar controladores e Swagger para documentação da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
