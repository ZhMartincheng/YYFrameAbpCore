
using AutoMapper;
using YY.Frame.AbpCore.Persons;
using YY.Frame.AbpCore.Persons.Dtos;

namespace YY.Frame.AbpCore.Persons.Mapper
{

	/// <summary>
    /// 配置Book的AutoMapper
    /// </summary>
	internal static class BookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Book,BookListDto>();
            configuration.CreateMap <BookListDto,Book>();

            configuration.CreateMap <BookEditDto,Book>();
            configuration.CreateMap <Book,BookEditDto>();

        }
	}
}
