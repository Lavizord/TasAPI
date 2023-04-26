using Microsoft.OpenApi.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationPOCO;


void ConfigSwagger(WebApplication app)
{
    // Estas duas linhas podem estar wraped no if in development statement.
    // Swagger fica disiponivel em: http://localhost:<portNumber>/swagger/
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

var app = AppBuilder.GetApp(args);
ConfigSwagger(app);

app.MapGet("/scenes", async (TasDB db) =>
{
    await db.Scenes.Include("SceneEffect").ToListAsync();
});

// TODO: Criar as scenas já existentes com este endpoint. Documentar particularidades.
app.MapPost("/scenes", async (TasDB db, Scene scene) =>
{
    await db.Scenes.AddAsync(scene);
    await db.SaveChangesAsync();
    return Results.Created($"/scene/{scene._Id}", scene);
});

app.MapGet("/sceneseffect", async (TasDB db) =>
{
    await db.SceneEffects.ToListAsync();
});

app.MapGet("/choice", async (TasDB db) => 
{
    await db.Choices.ToListAsync();
});

app.Run();