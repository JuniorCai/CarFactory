using Abp.AutoMapper;
using NbscwMPACarFactory.Sessions.Dto;

namespace NbscwMPACarFactory.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}