using BLL.Services.Interface;
using MediatR;
using QueryService.QueryModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.View;

namespace QueryService.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IList<UserViewModel>>
    {
        private readonly IUserService _UserService;

        public GetAllUsersQueryHandler(IUserService UserService)
        {
            _UserService = UserService;
        }
        public async Task<IList<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _UserService.GetAll();
        }
    }
}
