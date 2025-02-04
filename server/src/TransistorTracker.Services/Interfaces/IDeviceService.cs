namespace TransistorTracker.Server.Interfaces;

public interface IDeviceService
{
    IEnumerable<string> GetAllDevices();
    string GetDeviceById(int id);
    void CreateDevice(string device);
    void UpdateDevice(int id, string device);
    void DeleteDevice(int id);
}