using AutoMapper;
using CommandService.CommandModels;
using Models;
using ViewModels.Create;
using ViewModels.View;

namespace Deathmatch.Mapping
{
    public class LocationMapperProfile : Profile
    {
        public LocationMapperProfile()   
        {
            CreateMap<Location, LocationViewModel>();
            CreateMap<LocationCreateModel, Location>();
            CreateMap<CreateLocationCommand, LocationCreateModel>();
        }
    }
}
