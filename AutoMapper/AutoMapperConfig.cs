using AutoMapper;
using Entities.Models;
using DTOs.Scene;
using DTOs.Item;
using DTOs.Type;

namespace Tas.AutoMapper.Configuration
{
    public class SceneMappConfig : Profile
    {
        public SceneMappConfig()
        {   
            CreateMap<Scene, GetSceneCompleteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.storyId, opt => opt.MapFrom(src => src.storyId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.OwnChoices))
                .ForMember(dest => dest.SceneEffect, opt => opt.MapFrom(src => src.SceneEffect))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.Types, opt => opt.MapFrom(src => src.Types))
                ;
        }
    }

    public class ChoiceMappConfig : Profile
    {
        public ChoiceMappConfig()
        {
            CreateMap<Choice, GetChoicefromSceneDTO>()
                //.ForMember(dest => dest._Id, opt => opt.MapFrom(src => src._Id))
                .ForMember(dest => dest.nextSceneID, opt => opt.MapFrom(src => src.NextSceneId))
                .ForMember(dest => dest.text, opt => opt.MapFrom(src => src.Text))
                ;
        }
    }

    public class SceneEffectMappConfig : Profile
    {
        public SceneEffectMappConfig()
        {
            CreateMap<SceneEffect, GetSceneEffectFromSceneDTO>()
                .ForMember(dest => dest.goldChange, opt => opt.MapFrom(src => src.goldChange))
                .ForMember(dest => dest.hpChange, opt => opt.MapFrom(src => src.hpChange))
                ;
        }
    }

    public class ItemMappConfig : Profile
    {
        public ItemMappConfig()
        {
            CreateMap<Item, ItemDTO>()
                .ForMember(dest => dest.Types, opt => opt.MapFrom(src => src.Types));
        }
    }

    public class  TypeMappConfig: Profile
    {
        public TypeMappConfig()
        {
            CreateMap<Entities.Models.Type, TypeDTO>();
        }
    }
}