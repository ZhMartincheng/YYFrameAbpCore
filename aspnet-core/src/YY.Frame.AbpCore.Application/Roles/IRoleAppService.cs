using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YY.Frame.AbpCore.Roles.Dto;

namespace YY.Frame.AbpCore.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
		Task<GetRoleForEditOutput> GetGrantedPermissionNames(NullableIdDto input);
	}
}
