using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IDeviceInfoService
    {
        Task Add(AddDeviceInfoInput input);
        Task Delete(DeleteDeviceInfoInput input);
        Task<DeviceInfo> Get([FromQuery] QueryeDeviceInfoInput input);
        Task<dynamic> List([FromQuery] DeviceInfoInput input);
        Task<dynamic> Page([FromQuery] DeviceInfoInput input);
        Task Update(UpdateDeviceInfoInput input);
        Task<dynamic> Page2([FromQuery] DeviceQueryInfoInput input);
        Task<IActionResult> ExportDevice([FromQuery] DeviceInfoInput input);

        Task Transfer([FromQuery] TransferDeviceInput input);

        Task LotUpdate([FromQuery] LotUpdateDeviceInfoInput input);

        Task SendCommand([FromQuery] DeviceCommandInfos input);

        Task<dynamic> GetDevicesByIds([FromQuery] DevicesIDs input );

    }
}