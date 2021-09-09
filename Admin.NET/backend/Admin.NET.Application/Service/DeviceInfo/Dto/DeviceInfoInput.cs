using Furion.Extras.Admin.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备信息输入参数
    /// </summary>
    public class DeviceInfoInput : PageInputBase
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public virtual string DeviceName { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public virtual string DeviceType { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public virtual string DModel { get; set; }

        /// <summary>
        /// 电压
        /// </summary>
        public virtual string Voltage { get; set; }

        /// <summary>
        /// 电流
        /// </summary>
        public virtual string Electricity { get; set; }

        /// <summary>
        /// 电芯
        /// </summary>
        public virtual string BatteryType { get; set; }

        /// <summary>
        /// ICCD
        /// </summary>
        public virtual string ICCID { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        public virtual string FWVersion { get; set; }

        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual long OwnedOrg { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public virtual string DeviceStatus { get; set; }

        /// <summary>
        /// 制造日期
        /// </summary>
        public virtual string ManufactureDate { get; set; }

        /// <summary>
        /// 最后定位日期
        /// </summary>
        public virtual string LastLoationDtime { get; set; }

        /// <summary>
        /// 蓝牙ID
        /// </summary>
        public virtual string BlueToothID { get; set; }

        /// <summary>
        /// 激活时间
        /// </summary>
        public virtual string ActiveDtime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public virtual string ExpiredDtime { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public virtual string CarNo { get; set; }

        /// <summary>
        /// 车主姓名
        /// </summary>
        public virtual string CarOwerName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual string CarOwnerPhone { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public virtual string IconId { get; set; }

        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }


        public virtual long Id { get; set; }



    }

    //
    /// <summary>
    /// 设备查询输入参数 1.所属门店 2.设备名称 3.设备编号 4.设备状态 5.设备类型 6.电芯类型 7.租赁状态
    /// </summary>
    public class DeviceQueryInfoInput: PageInputBase
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public virtual string DeviceName { get; set; }

        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public virtual string DeviceType { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public virtual string DModel { get; set; }
        /// <summary>
        /// 电芯
        /// </summary>
        public virtual string BatteryType { get; set; }

        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual long OwnedOrg { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public virtual string DeviceStatus { get; set; }




    }

    public class AddDeviceInfoInput : DeviceInfoInput
    {

    }

    public class DeleteDeviceInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateDeviceInfoInput : DeviceInfoInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class LotUpdateDeviceInfoInput : DeviceInfoInput
    {
        /// <summary>
        /// 批量更新的设备编码
        /// </summary>
        
        public virtual List<string> UpdateDeviceList { get; set; }

        public virtual List<string> UpdateProperty { get; set; } 

        public virtual string SimType { get; set; }

        public virtual string AnnualFee { get; set; }

        public virtual string BatteryCalType { get; set; }

        public virtual string BatterySerialQty { get; set; }

        public List<DeviceBattertCalibInput> DeviceBattertCalibs { get; set; }

        public object GetValue(string propertyName) 
        {
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }

    }

    public class QueryeDeviceInfoInput : DeleteDeviceInfoInput
    {

    }

    /// <summary>
    /// 发送指令信息
    /// </summary>
    public class DeviceCommandInfos 
    {
        public List<DeviceCommand> deviceCommands { get; set; }
    }

    public class DeviceCommand 
    {
        public string commandname { get; set; } 
    }

    public class DevicesIDs 
    {
        public List<string> deviceNos { get; set; }
    }
}
