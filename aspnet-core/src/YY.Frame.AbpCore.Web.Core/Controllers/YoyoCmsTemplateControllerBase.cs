using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace YY.Frame.AbpCore.Controllers
{
    public abstract class YoyoCmsTemplateControllerBase: AbpController
    {
        protected YoyoCmsTemplateControllerBase()
        {
            LocalizationSourceName = YoyoCmsTemplateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
