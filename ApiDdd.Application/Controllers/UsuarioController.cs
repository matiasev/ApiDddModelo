using System;
using System.Security.Cryptography;
using System.Text;
using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDdd.Application.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] UsuarioViewModel item)
        {
            try
            {
                if (item == null)
                    return NotFound();

                item.Password = CreateHash(item.Password);


                _service.Add(item);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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