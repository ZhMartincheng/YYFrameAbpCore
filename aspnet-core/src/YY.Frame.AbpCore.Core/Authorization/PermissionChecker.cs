using Abp.Authorization;
using YY.Frame.AbpCore.Authorization.Roles;
using YY.Frame.AbpCore.Authorization.Users;

namespace YY.Frame.AbpCore.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
