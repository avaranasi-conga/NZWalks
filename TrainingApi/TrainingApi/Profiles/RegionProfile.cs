using AutoMapper;

namespace TrainingApi.Profiles
{
    public class RegionProfile: Profile
    {
        public RegionProfile()
        {
            CreateMap<Module.Domain.Region, Module.DTO.Region>().ReverseMap();
        }
    }
}
