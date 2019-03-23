using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace ApiDdd.Application.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;


        public TokenController(IConfiguration config, IUsuarioService usuarioService, IMapper mapper)
        {
            _config = config;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string BuildToken(LoginViewModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddDays(5),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private LoginViewModel Authenticate(LoginViewModel login)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] data = Encoding.ASCII.GetBytes(login.Password);
            data = md5.ComputeHash(data);
            login.Password = Encoding.ASCII.GetString(data);

            var user = _usuarioService.GetByUser(login);

            return user;
        }
    }

}
