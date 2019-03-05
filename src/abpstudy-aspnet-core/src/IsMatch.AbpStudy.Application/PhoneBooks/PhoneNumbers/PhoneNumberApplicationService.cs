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
    /// PhoneNumber????????????????????????????????????  
    ///</summary>
    [AbpAuthorize]
    public class PhoneNumberAppService : AbpStudyAppServiceBase, IPhoneNumberAppService
    {
        private readonly IRepository<PhoneNumber, long> _entityRepository;

        private readonly IPhoneNumberManager _entityManager;

        /// <summary>
        /// ???????????? 
        ///</summary>
        public PhoneNumberAppService(
        IRepository<PhoneNumber, long> entityRepository
        , IPhoneNumberManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// ??????PhoneNumber?????????????????????
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(PhoneNumberPermissions.Query)]
        public async Task<PagedResultDto<PhoneNumberListDto>> GetPaged(GetPhoneNumbersInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:???????????????????????????????????????


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<PhoneNumberListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<PhoneNumberListDto>>();

            return new PagedResultDto<PhoneNumberListDto>(count, entityListDtos);
        }


        /// <summary>
        /// ????????????id??????PhoneNumberListDto??????
        /// </summary>
        [AbpAuthorize(PhoneNumberPermissions.Query)]
        public async Task<PhoneNumberListDto> GetById(EntityDto<long> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<PhoneNumberListDto>();
        }

        /// <summary>
        /// ???????????? PhoneNumber
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PhoneNumberPermissions.Create, PhoneNumberPermissions.Edit)]
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
        /// ??????????????????PhoneNumber???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PhoneNumberPermissions.Create, PhoneNumberPermissions.Edit)]
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
        /// ??????PhoneNumber
        /// </summary>
        [AbpAuthorize(PhoneNumberPermissions.Create)]
        protected virtual async Task<PhoneNumberEditDto> Create(PhoneNumberEditDto input)
        {
            //TODO:?????????????????????????????????????????????

            // var entity = ObjectMapper.Map <PhoneNumber>(input);
            var entity = input.MapTo<PhoneNumber>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<PhoneNumberEditDto>();
        }

        /// <summary>
        /// ??????PhoneNumber
        /// </summary>
        [AbpAuthorize(PhoneNumberPermissions.Edit)]
        protected virtual async Task Update(PhoneNumberEditDto input)
        {
            //TODO:?????????????????????????????????????????????

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// ??????PhoneNumber???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PhoneNumberPermissions.Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            //TODO:?????????????????????????????????????????????
            await _entityRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// ????????????PhoneNumber?????????
        /// </summary>
        [AbpAuthorize(PhoneNumberPermissions.BatchDelete)]
        public async Task BatchDelete(List<long> input)
        {
            // TODO:???????????????????????????????????????????????????
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        /// <summary>
        /// ??????PhoneNumber???excel???,???????????????
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


