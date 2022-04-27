using AutoMapper;
using BLL.Exceptions;
using BLL.Services.Interface;
using DAL.Exceptions;
using DAL.Repositories.Interface;
using Models;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services
{
    public class LocationService : Service<Location, LocationViewModel, LocationCreateModel>, ILocationService
    {
        public LocationService(ILocationRepository locationRepository, IMapper mapper) 
            : base(locationRepository, mapper)
        {

        }

        public async Task<LocationViewModel> GetByName(string name)
        {
            try
            {
                var entity = await ((ILocationRepository)_repository).GetByName(name);
                return _mapper.Map<LocationViewModel>(entity);
            }
            catch (ItemNotFoundException)
            {
                throw new UserNotFoundException();
            }
        }
    }
}
