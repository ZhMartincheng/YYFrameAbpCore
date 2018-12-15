using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;
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

			//var book = pages.CreateChildPermission(BookPermissions.Node, L("Book"));
			//book.CreateChildPermission(BookPermissions.Query, L("QueryBook"));
			//book.CreateChildPermission(BookPermissions.Create, L("CreateBook"));
			//book.CreateChildPermission(BookPermissions.Edit, L("EditBook"));
			//book.CreateChildPermission(BookPermissions.Delete, L("DeleteBook"));
			//book.CreateChildPermission(BookPermissions.BatchDelete, L("BatchDeleteBook"));
			//book.CreateChildPermission(BookPermissions.ExportExcel, L("ExportExcelBook"));
		}

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, YoyoCmsTemplateConsts.LocalizationSourceName);
        }
    }
}
