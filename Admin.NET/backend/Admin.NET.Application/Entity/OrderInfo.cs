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
    [Comment("订单信息")]
    [Table("tyy_order_info1")]
    public class OrderInfo: DEntityTenant
    {

        [Comment("订单编号")]
        [Required, MaxLength(50)]
        public string OrderNo { get; set; }


        [Comment("订单类型")]
        [Required, MaxLength(50)]
        public string OrderType { get; set; }

        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("商家")]
        [Required, MaxLength(50)]
        public string vendor { get; set; }


        [Comment("用户")]
        [Required, MaxLength(50)]
        public string User { get; set; }


        [Comment("卡号")]
        [Required, MaxLength(50)]
        public string CardId{ get; set; }


        [Comment("ICCID")]
        [Required, MaxLength(50)]
        public string ICCID { get; set; }


        [Comment("付款账户")]
        [Required, MaxLength(50)]
        public string PayAccount { get; set; }


        [Comment("金额")]
        [Required, MaxLength(50)]
        public string PayAmount { get; set; }


        [Comment("发生时间")]
        [Required, MaxLength(50)]
        public string PayDtime { get; set; }


    }
}
