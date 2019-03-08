
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using IsMatch.AbpStudy.PhoneBooks.Persons;
using IsMatch.AbpStudy.PhoneBooks.Persons.Dtos;
using IsMatch.AbpStudy.PhoneBooks.Persons.DomainService;
using IsMatch.AbpStudy.PhoneBooks.Persons.Authorization;


namespace IsMatch.AbpStudy.PhoneBooks.Persons
{
    /// <summary>
    /// Person应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class PersonAppService : AbpStudyAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person, int> _entityRepository;

        private readonly IPersonManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public PersonAppService(
        IRepository<Person, int> entityRepository
        ,IPersonManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Person的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(PersonPermissions.Query)] 
        public async Task<PagedResultDto<PersonListDto>> GetPaged(GetPersonsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<PersonListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<PersonListDto>>();

			return new PagedResultDto<PersonListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取PersonListDto信息
		/// </summary>
		[AbpAuthorize(PersonPermissions.Query)] 
		public async Task<PersonListDto> GetById(EntityDto<int> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<PersonListDto>();
		}

		/// <summary>
		/// 获取编辑 Person
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(PersonPermissions.Create,PersonPermissions.Edit)]
		public async Task<GetPersonForEditOutput> GetForEdit(NullableIdDto<int> input)
		{
			var output = new GetPersonForEditOutput();
PersonEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<PersonEditDto>();

				//personEditDto = ObjectMapper.Map<List<personEditDto>>(entity);
			}
			else
			{
				editDto = new PersonEditDto();
			}

			output.Person = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Person的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(PersonPermissions.Create,PersonPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdatePersonInput input)
		{

			if (input.Person.Id.HasValue)
			{
				await Update(input.Person);
			}
			else
			{
				await Create(input.Person);
			}
		}


		/// <summary>
		/// 新增Person
		/// </summary>
		[AbpAuthorize(PersonPermissions.Create)]
		protected virtual async Task<PersonEditDto> Create(PersonEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <Person>(input);
            var entity=input.MapTo<Person>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<PersonEditDto>();
		}

		/// <summary>
		/// 编辑Person
		/// </summary>
		[AbpAuthorize(PersonPermissions.Edit)]
		protected virtual async Task Update(PersonEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Person信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(PersonPermissions.Delete)]
		public async Task Delete(EntityDto<int> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Person的方法
		/// </summary>
		[AbpAuthorize(PersonPermissions.BatchDelete)]
		public async Task BatchDelete(List<int> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Person为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


