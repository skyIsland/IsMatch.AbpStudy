using System.Threading.Tasks;
using Abp.Application.Services;
using IsMatch.AbpStudy.Sessions.Dto;

namespace IsMatch.AbpStudy.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
