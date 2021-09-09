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
    /// 围栏报警统计服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "FenceStatics", Order = 100)]
    public class FenceStaticsService : IFenceStaticsService, IDynamicApiController, ITransient
    {
        private readonly IRepository<FenceStatics> _rep;

        public FenceStaticsService(
            IRepository<FenceStatics> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询围栏报警统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/FenceStatics/page")]
        public async Task<dynamic> Page([FromQuery] FenceStaticsInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.OwnedCus), u => u.OwnedCus == input.OwnedCus)
                                     .Where(!string.IsNullOrEmpty(input.FenceType), u => u.FenceType == input.FenceType)
                                     .OrderBy(PageInputOrder.OrderBuilder<FenceStaticsInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<FenceStatics>.PageResult<FenceStaticsDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加围栏报警统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/FenceStatics/add")]
        public async Task Add(AddFenceStaticsInput input)
        {
            var entity = input.Adapt<FenceStatics>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除围栏报警统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/FenceStatics/delete")]
        public async Task Delete(DeleteFenceStaticsInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新围栏报警统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/FenceStatics/edit")]
        public async Task Update(UpdateFenceStaticsInput input)
        {
            var entity = input.Adapt<FenceStatics>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取围栏报警统计
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/FenceStatics/detail")]
        public async Task<FenceStatics> Get([FromQuery] QueryeFenceStaticsInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取围栏报警统计列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/FenceStatics/list")]
        public async Task<dynamic> List([FromQuery] FenceStaticsInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<FenceStaticsDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
