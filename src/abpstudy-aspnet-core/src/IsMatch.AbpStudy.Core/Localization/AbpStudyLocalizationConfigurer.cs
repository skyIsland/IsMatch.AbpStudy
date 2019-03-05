using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace IsMatch.AbpStudy.Localization
{
    public static class AbpStudyLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AbpStudyConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AbpStudyLocalizationConfigurer).GetAssembly(),
                        "IsMatch.AbpStudy.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
