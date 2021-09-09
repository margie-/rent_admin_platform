using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 订单列表输入参数
    /// </summary>
    public class RentOrderInfoInput : PageInputBase
    {
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
        /// 电池编号
        /// </summary>
        public virtual string BatteryNo { get; set; }
        
        /// <summary>
        /// 电池类型
        /// </summary>
        public virtual string BatteryType { get; set; }
        
        /// <summary>
        /// 租赁价格
        /// </summary>
        public virtual string RentPrice { get; set; }
        
        /// <summary>
        /// 租赁时长
        /// </summary>
        public virtual string RentTime { get; set; }
        
        /// <summary>
        /// 租赁金额
        /// </summary>
        public virtual string RentAmount { get; set; }
        
        /// <summary>
        /// 应付金额
        /// </summary>
        public virtual string PRAmmount { get; set; }
        
        /// <summary>
        /// 实收金额
        /// </summary>
        public virtual string ARAmount { get; set; }
        
        /// <summary>
        /// 租赁用户
        /// </summary>
        public virtual string RentUser { get; set; }
        
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public virtual string OrderCreateDtime { get; set; }
        
        /// <summary>
        /// 付款时间
        /// </summary>
        public virtual string PayDtime { get; set; }
        
        /// <summary>
        /// 设备解绑时间
        /// </summary>
        public virtual string DisAssignDtime { get; set; }
        
        /// <summary>
        /// 支付端设备
        /// </summary>
        public virtual string PayDevice { get; set; }
        
        /// <summary>
        /// 支付类型
        /// </summary>
        public virtual string PayType { get; set; }
        
        /// <summary>
        /// 支付状态
        /// </summary>
        public virtual string PayStatus { get; set; }
        
        /// <summary>
        /// 分佣状态
        /// </summary>
        public virtual string SubCommissionStatus { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddRentOrderInfoInput : RentOrderInfoInput
    {
    }

    public class DeleteRentOrderInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateRentOrderInfoInput : RentOrderInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeRentOrderInfoInput : DeleteRentOrderInfoInput
    {

    }
}
