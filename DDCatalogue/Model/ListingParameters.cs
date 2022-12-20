using System.Text.RegularExpressions;
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
        private string filter = null;
        public string Filter
        {
            get { return filter; }
            set
            {
                // ParameterExpression parameter = Expression.Parameter(typeof(T));
                // IEnumerable<MemberAssignment> bindings = value
                //     .Select(name => Expression.PropertyOrField(parameter, name))
                //     .Select(member => Expression.Bind(member.Member, member));
                // MemberInitExpression body = Expression.MemberInit(Expression.New(typeof(T)), bindings);
                // filter = Expression.Lambda<Func<T, T>>(body, parameter);
                filter = ParseFilterLogic(value);
            }
        }
        // private string filterPattern = @"(AND|OR)\((.*?)\)$";
        private string filterPattern = @"(AND|OR)(\(((?>\((?<c>)|[^()]+|\)(?<-c>))*(?(c)(?!)))\))";
        // public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; set; } = null;
        public string Include { get; set; } = null;
        public string[] IncludeProperties { get { return Include?.Split(','); } }
        public string Expand { get; set; } = null;
        public string[] ExpandProperties { get { return Expand?.Split(','); } }
        private Dictionary<string, string> operators = new() {
            {"eq", "=="},
            {"gt" , ">"},
            {"gte" , ">="},
            {"lt", "<"},
            { "lte", "<="},
            { "neq", "!="},
        };

        private string ParseFilterLogic(string filter, string gate = "AND")
        {
            string query = "";
            string currentFilter = filter;
            MatchCollection matches = Regex.Matches(filter, filterPattern, RegexOptions.IgnoreCase);
            if (matches.Count > 0)
            {
                List<string> innerOperations = new();
                foreach (Match match in matches)
                {
                    var groups = match.Groups;
                    innerOperations.Add($"({ParseFilterLogic(groups[3].Value, groups[1].Value)})");
                }
                query += $"({string.Join($" {gate} ", innerOperations)})";
                currentFilter = Regex.Replace(filter, filterPattern, string.Empty, RegexOptions.IgnoreCase);

            }

            List<string> operations = new();
            foreach (string operation in currentFilter.Split(','))
            {
                if (!string.IsNullOrEmpty(operation))
                {
                    string[] opParams = operation.Split('|');
                    operations.Add($"{opParams[0]} {operators[opParams[1]]} {opParams[2]}");
                }
            }
            query += $"{string.Join($" {gate} ", operations)}";


            return query;
        }
    }
    public static class QueryableExtensions
    {
        public static IQueryable IncludeProperties(this IQueryable result, string[] includeProperties)
        {
            if (includeProperties?.Length > 0)
            {
                return result.Select(
                    $"new {{ {String.Join(",", includeProperties.Select(name => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name).Replace("_", "")))} }}");
            }
            else return result;
        }

        public static IQueryable Filter(this IQueryable result, string filterQuery)
        {
            if (!string.IsNullOrEmpty(filterQuery))
            {
                return result.Where(filterQuery);
            }
            else return result;
        }
    }
}