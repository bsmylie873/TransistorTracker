namespace TransistorTracker.Server.Interfaces;

public interface ISoftwareService
{
    IEnumerable<string> GetAllSoftware();
    string GetSoftwareById(int id);
    void CreateSoftware(string software);
    void UpdateSoftware(int id, string software);
    void DeleteSoftware(int id);
}