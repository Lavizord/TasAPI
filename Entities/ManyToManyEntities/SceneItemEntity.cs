using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{
    public class SceneItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SceneId { get; set; }
        public int ItemId { get; set; }
        public Scene? Scene { get; set; } 
        public Item? Item { get; set; }      
    }
}