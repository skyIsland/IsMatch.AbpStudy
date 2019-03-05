using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IsMatch.AbpStudy.MultiTenancy.Dto;

namespace IsMatch.AbpStudy.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
