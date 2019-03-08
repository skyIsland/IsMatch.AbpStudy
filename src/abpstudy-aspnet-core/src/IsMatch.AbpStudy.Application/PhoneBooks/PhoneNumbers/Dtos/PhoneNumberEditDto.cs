
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;

namespace  IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Dtos
{
    public class PhoneNumberEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
		/// <summary>
		/// Number
		/// </summary>
[MaxLength(11)]
		[Required(ErrorMessage="Number不能为空")]
		public string Number { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		public PhoneNumberType Type { get; set; }



		/// <summary>
		/// PersonId
		/// </summary>
		public int PersonId { get; set; }



		/// <summary>
		/// Person
		/// </summary>
		public Person Person { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }




    }
}