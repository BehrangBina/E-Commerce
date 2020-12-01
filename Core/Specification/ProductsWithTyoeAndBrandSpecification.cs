using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTyPesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTyPesAndBrandSpecification()
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
        public ProductsWithTyPesAndBrandSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}