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
    [Comment("设备电池校准信息")]
    [Table("tyy_device_batteryCalib")]
    public class DeviceBattertCalib : DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("电池串号")]
        [Required, MaxLength(10)]
        public string BatterySeries { get; set; }

        [Comment("占百分比")]
        [Required, MaxLength(10)]
        public string ElectronicPer_s { get; set; }
        [Comment("电压数值")]
        [MaxLength(20)]
        public string ElectronicVol_s { get; set; }

        [Comment("电压数值2")]
        [MaxLength(20)]
        public string ElectronicVol_2 { get; set; }

        [Comment("备注")]
        [MaxLength(50)]
        public string BattertRemark { get; set; }

        [Comment("信息来源类型")]
        [MaxLength(20)]
        public string InfoSourceType { get; set; }


    }
}
