using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{
    public class Scene
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int _Id { get; set; }
        public int storyId { get; set; }
        public string? Type { get; set; }
        public string? Text { get; set; }
        // Aqui definimos que a Scene tem Choices. Uso da Keyword virtual: 
        // https://stackoverflow.com/questions/8542864/why-use-virtual-for-class-properties-in-entity-framework-model-definitions
        public virtual ICollection<Choice>? OwnChoices { get; set;}
        public virtual ICollection<Choice>? PrecidingChoices { get; set;}
        public virtual SceneEffect? SceneEffect { get; set;}
    }
}