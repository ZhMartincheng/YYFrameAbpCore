using Abp.Authorization;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace YY.Frame.Application.Authorization.Permissions.Dto
{
	public class PermissionProfile: Profile
	{

		public PermissionProfile()
		{
			//CreateMap<Permission, string>().ConvertUsing(r => r.Name);
			//CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

			//CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
			//CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
			//Permission
			CreateMap<Permission, FlatPermissionDto>();
			CreateMap<Permission, FlatPermissionWithLevelDto>().ForMember(x=>x.level,opt=>opt.Ignore())
				.ForMember(dest => dest.title, opt => opt.MapFrom(src => src.DisplayName))//定义映射规则
				.ForMember(dest => dest.key, opt => opt.MapFrom(src => src.Name))//定义映射规则
				;
		}
	}
}
