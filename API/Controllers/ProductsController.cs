using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _storeContext;
        public ProductsController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        //  https://localhost:5001/api/products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products= await _storeContext.products.ToListAsync();
            return Ok(products);
        }

        //  https://localhost:5001/api/products/12
        [HttpGet("{iD}")]
        public async Task<ActionResult<Product>>  GetProduct(int Id)
        {
            return await _storeContext.products.FindAsync(Id);
        }
    }
}