using AutoMapper;
using BLL.Exceptions;
using BLL.Services.Interface;
using DAL.Exceptions;
using DAL.Repositories.Interface;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services
{
    public class RoleService : Service<Role, RoleViewModel, RoleCreateModel>, IRoleService
    {
        public RoleService(IRoleRepository RoleRepository, IMapper mapper)
            : base(RoleRepository, mapper)
        {

        }

    }
}
