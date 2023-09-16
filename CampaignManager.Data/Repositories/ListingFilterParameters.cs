using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq.Dynamic.Core;
using CampaignManager.Data.Model;

namespace CampaignManager.Data.Repositories
{
    public class ListingFilterParameters<T> : FilterParameters<T> where T : IBase
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;
        public int Page { get; set; } = 1;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
        public string? OrderBy { get; set; }
    }
}