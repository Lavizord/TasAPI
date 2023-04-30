using AutoMapper;
using Entities.Models;
using DTOs.Models;

namespace Tas.AutoMapper.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {   
            CreateMap<Scene, SceneDTO>().ReverseMap();   
        }
    }
}