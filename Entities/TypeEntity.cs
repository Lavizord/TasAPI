using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{
    public class Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int _Id { get; set; }
        public string? type { get; set; }     
        public List<ItemType> ItemTypes { get; } = new();

    }
}