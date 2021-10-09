using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Tupa_Web.Common.Security
{
    /// <summary>
    /// See https://docs.microsoft.com/pt-br/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-5.0
    /// </summary>
    public class PaginatedList<T>
    {
        public List<T> items { get; set; }
        public int pageIndex { get; set; }
        public int totalPages { get; set; }
        public int totalCount { get; set; }

       /* public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            this.pageIndex = pageIndex;
            this.totalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.totalCount = count;
            this.items = items;
        }

        public bool HasPreviousPage => pageIndex > 1;

        public bool HasNextPage => pageIndex < totalPages;

        public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }*/
    }
}