using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandService.Commands
{
    public class RemoveSessionCommandHandler : IRequestHandler<RemoveByIdCommand, Unit>
    {
        private readonly ISessionService _SessionService;
        public RemoveSessionCommandHandler(ISessionService SessionService)
        {
            _SessionService = SessionService;
        }

        public async Task<Unit> Handle(RemoveByIdCommand request, CancellationToken cancellationToken)
        {
            await _SessionService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
