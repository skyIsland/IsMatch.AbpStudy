
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Dtos;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;

namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers
{
    /// <summary>
    /// PhoneNumber??????????????????????????????
    ///</summary>
    public interface IPhoneNumberAppService : IApplicationService
    {
        /// <summary>
		/// ??????PhoneNumber?????????????????????
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PhoneNumberListDto>> GetPaged(GetPhoneNumbersInput input);


		/// <summary>
		/// ????????????id??????PhoneNumberListDto??????
		/// </summary>
		Task<PhoneNumberListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// ???????????????EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPhoneNumberForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// ??????????????????PhoneNumber???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdatePhoneNumberInput input);


        /// <summary>
        /// ??????PhoneNumber???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// ????????????PhoneNumber
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// ??????PhoneNumber???excel???
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
