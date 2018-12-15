using Abp.Auditing;
using Abp.EntityHistory;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YY.Frame.AbpCore.Auditing.Dtos;

namespace YY.Frame.AbpCore
{
	internal static class CustomDtoMapper
	{
		public static void CreateMappings(IMapperConfigurationExpression configuration)
		{
			//AuditLog
			configuration.CreateMap<AuditLog, AuditLogListDto>();
			configuration.CreateMap<EntityChange, EntityChangeListDto>();
		}
	}
}
