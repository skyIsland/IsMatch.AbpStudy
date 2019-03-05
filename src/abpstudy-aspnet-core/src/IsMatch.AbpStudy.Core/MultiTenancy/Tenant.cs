using Abp.MultiTenancy;
using IsMatch.AbpStudy.Authorization.Users;

namespace IsMatch.AbpStudy.MultiTenancy
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
