using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace WebApi.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminLogin _repo;
        private readonly IOptions<AuthOptions> _options;
        public AdminController(IAdminLogin repo, IOptions<AuthOptions> options)
        {
            _repo = repo;
            _options = options;
        }

        private string GenerateJwt(AdminLogin login)
        {
            var authParam = _options.Value;
            var key = authParam.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, login.Login),
                new Claim(JwtRegisteredClaimNames.Sub, login.AdminId.ToString())
            };
            var token = new JwtSecurityToken(
                authParam.Issuer,
                authParam.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParam.TokenLifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost]
        public IActionResult GetAccess(AdminLogin data)
        {
            var user = _repo.GetAccess(data.Login, data.Password);

            if (user != null)
            {
                var token = GenerateJwt(user);
                return Ok(
                    new
                    {
                        access_token = token
                    });
            }
            return Unauthorized();
        }
    }
}
