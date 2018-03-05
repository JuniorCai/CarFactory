using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.MultiTenancy.Dto;

namespace CarFactory.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
