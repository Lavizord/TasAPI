using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.ManyToMany
{
    public class SceneItem
    {
        public int SceneId { get; set; }
        public int ItemId { get; set; }
        public Scene? Scene { get; set; } 
        public Item? Item { get; set; }      
    }
}