using System.Threading.Tasks;
using Abp.Application.Services;
using YY.Frame.AbpCore.Sessions.Dto;

namespace YY.Frame.AbpCore.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
