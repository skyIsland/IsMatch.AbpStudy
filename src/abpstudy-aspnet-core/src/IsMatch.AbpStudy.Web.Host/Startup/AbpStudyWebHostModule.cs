using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IsMatch.AbpStudy.Configuration;

namespace IsMatch.AbpStudy.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpStudyWebCoreModule))]
    public class AbpStudyWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpStudyWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpStudyWebHostModule).GetAssembly());
        }
    }
}
