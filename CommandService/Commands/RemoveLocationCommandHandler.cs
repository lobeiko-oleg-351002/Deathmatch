using AutoMapper;
using BLL.Services.Interface;
using CommandService.CommandModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CommandService.Commands
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveByIdCommand, Unit>
    {
        private readonly ILocationService _locationService;
        public RemoveLocationCommandHandler(ILocationService locationService)
        {
            _locationService = locationService;
        }

        public async Task<Unit> Handle(RemoveByIdCommand request, CancellationToken cancellationToken)
        {
            await _locationService.Delete(request.Id);
            return Unit.Value;
        }
    }
}
