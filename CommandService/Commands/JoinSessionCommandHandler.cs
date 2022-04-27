using AutoMapper;
using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Create;

namespace CommandService.Commands
{
    public class JoinSessionCommandHandler : IRequestHandler<JoinSessionCommand, Unit>
    {
        private readonly IUserInSessionService _userInSessionService;
        public JoinSessionCommandHandler(IUserInSessionService userInSessionService)
        {
            _userInSessionService = userInSessionService;
        }

        public async Task<Unit> Handle(JoinSessionCommand request, CancellationToken cancellationToken)
        {
            await _userInSessionService.Create(new UserInSessionCreateModel { Session = request.Session, User = request.User});
            return Unit.Value;
        }
    }
}
