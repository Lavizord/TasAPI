using Entities.Models;
using DTOs.Models;
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

// Exemplo de DTO usando metodo normal.
app.MapGet("/scenes/testdto", async (int id, TasDB db)=>
{
    var scene = await db.Scenes.Include(s => s.OwnChoices).Select( s => 
        new SceneDTO()
        {
            _Id = s._Id,
            storyId = s.storyId,
            type = s.Type,
            text = s.Text,
            Choices = s.OwnChoices
        }
    ).SingleOrDefaultAsync(s => s._Id == id );
    return Results.Ok(scene);
});

// Exemplo DTO usando automapper.
app.MapGet("/scenes/testemapper", async (int id, TasDB db)=>
{
    var scene = await db.Scenes.Include(s => s.OwnChoices)
        .SingleOrDefaultAsync(s => s._Id == id );
    return Results.Ok(mapper.Map<SceneDTO>(scene));
});

app.UseCors(MyAllowSpecificOrigins);
app.Run();