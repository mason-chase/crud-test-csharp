using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mc2.CrudTest.Application.Common.Models
{
    public class PagingResult<T>
    {
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public bool IsLastPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool HasNextPage { get; set; }
        public IEnumerable<T> Items { get; set; }
        public bool HasPreviousPage { get; set; }
        public int TotalFilteredItems { get; set; }
    }
}
