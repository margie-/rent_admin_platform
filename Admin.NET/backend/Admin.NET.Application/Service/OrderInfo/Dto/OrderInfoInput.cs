using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 续费记录输入参数
    /// </summary>
    public class OrderInfoInput : PageInputBase
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public virtual string OrderNo { get; set; }
        
        /// <summary>
        /// 订单类型
        /// </summary>
        public virtual string OrderType { get; set; }
        
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 商家
        /// </summary>
        public virtual string vendor { get; set; }
        
        /// <summary>
        /// 用户
        /// </summary>
        public virtual string User { get; set; }
        
        /// <summary>
        /// 卡号
        /// </summary>
        public virtual string CardId { get; set; }
        
        /// <summary>
        /// ICCID
        /// </summary>
        public virtual string ICCID { get; set; }
        
        /// <summary>
        /// 付款账户
        /// </summary>
        public virtual string PayAccount { get; set; }
        
        /// <summary>
        /// 金额
        /// </summary>
        public virtual string PayAmount { get; set; }
        
        /// <summary>
        /// 发生时间
        /// </summary>
        public virtual string PayDtime { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddOrderInfoInput : OrderInfoInput
    {
    }

    public class DeleteOrderInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateOrderInfoInput : OrderInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeOrderInfoInput : DeleteOrderInfoInput
    {

    }
}
