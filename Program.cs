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
            policy.WithOrigins(
                "http://localhost:4200",
                "https://localhost:4200",
                "https://*.vercel.app",
                "https://*.netlify.app",
                "https://*.github.io"
            )
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

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

Console.WriteLine("Ortosleep API iniciada!");
Console.WriteLine($"Swagger disponível em: http://localhost:{port}");

app.Run();