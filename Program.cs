using Microsoft.OpenApi.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationPOCO;


// Criação e Configuração da APP.
var app = AppBuilder.GetApp(args);
app = AppConfig.ConfigApp(app);

// Inicio da definição dos endpoints.

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