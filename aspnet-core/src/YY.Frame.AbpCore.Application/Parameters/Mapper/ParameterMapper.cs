
using AutoMapper;
using YY.Frame.AbpCore.Parameters;
using YY.Frame.AbpCore.Parameters.Dtos;

namespace YY.Frame.AbpCore.Parameters.Mapper
{

	/// <summary>
    /// 配置Parameter的AutoMapper
    /// </summary>
	internal static class ParameterMapper
	{
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Parameter,ParameterListDto>();
            configuration.CreateMap <ParameterListDto,Parameter>();

            configuration.CreateMap <ParameterEditDto,Parameter>().ForMember(x => x.Id, opt => opt.Ignore());
            configuration.CreateMap <Parameter,ParameterEditDto>();

	       // CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());



		}
	}
}
