using System.Threading.Tasks;
using Abp.Application.Services;
using CarFactory.Application.Configuration.Dto;

namespace CarFactory.Application.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}