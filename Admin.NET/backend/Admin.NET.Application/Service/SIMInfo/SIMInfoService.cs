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
    /// SIM信息服务
    /// </summary>
    [ApiDescriptionSettings("SIM信息", Name = "SIMInfo", Order = 100)]
    public class SIMInfoService : ISIMInfoService, IDynamicApiController, ITransient
    {
        private readonly IRepository<SIMInfo> _rep;

        public SIMInfoService(
            IRepository<SIMInfo> rep
        )
        {
            _rep = rep;
        }

        /// <summary>
        /// 分页查询SIM信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/SIMInfo/page")]
        public async Task<dynamic> Page([FromQuery] SIMInfoInput input)
        {
            var device = Db.GetRepository<DeviceInfo>();
            var entities = await _rep.DetachedEntities
                                     .Join(device.DetachedEntities ,u=>u.DeviceNo ,d=>d.DeviceNo,(u,d)=>new SIMInfoDto() {
                                     DeviceNo = u.DeviceNo,
                                         SimType = u.SimType,
                                         CardNo = u.CardNo,
                                         ICCID = u.ICCID,
                                         SimStatus = u.SimStatus,
                                         ActivationDtime = u.ActivationDtime,
                                         ExpiredDtime = u.ExpiredDtime,
                                         AnnualFee = u.AnnualFee,
                                         Note = u.Note,
                                         TenantId = u.TenantId,
                                        OwnedOrg = d.OwnedOrg })
                                     .Where(!string.IsNullOrEmpty(input.OwnedOrg) && input.OwnedOrg != "0", u=>u.OwnedOrg == long.Parse(input.OwnedOrg))
                                     .Where(!string.IsNullOrEmpty(input.DeviceNo), u => u.DeviceNo == input.DeviceNo)
                                     .Where(!string.IsNullOrEmpty(input.SimType), u => u.SimType == input.SimType)
                                     .Where(!string.IsNullOrEmpty(input.SimStatus), u => u.SimStatus == input.SimStatus)
                                     .Select(u => u.Adapt<SIMInfoDto>())
                                     .ToPagedListAsync(input.PageNo, input.PageSize);
            var result = XnPageResult<SIMInfoDto>.PageResult<SIMInfoDto>(entities);
            await DtoMapper(result.Rows);
            return result;
        }

        /// <summary>
        /// 增加SIM信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/SIMInfo/add")]
        public async Task Add(AddSIMInfoInput input)
        {
            var entity = input.Adapt<SIMInfo>();
            await entity.InsertAsync();
        }

        /// <summary>
        /// 删除SIM信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/SIMInfo/delete")]
        public async Task Delete(DeleteSIMInfoInput input)
        {
            var entity = await _rep.FirstOrDefaultAsync(u => u.Id == input.Id);
            await entity.DeleteAsync();
        }

        /// <summary>
        /// 更新SIM信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("/SIMInfo/edit")]
        public async Task Update(UpdateSIMInfoInput input)
        {
            var entity = input.Adapt<SIMInfo>();
            await entity.UpdateAsync(true);
        }

        /// <summary>
        /// 获取SIM信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/SIMInfo/detail")]
        public async Task<SIMInfo> Get([FromQuery] QueryeSIMInfoInput input)
        {
            return await _rep.DetachedEntities.FirstOrDefaultAsync(u => u.Id == input.Id);
        }

        /// <summary>
        /// 获取SIM信息列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("/SIMInfo/list")]
        public async Task<dynamic> List([FromQuery] SIMInfoInput input)
        {
            return await _rep.DetachedEntities.ToListAsync();
        }    

        private async Task DtoMapper(ICollection<SIMInfoDto> rows)
        {
            foreach (var item in rows)
            {
            }
        }

        public async Task<SIMInfo> GetSimInfoByDeviceNO(string  deviceno)
        {
            return  await _rep.FirstOrDefaultAsync(u => u.DeviceNo == deviceno);
        }
    }
}
