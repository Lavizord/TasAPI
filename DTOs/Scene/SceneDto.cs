using Entities.Models;

namespace DTOs.Models
{
    public class SceneDTO
    {
        public int _Id { get; set; }
        public int storyId { get; set; }
        public string? type { get; set; }
        public string? text { get; set; }

        public List<ChoiceDTO>? Choices { get; set; }
    }

    public class ChoiceDTO
    {
        //public int _Id { get; set; }
        public int nextSceneID { get; set; }
        public string? text { get; set; }
    }

}

