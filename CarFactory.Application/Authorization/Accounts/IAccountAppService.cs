using System.Threading.Tasks;
using Abp.Application.Services;
using CarFactory.Application.Authorization.Accounts.Dto;

namespace CarFactory.Application.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
