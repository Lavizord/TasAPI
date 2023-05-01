using Entities.Models;

namespace DTOs.Models
{
    public class GetSceneCompleteDTO
    {
        public int _Id { get; set; }
        public int storyId { get; set; }
        public string? type { get; set; }
        public string? text { get; set; }

        public List<GetChoicefromSceneDTO>? Choices { get; set; }
        public GetSceneEffectFromSceneDTO? SceneEffect { get; set; }

    }

    public class GetChoicefromSceneDTO
    {
        //public int _Id { get; set; }
        public int nextSceneID { get; set; }
        public string? text { get; set; }
    }

    public class GetSceneEffectFromSceneDTO
    {
        public int hpChange { get; set; }
        public int goldChange { get; set; }
    }
}

