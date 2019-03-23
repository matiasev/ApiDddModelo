using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDdd.Application.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Password = CreateHash(usuario.Password);
                var response = await _usuarioService.Add(usuario);
                if (response == null)
                {
                    return Json(new { success = false, message = "Your request has been failed" });
                }
                else
                {
                    return Json(new { success = true, message = "Your request has been processed" });
                }
            }
            else
            {
                return Json(new { success = false, message = "Invalid" });
            }
        }

        private string CreateHash(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] data = Encoding.ASCII.GetBytes(password);
            data = md5.ComputeHash(data);

            return Encoding.ASCII.GetString(data);
        }
    }
}