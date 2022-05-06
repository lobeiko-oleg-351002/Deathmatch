using AutoMapper;
using BLL.AuthTokens;
using BLL.Services.Interface;
using MediatR;
using QueryService.QueryModels;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.View;

namespace QueryService.Queries
{
    public class AuthorizeQueryHandler : IRequestHandler<AuthorizeQuery, UserToken>
    {
        private readonly IUserService _userService;
        public AuthorizeQueryHandler(IUserService UserService)
        {
            _userService = UserService;
        }

        public async Task<UserToken> Handle(AuthorizeQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByNameAndPassword(request.Login, request.Password);
            var userToken = AuthOptions.CreateUserToken(user);
            return userToken;
        }
    }
}
