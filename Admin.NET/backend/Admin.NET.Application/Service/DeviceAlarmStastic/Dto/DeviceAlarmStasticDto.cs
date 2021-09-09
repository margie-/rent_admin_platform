using System;
using Furion.Extras.Admin.NET;

namespace Admin.NET.Application
{
    /// <summary>
    /// 报警统计日报表输出参数
    /// </summary>
    public class DeviceAlarmStasticDto
    {
        /// <summary>
        /// 设备编号
        /// </summary>
        public string DeviceNo { get; set; }
        
        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }
        
        /// <summary>
        /// 所属门店
        /// </summary>
        public string OwnedOrg { get; set; }
        
        /// <summary>
        /// 报表日期
        /// </summary>
        public string reportDate { get; set; }
        
        /// <summary>
        /// 出围栏报警
        /// </summary>
        public string alarm1 { get; set; }
        
        /// <summary>
        /// 入围栏报警
        /// </summary>
        public string alarm2 { get; set; }
        
        /// <summary>
        /// 断电报警
        /// </summary>
        public string alarm3 { get; set; }
        
        /// <summary>
        /// 低电报警
        /// </summary>
        public string alarm4 { get; set; }
        
        /// <summary>
        /// 震动报警
        /// </summary>
        public string alarm5 { get; set; }
        
        /// <summary>
        /// 位移报警
        /// </summary>
        public string alarm6 { get; set; }
        
        /// <summary>
        /// 点火报警
        /// </summary>
        public string alarm7 { get; set; }
        
        /// <summary>
        /// 侧翻报警
        /// </summary>
        public string alarm8 { get; set; }
        
        /// <summary>
        /// 拆卸报警
        /// </summary>
        public string alarm9 { get; set; }
        
        /// <summary>
        /// 其他报警
        /// </summary>
        public string alarm10 { get; set; }
        
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
