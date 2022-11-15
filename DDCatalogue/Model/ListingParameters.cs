using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace DDCatalogue.Model
{
    public class ListingParameters<T> where T : IBase
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;
        public int Page { get; set; } = 1;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
        // public Expression<Func<T, bool>> Filter { get; set; } = null;
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; set; } = null;
        public string Include { get; set; } = null;
        public string[] IncludeProperties { get { return Include?.Split(','); } }
        public string Expand { get; set; } = null;
        public string[] ExpandProperties { get { return Expand?.Split(','); } }
    }
    public static class QueryableExtensions
    {
        public static List<dynamic> FilterProperties(this IQueryable result, string[] includeProperties)
        {
            if (includeProperties?.Length > 0)
            {
                return result.Select(
                    $"new {{ {String.Join(",", includeProperties.Select(name => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name).Replace("_", "")))} }}").ToDynamicList();
            }
            else return result.ToDynamicList();
        }
    }
}