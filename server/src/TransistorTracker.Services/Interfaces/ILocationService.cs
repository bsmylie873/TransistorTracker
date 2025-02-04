namespace TransistorTracker.Server.Interfaces;

public interface ILocationService
{
    IEnumerable<string> GetAllLocations();
    string GetLocationById(int id);
    void CreateLocation(string location);
    void UpdateLocation(int id, string location);
    void DeleteLocation(int id);
}