

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
        /// 初始化方法
        ///</summary>
        void InitPhoneNumber();



		 
      
         

    }
}
