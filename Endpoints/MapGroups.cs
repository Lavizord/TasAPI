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

        public static RouteGroupBuilder Scenes(this RouteGroupBuilder group, IMapper mapper)
        {
            group.MapGet("/initial/random", async (TasDB db)=>
            {
                var random = new Random();
                var list = await db.Scenes
                    .Where(s => s.Type == "initial")
                    .Include(s => s.OwnChoices)
                    .Include(s => s.SceneEffect)
                    .ToListAsync();
                
                var scene = list[random.Next(list.Count)];
                
                if(scene is null)
                    return Results.NotFound();

                return Results.Ok
                (
                    mapper.Map<Scene, GetSceneCompleteDTO>(scene)
                );
            });
                       
            group.MapGet("/complete/{id}", async (int id, TasDB db)=>
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
            
            return group; 
        }

        public static RouteGroupBuilder Choices(this RouteGroupBuilder group, IMapper mapper)
        {
            //TODO: Avaliar se faz sentido termos este endpoint.
            //TODO: Avaliar se devemos retornar obejtos filhos neste endpoint.
            group.MapGet("{id}", async (int id, TasDB db) =>
                await db.Choices.FindAsync(id)
                is Choice choice
                    ? Results.Ok(choice)
                    : Results.NotFound()
            );

            //TODO: Avaliar se faz sentido termos este endpoint.
            //TODO: Avaliar se devemos retornar obejtos filhos neste endpoint.
            group.MapGet("/byscene/{id}", async (int id, TasDB db) =>
            {
                var list = await db.Choices.Where(c => c.OwnSceneId == id).ToListAsync();
                return Results.Ok(list);
            });

            return group;
        }
        
        public static RouteGroupBuilder Items(this RouteGroupBuilder group, IMapper mapper)
        {
            group.MapGet("/item/{id}", async (int id, TasDB db) => 
                await db.Items.FindAsync(id)
                is Item item
                    ? Results.Ok(item)
                    : Results.NotFound()
            );
            return group;
        }
    }
}