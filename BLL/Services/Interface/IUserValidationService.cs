using ViewModels.Create;

namespace BLL.Services.Interface
{
    public interface IUserValidationService
    {
        void ValidateNewUser(UserCreateModel user);

        void ValidateNameAndPassword(string name, string password);
    }
}
