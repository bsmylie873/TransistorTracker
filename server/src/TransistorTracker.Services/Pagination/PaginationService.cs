using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.Extensions;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Server.Pagination;

public class PaginationService : IPaginationService
{
    public async Task<PaginatedDto<T>> CreatePaginatedResponseAsync<T>(IQueryable<T> query, int pageSize, int pageNumber)
    {
        var (items, totalCount) = await query.PaginateAsync(pageSize, pageNumber);
        return new PaginatedDto<T>
        {
            Data = items.ToArray(),
            TotalCount = totalCount
        };
    }
}