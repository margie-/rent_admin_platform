using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 围栏报警统计输入参数
    /// </summary>
    public class FenceStaticsInput : PageInputBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 设备名称
        /// </summary>
        public virtual string DeviceName { get; set; }
        
        /// <summary>
        /// 所属客户
        /// </summary>
        public virtual string OwnedCus { get; set; }
        
        /// <summary>
        /// 围栏名称
        /// </summary>
        public virtual string FenceName { get; set; }
        
        /// <summary>
        /// 围栏类型
        /// </summary>
        public virtual string FenceType { get; set; }
        
        /// <summary>
        /// 速度(km/h)
        /// </summary>
        public virtual string Speed { get; set; }
        
        /// <summary>
        /// 定位时间
        /// </summary>
        public virtual string LocationDtime { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddFenceStaticsInput : FenceStaticsInput
    {
    }

    public class DeleteFenceStaticsInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateFenceStaticsInput : FenceStaticsInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeFenceStaticsInput : DeleteFenceStaticsInput
    {

    }
}
