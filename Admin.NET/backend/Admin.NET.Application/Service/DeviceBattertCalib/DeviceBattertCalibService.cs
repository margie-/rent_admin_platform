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
    [ApiDescriptionSettings("自己的业务", Name = "DeviceBattertCalib", Order = 100)]
    public class DeviceBattertCalibService : IDeviceBattertCalibService, IDynamicApiController, ITransient
    {
        private readonly IRepository<DeviceBattertCalib> _rep;

        public DeviceBattertCalibService(
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
        [HttpGet("/DeviceBattertCalib/page")]
        public async Task<dynamic> Page([FromQuery] DeviceBattertCalibInput input)
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
                                     .OrderBy(PageInputOrder.OrderBuilder<DeviceBattertCalibInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<DeviceBattertCalib>.PageResult<DeviceBattertCalibDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceBattertCalib/add")]
        public async Task Add(AddDeviceBattertCalibInput input)
        {
            var entity = input.Adapt<DeviceBattertCalib>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceBattertCalib/delete")]
        public async Task Delete(DeleteDeviceBattertCalibInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/DeviceBattertCalib/edit")]
        public async Task Update(UpdateDeviceBattertCalibInput input)
        {
            var entity = input.Adapt<DeviceBattertCalib>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取设备电池校准信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceBattertCalib/detail")]
        public async Task<DeviceBattertCalib> Get([FromQuery] QueryeDeviceBattertCalibInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取设备电池校准信息列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/DeviceBattertCalib/list")]
        public async Task<dynamic> List([FromQuery] DeviceBattertCalibInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<DeviceBattertCalibDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }

        /// <summary>
        /// 通过编号获取电量校准信息
        /// </summary>
        /// <param name="deviceNo"></param>
        /// <returns></returns>
        [HttpPost("/DeviceBattertCalib/getfromdevice")]
        public async Task<List<DeviceBattertCalib>> GetFromDeviceNo(string deviceNo)
        {
            return await _rep.Where(u => u.DeviceNo == deviceNo).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceNo"></param>
        /// <returns></returns>
        [HttpPost("/DeviceBattertCalib/deletefromdevice")]
        public  async Task DeleteByDevice(string deviceNo)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.DeviceNo == deviceNo);
            if(entity != null)
            {
                await entity.DeleteAsync();
            }
        }
    }
}
