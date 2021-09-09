using System;
using Furion.Extras.Admin.NET;

namespace Admin.NET.Application
{
    /// <summary>
    /// 里程统计输出参数
    /// </summary>
    public class MileStatisticsDto
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 统计日期
        /// </summary>
        public string Sdate { get; set; }
        
        /// <summary>
        /// 日里程数
        /// </summary>
        public string DayMiles { get; set; }
        
        /// <summary>
        /// 里程单位
        /// </summary>
        public string MileUnit { get; set; }
        
        /// <summary>
        /// 当日油耗
        /// </summary>
        public string DayUsedOil { get; set; }
        
        /// <summary>
        /// 油耗单位
        /// </summary>
        public string OilUnit { get; set; }
        
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public string LastLocationDtime { get; set; }
        
        /// <summary>
        /// 行驶时间
        /// </summary>
        public string DriverTimes { get; set; }
        
        /// <summary>
        /// 平均速度
        /// </summary>
        public string AvgSpeed { get; set; }
        
        /// <summary>
        /// 最大速度
        /// </summary>
        public string MaxSpeed { get; set; }
        
        /// <summary>
        /// GPS里程数
        /// </summary>
        public string GPSMiles { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual  long? TenantId { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 所属组织
        /// </summary>
        public string OwnedOrg { get; set; }
        /// <summary>
        /// 当前年度
        /// </summary>
        public string CurYear { get; set; }
        /// <summary>
        /// 当前月份
        /// </summary>
        public string CurMonth { get; set; }
        
    }
}
