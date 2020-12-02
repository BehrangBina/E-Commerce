using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Core.Entities;
using Core.Specification;
using API.DTos;
using System.Reflection;
using System.Linq;
using AutoMapper;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {     
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepo,
           IGenericRepository<ProductBrand> productBrandRepo,
           IGenericRepository<ProductType> productTypeRepo,
           IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper=mapper;
        }
 
        //  https://localhost:5001/api/products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Product>>> GetProducts()
        {    
            var spec = new ProductsWithTyPesAndBrandSpecification();       
            var products= await _productRepo.ListAsync(spec);
 
            return Ok(_mapper
            .Map<
            IReadOnlyCollection<Product> ,
            IReadOnlyCollection<ProductToReturnDto>>(products));
        }

        //  https://localhost:5001/api/products/12
        [HttpGet("{iD}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int Id)
        {
           var spec = new ProductsWithTyPesAndBrandSpecification(Id); 
            var product= await _productRepo.GetEntityWithSpec(spec);

         return _mapper.Map<Product,ProductToReturnDto>(product);
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