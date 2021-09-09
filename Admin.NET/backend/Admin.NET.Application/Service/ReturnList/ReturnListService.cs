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
    /// 设备退押记录服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "ReturnList", Order = 100)]
    public class ReturnListService : IReturnListService, IDynamicApiController, ITransient
    {
        private readonly IRepository<ReturnList> _rep;

        public ReturnListService(
            IRepository<ReturnList> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询设备退押记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ReturnList/page")]
        public async Task<dynamic> Page([FromQuery] ReturnListInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.returnNo), u => u.returnNo == input.returnNo)
                                     .Where(!string.IsNullOrEmpty(input.OrderNo), u => u.OrderNo == input.OrderNo)
                                     .Where(!string.IsNullOrEmpty(input.OwnedOrg), u => u.OwnedOrg == input.OwnedOrg)
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.RentUser), u => u.RentUser == input.RentUser)
                                     .Where(!string.IsNullOrEmpty(input.ReturnReason), u => u.ReturnReason == input.ReturnReason)
                                     .Where(!string.IsNullOrEmpty(input.ReturnType), u => u.ReturnType == input.ReturnType)
                                     .Where(!string.IsNullOrEmpty(input.ReturnCreateDtime), u => u.ReturnCreateDtime == input.ReturnCreateDtime)
                                     .Where(!string.IsNullOrEmpty(input.AccountDtime), u => u.AccountDtime == input.AccountDtime)
                                     .Where(!string.IsNullOrEmpty(input.ReturnStatus), u => u.ReturnStatus == input.ReturnStatus)
                                     .OrderBy(PageInputOrder.OrderBuilder<ReturnListInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<ReturnList>.PageResult<ReturnListDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加设备退押记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ReturnList/add")]
        public async Task Add(AddReturnListInput input)
        {
            var entity = input.Adapt<ReturnList>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除设备退押记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ReturnList/delete")]
        public async Task Delete(DeleteReturnListInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新设备退押记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ReturnList/edit")]
        public async Task Update(UpdateReturnListInput input)
        {
            var entity = input.Adapt<ReturnList>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取设备退押记录
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ReturnList/detail")]
        public async Task<ReturnList> Get([FromQuery] QueryeReturnListInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取设备退押记录列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ReturnList/list")]
        public async Task<dynamic> List([FromQuery] ReturnListInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<ReturnListDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
