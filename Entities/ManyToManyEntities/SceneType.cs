using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.ManyToMany
{
    public class SceneType
    {
        public int ScenId { get; set; }
        public int TypeId { get; set; }
        public Scene? Scene { get; set; } 
        public Type? Type { get; set; }      
    }
}