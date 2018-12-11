

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using YY.Frame.AbpCore.Persons;


namespace YY.Frame.AbpCore.Persons.DomainService
{
    public interface IBookManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitBook();



		 
      
         

    }
}
