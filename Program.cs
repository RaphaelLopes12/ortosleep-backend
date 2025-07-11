using Microsoft.EntityFrameworkCore;
using OrtosleepApi.Data;
using OrtosleepApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { 
        Title = "Ortosleep API", 
        Version = "v1",
        Description = "API para sistema de precificação Ortosleep"
    });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("OrtosleepDb"));

builder.Services.AddScoped<IPrecificacaoService, PrecificacaoService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ortosleep API v1");
    c.RoutePrefix = ""; 
});

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

try 
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated();
        Console.WriteLine("✅ Banco de dados criado com sucesso!");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Erro ao criar banco: {ex.Message}");
}

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var host = Environment.GetEnvironmentVariable("HOST") ?? "0.0.0.0";

app.Urls.Clear();
app.Urls.Add($"http://{host}:{port}");

Console.WriteLine($"🚀 Ortosleep API rodando em http://{host}:{port}");
Console.WriteLine($"📖 Swagger disponível em: http://{host}:{port}");

app.Run();