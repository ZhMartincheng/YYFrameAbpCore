

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

using YY.Frame;
using YY.Frame.AbpCore.Persons;


namespace YY.Frame.AbpCore.Persons.DomainService
{
    /// <summary>
    /// Book领域层的业务管理
    ///</summary>
    public class BookManager :FrameDomainServiceBase, IBookManager
    {
		
		private readonly IRepository<Book,long> _repository;

		/// <summary>
		/// Book的构造方法
		///</summary>
		public BookManager(
			IRepository<Book, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitBook()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
