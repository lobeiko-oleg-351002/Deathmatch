using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandService.Commands
{
    public class RemoveUserFromSessionCommandHandler : IRequestHandler<RemoveUserFromSessionCommand, Unit>
    {
        private readonly ISessionService _sessionService;
        public RemoveUserFromSessionCommandHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<Unit> Handle(RemoveUserFromSessionCommand request, CancellationToken cancellationToken)
        {
            await _sessionService.RemoveUserFromSession(request.UserViewModel, request.SessionViewModel);
            return Unit.Value;
        }
    }
}
