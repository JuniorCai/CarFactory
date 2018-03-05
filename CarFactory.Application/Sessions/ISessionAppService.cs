using System.Threading.Tasks;
using Abp.Application.Services;
using CarFactory.Sessions.Dto;

namespace CarFactory.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
