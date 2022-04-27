using AutoMapper;
using Models;
using ViewModels.Create;
using ViewModels.View;

namespace Deathmatch.Mapping
{
    public class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleCreateModel, Role>();
        }
    }
}
