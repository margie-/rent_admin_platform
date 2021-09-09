using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IDeviceBattertCalibService
    {
        Task Add(AddDeviceBattertCalibInput input);
        Task Delete(DeleteDeviceBattertCalibInput input);
        Task<DeviceBattertCalib> Get([FromQuery] QueryeDeviceBattertCalibInput input);
        Task<dynamic> List([FromQuery] DeviceBattertCalibInput input);
        Task<dynamic> Page([FromQuery] DeviceBattertCalibInput input);
        Task Update(UpdateDeviceBattertCalibInput input);
        Task <List<DeviceBattertCalib>> GetFromDeviceNo(string deviceNo);

        Task DeleteByDevice(string deviceNo);
    }
}