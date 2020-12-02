using AutoMapper;
using Core.Entities;
using API.DTos;
namespace API.Helpers
{
    public class MappingPrpfiles:Profile
    {
        public MappingPrpfiles(){
            CreateMap<Product,ProductToReturnDto>()
                .ForMember(d =>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d=>d.ProductType, o=>o.MapFrom(s=>s.ProductType.Name));
                // Map product type class . name prop to string ProductType 
        }
    }
}