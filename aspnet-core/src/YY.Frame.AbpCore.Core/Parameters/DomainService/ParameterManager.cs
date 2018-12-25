

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
using YY.Frame.AbpCore.Parameters;


namespace YY.Frame.AbpCore.Parameters.DomainService
{
    /// <summary>
    /// Parameter领域层的业务管理
    ///</summary>
    public class ParameterManager :FrameDomainServiceBase, IParameterManager
    {
		
		private readonly IRepository<Parameter,long> _repository;

		/// <summary>
		/// Parameter的构造方法
		///</summary>
		public ParameterManager(
			IRepository<Parameter, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitParameter()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
