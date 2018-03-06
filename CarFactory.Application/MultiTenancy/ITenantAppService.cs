using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CarFactory.Application.MultiTenancy.Dto;

namespace CarFactory.Application.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
