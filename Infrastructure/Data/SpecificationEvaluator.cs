using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;
        if(spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }

        // takes multiple "Include" statements then aggregates thme(put them together) and pass them into our query
        // which is an IQueryable that we then past to our list
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }
}
