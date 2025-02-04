using AutoMapper;
using TransistorTracker.Dal.Interfaces;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Server.Services;

public class UserService : IUserService
{
    private readonly ITransitorTrackerDatabase _database;
    private readonly IMapper _mapper;

    public UserService(ITransitorTrackerDatabase database, IMapper mapper)
    {
        (_database, _mapper) = (database, mapper);
    }
    
    public IEnumerable<string> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public string GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public void CreateUser(string user)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(int id, string user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(int id)
    {
        throw new NotImplementedException();
    }
}