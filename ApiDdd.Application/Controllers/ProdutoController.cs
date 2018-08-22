using System;
using System.Net;
using System.Net.Http;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.Services;
using ApiDdd.Service.Validators;
using ApiDdd.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDdd.Application.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {

        private readonly IProdutoServiceApp _service;

        public ProdutoController(IProdutoServiceApp service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                return new ObjectResult(_service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost, Authorize]
        public IActionResult Create([FromBody] ProdutoViewModel item)
        {
            try
            {
                if (item == null)
                    return NotFound();

                _service.Add(item);

                return new ObjectResult(item.ProdutoId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut, Authorize]
        public IActionResult Update([FromBody] ProdutoViewModel item)
        {
            try
            {
                if (item == null)
                    return NotFound();

                _service.Update(item);

                return new ObjectResult(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();

                _service.Delete(id);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
