using Entities.Models;
using DTOs.Type;

namespace DTOs.Item
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public bool unique { get; set; }
        public string? name { get; set; }
        public bool? stackable { get; set; }
        public string? description { get; set; }     
        public List<TypeDTO>? Types { get; set; }
    }
}

