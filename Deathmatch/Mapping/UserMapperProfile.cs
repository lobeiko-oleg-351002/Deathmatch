using AutoMapper;
using CommandService.CommandModels;
using Models;
using ViewModels.Create;
using ViewModels.View;

namespace Deathmatch.Mapping
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserCreateModel, User>();
            CreateMap<CreateUserCommand, UserCreateModel>();
            CreateMap<RoleViewModel, Role>().ReverseMap();
        }
    }
}
