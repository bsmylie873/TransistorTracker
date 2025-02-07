using TransistorTracker.Server.DTOs.Devices;
using TransistorTracker.Server.DTOs.Pagination;

namespace TransistorTracker.Server.Interfaces;

public interface IDeviceService
{
    Task<PaginatedDto<DeviceDto>> GetAllDevices(PaginationDto pagination);
    Task<DeviceDto?> GetDeviceById(int id);
    Task CreateDevice(CreateDeviceDto device);
    Task<bool> UpdateDevice(int id, UpdateDeviceDto device);
    Task<bool> DeleteDevice(int id);
}