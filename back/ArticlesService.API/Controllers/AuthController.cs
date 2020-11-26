using ArticleService.Common;
using ArticlesService.Domain.Interfaces;
using ArticlesService.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArticlesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IUserRepository _repository;
        private IOptions<AuthOptions> _authOptions;

        public AuthController(IUserRepository repository, IOptions<AuthOptions> authOptions)
        {
            _repository = repository;
            _authOptions = authOptions;
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            var user = _repository.GetUser(login);
            if (user != null)
            {
                var token = GenerateJwt(user);

                return Ok(new
                {
                    access_token = token
                });
            }

            return Unauthorized();
        }

        internal string GenerateJwt(User user)
        { 
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.EMail),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
