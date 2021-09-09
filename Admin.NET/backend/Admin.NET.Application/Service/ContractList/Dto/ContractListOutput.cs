using System;

namespace Admin.NET.Application
{
    /// <summary>
    /// 合同管理输出参数
    /// </summary>
    public class ContractListOutput
    {
        /// <summary>
        /// 合同名称
        /// </summary>
        public string ContractName { get; set; }
        
        /// <summary>
        /// 合同内容
        /// </summary>
        public string ContractDetails { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string ContractNote { get; set; }
        
        /// <summary>
        /// 是否展示给用户
        /// </summary>
        public string isShowToUser { get; set; }
        
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
