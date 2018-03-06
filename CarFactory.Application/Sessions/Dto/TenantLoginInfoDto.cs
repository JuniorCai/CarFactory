using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CarFactory.Core.MultiTenancy;

namespace CarFactory.Application.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}