using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.NET.Application.Entity
{
    [Comment("AT指令运行记录表")]
    [Table("tyy_atcommand_record")]
    public class ATCommandRecord : DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("指令代码")]
        [MaxLength(50)]
        public string ATCode { get; set; }

        [Comment("指令名")]
        [MaxLength(50)]
        public string ATName { get; set; }

        [Comment("指令文本")]
        [MaxLength(100)]
        public string ATCommandText { get; set; }
      
        [Comment("操作结果")]
        [MaxLength(50)]
        public string ATCommandResult { get; set; }

        [Comment("备注")]
        [MaxLength(50)]
        public string ATCommandNote { get; set; }

    }
}
