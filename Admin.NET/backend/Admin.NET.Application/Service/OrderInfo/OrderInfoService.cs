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
    /// 续费记录服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "OrderInfo", Order = 100)]
    public class OrderInfoService : IOrderInfoService, IDynamicApiController, ITransient
    {
        private readonly IRepository<OrderInfo> _rep;

        public OrderInfoService(
            IRepository<OrderInfo> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询续费记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/OrderInfo/page")]
        public async Task<dynamic> Page([FromQuery] OrderInfoInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.OrderNo), u => u.OrderNo == input.OrderNo)
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.vendor), u => u.vendor == input.vendor)
                                     .Where(!string.IsNullOrEmpty(input.User), u => u.User == input.User)
                                     .OrderBy(PageInputOrder.OrderBuilder<OrderInfoInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<OrderInfo>.PageResult<OrderInfoDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加续费记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/OrderInfo/add")]
        public async Task Add(AddOrderInfoInput input)
        {
            var entity = input.Adapt<OrderInfo>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除续费记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/OrderInfo/delete")]
        public async Task Delete(DeleteOrderInfoInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新续费记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/OrderInfo/edit")]
        public async Task Update(UpdateOrderInfoInput input)
        {
            var entity = input.Adapt<OrderInfo>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取续费记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/OrderInfo/detail")]
        public async Task<OrderInfo> Get([FromQuery] QueryeOrderInfoInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取续费记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/OrderInfo/list")]
        public async Task<dynamic> List([FromQuery] OrderInfoInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<OrderInfoDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
