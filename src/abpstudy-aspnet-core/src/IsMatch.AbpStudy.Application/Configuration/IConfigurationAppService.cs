using System.Threading.Tasks;
using IsMatch.AbpStudy.Configuration.Dto;

namespace IsMatch.AbpStudy.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
