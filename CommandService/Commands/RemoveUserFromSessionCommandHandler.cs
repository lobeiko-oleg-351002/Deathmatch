using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandService.Commands
{
    public class RemoveUserFromSessionCommandHandler : IRequestHandler<RemoveUserFromSessionCommand, Unit>
    {
        private readonly IUserInSessionService _UserInSessionService;
        public RemoveUserFromSessionCommandHandler(IUserInSessionService UserInSessionService)
        {
            _UserInSessionService = UserInSessionService;
        }

        public async Task<Unit> Handle(RemoveUserFromSessionCommand request, CancellationToken cancellationToken)
        {
            await _UserInSessionService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
