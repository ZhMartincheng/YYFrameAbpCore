using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using YY.Frame.AbpCore.Configuration;
using Abp.Dependency;

namespace YY.Frame.AbpCore.Web.Host.Startup
{
    [DependsOn(
       typeof(YoyoCmsTemplateWebCoreModule))]
    public class YoyoCmsTemplateWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public YoyoCmsTemplateWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(YoyoCmsTemplateWebHostModule).GetAssembly());
        }

		public override void PostInitialize()
		{
			
		}

	}
}
