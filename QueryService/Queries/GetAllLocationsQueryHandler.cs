using BLL.Services.Interface;
using MediatR;
using QueryService.QueryModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.View;

namespace QueryService.Queries
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, IList<LocationViewModel>>
    {
        private readonly ILocationService _LocationService;

        public GetAllLocationsQueryHandler(ILocationService LocationService)
        {
            _LocationService = LocationService;
        }
        public async Task<IList<LocationViewModel>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            return await _LocationService.GetAll();
        }
    }
}
