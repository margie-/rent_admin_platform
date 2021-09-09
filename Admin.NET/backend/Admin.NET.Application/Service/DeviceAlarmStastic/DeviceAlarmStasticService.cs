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

namespace Admin.NET.Application
{
    /// <summary>
    /// 报警统计日报表服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "DeviceAlarmStastic", Order = 100)]
    public class DeviceAlarmStasticService : IDeviceAlarmStasticService, IDynamicApiController, ITransient
    {
        private readonly IRepository<DeviceAlarmStastic> _rep;

        public DeviceAlarmStasticService(
            IRepository<DeviceAlarmStastic> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询报警统计日报表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceAlarmStastic/page")]
        public async Task<dynamic> Page([FromQuery] DeviceAlarmStasticInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.OwnedOrg), u => u.OwnedOrg == input.OwnedOrg)
                                     .Where(!string.IsNullOrEmpty(input.reportDate), u => u.reportDate == input.reportDate)
                                     .OrderBy(PageInputOrder.OrderBuilder<DeviceAlarmStasticInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<DeviceAlarmStastic>.PageResult<DeviceAlarmStasticDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加报警统计日报表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceAlarmStastic/add")]
        public async Task Add(AddDeviceAlarmStasticInput input)
        {
            var entity = input.Adapt<DeviceAlarmStastic>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除报警统计日报表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceAlarmStastic/delete")]
        public async Task Delete(DeleteDeviceAlarmStasticInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新报警统计日报表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceAlarmStastic/edit")]
        public async Task Update(UpdateDeviceAlarmStasticInput input)
        {
            var entity = input.Adapt<DeviceAlarmStastic>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取报警统计日报表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceAlarmStastic/detail")]
        public async Task<DeviceAlarmStastic> Get([FromQuery] QueryeDeviceAlarmStasticInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取报警统计日报表列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceAlarmStastic/list")]
        public async Task<dynamic> List([FromQuery] DeviceAlarmStasticInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<DeviceAlarmStasticDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
