using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace PRN221.Team5.Application.Common
{
    public static class LinqExtension
    {
        public static IQueryable<T> Includes<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
    }
}
