using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YY.Frame.AbpCore.Roles.Dto;
using YY.Frame.AbpCore.Users.Dto;

namespace YY.Frame.AbpCore.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
