using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{
    // Esta entidade vai conter todos os tipos possiveis. Testar primeiro no ItemTypes
    // depois expandir para as restantes.
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int _Id { get; set; }
        public string? type { get; set; }     
        public List<ItemType> ItemTypes { get; } = new();
        public List<SceneType> SceneTypes { get; } = new();

    }
}