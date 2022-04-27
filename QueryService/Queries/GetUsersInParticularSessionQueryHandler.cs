using AutoMapper;
using BLL.Services.Interface;
using MediatR;
using QueryService.QueryModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.View;

namespace QueryService.Queries
{
    public class GetUsersInParticularSessionQueryHandler : IRequestHandler<GetUsersInParticularSessionQuery, IList<UserInSessionViewModel>>
    {
        private readonly IUserInSessionService _userInSessionService;

        public GetUsersInParticularSessionQueryHandler(IUserInSessionService userInSessionService)
        {
            _userInSessionService = userInSessionService;
        }
        public async Task<IList<UserInSessionViewModel>> Handle(GetUsersInParticularSessionQuery request, CancellationToken cancellationToken)
        {
            return await _userInSessionService.GetUsersInParticularSession(request.Session);
        }
    }
}
