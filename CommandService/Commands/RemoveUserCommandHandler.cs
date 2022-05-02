using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandService.Commands
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserByIdCommand, Unit>
    {
        private readonly IUserService _UserService;
        public RemoveUserCommandHandler(IUserService UserService)
        {
            _UserService = UserService;
        }

        public async Task<Unit> Handle(RemoveUserByIdCommand request, CancellationToken cancellationToken)
        {
            await _UserService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
