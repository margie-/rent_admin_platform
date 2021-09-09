using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// SIM信息输出参数
    /// </summary>
    public class SIMInfoOutput
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// Sim卡类型
        /// </summary>
        public string SimType { get; set; }
        
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }
        
        /// <summary>
        /// ICCID
        /// </summary>
        public string ICCID { get; set; }
        
        /// <summary>
        /// 卡状态
        /// </summary>
        public string SimStatus { get; set; }
        
        /// <summary>
        /// 激活时间
        /// </summary>
        public string ActivationDtime { get; set; }
        
        /// <summary>
        /// 过期时间
        /// </summary>
        public string ExpiredDtime { get; set; }
        
        /// <summary>
        /// 年费
        /// </summary>
        public string AnnualFee { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }
        
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
