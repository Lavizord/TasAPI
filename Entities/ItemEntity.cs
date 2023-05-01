using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models 
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int _Id { get; set; }
        public bool unique { get; set; }
        public bool? stackable { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }     
        public List<ItemType> ItemTypes { get; } = new();
    }
}