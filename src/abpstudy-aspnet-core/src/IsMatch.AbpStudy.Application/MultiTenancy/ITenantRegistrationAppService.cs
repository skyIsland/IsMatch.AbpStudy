using IsMatch.AbpStudy.MultiTenancy.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IsMatch.AbpStudy.MultiTenancy
{
    public interface ITenantRegistrationAppService
    {
        /// <summary>
        /// ??????????????????
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        Task<TenantDto> RegisterTenantAsync(CreateTenantDto input);
    }
}
