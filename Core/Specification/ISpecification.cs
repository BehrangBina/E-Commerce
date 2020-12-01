using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specification
{
    public interface ISpecification<T>
    {
         Expression<Func<T,bool>> Criteria{get;} //Where
        List<Expression<Func<T,object>>> Includes{get;} 
    }
}