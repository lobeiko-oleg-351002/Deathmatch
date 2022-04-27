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
    public class GetAllSessionsQueryHandler : IRequestHandler<GetAllSessionsQuery, IList<SessionViewModel>>
    {
        private readonly ISessionService _sessionService;

        public GetAllSessionsQueryHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public async Task<IList<SessionViewModel>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
        {
            return await _sessionService.GetAll();
        }
    }
}
