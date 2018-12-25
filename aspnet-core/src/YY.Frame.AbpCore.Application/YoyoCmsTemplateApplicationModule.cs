using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YY.Frame.AbpCore.Authorization;
using YY.Frame.AbpCore.Parameters.Mapper;

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

			//// 自定义类型映射
			//Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
			//{
			//    // XXXMapper.CreateMappers(configuration);


			//});


			//Adding custom AutoMapper configuration
			Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
	        Configuration.Modules.AbpAutoMapper().Configurators.Add(ParameterMapper.CreateMappings);

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
