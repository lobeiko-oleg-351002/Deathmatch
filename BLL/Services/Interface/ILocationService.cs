using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services.Interface
{
    public interface ILocationService : IService<LocationViewModel, LocationCreateModel>
    {
        public Task<LocationViewModel> GetByName(string name);
    }
}
