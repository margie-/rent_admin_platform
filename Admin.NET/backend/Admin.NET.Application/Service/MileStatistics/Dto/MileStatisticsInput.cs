using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 里程统计输入参数
    /// </summary>
    public class MileStatisticsInput : PageInputBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 统计日期
        /// </summary>
        public virtual string Sdate { get; set; }
        
        /// <summary>
        /// 日里程数
        /// </summary>
        public virtual string DayMiles { get; set; }
        
        /// <summary>
        /// 里程单位
        /// </summary>
        public virtual string MileUnit { get; set; }
        
        /// <summary>
        /// 当日油耗
        /// </summary>
        public virtual string DayUsedOil { get; set; }
        
        /// <summary>
        /// 油耗单位
        /// </summary>
        public virtual string OilUnit { get; set; }
        
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public virtual string LastLocationDtime { get; set; }
        
        /// <summary>
        /// 行驶时间
        /// </summary>
        public virtual string DriverTimes { get; set; }
        
        /// <summary>
        /// 平均速度
        /// </summary>
        public virtual string AvgSpeed { get; set; }
        
        /// <summary>
        /// 最大速度
        /// </summary>
        public virtual string MaxSpeed { get; set; }
        
        /// <summary>
        /// GPS里程数
        /// </summary>
        public virtual string GPSMiles { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }

        /// <summary>
        /// 当前所属门店
        /// </summary>
        public virtual string OwnedOrg { get; set; }
        
    }

    public class AddMileStatisticsInput : MileStatisticsInput
    {
    }

    public class DeleteMileStatisticsInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateMileStatisticsInput : MileStatisticsInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeMileStatisticsInput : DeleteMileStatisticsInput
    {

    }
}
