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
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        public ProductsController(IGenericRepository<Product> productRepo,
           IGenericRepository<ProductBrand> productBrandRepo,
           IGenericRepository<ProductType> productTypeRepo)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
        }
 
        //  https://localhost:5001/api/products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {           
            var products= await _productRepo.ListAllAsync();
            return Ok(products);
        }

        //  https://localhost:5001/api/products/12
        [HttpGet("{iD}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {
            return await _productRepo.GetProductByIdAsync(Id);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrandAsync()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTyppesAsync()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}