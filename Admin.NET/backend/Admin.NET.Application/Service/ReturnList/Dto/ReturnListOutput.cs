using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备退押记录输出参数
    /// </summary>
    public class ReturnListOutput
    {
        /// <summary>
        /// 退款单号
        /// </summary>
        public string returnNo { get; set; }
        
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
        /// 电芯类型
        /// </summary>
        public string BatteryType { get; set; }
        
        /// <summary>
        /// 租赁用户
        /// </summary>
        public string RentUser { get; set; }
        
        /// <summary>
        /// 押金金额
        /// </summary>
        public string DepositAmount { get; set; }
        
        /// <summary>
        /// 退款金额
        /// </summary>
        public string ReturnAmount { get; set; }
        
        /// <summary>
        /// 退款原因
        /// </summary>
        public string ReturnReason { get; set; }
        
        /// <summary>
        /// 退款类型
        /// </summary>
        public string ReturnType { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public string ReturnCreateDtime { get; set; }
        
        /// <summary>
        /// 审核时间
        /// </summary>
        public string AuditDtime { get; set; }
        
        /// <summary>
        /// 到账时间
        /// </summary>
        public string AccountDtime { get; set; }
        
        /// <summary>
        /// 退款状态
        /// </summary>
        public string ReturnStatus { get; set; }
        
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
