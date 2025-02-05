using TransistorTracker.Server.DTOs.Devices;

namespace TransistorTracker.Server.Interfaces;

public interface IDeviceService
{
    IList<DeviceDto> GetAllDevices();
    DeviceDto? GetDeviceById(int id);
    void CreateDevice(CreateDeviceDto device);
    bool UpdateDevice(int id, UpdateDeviceDto device);
    bool DeleteDevice(int id);
}