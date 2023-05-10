using Entities.Models;
using DTOs.Scene;
using DTOs.Item;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Endpoints.Groups
{
    public static class MapGroups
    {
        public static RouteGroupBuilder Scenes(this RouteGroupBuilder group, IMapper mapper)
        {
            group.MapGet("/initial/random", async (TasDB db)=>
            {
                var random = new Random();
                var list = await db.Scenes
                    .Where(s => s.Type == "initial")
                    .Include(s => s.OwnChoices)
                    .Include(s => s.SceneEffect)
                    .Include(s => s.Items)
                    .ThenInclude(i => i.Types)
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
                    .Include(s => s.Items)
                    .ThenInclude(i => i.Types)
                    .SingleOrDefaultAsync(s => s.Id == id );
                if(scene is null)
                    return Results.NotFound();
                return Results.Ok
                (
                    mapper.Map<Scene, GetSceneCompleteDTO>(scene)
                );
            });
            
            return group; 
        }
        public static RouteGroupBuilder Items(this RouteGroupBuilder group, IMapper mapper)
        {           
            group.MapGet("{id}", async (int id, TasDB db) => 
            {
                var item = await db.Items
                    .Include(i => i.Types)
                    .SingleOrDefaultAsync(i => i.Id == id );
                if(item is null)
                    return Results.NotFound();
                return Results.Ok
                (
                    mapper.Map<Item, ItemDTO>(item)
                );
            });
            return group;
        }
    }
}