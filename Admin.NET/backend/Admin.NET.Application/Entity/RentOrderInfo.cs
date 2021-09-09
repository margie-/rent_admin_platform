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
    [Comment("租赁订单")]
    [Table("tyy_rend_orders")]
    public class RentOrderInfo : DEntityTenant
    {
        [Comment("订单号")]
        [ MaxLength(50)]
        public string OrderNo { get; set; }

        [Comment("所属门店")]
        [ MaxLength(50)]
        public string OwnedOrg { get; set; }

        [Comment("设备编号")]
        [MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("电池编号")]
        [MaxLength(50)]
        public string BatteryNo { get; set; }

        [Comment("电池类型")]
        [MaxLength(50)]
        public string BatteryType { get; set; }

        [Comment("租赁价格")]
        [MaxLength(20)]
        public string RentPrice { get; set; }

        [Comment("租赁时长")]
        [MaxLength(20)]
        public string RentTime { get; set; }

        [Comment("租赁金额")]
        [MaxLength(30)]
        public string RentAmount { get; set; }

        [Comment("应付金额")]
        [MaxLength(30)]
        public string PRAmmount { get; set; }

        [Comment("实收金额")]
        [MaxLength(30)]
        public string ARAmount { get; set; }

        [Comment("租赁用户")]
        [MaxLength(30)]
        public string RentUser { get; set; }

        [Comment("订单创建时间")]
        [MaxLength(20)]
        public string OrderCreateDtime { get; set; }

        [Comment("付款时间")]
        [MaxLength(20)]
        public string PayDtime { get; set; }

        [Comment("设备解绑时间")]
        [MaxLength(20)]
        public string DisAssignDtime { get; set; }

        [Comment("支付端设备")]
        [MaxLength(50)]
        public string PayDevice { get; set; }

        [Comment("支付类型")]
        [MaxLength(30)]
        public string PayType { get; set; }

        [Comment("支付状态")]
        [MaxLength(10)]
        public string PayStatus { get; set; }

        [Comment("分佣状态")]
        [MaxLength(10)]
        public string SubCommissionStatus { get; set; }







    }
}
