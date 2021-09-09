using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IReturnListService
    {
        Task Add(AddReturnListInput input);
        Task Delete(DeleteReturnListInput input);
        Task<ReturnList> Get([FromQuery] QueryeReturnListInput input);
        Task<dynamic> List([FromQuery] ReturnListInput input);
        Task<dynamic> Page([FromQuery] ReturnListInput input);
        Task Update(UpdateReturnListInput input);
    }
}