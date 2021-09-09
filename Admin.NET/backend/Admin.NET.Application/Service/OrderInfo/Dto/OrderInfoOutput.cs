using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 续费记录输出参数
    /// </summary>
    public class OrderInfoOutput
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }
        
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 商家
        /// </summary>
        public string vendor { get; set; }
        
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
        
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardId { get; set; }
        
        /// <summary>
        /// ICCID
        /// </summary>
        public string ICCID { get; set; }
        
        /// <summary>
        /// 付款账户
        /// </summary>
        public string PayAccount { get; set; }
        
        /// <summary>
        /// 金额
        /// </summary>
        public string PayAmount { get; set; }
        
        /// <summary>
        /// 发生时间
        /// </summary>
        public string PayDtime { get; set; }
        
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
