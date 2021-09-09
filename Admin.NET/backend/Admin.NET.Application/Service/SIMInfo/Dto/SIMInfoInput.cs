using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// SIM信息输入参数
    /// </summary>
    public class SIMInfoInput : PageInputBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// Sim卡类型
        /// </summary>
        public virtual string SimType { get; set; }
        
        /// <summary>
        /// 卡号
        /// </summary>
        public virtual string CardNo { get; set; }
        
        /// <summary>
        /// ICCID
        /// </summary>
        public virtual string ICCID { get; set; }
        
        /// <summary>
        /// 卡状态
        /// </summary>
        public virtual string SimStatus { get; set; }
        
        /// <summary>
        /// 激活时间
        /// </summary>
        public virtual string ActivationDtime { get; set; }
        
        /// <summary>
        /// 过期时间
        /// </summary>
        public virtual string ExpiredDtime { get; set; }
        
        /// <summary>
        /// 年费
        /// </summary>
        public virtual string AnnualFee { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long? TenantId { get; set; }

        public virtual string OwnedOrg { get; set; }
        
    }

    public class AddSIMInfoInput : SIMInfoInput
    {
    }

    public class DeleteSIMInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateSIMInfoInput : SIMInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeSIMInfoInput : DeleteSIMInfoInput
    {

    }
}
