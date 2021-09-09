using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备警报输入参数
    /// </summary>
    public class DeviceAlarmRecordInput : PageInputBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 报警时间
        /// </summary>
        public virtual string AlertDtime { get; set; }
        
        /// <summary>
        /// 报警日期
        /// </summary>
        public virtual string AlertDate { get; set; }
        
        /// <summary>
        /// 报警位置X
        /// </summary>
        public virtual string AlertPosition_x { get; set; }
        
        /// <summary>
        /// 报警位置Y
        /// </summary>
        public virtual string AlertPosition_y { get; set; }
        
        /// <summary>
        /// 报警位置
        /// </summary>
        public virtual string AlertPosition { get; set; }
        
        /// <summary>
        /// 报警类型
        /// </summary>
        public virtual string AlertType { get; set; }
        
        /// <summary>
        /// 报警信息
        /// </summary>
        public virtual string AlertInfo { get; set; }
        
        /// <summary>
        /// 当前速度
        /// </summary>
        public virtual string CurSpeed { get; set; }
        
        /// <summary>
        /// 报警状态
        /// </summary>
        public virtual string AlterStatus { get; set; }
        
        /// <summary>
        /// 是否处理
        /// </summary>
        public virtual string isHandled { get; set; }
        
        /// <summary>
        /// 处理信息
        /// </summary>
        public virtual string HandleInfo { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddDeviceAlarmRecordInput : DeviceAlarmRecordInput
    {
    }

    public class DeleteDeviceAlarmRecordInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateDeviceAlarmRecordInput : DeviceAlarmRecordInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeDeviceAlarmRecordInput : DeleteDeviceAlarmRecordInput
    {

    }
}
