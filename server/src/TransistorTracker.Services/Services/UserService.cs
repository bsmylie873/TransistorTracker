using AutoMapper;
using TransistorTracker.Dal.Extensions;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Users;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Users;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.EF6.Extensions;

namespace TransistorTracker.Server.Services;

public class UserService : IUserService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;
    private readonly IPaginationService _paginationService;

    public UserService(ITransitorTrackerDatabase database, IMapper mapper, IPaginationService paginationService)
    {
        (_database, _mapper, _paginationService) = (database, mapper, paginationService);
    }
    
    public async Task<PaginatedDto<UserDto>> GetAllUsers(PaginationDto pagination)
    {
        var (pageSize, pageNumber, searchQuery, sortBy, ascending) = pagination;
        
        var userQuery = _database
            .Get<User>()
            .Where(new UsersBySearchSpec(searchQuery));

        var users = _mapper
            .ProjectTo<UserDto>(userQuery)
            .OrderBy(sortBy, ascending);
        
        return await _paginationService.CreatePaginatedResponseAsync(users, pageSize, pageNumber);
    }

    public async Task<UserDto?> GetUserById(int id)
    {
        var user = await _database
            .Get<User>()
            .FirstOrDefaultAsync(new UserByIdSpec(id));

        return _mapper.Map<UserDto>(user) ?? null;
    }

    public async Task CreateUser(CreateUserDto user)
    {
        var newAccount = _mapper.Map<User>(user);
        _database.Add(newAccount);
        await _database.SaveChangesAsync();
    }

    public async Task<bool> UpdateUser(int id, UpdateUserDto user)
    {
        var currentUser = _database
            .Get<User>()
            .FirstOrDefault(new UserByIdSpec(id));

        if (currentUser == null) return false;

        _mapper.Map(user, currentUser);
        await _database.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var currentUser = _database
            .Get<User>()
            .FirstOrDefault(new UserByIdSpec(id));

        if (currentUser == null) return false;

        _database.Delete(currentUser);
        await _database.SaveChangesAsync();
        return true;
    }
}