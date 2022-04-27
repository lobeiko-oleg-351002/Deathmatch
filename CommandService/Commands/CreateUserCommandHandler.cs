using AutoMapper;
using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Create;

namespace CommandService.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateSessionCommand, Unit>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(IUserService UserService, IMapper mapper)
        {
            _userService = UserService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            await _userService.Create(_mapper.Map<UserCreateModel>(request));
            return Unit.Value;
        }
    }
}
