using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using YY.Frame.AbpCore.MultiTenancy;

namespace YY.Frame.AbpCore.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
