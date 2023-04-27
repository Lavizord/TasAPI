using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationPOCO;



public static class AppBuilder
{
    // Retorna WebApp com serviços configurados.
    // App deve depois ser configurada / adicionado endpoints e iniciada .Run()
    public static WebApplication GetApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Forçamos a usar a porta 80.
        builder.WebHost.UseUrls("http://*:5000");
        
        builder.Services.Configure<DatabaseConfiguration>(
            builder.Configuration.GetSection("DatabaseConfiguration")
        );

        // Setup database connection // TODO: Alterar para POCO?
        var connectionString = builder.Configuration.GetConnectionString("SqlConnectionString");
        
        builder
            .Services
            .AddDbContext<TasDB>(opt => opt.UseSqlServer(connectionString));
        

        builder
            .Services
            .AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {
            Title = "Take a Step API",
            Description = "Taking the steps you love",
            Version = "v1" });
        });

        var app = builder.Build();
        return app;
    }
}