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
    [Comment("设备信息")]
    [Table("tyy_devicedlarm_record")]
    public class DeviceAlarmRecord : DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("报警时间")]
        [ MaxLength(20)]
        public string AlertDtime { get; set; }

        [Comment("报警日期")]
        [MaxLength(20)]
        public string AlertDate { get; set; }

        [Comment("报警位置X")]
        [MaxLength(20)]
        public string AlertPosition_x { get; set; }

        [Comment("报警位置Y")]
        [MaxLength(20)]
        public string AlertPosition_y { get; set; }

        [Comment("报警位置")]
        [MaxLength(100)]
        public string AlertPosition { get; set; }

        [Comment("报警类型")]
        [MaxLength(20)]
        public string AlertType { get; set; }

        [Comment("报警信息")]
        [MaxLength(100)]
        public string AlertInfo { get; set; }

        [Comment("当前速度")]
        [MaxLength(20)]
        public string CurSpeed { get; set; }

        [Comment("报警状态")]
        [MaxLength(20)]
        public string AlterStatus { get; set; }
       
        [Comment("是否处理")]
        [MaxLength(5)]
        public string isHandled { get; set; }

        [Comment("处理信息")]
        [MaxLength(100)]
        public string HandleInfo { get; set; }

    }
}
