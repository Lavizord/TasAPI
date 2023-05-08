using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{
    public class Choice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int? OwnSceneId { get; set; }
        public int? NextSceneId { get; set; }
        public string? Text { get; set; }

        public virtual Scene? OwnScene { get; set; }
        public virtual Scene? NextScene { get; set; } 
        
    }
}