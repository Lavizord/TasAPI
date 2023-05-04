using Entities.Models;
using DTOs.Scene;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var MyAllowSpecificOrigins = "_CorsPolicyLocalhost"; 

// Criação e Configuração da APP.
var app = AppBuilder.GetApp(args, MyAllowSpecificOrigins);
app = AppConfig.ConfigApp(app);

var mapper = app.Services.GetService<IMapper>();
if (mapper == null)
{
    throw new InvalidOperationException(
      "Mapper not found");
}

app.MapGet("/scenes/{id}", async (int id, TasDB db) =>
    await db.Scenes.FindAsync(id)
        is Scene scene
            ? Results.Ok(scene)
            : Results.NotFound()
);

app.MapGet("/scenes/with/choice/{id}", async (int id, TasDB db) =>
{
    var scene = db.Scenes
        .Where(scene => scene._Id == id)
        .Include(scene => scene.OwnChoices)
        .ToList();

    return Results.Ok(scene);
});

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

// Exemplo DTO usando automapper.
app.MapGet("/scene/complete/from/{id}", async (int id, TasDB db)=>
{
    var scene = await db.Scenes
        .Include(s => s.OwnChoices)
        .Include(s => s.SceneEffect)
        .SingleOrDefaultAsync(s => s._Id == id );

    if(scene is null)
        return Results.NotFound();

    return Results.Ok
    (
        mapper.Map<Scene, GetSceneCompleteDTO>(scene)
    );
});

app.UseCors(MyAllowSpecificOrigins);
app.Run();