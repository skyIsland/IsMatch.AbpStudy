using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IsMatch.AbpStudy.Authorization;
using IsMatch.AbpStudy.PhoneBooks.Persons.Authorization;
using IsMatch.AbpStudy.PhoneBooks.Persons.Mapper;

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
            Configuration.Authorization.Providers.Add<PersonAuthorizationProvider>();


            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);

                PersonMapper.CreateMappings(configuration);
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
