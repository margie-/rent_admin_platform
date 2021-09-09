using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IContractListService
    {
        Task Add(AddContractListInput input);
        Task Delete(DeleteContractListInput input);
        Task<ContractList> Get([FromQuery] QueryeContractListInput input);
        Task<dynamic> List([FromQuery] ContractListInput input);
        Task<dynamic> Page([FromQuery] ContractListInput input);
        Task Update(UpdateContractListInput input);
    }
}