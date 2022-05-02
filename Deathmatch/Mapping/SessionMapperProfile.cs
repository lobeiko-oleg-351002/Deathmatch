using AutoMapper;
using CommandService.CommandModels;
using Models;
using ViewModels.Create;
using ViewModels.View;

namespace Deathmatch.Mapping
{
    public class SessionMapperProfile : Profile
    {
        public SessionMapperProfile()
        {
            CreateMap<Session, SessionViewModel>();
            CreateMap<SessionCreateModel, Session>();
            CreateMap<CreateSessionCommand, SessionCreateModel>();
            CreateMap<LocationViewModel, Location>();
            CreateMap<UserViewModel, User>();
        }
    }
}
