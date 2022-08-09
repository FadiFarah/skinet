using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications;

public interface ISpecification<T>
{
    //Generic method
    //Generic methods are methods that introduce their own type parameters. 
    //This is similar to declaring a generic type, but the type parameter's scope is limited to the method where it is declared.
    Expression<Func<T, bool>> Criteria { get; }

    List<Expression<Func<T, object>>> Includes { get; }
}
