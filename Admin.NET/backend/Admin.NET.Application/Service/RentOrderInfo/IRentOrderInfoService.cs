using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IRentOrderInfoService
    {
        Task Add(AddRentOrderInfoInput input);
        Task Delete(DeleteRentOrderInfoInput input);
        Task<RentOrderInfo> Get([FromQuery] QueryeRentOrderInfoInput input);
        Task<dynamic> List([FromQuery] RentOrderInfoInput input);
        Task<dynamic> Page([FromQuery] RentOrderInfoInput input);
        Task Update(UpdateRentOrderInfoInput input);
    }
}