using AutoMapper;
using CommandService.CommandModels;
using Models;
using ViewModels.Create;
using ViewModels.View;

namespace Deathmatch.Mapping
{
    public class UserInSessionMapperProfile : Profile
    {
        public UserInSessionMapperProfile()
        {
            CreateMap<UserInSession, UserInSessionViewModel>();
            CreateMap<UserInSessionCreateModel, UserInSession>();
        }
    }
}
