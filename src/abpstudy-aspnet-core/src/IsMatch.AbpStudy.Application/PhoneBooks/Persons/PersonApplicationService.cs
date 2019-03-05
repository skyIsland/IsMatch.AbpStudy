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
    /// Person????????????????????????????????????  
    ///</summary>
    [AbpAuthorize]
    public class PersonAppService : AbpStudyAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person, int> _entityRepository;

        private readonly IPersonManager _entityManager;

        /// <summary>
        /// ???????????? 
        ///</summary>
        public PersonAppService(
        IRepository<Person, int> entityRepository
        , IPersonManager entityManager
        )
        {
            _entityRepository = entityRepository;
            _entityManager = entityManager;
        }


        /// <summary>
        /// ??????Person?????????????????????
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(PersonPermissions.Query)]
        public async Task<PagedResultDto<PersonListDto>> GetPaged(GetPersonsInput input)
        {

            var query = _entityRepository.GetAll();
            // TODO:???????????????????????????????????????


            var count = await query.CountAsync();

            var entityList = await query
                    .OrderBy(input.Sorting).AsNoTracking()
                    .PageBy(input)
                    .ToListAsync();

            // var entityListDtos = ObjectMapper.Map<List<PersonListDto>>(entityList);
            var entityListDtos = entityList.MapTo<List<PersonListDto>>();

            return new PagedResultDto<PersonListDto>(count, entityListDtos);
        }


        /// <summary>
        /// ????????????id??????PersonListDto??????
        /// </summary>
        [AbpAuthorize(PersonPermissions.Query)]
        public async Task<PersonListDto> GetById(EntityDto<int> input)
        {
            var entity = await _entityRepository.GetAsync(input.Id);

            return entity.MapTo<PersonListDto>();
        }

        /// <summary>
        /// ???????????? Person
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PersonPermissions.Create, PersonPermissions.Edit)]
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
        /// ??????????????????Person???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PersonPermissions.Create, PersonPermissions.Edit)]
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
        /// ??????Person
        /// </summary>
        [AbpAuthorize(PersonPermissions.Create)]
        protected virtual async Task<PersonEditDto> Create(PersonEditDto input)
        {
            //TODO:?????????????????????????????????????????????

            // var entity = ObjectMapper.Map <Person>(input);
            var entity = input.MapTo<Person>();


            entity = await _entityRepository.InsertAsync(entity);
            return entity.MapTo<PersonEditDto>();
        }

        /// <summary>
        /// ??????Person
        /// </summary>
        [AbpAuthorize(PersonPermissions.Edit)]
        protected virtual async Task Update(PersonEditDto input)
        {
            //TODO:?????????????????????????????????????????????

            var entity = await _entityRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _entityRepository.UpdateAsync(entity);
        }



        /// <summary>
        /// ??????Person???????????????
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PersonPermissions.Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            //TODO:?????????????????????????????????????????????
            await _entityRepository.DeleteAsync(input.Id);
        }



        /// <summary>
        /// ????????????Person?????????
        /// </summary>
        [AbpAuthorize(PersonPermissions.BatchDelete)]
        public async Task BatchDelete(List<int> input)
        {
            // TODO:???????????????????????????????????????????????????
            await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        /// <summary>
        /// ??????Person???excel???,???????????????
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


