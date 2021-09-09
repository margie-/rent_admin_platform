using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface ISIMInfoService
    {
        Task Add(AddSIMInfoInput input);
        Task Delete(DeleteSIMInfoInput input);
        Task<SIMInfo> Get([FromQuery] QueryeSIMInfoInput input);
        Task<dynamic> List([FromQuery] SIMInfoInput input);
        Task<dynamic> Page([FromQuery] SIMInfoInput input);
        Task Update(UpdateSIMInfoInput input);

        Task<SIMInfo> GetSimInfoByDeviceNO(string deviceno);
    }
}