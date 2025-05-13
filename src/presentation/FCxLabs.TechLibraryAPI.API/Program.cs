using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

//Garante que a app escute sempre na mesma URL
builder.WebHost.UseUrls("https://localhost:5001");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseReDoc(c =>
    {
        c.RoutePrefix = "redoc";
        c.SpecUrl = "/swagger/v1/swagger.json";
        c.DocumentTitle = "Documentação da API - Redoc";
    });

    // Abre navegador automaticamente
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        var url = "https://localhost:5001/redoc";
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch { }
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
