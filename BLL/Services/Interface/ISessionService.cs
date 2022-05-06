using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services.Interface
{
    public interface ISessionService : IService<SessionViewModel, SessionCreateModel>
    {
        Task RemoveUserFromSession(UserViewModel user, SessionViewModel session);
    }
}
