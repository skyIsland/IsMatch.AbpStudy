
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


using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Dtos;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.DomainService;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Authorization;


namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers
{
    /// <summary>
    /// PhoneNumber应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class PhoneNumberAppService : AbpStudyAppServiceBase, IPhoneNumberAppService
    {
        private readonly IRepository<PhoneNumber, long> _entityRepository;

        private readonly IPhoneNumberManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public PhoneNumberAppService(
        IRepository<PhoneNumber, long> entityRepository
        ,IPhoneNumberManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取PhoneNumber的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(PhoneNumberPermissions.Query)] 
        public async Task<PagedResultDto<PhoneNumberListDto>> GetPaged(GetPhoneNumbersInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<PhoneNumberListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<PhoneNumberListDto>>();

			return new PagedResultDto<PhoneNumberListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取PhoneNumberListDto信息
		/// </summary>
		[AbpAuthorize(PhoneNumberPermissions.Query)] 
		public async Task<PhoneNumberListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<PhoneNumberListDto>();
		}

		/// <summary>
		/// 获取编辑 PhoneNumber
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(PhoneNumberPermissions.Create,PhoneNumberPermissions.Edit)]
		public async Task<GetPhoneNumberForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetPhoneNumberForEditOutput();
PhoneNumberEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<PhoneNumberEditDto>();

				//phoneNumberEditDto = ObjectMapper.Map<List<phoneNumberEditDto>>(entity);
			}
			else
			{
				editDto = new PhoneNumberEditDto();
			}

			output.PhoneNumber = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改PhoneNumber的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(PhoneNumberPermissions.Create,PhoneNumberPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdatePhoneNumberInput input)
		{

			if (input.PhoneNumber.Id.HasValue)
			{
				await Update(input.PhoneNumber);
			}
			else
			{
				await Create(input.PhoneNumber);
			}
		}


		/// <summary>
		/// 新增PhoneNumber
		/// </summary>
		[AbpAuthorize(PhoneNumberPermissions.Create)]
		protected virtual async Task<PhoneNumberEditDto> Create(PhoneNumberEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <PhoneNumber>(input);
            var entity=input.MapTo<PhoneNumber>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<PhoneNumberEditDto>();
		}

		/// <summary>
		/// 编辑PhoneNumber
		/// </summary>
		[AbpAuthorize(PhoneNumberPermissions.Edit)]
		protected virtual async Task Update(PhoneNumberEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除PhoneNumber信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(PhoneNumberPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除PhoneNumber的方法
		/// </summary>
		[AbpAuthorize(PhoneNumberPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出PhoneNumber为excel表,等待开发。
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


