using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IsMatch.AbpStudy.Controllers
{
    public abstract class AbpStudyControllerBase: AbpController
    {
        protected AbpStudyControllerBase()
        {
            LocalizationSourceName = AbpStudyConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
