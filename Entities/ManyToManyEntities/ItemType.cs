using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.ManyToMany 
{
    public class ItemType
    {
        public int ItemId { get; set; }
        public int TypeId { get; set; }
        public Item? Item { get; set; } 
        public Type? Type { get; set; }      
    
    }
}