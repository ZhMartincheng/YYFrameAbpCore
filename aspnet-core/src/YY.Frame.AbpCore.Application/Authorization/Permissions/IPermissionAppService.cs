using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YY.Frame.Application.Authorization.Permissions.Dto;

namespace YY.Frame.Application.Authorization.Authorization.Permissions
{
	public interface IPermissionAppService : IApplicationService
	{
		//Task<ListResultDto<FlatPermissionWithLevelDto>> GetAllPermissions();
		//Task<FlatPermissionWithLevelDto> GetAllPermissionsAsync();

		//string GetAllPermissionsTree();

		Task<List<FlatPermissionWithLevelDto>> GetAllPermissionsTree();
	}
}
