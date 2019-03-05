

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;


namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.DomainService
{
    public interface IPhoneNumberManager : IDomainService
    {

        /// <summary>
        /// ???????????????
        ///</summary>
        void InitPhoneNumber();



		 
      
         

    }
}
