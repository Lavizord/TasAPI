using Entities.Models;

namespace DTOs.Models
{
    public class SceneDTO
    {
        public int _Id { get; set; }
        public int storyId { get; set; }
        public string? type { get; set; }
        public string? text { get; set; }

        public ICollection<Choice>? Choices { get; set; }
    }
}

namespace DTOs.Models
{
    public class ChoiceDTO
    {
        public int _Id { get; set; }
        public int nextSceneID { get; set; }
        public int text { get; set; }
    }
}