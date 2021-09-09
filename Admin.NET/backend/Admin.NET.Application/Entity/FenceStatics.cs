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
    [Table("tyy_device_fence_records")]
    public class FenceStatics : DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("设备名称")]
        [MaxLength(50)]
        public string DeviceName { get; set; }

        [Comment("所属客户")]
        [MaxLength(50)]
        public string OwnedCus { get; set; }


        [Comment("围栏名称")]
        [MaxLength(50)]
        public string FenceName { get; set; }


        [Comment("围栏类型")]
        [MaxLength(50)]
        public string FenceType { get; set; }

        [Comment("速度(km/h)")]
        [MaxLength(50)]
        public string Speed { get; set; }

        [Comment("定位时间")]
        [MaxLength(20)]
        public string LocationDtime { get; set; }

    }
}
