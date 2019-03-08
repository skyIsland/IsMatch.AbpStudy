using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IsMatch.AbpStudy.Authorization;

namespace IsMatch.AbpStudy
{
    [DependsOn(
        typeof(AbpStudyCoreModule),
        typeof(AbpAutoMapperModule))]
    public class AbpStudyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpStudyAuthorizationProvider>();

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);


            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpStudyApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
