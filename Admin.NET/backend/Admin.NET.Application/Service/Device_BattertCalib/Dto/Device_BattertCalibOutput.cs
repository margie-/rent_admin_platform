using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备电池校准信息输出参数
    /// </summary>
    public class Device_BattertCalibOutput
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 电池串号
        /// </summary>
        public string BatterySeries { get; set; }
        
        /// <summary>
        /// 占百分比
        /// </summary>
        public string ElectronicPer_s { get; set; }
        
        /// <summary>
        /// 电压数值
        /// </summary>
        public string ElectronicVol_s { get; set; }
        
        /// <summary>
        /// 电压数值2
        /// </summary>
        public string ElectronicVol_2 { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string BattertRemark { get; set; }
        
        /// <summary>
        /// 信息来源类型
        /// </summary>
        public string InfoSourceType { get; set; }
        
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
