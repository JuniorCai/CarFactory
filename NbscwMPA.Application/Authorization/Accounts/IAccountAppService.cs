using System.Threading.Tasks;
using Abp.Application.Services;
using NbscwMPACarFactory.Authorization.Accounts.Dto;

namespace NbscwMPACarFactory.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
