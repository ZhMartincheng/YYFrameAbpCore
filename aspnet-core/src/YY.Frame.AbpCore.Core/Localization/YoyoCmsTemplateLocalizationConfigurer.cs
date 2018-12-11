using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace YY.Frame.AbpCore.Localization
{
    public static class YoyoCmsTemplateLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(YoyoCmsTemplateConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(YoyoCmsTemplateLocalizationConfigurer).GetAssembly(),
                        "YY.Frame.AbpCore.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
