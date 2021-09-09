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
    /// 换电记录服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "ChangeBatteryRecord", Order = 100)]
    public class ChangeBatteryRecordService : IChangeBatteryRecordService, IDynamicApiController, ITransient
    {
        private readonly IRepository<ChangeBatteryRecord> _rep;

        public ChangeBatteryRecordService(
            IRepository<ChangeBatteryRecord> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询换电记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ChangeBatteryRecord/page")]
        public async Task<dynamic> Page([FromQuery] ChangeBatteryRecordInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.OrderNo), u => u.OrderNo == input.OrderNo)
                                     .Where(!string.IsNullOrEmpty(input.RentUser), u => u.RentUser == input.RentUser)
                                     .Where(!string.IsNullOrEmpty(input.NewDeviceNo), u => u.NewDeviceNo == input.NewDeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.NewOrg), u => u.NewOrg == input.NewOrg)
                                     .Where(!string.IsNullOrEmpty(input.ChangeDtime), u => u.ChangeDtime == input.ChangeDtime)
                                     .OrderBy(PageInputOrder.OrderBuilder<ChangeBatteryRecordInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<ChangeBatteryRecord>.PageResult<ChangeBatteryRecordDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加换电记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ChangeBatteryRecord/add")]
        public async Task Add(AddChangeBatteryRecordInput input)
        {
            var entity = input.Adapt<ChangeBatteryRecord>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除换电记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ChangeBatteryRecord/delete")]
        public async Task Delete(DeleteChangeBatteryRecordInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新换电记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ChangeBatteryRecord/edit")]
        public async Task Update(UpdateChangeBatteryRecordInput input)
        {
            var entity = input.Adapt<ChangeBatteryRecord>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取换电记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ChangeBatteryRecord/detail")]
        public async Task<ChangeBatteryRecord> Get([FromQuery] QueryeChangeBatteryRecordInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取换电记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ChangeBatteryRecord/list")]
        public async Task<dynamic> List([FromQuery] ChangeBatteryRecordInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<ChangeBatteryRecordDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
