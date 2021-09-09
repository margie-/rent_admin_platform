using Furion.Extras.Admin.NET;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    public interface IMileStatisticsService
    {
        Task Add(AddMileStatisticsInput input);
        Task Delete(DeleteMileStatisticsInput input);
        Task<MileStatistics> Get([FromQuery] QueryeMileStatisticsInput input);
        Task<dynamic> List([FromQuery] MileStatisticsInput input);
        Task<dynamic> Page([FromQuery] MileStatisticsInput input);
        Task Update(UpdateMileStatisticsInput input);
    }
}