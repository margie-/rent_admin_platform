using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Furion.Extras.Admin.NET;

namespace Admin.NET.Application
{
    [Comment("设备信息")]
    [Table("tyy_device_info")]
    public class DeviceInfo : DEntityTenant
    {

        [Comment("设备名称")]
        [Required, MaxLength(50)]
        public string DeviceName { get; set; }

        [Comment("设备编号")]
        [MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("类型")]
        [MaxLength(20)]
        public string DeviceType { get; set; }

        [Comment("型号")]
        [MaxLength(20)]
        public string DModel { get; set; }

        [Comment("电压")]
        [MaxLength(20)]
        public string Voltage { get; set; }

        [Comment("电流")]
        [MaxLength(20)]
        public string Electricity { get; set; }

        [Comment("电芯")]
        [MaxLength(20)]
        public string BatteryType { get; set; }

        [Comment("电池校正类型")]
        [MaxLength(20)]
        public string BatteryCalType { get; set; }

        [Comment("电池串数")]
        [MaxLength(20)]
        public string BatterySerialQty { get; set; }

        [Comment("ICCD")]
        [MaxLength(50)]
        public string ICCID { get; set; }

        [Comment("版本")]
        [MaxLength(20)]
        public string FWVersion { get; set; }

        [Comment("所属门店")]
      
        public long OwnedOrg { get; set; }

        [Comment("设备状态")]
        [MaxLength(20)]
        public string DeviceStatus { get; set; }

        [Comment("制造日期")]
        [MaxLength(20)]
        public string ManufactureDate { get; set; }

        [Comment("最后定位日期")]
        [MaxLength(20)]
        public string LastLoationDtime { get; set; }

        [Comment("蓝牙ID")]
        [MaxLength(50)]
        public string BlueToothID { get; set; }

        [Comment("激活时间")]
        [MaxLength(20)]
        public string ActiveDtime { get; set; }

        [Comment("过期时间")]
        [MaxLength(20)]
        public string ExpiredDtime { get; set; }

        [Comment("车牌号")]
        [MaxLength(20)]
        public string CarNo { get; set; }

        [Comment("车主姓名")]
        [MaxLength(20)]
        public string CarOwerName { get; set; }

        [Comment("电话")]
        [MaxLength(20)]
        public string CarOwnerPhone { get; set; }

        [Comment("图标")]
        [MaxLength(20)]
        public string IconId { get; set; }

    }
}
