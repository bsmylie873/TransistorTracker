namespace TransistorTracker.Server.Interfaces;

public interface IUserService
{
    IEnumerable<string> GetAllUsers();
    string GetUserById(int id);
    void CreateUser(string user);
    void UpdateUser(int id, string user);
    void DeleteUser(int id);
}