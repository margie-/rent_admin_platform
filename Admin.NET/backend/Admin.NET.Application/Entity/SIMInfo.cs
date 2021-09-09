using Furion.Extras.Admin.NET;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Application
{
    [Comment("SIM信息")]
    [Table("tyy_sim_info")]
    public class SIMInfo : DEntityTenant
    {
        [Comment("设备编号")]
        [Required, MaxLength(50)]
        public string DeviceNo { get; set; }

        [Comment("Sim卡类型")]
        [MaxLength(20)]
        public string SimType { get; set; }

        [Comment("卡号")]
        [MaxLength(50)]
        public string CardNo { get; set; }

        [Comment("ICCID")]
        [MaxLength(50)]
        public string ICCID { get; set; }

        [Comment("卡状态")]
        [MaxLength(20)]
        public string SimStatus { get; set; }

        [Comment("激活时间")]
        [MaxLength(20)]
        public string ActivationDtime { get; set; }

        [Comment("过期时间")]
        [MaxLength(20)]
        public string ExpiredDtime { get; set; }

        [Comment("年费")]
        [MaxLength(20)]
        public string AnnualFee { get; set; }

        [Comment("备注")]
        [MaxLength(100)]
        public string Note { get; set; }
    }
}
