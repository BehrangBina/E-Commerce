using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandSpecification(ProductSpecParams productSpecParams): 
        base(
            exp=>
            (!productSpecParams.BrandId.HasValue || exp.ProductBrandId==productSpecParams.BrandId )&&
            (!productSpecParams.TypeId.HasValue  || exp.ProductTypeId==productSpecParams.TypeId)
        )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name); //default order by name
            ApplyPaging(productSpecParams.PageSize* (productSpecParams.PageIndex-1),
            productSpecParams.PageSize); // app;ly pagination
            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDecscending(p => p.Price);
                        break;
                }

            }
        }
        public ProductsWithTypesAndBrandSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}