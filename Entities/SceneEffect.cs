using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{
    public class SceneEffect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int sceneId { get; set; }
        public int? hpChange { get; set; }
        public int? goldChange { get; set; }
        
        public virtual Scene? Scene { get; set; }        
    }
}