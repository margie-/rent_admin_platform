using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IDeviceAlarmStasticService
    {
        Task Add(AddDeviceAlarmStasticInput input);
        Task Delete(DeleteDeviceAlarmStasticInput input);
        Task<DeviceAlarmStastic> Get([FromQuery] QueryeDeviceAlarmStasticInput input);
        Task<dynamic> List([FromQuery] DeviceAlarmStasticInput input);
        Task<dynamic> Page([FromQuery] DeviceAlarmStasticInput input);
        Task Update(UpdateDeviceAlarmStasticInput input);
    }
}
