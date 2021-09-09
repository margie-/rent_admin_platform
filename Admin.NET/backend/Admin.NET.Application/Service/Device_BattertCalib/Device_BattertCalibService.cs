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
    /// 设备电池校准信息服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "Device_BattertCalib", Order = 100)]
    public class Device_BattertCalibService : IDevice_BattertCalibService, IDynamicApiController, ITransient
    {
        private readonly IRepository<DeviceBattertCalib> _rep;

        public Device_BattertCalibService(
            IRepository<DeviceBattertCalib> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Device_BattertCalib/page")]
        public async Task<dynamic> Page([FromQuery] Device_BattertCalibInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.BatterySeries), u => u.BatterySeries == input.BatterySeries)
                                     .Where(!string.IsNullOrEmpty(input.ElectronicPer_s), u => u.ElectronicPer_s == input.ElectronicPer_s)
                                     .Where(!string.IsNullOrEmpty(input.ElectronicVol_s), u => u.ElectronicVol_s == input.ElectronicVol_s)
                                     .Where(!string.IsNullOrEmpty(input.ElectronicVol_2), u => u.ElectronicVol_2 == input.ElectronicVol_2)
                                     .Where(!string.IsNullOrEmpty(input.BattertRemark), u => u.BattertRemark == input.BattertRemark)
                                     .Where(!string.IsNullOrEmpty(input.InfoSourceType), u => u.InfoSourceType == input.InfoSourceType)
                                     .Where(u => u.TenantId == input.TenantId)
                                     .OrderBy(PageInputOrder.OrderBuilder<Device_BattertCalibInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<DeviceBattertCalib>.PageResult<Device_BattertCalibDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Device_BattertCalib/add")]
        public async Task Add(AddDevice_BattertCalibInput input)
        {
            var entity = input.Adapt<DeviceBattertCalib>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Device_BattertCalib/delete")]
        public async Task Delete(DeleteDevice_BattertCalibInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/Device_BattertCalib/edit")]
        public async Task Update(UpdateDevice_BattertCalibInput input)
        {
            var entity = input.Adapt<DeviceBattertCalib>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Device_BattertCalib/detail")]
        public async Task<DeviceBattertCalib> Get([FromQuery] QueryeDevice_BattertCalibInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取设备电池校准信息列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/Device_BattertCalib/list")]
        public async Task<dynamic> List([FromQuery] Device_BattertCalibInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<Device_BattertCalibDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
