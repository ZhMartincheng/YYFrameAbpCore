using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YY.Frame.AbpCore.Authorization;

namespace YY.Frame.AbpCore
{
    [DependsOn(
        typeof(YoyoCmsTemplateCoreModule),
        typeof(AbpAutoMapperModule))]
    public class YoyoCmsTemplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<YoyoCmsTemplateAuthorizationProvider>();

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);


            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(YoyoCmsTemplateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
