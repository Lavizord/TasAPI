using Entities.Models;

namespace Dtos.Models
{
    public class SceneDto
    {
        public int _Id { get; set; }
        public int storyId { get; set; }
        public string? type { get; set; }
        public string? text { get; set; }

        public ICollection<Choice>? Choices { get; set; }
    }
}

namespace Dtos.Models
{
    public class ChoiceDto
    {
        public int _Id { get; set; }
        public int nextSceneID { get; set; }
        public int text { get; set; }
    }
}