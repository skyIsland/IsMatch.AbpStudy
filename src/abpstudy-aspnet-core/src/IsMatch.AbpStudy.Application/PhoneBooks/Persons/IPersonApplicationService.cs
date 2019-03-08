
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
    /// Person应用层服务的接口方法
    ///</summary>
    public interface IPersonAppService : IApplicationService
    {
        /// <summary>
		/// 获取Person的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<PersonListDto>> GetPaged(GetPersonsInput input);


		/// <summary>
		/// 通过指定id获取PersonListDto信息
		/// </summary>
		Task<PersonListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetPersonForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改Person的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdatePersonInput input);


        /// <summary>
        /// 删除Person信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除Person
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出Person为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
