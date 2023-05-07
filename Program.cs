using Entities.Models;
using DTOs.Scene;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Endpoints.Groups;

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

app.MapGroup("/misc")
    .Misc()
    .WithTags("Misc");

app.MapGroup("/scenes")
    .Scenes()
    .WithTags("Scenes");

app.MapGroup("/choices")
    .Choices()
    .WithTags("Choices");


app.MapGroup("/items")
    .Items()
    .WithTags("Items");
    

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