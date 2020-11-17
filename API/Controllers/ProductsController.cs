using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController:ControllerBase
    {
        //  https://localhost:5001/api/products
        [HttpGet]
        public string GetProducts(){
            return "All products will be returned";
        }

        //  https://localhost:5001/api/products/12
        [HttpGet("{iD}")]
        public string GetProduct(int Id){
            return "Product returned: "+Id;
        }
    }
}