using System.Threading.Tasks;
using Abp.Application.Services;
using NbscwMPACarFactory.Sessions.Dto;

namespace NbscwMPACarFactory.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
