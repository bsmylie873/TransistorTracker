using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Dal.Models;
using TransistorTracker.Dal.Specifications.Users;
using TransistorTracker.Server.DTOs.Users;
using TransistorTracker.Server.Interfaces;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace TransistorTracker.Server.Services;

public class UserService : IUserService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public UserService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IList<UserDto> GetAllUsers()
    {
        var userQuery = _database
            .Get<User>();

        return _mapper
            .ProjectTo<UserDto>(userQuery)
            .ToList();
    }

    public UserDto? GetUserById(int id)
    {
        var user = _database
            .Get<User>()
            .FirstOrDefault(new UserByIdSpec(id));

        return _mapper.Map<UserDto>(user) ?? null;
    }

    public void CreateUser(CreateUserDto user)
    {
        var newAccount = _mapper.Map<User>(user);
        _database.Add(newAccount);
        _database.SaveChanges();
    }

    public bool UpdateUser(int id, UpdateUserDto user)
    {
        var currentUser = _database
            .Get<User>()
            .FirstOrDefault(new UserByIdSpec(id));

        if (currentUser == null) return false;

        _mapper.Map(user, currentUser);
        _database.SaveChanges();
        return true;
    }

    public bool DeleteUser(int id)
    {
        var currentUser = _database
            .Get<User>()
            .FirstOrDefault(new UserByIdSpec(id));

        if (currentUser == null) return false;

        _database.Delete(currentUser);
        _database.SaveChanges();
        return true;
    }
}