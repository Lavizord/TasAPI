using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ConfigurationPOCO;
using System.Text.Json;
using AutoMapper;
using Tas.AutoMapper.Configuration;

public static class AppBuilder
{
    // Retorna WebApp com serviços configurados.
    // App deve depois ser configurada / adicionado endpoints e iniciada .Run()
    public static WebApplication GetApp(string[] args, string MyAllowSpecificOrigins)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Forçamos a usar a porta 80.
        builder.WebHost.UseUrls("http://*:5005");
        
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

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*")
                                .AllowAnyMethod()
                                .AllowAnyOrigin()
                                .AllowAnyHeader();
                      });
        });

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {
            Title = "Take a Step API",
            Description = "Taking the steps you love",
            Version = "v1" });
        });

        // Auto Mapper service for mapping entities to DTOs.
        builder.Services.AddAutoMapper(typeof(MapperConfig));

        var app = builder.Build();
        return app;
    }
}