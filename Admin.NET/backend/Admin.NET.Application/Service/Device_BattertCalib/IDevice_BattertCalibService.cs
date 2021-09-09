using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IDevice_BattertCalibService
    {
        Task Add(AddDevice_BattertCalibInput input);
        Task Delete(DeleteDevice_BattertCalibInput input);
        Task<DeviceBattertCalib> Get([FromQuery] QueryeDevice_BattertCalibInput input);
        Task<dynamic> List([FromQuery] Device_BattertCalibInput input);
        Task<dynamic> Page([FromQuery] Device_BattertCalibInput input);
        Task Update(UpdateDevice_BattertCalibInput input);
    }
}