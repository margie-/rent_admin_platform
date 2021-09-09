using System;
using Furion.Extras.Admin.NET;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备警报输出参数
    /// </summary>
    public class DeviceAlarmRecordDto
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 报警时间
        /// </summary>
        public string AlertDtime { get; set; }
        
        /// <summary>
        /// 报警日期
        /// </summary>
        public string AlertDate { get; set; }
        
        /// <summary>
        /// 报警位置X
        /// </summary>
        public string AlertPosition_x { get; set; }
        
        /// <summary>
        /// 报警位置Y
        /// </summary>
        public string AlertPosition_y { get; set; }
        
        /// <summary>
        /// 报警位置
        /// </summary>
        public string AlertPosition { get; set; }
        
        /// <summary>
        /// 报警类型
        /// </summary>
        public string AlertType { get; set; }
        
        /// <summary>
        /// 报警信息
        /// </summary>
        public string AlertInfo { get; set; }
        
        /// <summary>
        /// 当前速度
        /// </summary>
        public string CurSpeed { get; set; }
        
        /// <summary>
        /// 报警状态
        /// </summary>
        public string AlterStatus { get; set; }
        
        /// <summary>
        /// 是否处理
        /// </summary>
        public string isHandled { get; set; }
        
        /// <summary>
        /// 处理信息
        /// </summary>
        public string HandleInfo { get; set; }
        
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
