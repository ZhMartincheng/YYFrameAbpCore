

using Abp.Domain.Services;
using YY.Frame.AbpCore;

namespace YY.Frame
{
	public abstract class FrameDomainServiceBase : DomainService
	{
		/* Add your common members for all your domain services. */
		/*在领域服务中添加你的自定义公共方法*/





		protected FrameDomainServiceBase()
		{
			LocalizationSourceName = YoyoCmsTemplateConsts.LocalizationSourceName;
		}
	}
}
