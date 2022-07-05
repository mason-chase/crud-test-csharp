using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Mc2.CrudTest.Application.Common.Models;

namespace Mc2.CrudTest.Application.Common.Extensions
{
    public static class PagingExtensions
    {
        public static PagingResult<T> ApplyPaging<T>(this IQueryable<T> source, int page, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source is null.");
            }

            if (page <= 0)
            {
                throw new ArgumentOutOfRangeException("page is equal or less than 0.");
            }

            if (pageSize <= 0)
            {
                throw new ArgumentOutOfRangeException("pageSize is equal or less than 0.");
            }

            var totalItems = source.Count();

            var result = new PagingResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                Items = source.Skip((page - 1) * pageSize).Take(pageSize),
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
            };

            result.TotalFilteredItems = result.Items.Count();

            result.IsFirstPage = result.CurrentPage == 1;
            result.IsLastPage = result.CurrentPage == result.TotalPages;

            result.HasNextPage = result.CurrentPage < result.TotalPages;
            result.HasPreviousPage = result.CurrentPage > 1;

            return result;
        }

        public static PagingResult<T> ApplyPaging<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            return ApplyPaging(source.AsQueryable(), page, pageSize);
        }
    }
}