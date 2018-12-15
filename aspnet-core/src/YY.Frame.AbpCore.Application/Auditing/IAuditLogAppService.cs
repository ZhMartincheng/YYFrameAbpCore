using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YY.Frame.AbpCore.Auditing.Dtos;
using YY.Frame.AbpCore.ExcelExport;

namespace YY.Frame.AbpCore.Auditing
{
	public interface IAuditLogAppService: IApplicationService
	{
		Task<PagedResultDto<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

		Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);

		Task<PagedResultDto<EntityChangeListDto>> GetEntityChanges(GetEntityChangeInput input);

		Task<FileDto> GetEntityChangesToExcel(GetEntityChangeInput input);

		Task<List<EntityPropertyChangeDto>> GetEntityPropertyChanges(long entityChangeId);

		List<NameValueDto> GetEntityHistoryObjectTypes();
	}
}
