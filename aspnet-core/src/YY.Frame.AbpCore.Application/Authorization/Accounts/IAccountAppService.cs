using System.Threading.Tasks;
using Abp.Application.Services;
using YY.Frame.AbpCore.Authorization.Accounts.Dto;

namespace YY.Frame.AbpCore.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
