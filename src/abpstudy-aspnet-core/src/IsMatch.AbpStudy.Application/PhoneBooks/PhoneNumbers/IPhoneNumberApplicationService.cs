
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
    /// PhoneNumber应用层服务的接口方法
    ///</summary>
    public interface IPhoneNumberAppService : IApplicationService
    {
        /// <summary>
		/// 获取PhoneNumber的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PhoneNumberListDto>> GetPaged(GetPhoneNumbersInput input);


		/// <summary>
		/// 通过指定id获取PhoneNumberListDto信息
		/// </summary>
		Task<PhoneNumberListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPhoneNumberForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改PhoneNumber的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdatePhoneNumberInput input);


        /// <summary>
        /// 删除PhoneNumber信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除PhoneNumber
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出PhoneNumber为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
