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
    [Comment("设备BMS信息设置")]
    [Table("tyy_device_BmsInfo")]
    public class DeviceBMSInfo : DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

    }
}
