using BLL.AuthTokens;
using MediatR;
using ViewModels.View;

namespace QueryService.QueryModels
{
    public class AuthorizeQuery : IRequest<UserToken>
    {
        public readonly string Login;

        public readonly string Password;

        public AuthorizeQuery(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
