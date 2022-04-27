using DAL.Repositories.Interface;
using DAL.Repositories.Logging;
using Database;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using DAL.Exceptions;

namespace DAL.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(DeathmatchDbContext context, ILogMessageManager<Location> logMessageManager) : base(context, logMessageManager)
        {

        }

        public async Task<Location> GetByName(string name)
        {
            _logMessageManager.LogCustomMessage("GetByName.Name: " + name);
            var entity = await _context.Locations.FirstOrDefaultAsync(e => (e.Name == name));
            if (entity == null)
            {
                var ex = new ItemNotFoundException();
                _logMessageManager.LogFailure(ex.Message);
                throw ex;
            }
            _logMessageManager.LogSuccess();
            return entity;
        }
    }
}
