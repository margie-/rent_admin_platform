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
    /// 订单列表服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "RentOrderInfo", Order = 100)]
    public class RentOrderInfoService : IRentOrderInfoService, IDynamicApiController, ITransient
    {
        private readonly IRepository<RentOrderInfo> _rep;

        public RentOrderInfoService(
            IRepository<RentOrderInfo> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询订单列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/RentOrderInfo/page")]
        public async Task<dynamic> Page([FromQuery] RentOrderInfoInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.OrderNo), u => u.OrderNo == input.OrderNo)
                                     .Where(!string.IsNullOrEmpty(input.OwnedOrg), u => u.OwnedOrg == input.OwnedOrg)
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.RentUser), u => u.RentUser == input.RentUser)
                                     .Where(!string.IsNullOrEmpty(input.OrderCreateDtime), u => u.OrderCreateDtime == input.OrderCreateDtime)
                                     .Where(!string.IsNullOrEmpty(input.PayType), u => u.PayType == input.PayType)
                                     .Where(!string.IsNullOrEmpty(input.PayStatus), u => u.PayStatus == input.PayStatus)
                                     .Where(!string.IsNullOrEmpty(input.SubCommissionStatus), u => u.SubCommissionStatus == input.SubCommissionStatus)
                                     .OrderBy(PageInputOrder.OrderBuilder<RentOrderInfoInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<RentOrderInfo>.PageResult<RentOrderInfoDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加订单列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/RentOrderInfo/add")]
        public async Task Add(AddRentOrderInfoInput input)
        {
            var entity = input.Adapt<RentOrderInfo>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除订单列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/RentOrderInfo/delete")]
        public async Task Delete(DeleteRentOrderInfoInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新订单列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/RentOrderInfo/edit")]
        public async Task Update(UpdateRentOrderInfoInput input)
        {
            var entity = input.Adapt<RentOrderInfo>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/RentOrderInfo/detail")]
        public async Task<RentOrderInfo> Get([FromQuery] QueryeRentOrderInfoInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取订单列表列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/RentOrderInfo/list")]
        public async Task<dynamic> List([FromQuery] RentOrderInfoInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<RentOrderInfoDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
