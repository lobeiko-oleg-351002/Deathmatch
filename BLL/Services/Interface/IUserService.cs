using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services.Interface
{
    public interface IUserService : IService<UserViewModel, UserCreateModel>
    {
        public Task<UserViewModel> GetByNameAndPassword(string name, string password);
    }
}
