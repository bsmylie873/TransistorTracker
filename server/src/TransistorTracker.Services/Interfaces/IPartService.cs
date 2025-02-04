namespace TransistorTracker.Server.Interfaces;

public interface IPartService
{
    IEnumerable<string> GetAllParts();
    string GetPartById(int id);
    void CreatePart(string part);
    void UpdatePart(int id, string part);
    void DeletePart(int id);
}