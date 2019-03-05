

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using IsMatch.AbpStudy;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;


namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.DomainService
{
    /// <summary>
    /// PhoneNumber????????????????????????
    ///</summary>
    public class PhoneNumberManager :AbpStudyDomainServiceBase, IPhoneNumberManager
    {
		
		private readonly IRepository<PhoneNumber,long> _repository;

		/// <summary>
		/// PhoneNumber???????????????
		///</summary>
		public PhoneNumberManager(
			IRepository<PhoneNumber, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// ?????????
		///</summary>
		public void InitPhoneNumber()
		{
			throw new NotImplementedException();
		}

		// TODO:????????????????????????



		 
		  
		 

	}
}
