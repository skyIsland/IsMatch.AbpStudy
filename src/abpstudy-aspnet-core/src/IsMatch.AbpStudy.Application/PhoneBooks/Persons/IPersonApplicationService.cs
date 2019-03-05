
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


using IsMatch.AbpStudy.PhoneBooks.Persons.Dtos;
using IsMatch.AbpStudy.PhoneBooks.Persons;

namespace IsMatch.AbpStudy.PhoneBooks.Persons
{
    /// <summary>
    /// Person??????????????????????????????
    ///</summary>
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
		/// ??????Person?????????????????????
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPaged(GetPersonsInput input);


		/// <summary>
		/// ????????????id??????PersonListDto??????
		/// </summary>
		Task<PersonListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// ???????????????EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPersonForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// ??????????????????Person???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdatePersonInput input);


        /// <summary>
        /// ??????Person???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// ????????????Person
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// ??????Person???excel???
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
