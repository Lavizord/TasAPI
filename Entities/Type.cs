using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.ManyToMany;

namespace Entities.Models 
{
    // Esta entidade vai conter todos os tipos possiveis. Testar primeiro no ItemTypes
    // depois expandir para as restantes.
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string? type { get; set; }

        // Ligação Many to Many com a entidade de Items          
        public virtual List<Item>? Items { get; set; }
        public virtual List<ItemType>? ItemTypes { get; set; }

        // Ligação Many to Many com a entidade de Scenes.
        /*
        public virtual List<Scene> Scenes { get; set; }
        public virtual List<SceneType> SceneTypes { get; set; }
        */
    }
}