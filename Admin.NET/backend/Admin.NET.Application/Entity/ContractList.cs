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
    [Comment("合同")]
    [Table("tyy_contract_info")]
    public class ContractList : DEntityTenant
    {
        [Comment("合同名称")]
        [Required, MaxLength(50)]
        public string ContractName { get; set; }

        [Comment("合同内容")]
        [Required, MaxLength(200)]
        public string ContractDetails { get; set; }

        [Comment("备注")]
        [Required, MaxLength(50)]
        public string ContractNote { get; set; }


        [Comment("是否展示给用户")]
        [Required, MaxLength(20)]
        public string isShowToUser { get; set; }




    }
}
