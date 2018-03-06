using System.Threading.Tasks;
using Abp.Application.Services;
using CarFactory.Application.Sessions.Dto;

namespace CarFactory.Application.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
