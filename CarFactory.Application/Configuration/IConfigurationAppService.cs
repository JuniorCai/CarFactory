using System.Threading.Tasks;
using Abp.Application.Services;
using CarFactory.Configuration.Dto;

namespace CarFactory.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}