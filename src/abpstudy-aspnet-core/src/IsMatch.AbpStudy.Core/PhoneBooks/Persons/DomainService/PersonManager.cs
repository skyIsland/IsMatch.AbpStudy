

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
using IsMatch.AbpStudy.PhoneBooks.Persons;


namespace IsMatch.AbpStudy.PhoneBooks.Persons.DomainService
{
    /// <summary>
    /// Person领域层的业务管理
    ///</summary>
    public class PersonManager :AbpStudyDomainServiceBase, IPersonManager
    {
		
		private readonly IRepository<Person,int> _repository;

		/// <summary>
		/// Person的构造方法
		///</summary>
		public PersonManager(
			IRepository<Person, int> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitPerson()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
