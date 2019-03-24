using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDdd.Application.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                user.Password = CreateHash(user.Password);
                var response = await _userService.Add(user);
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