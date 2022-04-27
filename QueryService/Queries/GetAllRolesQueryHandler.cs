using BLL.Services.Interface;
using MediatR;
using QueryService.QueryModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.View;

namespace QueryService.Queries
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IList<RoleViewModel>>
    {
        private readonly IRoleService _RoleService;

        public GetAllRolesQueryHandler(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }
        public async Task<IList<RoleViewModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _RoleService.GetAll();
        }
    }
}
