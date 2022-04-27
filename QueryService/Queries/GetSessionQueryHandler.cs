using AutoMapper;
using BLL.Services.Interface;
using MediatR;
using QueryService.QueryModels;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.View;

namespace QueryService.Queries
{
    public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, SessionViewModel>
    {
        private readonly ISessionService _sessionService;

        public GetSessionQueryHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        public async Task<SessionViewModel> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            return await _sessionService.Get(request.Id);
        }
    }
}
