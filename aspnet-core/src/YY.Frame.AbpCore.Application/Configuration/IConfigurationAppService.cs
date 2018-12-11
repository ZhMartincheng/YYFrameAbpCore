using System.Threading.Tasks;
using YY.Frame.AbpCore.Configuration.Dto;

namespace YY.Frame.AbpCore.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
