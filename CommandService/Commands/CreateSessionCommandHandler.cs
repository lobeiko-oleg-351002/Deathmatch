using AutoMapper;
using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Create;

namespace CommandService.Commands
{
    public class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, Unit>
    {
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;
        public CreateSessionCommandHandler(ISessionService sessionService, IMapper mapper)
        {
            _sessionService = sessionService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
        {
            await _sessionService.Create(_mapper.Map<SessionCreateModel>(request));
            return Unit.Value;
        }
    }
}
