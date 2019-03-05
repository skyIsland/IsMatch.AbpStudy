using System.Threading.Tasks;
using Abp.Application.Services;
using IsMatch.AbpStudy.Authorization.Accounts.Dto;

namespace IsMatch.AbpStudy.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
