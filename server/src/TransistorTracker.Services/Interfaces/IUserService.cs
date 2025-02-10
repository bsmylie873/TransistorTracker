using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Users;

namespace TransistorTracker.Server.Interfaces;

public interface IUserService
{
    Task<PaginatedDto<UserDto>> GetAllUsers(PaginationDto pagination);
    Task<UserDto?> GetUserById(int id);
    Task CreateUser(CreateUserDto user);
    Task<bool> UpdateUser(int id, UpdateUserDto user);
    Task<bool> DeleteUser(int id);
}