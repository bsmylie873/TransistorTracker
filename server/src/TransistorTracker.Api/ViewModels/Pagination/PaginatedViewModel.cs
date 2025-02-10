using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TransistorTracker.Api.ViewModels.Pagination;

[ExcludeFromCodeCoverage]
public class PaginatedViewModel<T>
{
    [JsonPropertyName("data")]
    public T[] Data { get; set; }
    
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }
}