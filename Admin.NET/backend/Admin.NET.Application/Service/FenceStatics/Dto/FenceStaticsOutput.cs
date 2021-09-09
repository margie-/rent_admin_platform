using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 围栏报警统计输出参数
    /// </summary>
    public class FenceStaticsOutput
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        
        /// <summary>
        /// 所属客户
        /// </summary>
        public string OwnedCus { get; set; }
        
        /// <summary>
        /// 围栏名称
        /// </summary>
        public string FenceName { get; set; }
        
        /// <summary>
        /// 围栏类型
        /// </summary>
        public string FenceType { get; set; }
        
        /// <summary>
        /// 速度(km/h)
        /// </summary>
        public string Speed { get; set; }
        
        /// <summary>
        /// 定位时间
        /// </summary>
        public string LocationDtime { get; set; }
        
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
