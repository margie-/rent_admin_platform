using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IDeviceAlarmRecordService
    {
        Task Add(AddDeviceAlarmRecordInput input);
        Task Delete(DeleteDeviceAlarmRecordInput input);
        Task<DeviceAlarmRecord> Get([FromQuery] QueryeDeviceAlarmRecordInput input);
        Task<dynamic> List([FromQuery] DeviceAlarmRecordInput input);
        Task<dynamic> Page([FromQuery] DeviceAlarmRecordInput input);
        Task Update(UpdateDeviceAlarmRecordInput input);
    }
}