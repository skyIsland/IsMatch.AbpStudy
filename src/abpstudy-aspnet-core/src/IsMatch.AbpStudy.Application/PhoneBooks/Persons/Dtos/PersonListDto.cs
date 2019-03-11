

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using IsMatch.AbpStudy.PhoneBooks.Persons;
using System.Collections.Generic;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;

namespace IsMatch.AbpStudy.PhoneBooks.Persons.Dtos
{
    public class PersonListDto : FullAuditedEntityDto
    {


        /// <summary>
        /// Name
        /// </summary>
        [MaxLength(AbpStudyConsts.MaxNameLength)]
        [Required(ErrorMessage = "Name不能为空")]
        public string Name { get; set; }



        /// <summary>
        /// EmailAddress
        /// </summary>
        [MaxLength(AbpStudyConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }



        /// <summary>
        /// Address
        /// </summary>
        [MaxLength(AbpStudyConsts.MaxAddressLength)]
        public string Address { get; set; }



        /// <summary>
        /// PhoneNumbers
        /// </summary>
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }




    }
}