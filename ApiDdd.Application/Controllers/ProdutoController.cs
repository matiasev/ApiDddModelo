using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.Services;
using ApiDdd.Service.Validators;
using ApiDdd.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDdd.Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {

        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IList<ProdutoViewModel>> Get()
        {
            IList<ProdutoViewModel> produtos = await _produtoService.GetAsysc();
            return produtos;
        }

        [HttpGet("{id}"), ]
        public async Task<ProdutoViewModel> Get(int id)
        {
            ProdutoViewModel produto = await _produtoService.GetByIdAsync(id);
            return produto;
        }

        //Todo: make it better
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var response = await _produtoService.AddAsync(produto);
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

        //Todo: make it better
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var response = await _produtoService.UpdateAsync(produto);
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

        //Todo: make it better
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _produtoService.Delete(id);
            if (response == null)
            {
                return Json(new { success = false, message = "Your request has been failed" });
            }
            else
            {
                return Json(new { success = true, message = "Your request has been processed" });
            }
        }
    }
}
