using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备信息输出参数
    /// </summary>
    public class DeviceInfoOutput
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public string DeviceType { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public string DModel { get; set; }
        
        /// <summary>
        /// 电压
        /// </summary>
        public string Voltage { get; set; }
        
        /// <summary>
        /// 电流
        /// </summary>
        public string Electricity { get; set; }
        
        /// <summary>
        /// 电芯
        /// </summary>
        public string BatteryType { get; set; }
        
        /// <summary>
        /// ICCD
        /// </summary>
        public string ICCID { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        public string FWVersion { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public string OwnedOrg { get; set; }
        
        /// <summary>
        /// 设备状态
        /// </summary>
        public string DeviceStatus { get; set; }
        
        /// <summary>
        /// 制造日期
        /// </summary>
        public string ManufactureDate { get; set; }
        
        /// <summary>
        /// 最后定位日期
        /// </summary>
        public string LastLoationDtime { get; set; }
        
        /// <summary>
        /// 蓝牙ID
        /// </summary>
        public string BlueToothID { get; set; }
        
        /// <summary>
        /// 激活时间
        /// </summary>
        public string ActiveDtime { get; set; }
        
        /// <summary>
        /// 过期时间
        /// </summary>
        public string ExpiredDtime { get; set; }
        
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNo { get; set; }
        
        /// <summary>
        /// 车主姓名
        /// </summary>
        public string CarOwerName { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        public string CarOwnerPhone { get; set; }
        
        /// <summary>
        /// 图标
        /// </summary>
        public string IconId { get; set; }
        
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
