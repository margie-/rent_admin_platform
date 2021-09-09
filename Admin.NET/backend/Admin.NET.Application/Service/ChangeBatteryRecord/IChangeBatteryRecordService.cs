using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IChangeBatteryRecordService
    {
        Task Add(AddChangeBatteryRecordInput input);
        Task Delete(DeleteChangeBatteryRecordInput input);
        Task<ChangeBatteryRecord> Get([FromQuery] QueryeChangeBatteryRecordInput input);
        Task<dynamic> List([FromQuery] ChangeBatteryRecordInput input);
        Task<dynamic> Page([FromQuery] ChangeBatteryRecordInput input);
        Task Update(UpdateChangeBatteryRecordInput input);
    }
}