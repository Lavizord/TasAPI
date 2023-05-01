using AutoMapper;
using Entities.Models;
using DTOs.Models;

namespace Tas.AutoMapper.Configuration
{
    public class SceneMappConfig : Profile
    {
        public SceneMappConfig()
        {   
            CreateMap<Scene, SceneDTO>()
                .ForMember(dest => dest._Id, opt => opt.MapFrom(src => src._Id))
                .ForMember(dest => dest.storyId, opt => opt.MapFrom(src => src.storyId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.OwnChoices))
                ;
        }
    }

    public class ChoiceMappConfig : Profile
    {
        public ChoiceMappConfig()
        {
            CreateMap<Choice, ChoiceDTO>()
                //.ForMember(dest => dest._Id, opt => opt.MapFrom(src => src._Id))
                .ForMember(dest => dest.nextSceneID, opt => opt.MapFrom(src => src.NextSceneId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => src.Text))
                ;
        }
    }
}