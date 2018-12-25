using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
using YY.Frame.AbpCore.Parameters.Authorization;
using YY.Frame.AbpCore.Persons.Authorization;
using YY.Frame.Authorization;

namespace YY.Frame.AbpCore.Authorization
{
    public class YoyoCmsTemplateAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
			//context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
			//context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
			//context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var roles = administration.CreateChildPermission(PermissionNames.Pages_Roles, L("Roles"));

			var users = administration.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));

			var auditLog = administration.CreateChildPermission(PermissionNames.Pages_AuditLog, L("AuditLog"));
			

			var tenants = administration.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

	        var parameter = administration.CreateChildPermission(ParameterPermissions.Node, L("Parameter"));
	        parameter.CreateChildPermission(ParameterPermissions.Query, L("QueryParameter"));
	        parameter.CreateChildPermission(ParameterPermissions.Create, L("CreateParameter"));
	        parameter.CreateChildPermission(ParameterPermissions.Edit, L("EditParameter"));
	        parameter.CreateChildPermission(ParameterPermissions.Delete, L("DeleteParameter"));
	       // parameter.CreateChildPermission(ParameterPermissions.BatchDelete, L("BatchDeleteParameter"));
	       // parameter.CreateChildPermission(ParameterPermissions.ExportExcel, L("ExportExcelParameter"));


		}

		private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, YoyoCmsTemplateConsts.LocalizationSourceName);
        }
    }
}
