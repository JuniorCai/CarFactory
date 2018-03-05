using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CarFactory.Configuration.Dto;

namespace CarFactory.Configuration
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
