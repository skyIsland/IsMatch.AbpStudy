
using AutoMapper;
using IsMatch.AbpStudy.PhoneBooks.Persons;
using IsMatch.AbpStudy.PhoneBooks.Persons.Dtos;

namespace IsMatch.AbpStudy.PhoneBooks.Persons.Mapper
{

	/// <summary>
    /// ??????Person???AutoMapper
    /// </summary>
	internal static class PersonMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Person,PersonListDto>();
            configuration.CreateMap <PersonListDto,Person>();

            configuration.CreateMap <PersonEditDto,Person>();
            configuration.CreateMap <Person,PersonEditDto>();

        }
	}
}
