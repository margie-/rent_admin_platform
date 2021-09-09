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
    [Comment("设备押金退款")]
    [Table("tyy_return_orders")]
    public class ReturnList : DEntityTenant
    {
        [Comment("退款单号")]
        [MaxLength(50)]
        public string returnNo { get; set; }


        [Comment("订单号")]
        [MaxLength(50)]
        public string OrderNo { get; set; }


        [Comment("所属门店")]
        [MaxLength(50)]
        public string OwnedOrg { get; set; }


        [Comment("设备编号")]
        [MaxLength(50)]
        public string DeviceNo { get; set; }


        [Comment("电芯类型")]
        [MaxLength(50)]
        public string BatteryType { get; set; }


        [Comment("租赁用户")]
        [MaxLength(50)]
        public string RentUser { get; set; }

        [Comment("押金金额")]
        [MaxLength(50)]
        public string DepositAmount  { get; set; }

        [Comment("退款金额")]
        [MaxLength(50)]
        public string ReturnAmount { get; set; }


        [Comment("退款原因")]
        [MaxLength(50)]
        public string ReturnReason { get; set; }

        [Comment("退款类型")]
        [MaxLength(50)]
        public string ReturnType { get; set; }


        [Comment("创建时间")]
        [MaxLength(50)]
        public string ReturnCreateDtime { get; set; }


        [Comment("审核时间")]
        [MaxLength(50)]
        public string AuditDtime { get; set; }


        [Comment("到账时间")]
        [MaxLength(50)]
        public string AccountDtime { get; set; }


        [Comment("退款状态")]
        [MaxLength(50)]
        public string ReturnStatus { get; set; }


    }
}
