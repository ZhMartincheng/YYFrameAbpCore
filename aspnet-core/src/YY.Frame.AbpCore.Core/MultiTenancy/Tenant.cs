using Abp.MultiTenancy;
using YY.Frame.AbpCore.Authorization.Users;

namespace YY.Frame.AbpCore.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
