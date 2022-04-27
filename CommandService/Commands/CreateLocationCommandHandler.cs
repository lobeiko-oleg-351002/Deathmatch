using AutoMapper;
using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Create;

namespace CommandService.Commands
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, Unit>
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public CreateLocationCommandHandler(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _locationService.Create(_mapper.Map<LocationCreateModel>(request));
            return Unit.Value;
        }
    }
}
