using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YY.Frame.AbpCore.MultiTenancy.Dto;

namespace YY.Frame.AbpCore.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
