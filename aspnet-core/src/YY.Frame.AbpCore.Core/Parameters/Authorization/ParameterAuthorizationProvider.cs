

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using YY.Frame.Authorization;

namespace YY.Frame.AbpCore.Parameters.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="ParameterPermissions" /> for all permission names. Parameter
    ///</summary>
    public class ParameterAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public ParameterAuthorizationProvider()
		{

		}

        public ParameterAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public ParameterAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Parameter 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(ParameterPermissions.Node , L("Parameter"));
			entityPermission.CreateChildPermission(ParameterPermissions.Query, L("QueryParameter"));
			entityPermission.CreateChildPermission(ParameterPermissions.Create, L("CreateParameter"));
			entityPermission.CreateChildPermission(ParameterPermissions.Edit, L("EditParameter"));
			entityPermission.CreateChildPermission(ParameterPermissions.Delete, L("DeleteParameter"));
			entityPermission.CreateChildPermission(ParameterPermissions.BatchDelete, L("BatchDeleteParameter"));
			entityPermission.CreateChildPermission(ParameterPermissions.ExportExcel, L("ExportExcelParameter"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, YoyoCmsTemplateConsts.LocalizationSourceName);
		}
    }
}