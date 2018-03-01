using System.Threading.Tasks;
using Abp.Application.Services;
using NbscwMPACarFactory.Configuration.Dto;

namespace NbscwMPACarFactory.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}