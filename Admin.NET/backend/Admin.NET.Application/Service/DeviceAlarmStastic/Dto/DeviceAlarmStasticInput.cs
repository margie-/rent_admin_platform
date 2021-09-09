using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 报警统计日报表输入参数
    /// </summary>
    public class DeviceAlarmStasticInput : PageInputBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 设备名称
        /// </summary>
        public virtual string DeviceName { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual string OwnedOrg { get; set; }
        
        /// <summary>
        /// 报表日期
        /// </summary>
        public virtual string reportDate { get; set; }
        
        /// <summary>
        /// 出围栏报警
        /// </summary>
        public virtual string alarm1 { get; set; }
        
        /// <summary>
        /// 入围栏报警
        /// </summary>
        public virtual string alarm2 { get; set; }
        
        /// <summary>
        /// 断电报警
        /// </summary>
        public virtual string alarm3 { get; set; }
        
        /// <summary>
        /// 低电报警
        /// </summary>
        public virtual string alarm4 { get; set; }
        
        /// <summary>
        /// 震动报警
        /// </summary>
        public virtual string alarm5 { get; set; }
        
        /// <summary>
        /// 位移报警
        /// </summary>
        public virtual string alarm6 { get; set; }
        
        /// <summary>
        /// 点火报警
        /// </summary>
        public virtual string alarm7 { get; set; }
        
        /// <summary>
        /// 侧翻报警
        /// </summary>
        public virtual string alarm8 { get; set; }
        
        /// <summary>
        /// 拆卸报警
        /// </summary>
        public virtual string alarm9 { get; set; }
        
        /// <summary>
        /// 其他报警
        /// </summary>
        public virtual string alarm10 { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddDeviceAlarmStasticInput : DeviceAlarmStasticInput
    {
    }

    public class DeleteDeviceAlarmStasticInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateDeviceAlarmStasticInput : DeviceAlarmStasticInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeDeviceAlarmStasticInput : DeleteDeviceAlarmStasticInput
    {

    }
}
