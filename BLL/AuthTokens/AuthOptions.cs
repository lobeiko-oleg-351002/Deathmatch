using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViewModels.View;

namespace BLL.AuthTokens
{
    public static class AuthOptions
    {
        private const string ISSUER = "DeathmatchAuthServer";
        private const string AUDIENCE = "DeathmatchAuthClient";
        private const string KEY = "deathmatch_itechart44";
        private static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static TokenValidationParameters CreateValidationParameters()
        {
            return new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = ISSUER,
                ValidateAudience = false,
                ValidAudience = AUDIENCE,
                ValidateLifetime = false,
                IssuerSigningKey = GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };
        }

        public static ClaimsIdentity CreateClaimsIdentity(UserViewModel user)
        {
            return NewClaimsIdentity(user, "User");
        }

        public static ClaimsIdentity CreateClaimsIdentity(UserViewModel user, string token)
        {
            return NewClaimsIdentity(user, $"User: {token}");
        }

        private static ClaimsIdentity NewClaimsIdentity(UserViewModel user, string cred)
        {
            return new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, cred),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Name),
            }, "tokenAuthorization");
        }

        public static UserToken CreateUserToken(UserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = CreateClaimsIdentity(user),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var response = new UserToken
            {
                Token = tokenHandler.WriteToken(token),
                UserName = user.Name
            };

            return response;
        }
    }
}
