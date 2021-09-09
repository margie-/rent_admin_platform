using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application
{
    [Comment("里程统计")]
    [Table("tyy_milestatistics")]
    public class MileStatistics:DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string  DeviceNo { get; set; }

        [Comment("统计日期")]
        [Required, MaxLength(20)]
        public string  Sdate { get; set; }

        
        [Comment("日里程数")]
        [MaxLength(20)]
        public string DayMiles { get; set; }

        [Comment("里程单位")]
        [MaxLength(20)]
        public string MileUnit { get; set; }

        [Comment("当日油耗")]
        [MaxLength(20)]
        public string DayUsedOil { get; set; }

        [Comment("油耗单位")]
        [MaxLength(20)]
        public string OilUnit { get; set; }

        [Comment("最后更新时间")]
        [MaxLength(20)]
        public string LastLocationDtime { get; set; }

        [Comment("行驶时间")]
        [MaxLength(20)]
        public string DriverTimes { get; set; }

        [Comment("平均速度")]
        [MaxLength(20)]
        public string AvgSpeed { get; set; }

        [Comment("最大速度")]
        [MaxLength(20)]
        public string MaxSpeed { get; set; }

        [Comment("GPS里程数")]
        [MaxLength(20)]
        public string GPSMiles { get; set; }
    }
}
