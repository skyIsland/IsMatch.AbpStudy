using System.ComponentModel.DataAnnotations;
using Abp.MultiTenancy;

namespace IsMatch.AbpStudy.Authorization.Accounts.Dto
{
    public class IsTenantAvailableInput
    {
        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }
    }
}
