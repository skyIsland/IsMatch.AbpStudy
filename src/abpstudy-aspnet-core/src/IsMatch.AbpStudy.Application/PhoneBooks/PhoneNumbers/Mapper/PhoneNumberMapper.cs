
using AutoMapper;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Dtos;

namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Mapper
{

	/// <summary>
    /// ??????PhoneNumber???AutoMapper
    /// </summary>
	internal static class PhoneNumberMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <PhoneNumber,PhoneNumberListDto>();
            configuration.CreateMap <PhoneNumberListDto,PhoneNumber>();

            configuration.CreateMap <PhoneNumberEditDto,PhoneNumber>();
            configuration.CreateMap <PhoneNumber,PhoneNumberEditDto>();

        }
	}
}
