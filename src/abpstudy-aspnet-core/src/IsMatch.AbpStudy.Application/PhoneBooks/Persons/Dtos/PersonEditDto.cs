
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using IsMatch.AbpStudy.PhoneBooks.Persons;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;

namespace  IsMatch.AbpStudy.PhoneBooks.Persons.Dtos
{
    public class PersonEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// Name
		/// </summary>
[MaxLength(AbpStudyConsts.MaxNameLength)]
		[Required(ErrorMessage="Name不能为空")]
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