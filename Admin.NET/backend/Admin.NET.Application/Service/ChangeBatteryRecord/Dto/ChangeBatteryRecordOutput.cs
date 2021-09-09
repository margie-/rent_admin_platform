using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 换电记录输出参数
    /// </summary>
    public class ChangeBatteryRecordOutput
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public string OwnedOrg { get; set; }
        
        /// <summary>
        /// 租赁用户
        /// </summary>
        public string RentUser { get; set; }
        
        /// <summary>
        /// 租赁价格
        /// </summary>
        public string RentPrice { get; set; }
        
        /// <summary>
        /// 旧设备门店
        /// </summary>
        public string OldOrg { get; set; }
        
        /// <summary>
        /// 旧设备编号
        /// </summary>
        public string OldDeviceNo { get; set; }
        
        /// <summary>
        /// 新设备编号
        /// </summary>
        public string NewDeviceNo { get; set; }
        
        /// <summary>
        /// 新设备门店
        /// </summary>
        public string NewOrg { get; set; }
        
        /// <summary>
        /// 新设备名称
        /// </summary>
        public string NewDeviceName { get; set; }
        
        /// <summary>
        /// 换电时间
        /// </summary>
        public string ChangeDtime { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public long TenantId { get; set; }
        
        /// <summary>
        /// Id主键
        /// </summary>
        public long Id { get; set; }
        
    }
}
