using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CarFactory.Application.Configuration.Dto;
using CarFactory.Core.Configuration;

namespace CarFactory.Application.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CarFactoryAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
