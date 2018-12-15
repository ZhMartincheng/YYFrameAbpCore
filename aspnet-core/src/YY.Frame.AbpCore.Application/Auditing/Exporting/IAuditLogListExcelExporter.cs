using System.Collections.Generic;
using YY.Frame.AbpCore.Auditing.Dtos;
using YY.Frame.AbpCore.ExcelExport;

namespace YY.Frame.AbpCore.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
