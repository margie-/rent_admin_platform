using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IOrderInfoService
    {
        Task Add(AddOrderInfoInput input);
        Task Delete(DeleteOrderInfoInput input);
        Task<OrderInfo> Get([FromQuery] QueryeOrderInfoInput input);
        Task<dynamic> List([FromQuery] OrderInfoInput input);
        Task<dynamic> Page([FromQuery] OrderInfoInput input);
        Task Update(UpdateOrderInfoInput input);
    }
}