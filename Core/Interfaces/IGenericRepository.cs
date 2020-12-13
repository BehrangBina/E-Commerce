using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
         Task<T> GetProductByIdAsync(int id);
         Task<IReadOnlyList<T>> ListAllAsync(); 
         
         Task<T> GetEntityWithSpec(ISpecification<T> Sspec);
         Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec );
         Task<int> CountAsync(ISpecification<T> spec); 
    }
}