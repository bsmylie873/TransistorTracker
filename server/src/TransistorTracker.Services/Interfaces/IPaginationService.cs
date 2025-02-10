using TransistorTracker.Server.DTOs.Pagination;

namespace TransistorTracker.Server.Interfaces;

public interface IPaginationService
{
    Task<PaginatedDto<T>> CreatePaginatedResponseAsync<T>(IQueryable<T> query, int pageSize, int pageNumber);
}