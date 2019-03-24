using System.Collections.Generic;
using System.Threading.Tasks;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDdd.Application.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IList<ProductViewModel>> Get()
        {
            IList<ProductViewModel> products = await _productService.GetAsysc();
            return products;
        }

        [HttpGet("{id}"), ]
        public async Task<ProductViewModel> Get(int id)
        {
            ProductViewModel product = await _productService.GetByIdAsync(id);
            return product;
        }

        //Todo: make it better
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.AddAsync(product);
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
        public async Task<IActionResult> Update([FromBody] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateAsync(product);
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
            var response = _productService.Delete(id);
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
