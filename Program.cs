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
    // TODO: Serialização dá erro. Tentar corrigir.
    //var json = JsonSerializer.Serialize(list);
    return "FUCK OFF!!";
});

app.MapGet("/scenes/{id}", async (int id, TasDB db) =>
    await db.Scenes.FindAsync(id)
        is Scene scene
            ? Results.Ok(scene)
            : Results.NotFound()
);

// TODO: Limitar o load as related entities a 1 level, caso contrário dá erro ao serializar.
app.MapGet("/scenes/with/choice/{id}", async (int id, TasDB db) =>
{
    var scene = db.Scenes
        .Where(scene => scene._Id == id)
        .Include(scene => scene.OwnChoices)
        .ToList();

    return Results.Ok(scene);
}   
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

app.MapGet("/choice/bysceneid/{id}", async (int id, TasDB db) =>
{
    var list = await db.Choices.Where(c => c.OwnSceneId == id).ToListAsync();
    return Results.Ok(list);
});

app.MapGet("/scenes/random/initial", async (TasDB db)=>
{
    var random = new Random();
    var list = await db.Scenes.Where(s => s.Type == "initial").ToListAsync();
    return list[random.Next(list.Count)];
});

app.UseCors(MyAllowSpecificOrigins);
app.Run();