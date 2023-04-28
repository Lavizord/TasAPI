using Microsoft.OpenApi.Models;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
//using Newtonsoft.Json;

var MyAllowSpecificOrigins = "_CorsPolicyLocalhost"; 

// Criação e Configuração da APP.
var app = AppBuilder.GetApp(args, MyAllowSpecificOrigins);
app = AppConfig.ConfigApp(app);

// TODO: Implementar Status code?? Prolly not worth it.
app.MapGet("/BROKEN", async (TasDB db) =>
{
    var list = await db.Scenes.Include("SceneEffect").ToListAsync();
    // TODO: Serialização dá erro.
    //var json = JsonSerializer.Serialize(list);
    return "FUCK OFF!!";
});

/*
app.MapGet("/scenes/initial", async (TasDB db) =>
{
    var list = await db.Scenes.Where(s => s.Type == "initial").ToListAsync();
});
*/

app.MapGet("/scenes/{id}", async (int id, TasDB db) =>
    await db.Scenes.FindAsync(id)
        is Scene scene
            ? Results.Ok(scene)
            : Results.NotFound()
);

app.MapGet("/sceneseffect/{id}", async (int id, TasDB db) =>
    await db.SceneEffects.FindAsync(id)
    is SceneEffect sceneEffect
        ? Results.Ok(sceneEffect)
        : Results.NotFound()
);

app.MapGet("/choice/{id}", async (int id, TasDB db) =>
    await db.Choices.FindAsync(id)
    is Choice choice
        ? Results.Ok(choice)
        : Results.NotFound()
);

app.UseCors(MyAllowSpecificOrigins);
app.Run();