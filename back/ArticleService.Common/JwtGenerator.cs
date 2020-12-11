//using ArticleService.Common;
//using ArticlesService.Domain.Models;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;

//namespace ArticlesService.Common
//{
//    public class JwtGenerator
//    {
//        private IOptions<AuthOptions> _authOptions;

//        public JwtGenerator(IOptions<AuthOptions> authOptions)
//        {
//            _authOptions = authOptions;
//        }

//        public string GenerateJwt(User user)
//        {
//            var authParams = _authOptions.Value;

//            var securityKey = authParams.GetSymmetricSecurityKey();
//            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            var claims = new List<Claim>()
//            {
//                new Claim(JwtRegisteredClaimNames.Email, user.EMail),
//                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
//            };

//            var token = new JwtSecurityToken(
//                authParams.Issuer,
//                authParams.Audience,
//                claims,
//                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
//                signingCredentials: credentials);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }
//    }
//}
