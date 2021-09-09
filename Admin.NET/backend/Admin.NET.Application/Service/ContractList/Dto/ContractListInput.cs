using Furion.Extras.Admin.NET;
using System;
using System.ComponentModel.DataAnnotations;

namespace Admin.NET.Application
{
    /// <summary>
    /// 合同管理输入参数
    /// </summary>
    public class ContractListInput : PageInputBase
    {
        /// <summary>
        /// 合同名称
        /// </summary>
        public virtual string ContractName { get; set; }
        
        /// <summary>
        /// 合同内容
        /// </summary>
        public virtual string ContractDetails { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string ContractNote { get; set; }
        
        /// <summary>
        /// 是否展示给用户
        /// </summary>
        public virtual string isShowToUser { get; set; }
        
        /// <summary>
        /// 租户id
        /// </summary>
        public virtual long TenantId { get; set; }
        
    }

    public class AddContractListInput : ContractListInput
    {
    }

    public class DeleteContractListInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class UpdateContractListInput : ContractListInput
    {
        /// <summary>
        /// Id主键
        /// </summary>
        [Required(ErrorMessage = "Id主键不能为空")]
        public long Id { get; set; }
        
    }

    public class QueryeContractListInput : DeleteContractListInput
    {

    }
}
