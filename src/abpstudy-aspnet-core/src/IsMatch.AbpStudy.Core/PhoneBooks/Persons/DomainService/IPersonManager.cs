

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using IsMatch.AbpStudy.PhoneBooks.Persons;


namespace IsMatch.AbpStudy.PhoneBooks.Persons.DomainService
{
    public interface IPersonManager : IDomainService
    {

        /// <summary>
        /// ???????????????
        ///</summary>
        void InitPerson();



		 
      
         

    }
}
