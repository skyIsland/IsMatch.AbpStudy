using System.Collections.Generic;

namespace IsMatch.AbpStudy.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
