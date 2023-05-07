using Entities.Models;
using DTOs.Scene;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Endpoints.Groups
{
    public static class MapGroups
    {
        public static RouteGroupBuilder Misc(this RouteGroupBuilder group)
        {
            group.MapGet("/", () => Results.Ok(new List<int> { 1, 2, 3 }));
            return group;
        }

        public static RouteGroupBuilder Scenes(this RouteGroupBuilder group)
        {
            group.MapGet("/scenes/{id}", async (int id, TasDB db) =>
                await db.Scenes.FindAsync(id)
                    is Scene scene
                        ? Results.Ok(scene)
                        : Results.NotFound()
            );

            // TODO: Rever este endpoint.
            group.MapGet("/scenes/with/c/{id}", async (int id, TasDB db) =>
            {
                var scene = db.Scenes
                    .Where(scene => scene._Id == id)
                    .Include(scene => scene.OwnChoices)
                    .ToList();

                return Results.Ok(scene);
            });

            // TODO: Avaliar se este endpoint deve ser mantido.
            group.MapGet("/sceneseffect/{id}", async (int id, TasDB db) =>
                await db.SceneEffects.FindAsync(id)
                is SceneEffect sceneEffect
                    ? Results.Ok(sceneEffect)
                    : Results.NotFound()
            );

            group.MapGet("/scenes/random/initial", async (TasDB db)=>
            {
                var random = new Random();
                var list = await db.Scenes.Where(s => s.Type == "initial").ToListAsync();
                return list[random.Next(list.Count)];
            });
            
            // Exemplo DTO usando automapper.
            // TODO: Meter isto funcional. Necessário fazer dependencey inejction do mapper.
            /* 
            group.MapGet("/scene/complete/from/{id}", async (int id, TasDB db)=>
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
            */
            return group; 
        }

        public static RouteGroupBuilder Choices(this RouteGroupBuilder group)
        {
            group.MapGet("{id}", async (int id, TasDB db) =>
                await db.Choices.FindAsync(id)
                is Choice choice
                    ? Results.Ok(choice)
                    : Results.NotFound()
            );

            group.MapGet("/byscene/{id}", async (int id, TasDB db) =>
            {
                var list = await db.Choices.Where(c => c.OwnSceneId == id).ToListAsync();
                return Results.Ok(list);
            });

            return group;
        }
        
    }
}