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
    [Comment("换电记录")]
    [Table("tyy_changeBattery_record")]
    public class ChangeBatteryRecord : DEntityTenant
    {
        [Comment("订单号")]
        [ MaxLength(50)]
        public string OrderNo { get; set; }

        [Comment("所属门店")]
        [MaxLength(50)]
        public string OwnedOrg { get; set; }


        [Comment("租赁用户")]
        [MaxLength(50)]
        public string RentUser { get; set; }


        [Comment("租赁价格")]
        [MaxLength(50)]
        public string RentPrice { get; set; }


        [Comment("旧设备门店")]
        [MaxLength(50)]
        public string OldOrg { get; set; }


        [Comment("旧设备编号")]
        [MaxLength(50)]
        public string OldDeviceNo { get; set; }


        [Comment("新设备编号")]
        [MaxLength(50)]
        public string NewDeviceNo { get; set; }


        [Comment("新设备门店")]
        [MaxLength(50)]
        public string NewOrg { get; set; }

        [Comment("新设备名称")]
        [MaxLength(50)]
        public string NewDeviceName { get; set; }

        [Comment("换电时间")]
        [MaxLength(50)]
        public string ChangeDtime { get; set; }

    }
}
