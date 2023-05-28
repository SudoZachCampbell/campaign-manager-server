using System.Text.RegularExpressions;
using System.Globalization;
using System.Linq.Dynamic.Core;
using CampaignManager.Data.Model;
using System.Text.Json.Serialization;
using NSwag.Annotations;
namespace CampaignManager.Data.Repositories
{
    public class FilterParameters<T> where T : IBase
    {
        public string? Include { get; set; }
        [JsonIgnore]
        [OpenApiIgnore]
        public string[]? IncludeProperties { get { return Include?.Split(','); } }
        public string? Expand { get; set; }
        [JsonIgnore]
        [OpenApiIgnore]
        public string[]? ExpandProperties { get { return Expand?.Split(','); } }
        private string filter = string.Empty;
        public string Filter
        {
            get { return filter; }
            set
            {
                filter = ParseFilterLogic(value, initial: true);
            }
        }
        private Dictionary<string, string> operators = new() {
            {"eq", "=="},
            {"gt" , ">"},
            {"ge" , ">="},
            {"lt", "<"},
            {"le", "<="},
            {"neq", "!="},
        };
        private string filterPattern = @"(AND|OR)(\(((?>\((?<c>)|[^()]+|\)(?<-c>))*(?(c)(?!)))\))";

        private string ParseFilterLogic(string filter, string gate = "AND", bool initial = false)
        {
            try
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
                        innerOperations.Add($"{ParseFilterLogic(groups[3].Value, groups[1].Value)}");
                    }
                    query += $"{string.Join($" {gate} ", innerOperations)}";
                    currentFilter = Regex.Replace(filter, filterPattern, string.Empty, RegexOptions.IgnoreCase);

                }

                List<string> operations = new();
                foreach (string operation in currentFilter.Split(','))
                {
                    if (!string.IsNullOrEmpty(operation))
                    {
                        string[] opParams = operation.Split('|');
                        operations.Add($"{opParams[0]} {opParams[1]} {opParams[2]}");
                    }
                }
                if (operations.Count > 1)
                {
                    query += $"{(initial || string.IsNullOrEmpty(query) ? "" : $" {gate} ")}{string.Join($" {gate} ", operations)}";

                }
                else if (operations.Count > 0)
                {
                    query += $" {(initial ? "" : gate)} {operations[0]}";
                }

                return $"({query})";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse filter query", ex);
            }
        }
    }
    public static class QueryableExtensions
    {
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> result, string[] includeProperties)
        {
            if (includeProperties?.Length > 0)
            {
                return result.Select<T>(
                    $"new {{ {String.Join(",", includeProperties.Select(name => CultureInfo.InvariantCulture.TextInfo.ToTitleCase(name).Replace("_", "")))} }}");
            }
            else return result;
        }

        public static IQueryable<T> Filter<T>(this IQueryable<T> result, string filterQuery)
        {
            try
            {
                if (!string.IsNullOrEmpty(filterQuery))
                {
                    return result.Where(filterQuery);
                }
                else return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to execute filter query", ex);
            }
        }
    }
}