using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using YY.Frame.AbpCore;
using YY.Frame.Application.Authorization.Authorization.Permissions;
using YY.Frame.Application.Authorization.Permissions.Dto;

namespace YY.Frame.Application.Authorization.Permissions
{
	public class PermissionAppService : YoyoCmsTemplateAppServiceBase, IPermissionAppService
	{
		public Task<List<FlatPermissionWithLevelDto>> GetAllPermissionsTree()
		{
			var permissions = PermissionManager.GetAllPermissions();
			var rootPermissions = permissions.Where(p => p.Parent == null);

			var result = new List<FlatPermissionWithLevelDto>();

			foreach (var rootPermission in rootPermissions)
			{
				var level = 0;
				//AddPermission(rootPermission, permissions, result, level);
				var flatPermission = ObjectMapper.Map<FlatPermissionWithLevelDto>(rootPermission);
				flatPermission.level = level;
				result.Add(flatPermission);
			}
			return Task.FromResult( result );

		}

		private void AddPermission(Permission permission, IReadOnlyList<Permission> allPermissions, List<FlatPermissionWithLevelDto> result, int level)
		{
			var flatPermission = ObjectMapper.Map<FlatPermissionWithLevelDto>(permission);
			flatPermission.level = level;
			result.Add(flatPermission);

			if (permission.Children == null)
			{
				return;
			}

			var children = allPermissions.Where(p => p.Parent != null && p.Parent.Name == permission.Name).ToList();

			foreach (var childPermission in children)
			{
				AddPermission(childPermission, allPermissions, result, level + 1);
			}
		}




	}
}
