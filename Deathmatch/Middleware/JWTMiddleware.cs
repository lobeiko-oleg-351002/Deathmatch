using BLL.AuthTokens;
using BLL.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModels.View;

namespace Deathmatch.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                AttachUserToContext(context, userService, token);
            }

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IUserService userService, string token)
        {
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();
            TokenHandler.ValidateToken(token, AuthOptions.CreateValidationParameters(), out SecurityToken validatedToken);

            JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
            UserViewModel identity = userService.Get(userId).Result;

            var user = new ClaimsPrincipal(AuthOptions.CreateClaimsIdentity(identity, token));

            context.User = user;
            
        }
    }
}
