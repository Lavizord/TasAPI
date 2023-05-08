using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.ManyToMany;

namespace Entities.Models 
{
    public class Scene
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int storyId { get; set; }
        public string? Type { get; set; }
        public string? Text { get; set; }
        // Aqui definimos que a Scene tem Choices. Uso da Keyword virtual: 
        // https://stackoverflow.com/questions/8542864/why-use-virtual-for-class-properties-in-entity-framework-model-definitions
        public virtual List<Choice>? OwnChoices { get; set;}
        public virtual List<Choice>? PrecidingChoices { get; set;}
        // Ligação Many to Many com a entidade de Items     
        public virtual List<Item>? Items { get; set; }
        public virtual List<SceneItem>? ItemTypes { get; set; }
        
        // Ligação Many to Many com a entidade de Items     
        public virtual List<Type>? Types { get; set; }
        public virtual List<SceneType>? SceneTypes { get; set; }

        // TODO: Para já tem apenas um. Pensar se deve passar a ter uma Lista.
        //          Seria necessário refazer a tabela de forma a ter ou mais campos ou outra estrutura.
        public virtual SceneEffect? SceneEffect { get; set;}

    }
}