using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NbscwMPACarFactory.MultiTenancy.Dto;

namespace NbscwMPACarFactory.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
