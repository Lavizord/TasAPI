using Microsoft.OpenApi.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationPOCO;
//using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Json;


// Criação e Configuração da APP.
var app = AppBuilder.GetApp(args);
app = AppConfig.ConfigApp(app);

// Inicio da definição dos endpoints.
//TODO: ToListAsync querys but doesnt return object, only code 200
app.MapGet("/scenes", async (TasDB db) =>
{
    await db.Scenes.ToListAsync();
});
//TODO: ToListAsync querys but doesnt return object, only code 200
app.MapGet("/scenes/initial", async (TasDB db) =>
{
    await db.Scenes.Where(s => s.Type == "initial").ToListAsync();
});

// This one is Working
app.MapGet("/scenes/{id}", async (int id, TasDB db) =>
    await db.Scenes.FindAsync(id)
        is Scene scene
            ? Results.Ok(scene)
            : Results.NotFound()
);

// This one is Working
app.MapGet("/sceneseffect/{id}", async (int id, TasDB db) =>
    await db.SceneEffects.FindAsync(id)
    is SceneEffect sceneEffect
        ? Results.Ok(sceneEffect)
        : Results.NotFound()
);

// This one is Working
app.MapGet("/choice/{id}", async (int id, TasDB db) =>
    await db.Choices.FindAsync(id)
    is Choice choice
        ? Results.Ok(choice)
        : Results.NotFound()
);

app.Run();