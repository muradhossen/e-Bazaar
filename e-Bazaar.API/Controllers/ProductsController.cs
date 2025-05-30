using Application.Common.Pagination;
using Application.DTOs.Products;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Bazaar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<PagedList<ProductDto>>> GetProducts([FromQuery] PageParam pageParam)
        { 
            return await _productService.GetAllAsync(pageParam);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductCreateDto request)
        {
            return await _productService.AddAsync(request)
                ? Ok()
                : BadRequest("Product could not be added.");
        }
    }
}
