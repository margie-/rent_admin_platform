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
    [Comment("报警统计日报表")]
    [Table("tyy_device_alarm_dayreport")]
    public class DeviceAlarmStastic : DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("设备名称")]
        [ MaxLength(50)]
        public string DeviceName { get; set; }

        [Comment("所属门店")]
        [MaxLength(50)]
        public string OwnedOrg { get; set; }

        [Comment("报表日期")]
        [MaxLength(50)]
        public string reportDate { get; set; }

        [Comment("出围栏报警")]
        [MaxLength(50)]
        public string alarm1 { get; set; }

        [Comment("入围栏报警")]
        [MaxLength(50)]
        public string alarm2 { get; set; }


        [Comment("断电报警")]
        [MaxLength(50)]
        public string alarm3 { get; set; }


        [Comment("低电报警")]
        [MaxLength(50)]
        public string alarm4 { get; set; }

        [Comment("震动报警")]
        [MaxLength(50)]
        public string alarm5 { get; set; }

        [Comment("位移报警")]
        [MaxLength(50)]

        public string alarm6 { get; set; }

        [Comment("点火报警")]
        [MaxLength(50)]
        public string alarm7 { get; set; }

        [Comment("侧翻报警")]
        [MaxLength(50)]
        public string alarm8 { get; set; }

        [Comment("拆卸报警")]
        [MaxLength(50)]
        public string alarm9 { get; set; }

        [Comment("其他报警")]
        [MaxLength(50)]
        public string alarm10 { get; set; }



    }
}
