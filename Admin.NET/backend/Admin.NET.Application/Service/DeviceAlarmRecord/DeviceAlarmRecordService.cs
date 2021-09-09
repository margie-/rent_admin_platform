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
    /// 设备警报服务
    /// </summary>
    [ApiDescriptionSettings("报警记录", Name = "DeviceAlarmRecord", Order = 100)]
    public class DeviceAlarmRecordService : IDeviceAlarmRecordService, IDynamicApiController, ITransient
    {
        private readonly IRepository<DeviceAlarmRecord> _rep;

        public DeviceAlarmRecordService(
            IRepository<DeviceAlarmRecord> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询设备警报
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceAlarmRecord/page")]
        public async Task<dynamic> Page([FromQuery] DeviceAlarmRecordInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.AlertDate), u => u.AlertDate == input.AlertDate)
                                     .Where(!string.IsNullOrEmpty(input.AlertType), u => u.AlertType == input.AlertType)
                                     .Where(!string.IsNullOrEmpty(input.AlterStatus), u => u.AlterStatus == input.AlterStatus)
                                     .Where(!string.IsNullOrEmpty(input.isHandled), u => u.isHandled == input.isHandled)
                                     .OrderBy(PageInputOrder.OrderBuilder<DeviceAlarmRecordInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<DeviceAlarmRecord>.PageResult<DeviceAlarmRecordDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加设备警报
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceAlarmRecord/add")]
        public async Task Add(AddDeviceAlarmRecordInput input)
        {
            var entity = input.Adapt<DeviceAlarmRecord>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除设备警报
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceAlarmRecord/delete")]
        public async Task Delete(DeleteDeviceAlarmRecordInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新设备警报
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceAlarmRecord/edit")]
        public async Task Update(UpdateDeviceAlarmRecordInput input)
        {
            var entity = input.Adapt<DeviceAlarmRecord>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取设备警报
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceAlarmRecord/detail")]
        public async Task<DeviceAlarmRecord> Get([FromQuery] QueryeDeviceAlarmRecordInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取设备警报列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceAlarmRecord/list")]
        public async Task<dynamic> List([FromQuery] DeviceAlarmRecordInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<DeviceAlarmRecordDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
