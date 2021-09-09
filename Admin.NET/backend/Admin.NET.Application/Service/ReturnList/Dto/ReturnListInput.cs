using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备退押记录输入参数
    /// </summary>
    public class ReturnListInput : PageInputBase
    {
        /// <summary>
        /// 退款单号
        /// </summary>
        public virtual string returnNo { get; set; }
        
        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string OrderNo { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual string OwnedOrg { get; set; }
        
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 电芯类型
        /// </summary>
        public virtual string BatteryType { get; set; }
        
        /// <summary>
        /// 租赁用户
        /// </summary>
        public virtual string RentUser { get; set; }
        
        /// <summary>
        /// 押金金额
        /// </summary>
        public virtual string DepositAmount { get; set; }
        
        /// <summary>
        /// 退款金额
        /// </summary>
        public virtual string ReturnAmount { get; set; }
        
        /// <summary>
        /// 退款原因
        /// </summary>
        public virtual string ReturnReason { get; set; }
        
        /// <summary>
        /// 退款类型
        /// </summary>
        public virtual string ReturnType { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual string ReturnCreateDtime { get; set; }
        
        /// <summary>
        /// 审核时间
        /// </summary>
        public virtual string AuditDtime { get; set; }
        
        /// <summary>
        /// 到账时间
        /// </summary>
        public virtual string AccountDtime { get; set; }
        
        /// <summary>
        /// 退款状态
        /// </summary>
        public virtual string ReturnStatus { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddReturnListInput : ReturnListInput
    {
    }

    public class DeleteReturnListInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateReturnListInput : ReturnListInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeReturnListInput : DeleteReturnListInput
    {

    }
}
