using Abp.AutoMapper;
using YY.Frame.AbpCore.Authentication.External;

namespace YY.Frame.AbpCore.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
