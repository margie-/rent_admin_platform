using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IFenceStaticsService
    {
        Task Add(AddFenceStaticsInput input);
        Task Delete(DeleteFenceStaticsInput input);
        Task<FenceStatics> Get([FromQuery] QueryeFenceStaticsInput input);
        Task<dynamic> List([FromQuery] FenceStaticsInput input);
        Task<dynamic> Page([FromQuery] FenceStaticsInput input);
        Task Update(UpdateFenceStaticsInput input);
    }
}