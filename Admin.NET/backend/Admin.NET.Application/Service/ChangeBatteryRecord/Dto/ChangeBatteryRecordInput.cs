using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 换电记录输入参数
    /// </summary>
    public class ChangeBatteryRecordInput : PageInputBase
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string OrderNo { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public virtual string OwnedOrg { get; set; }
        
        /// <summary>
        /// 租赁用户
        /// </summary>
        public virtual string RentUser { get; set; }
        
        /// <summary>
        /// 租赁价格
        /// </summary>
        public virtual string RentPrice { get; set; }
        
        /// <summary>
        /// 旧设备门店
        /// </summary>
        public virtual string OldOrg { get; set; }
        
        /// <summary>
        /// 旧设备编号
        /// </summary>
        public virtual string OldDeviceNo { get; set; }
        
        /// <summary>
        /// 新设备编号
        /// </summary>
        public virtual string NewDeviceNo { get; set; }
        
        /// <summary>
        /// 新设备门店
        /// </summary>
        public virtual string NewOrg { get; set; }
        
        /// <summary>
        /// 新设备名称
        /// </summary>
        public virtual string NewDeviceName { get; set; }
        
        /// <summary>
        /// 换电时间
        /// </summary>
        public virtual string ChangeDtime { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddChangeBatteryRecordInput : ChangeBatteryRecordInput
    {
    }

    public class DeleteChangeBatteryRecordInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateChangeBatteryRecordInput : ChangeBatteryRecordInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeChangeBatteryRecordInput : DeleteChangeBatteryRecordInput
    {

    }
}
