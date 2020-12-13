using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersWithCountSpecification:BaseSpecification<Product>
    {
        public ProductWithFiltersWithCountSpecification(ProductSpecParams productSpecParams)
        :base(
            exp=>
            (string.IsNullOrEmpty(productSpecParams.Search)                 ||
            exp.Name.ToLower().Contains(productSpecParams.Search))  &&  
            (!productSpecParams.BrandId.HasValue || exp.ProductBrandId==productSpecParams.BrandId )&&
            (!productSpecParams.TypeId.HasValue  || exp.ProductTypeId==productSpecParams.TypeId)
        )
        {

        }
    }
}