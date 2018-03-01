using Abp.MultiTenancy;
using NbscwMPACarFactory.Authorization.Users;

namespace NbscwMPACarFactory.MultiTenancy
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