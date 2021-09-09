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
    /// 合同管理服务
    /// </summary>
    [ApiDescriptionSettings("自己的业务", Name = "ContractList", Order = 100)]
    public class ContractListService : IContractListService, IDynamicApiController, ITransient
    {
        private readonly IRepository<ContractList> _rep;

        public ContractListService(
            IRepository<ContractList> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询合同管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ContractList/page")]
        public async Task<dynamic> Page([FromQuery] ContractListInput input)
        {
            var entities = await _rep.DetachedEntities
                                     .Where(!string.IsNullOrEmpty(input.ContractName), u => u.ContractName == input.ContractName)
                                     .Where(!string.IsNullOrEmpty(input.ContractDetails), u => u.ContractDetails == input.ContractDetails)
                                     .OrderBy(PageInputOrder.OrderBuilder<ContractListInput>(input))
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<ContractList>.PageResult<ContractListDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加合同管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ContractList/add")]
        public async Task Add(AddContractListInput input)
        {
            var entity = input.Adapt<ContractList>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除合同管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ContractList/delete")]
        public async Task Delete(DeleteContractListInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新合同管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/ContractList/edit")]
        public async Task Update(UpdateContractListInput input)
        {
            var entity = input.Adapt<ContractList>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取合同管理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ContractList/detail")]
        public async Task<ContractList> Get([FromQuery] QueryeContractListInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取合同管理列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/ContractList/list")]
        public async Task<dynamic> List([FromQuery] ContractListInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<ContractListDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }
    }
}
