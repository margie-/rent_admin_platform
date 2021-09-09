using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 订单列表输出参数
    /// </summary>
    public class RentOrderInfoOutput
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public string OwnedOrg { get; set; }
        
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 电池编号
        /// </summary>
        public string BatteryNo { get; set; }
        
        /// <summary>
        /// 电池类型
        /// </summary>
        public string BatteryType { get; set; }
        
        /// <summary>
        /// 租赁价格
        /// </summary>
        public string RentPrice { get; set; }
        
        /// <summary>
        /// 租赁时长
        /// </summary>
        public string RentTime { get; set; }
        
        /// <summary>
        /// 租赁金额
        /// </summary>
        public string RentAmount { get; set; }
        
        /// <summary>
        /// 应付金额
        /// </summary>
        public string PRAmmount { get; set; }
        
        /// <summary>
        /// 实收金额
        /// </summary>
        public string ARAmount { get; set; }
        
        /// <summary>
        /// 租赁用户
        /// </summary>
        public string RentUser { get; set; }
        
        /// <summary>
        /// 订单创建时间
        /// </summary>
        public string OrderCreateDtime { get; set; }
        
        /// <summary>
        /// 付款时间
        /// </summary>
        public string PayDtime { get; set; }
        
        /// <summary>
        /// 设备解绑时间
        /// </summary>
        public string DisAssignDtime { get; set; }
        
        /// <summary>
        /// 支付端设备
        /// </summary>
        public string PayDevice { get; set; }
        
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType { get; set; }
        
        /// <summary>
        /// 支付状态
        /// </summary>
        public string PayStatus { get; set; }
        
        /// <summary>
        /// 分佣状态
        /// </summary>
        public string SubCommissionStatus { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public long TenantId { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public long Id { get; set; }
        
    }
}
