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
    [Comment("AT指令字典表")]
    [Table("tyy_dict_atcommand")]
    public class ATCommand : DEntityTenant 
    {
        [Comment("AT指令类型")]
        [MaxLength(10)]
        public string ATType { get; set; }
        //指令编码
        [Comment("AT指令编码")]
        [Required, MaxLength(10)]
        public string ATCode { get; set; }
        //指令名称
        [Comment("AT名称")]
        [MaxLength(30)]
        public string ATName { get; set; }
        //指令文本
        [Comment("AT文本")]
        [MaxLength(100)]
        public string ATCommandText { get; set; }

        [Comment("AT路径")]
        [MaxLength(100)]
        public string ATCommandUrl { get; set; }

        [Comment("AT呼叫状态")]
        [MaxLength(20)]
        public string ATCommandType { get; set; }

        [Comment("AT参数类型")]
        [MaxLength(100)]
        public string ATParameType { get; set; }

        [Comment("AT命令备注")]
        [MaxLength(200)]
        public string ATNote { get; set; }
    }
}
