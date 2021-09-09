using System;
using Furion.Extras.Admin.NET;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备信息输出参数
    /// </summary>
    public class DeviceInfoDto
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public virtual string DeviceName { get; set; }
        
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>
        public virtual string DeviceType { get; set; }
        
        /// <summary>
        /// 型号
        /// </summary>
        public virtual string DModel { get; set; }
        
        /// <summary>
        /// 电压
        /// </summary>
        public virtual string Voltage { get; set; }
        
        /// <summary>
        /// 电流
        /// </summary>
        public virtual string Electricity { get; set; }
        
        /// <summary>
        /// 电芯
        /// </summary>
        public virtual string BatteryType { get; set; }
        
        /// <summary>
        /// ICCD
        /// </summary>
        public string ICCID { get; set; }
        
        /// <summary>
        /// 版本
        /// </summary>
        public virtual string FWVersion { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual string OwnedOrg { get; set; }

        /// <summary>
        /// 所属门店名称
        /// </summary>
        public virtual string OwnedOrgName { get; set; }
        
        /// <summary>
        /// 设备状态
        /// </summary>
        public virtual string DeviceStatus { get; set; }
        
        /// <summary>
        /// 制造日期
        /// </summary>
        public virtual string ManufactureDate { get; set; }
        
        /// <summary>
        /// 最后定位日期
        /// </summary>
        public virtual string LastLoationDtime { get; set; }
        
        /// <summary>
        /// 蓝牙ID
        /// </summary>
        public virtual string BlueToothID { get; set; }
        
        /// <summary>
        /// 激活时间
        /// </summary>
        public virtual string ActiveDtime { get; set; }
        
        /// <summary>
        /// 过期时间
        /// </summary>
        public virtual string ExpiredDtime { get; set; }
        
        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo { get; set; }
        
        /// <summary>
        /// 车主姓名
        /// </summary>
        public virtual string CarOwerName { get; set; }
        
        /// <summary>
        /// 电话
        /// </summary>
        public virtual string CarOwnerPhone { get; set; }
        
        /// <summary>
        /// 图标
        /// </summary>
        public virtual string IconId { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long? TenantId { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public virtual long Id { get; set; }
        
    }
}
