using TransistorTracker.Server.DTOs.Users;

namespace TransistorTracker.Server.Interfaces;

public interface IUserService
{
    IList<UserDto> GetAllUsers();
    UserDto? GetUserById(int id);
    void CreateUser(CreateUserDto user);
    bool UpdateUser(int id, UpdateUserDto user);
    bool DeleteUser(int id);
}