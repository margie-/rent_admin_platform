using Furion.Extras.Admin.NET;
using Furion.DatabaseAccessor;
using Furion.DatabaseAccessor.Extensions;
using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Admin.NET.EntityFramework.Core;

namespace Admin.NET.Application
{
    /// <summary>
    /// 里程统计服务
    /// </summary>
    [ApiDescriptionSettings("里程统计", Name = "MileStatistics", Order = 100)]
    public class MileStatisticsService : IMileStatisticsService, IDynamicApiController, ITransient
    {
        private readonly IRepository<MileStatistics> _rep;

        public MileStatisticsService(
            IRepository<MileStatistics> rep
        )
        {
            _rep = rep;
        }


        /// <summary>
        /// 分页查询里程统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/MileStatistics/pagesum")]
        public async Task<dynamic> PageSum([FromQuery] MileStatisticsInput input)
        {
            
            MySqlConnector.MySqlParameter[] sqlparams = new MySqlConnector.MySqlParameter[]
            {
                new  MySqlConnector.MySqlParameter("@_deviceno",input.DeviceNo),
                new  MySqlConnector.MySqlParameter("@_ownedOrg",input.OwnedOrg),
                new  MySqlConnector.MySqlParameter("@_begDtime",""),
                new  MySqlConnector.MySqlParameter("@_endDtime",""),
            };
            var entities = _rep.SqlProcedureQuery<MileStatisticSumDto>("sp_getmilestaticsReport", sqlparams)
                            .AsQueryable()
                            .ToPagedList(input.PageNo, input.PageSize);
            var result = XnPageResult<MileStatisticSumDto>.PageResult<MileStatisticSumDto>(entities);
            //await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 分页查询里程统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/MileStatistics/page")]
        public async Task<dynamic> Page([FromQuery] MileStatisticsInput input)
        {
            var deviceRep = Db.GetRepository<DeviceInfo>();
            var entities = await _rep.DetachedEntities
                                     .Join(deviceRep.DetachedEntities, n => n.DeviceNo, d => d.DeviceNo, (n, d) => new MileStatisticsDto {
                                            DeviceNo = n.DeviceNo,
                                            Sdate = n.Sdate,
                                            DayMiles = n.DayMiles,
                                            MileUnit = n.MileUnit,
                                            DayUsedOil = n.DayUsedOil,
                                            OilUnit = n.OilUnit,
                                            LastLocationDtime = n.LastLocationDtime,
                                            DriverTimes = n.DriverTimes,
                                            AvgSpeed = n.AvgSpeed,
                                            MaxSpeed = n.MaxSpeed,
                                            GPSMiles = n.GPSMiles,
                                            TenantId = n.TenantId,
                                            Id = n.Id,
                                            OwnedOrg = d.OwnedOrg.ToString()
                                    })
                                     .Where(!string.IsNullOrEmpty(input.OwnedOrg), u => u.OwnedOrg == input.OwnedOrg)
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.Sdate), u => u.Sdate == input.Sdate)
                                     .Where(!string.IsNullOrEmpty(input.DayMiles), u => u.DayMiles == input.DayMiles)
                                     .Where(!string.IsNullOrEmpty(input.MileUnit), u => u.MileUnit == input.MileUnit)
                                     .Where(!string.IsNullOrEmpty(input.DayUsedOil), u => u.DayUsedOil == input.DayUsedOil)
                                     .Where(!string.IsNullOrEmpty(input.OilUnit), u => u.OilUnit == input.OilUnit)
                                     .Where(!string.IsNullOrEmpty(input.LastLocationDtime), u => u.LastLocationDtime == input.LastLocationDtime)
                                     .Where(!string.IsNullOrEmpty(input.DriverTimes), u => u.DriverTimes == input.DriverTimes)
                                     .Where(!string.IsNullOrEmpty(input.AvgSpeed), u => u.AvgSpeed == input.AvgSpeed)
                                     .Where(!string.IsNullOrEmpty(input.MaxSpeed), u => u.MaxSpeed == input.MaxSpeed)
                                     .Where(!string.IsNullOrEmpty(input.GPSMiles), u => u.GPSMiles == input.GPSMiles)
                                     .Where(input.TenantId != 0 ,u => u.TenantId == input.TenantId)
                                     .OrderBy(PageInputOrder.OrderBuilder<MileStatisticsInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<MileStatisticsDto>.PageResult<MileStatisticsDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加里程统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/MileStatistics/add")]
        public async Task Add(AddMileStatisticsInput input)
        {
            var entity = input.Adapt<MileStatistics>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除里程统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/MileStatistics/delete")]
        public async Task Delete(DeleteMileStatisticsInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新里程统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/MileStatistics/edit")]
        public async Task Update(UpdateMileStatisticsInput input)
        {
            var entity = input.Adapt<MileStatistics>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取里程统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/MileStatistics/detail")]
        public async Task<MileStatistics> Get([FromQuery] QueryeMileStatisticsInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取里程统计列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/MileStatistics/list")]
        public async Task<dynamic> List([FromQuery] MileStatisticsInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<MileStatisticsDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
