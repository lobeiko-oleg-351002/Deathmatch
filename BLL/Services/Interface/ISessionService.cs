using System.Threading.Tasks;
using ViewModels.Create;
using ViewModels.View;

namespace BLL.Services.Interface
{
    public interface ISessionService : IService<SessionViewModel, SessionCreateModel>
    {
        Task RemoveUserFromSession(UserInSessionViewModel user, SessionViewModel session);
    }
}
