using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 设备电池校准信息输入参数
    /// </summary>
    public class Device_BattertCalibInput : PageInputBase
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public virtual string DeviceNo { get; set; }
        
        /// <summary>
        /// 电池串号
        /// </summary>
        public virtual string BatterySeries { get; set; }
        
        /// <summary>
        /// 占百分比
        /// </summary>
        public virtual string ElectronicPer_s { get; set; }
        
        /// <summary>
        /// 电压数值
        /// </summary>
        public virtual string ElectronicVol_s { get; set; }
        
        /// <summary>
        /// 电压数值2
        /// </summary>
        public virtual string ElectronicVol_2 { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string BattertRemark { get; set; }
        
        /// <summary>
        /// 信息来源类型
        /// </summary>
        public virtual string InfoSourceType { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddDevice_BattertCalibInput : Device_BattertCalibInput
    {
    }

    public class DeleteDevice_BattertCalibInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateDevice_BattertCalibInput : Device_BattertCalibInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeDevice_BattertCalibInput : DeleteDevice_BattertCalibInput
    {

    }
}
