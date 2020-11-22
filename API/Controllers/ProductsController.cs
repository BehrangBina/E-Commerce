using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Entities;
namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
         
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;            
        }

        //  https://localhost:5001/api/products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products= await _repo.GetProductsAsync();
            return Ok(products);
        }

        //  https://localhost:5001/api/products/12
        [HttpGet("{iD}")]
        public async Task<ActionResult<Product>>  GetProduct(int Id)
        {
            return await _repo.GetProductByIdAsync(Id);
        }
    }
}